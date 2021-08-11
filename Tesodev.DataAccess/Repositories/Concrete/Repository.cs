using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Tesodev.Core.Entity.Concrete;
using Tesodev.DataAccess.Context;
using Tesodev.DataAccess.Repositories.Abstract;

namespace Tesodev.DataAccess.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {

        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;

        public Repository(ProjectContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Gelen Entity'i Database'e ekler.
        /// </summary>
        /// <param name="item">Model Alır</param>
        /// <returns></returns>
        public bool Add(T item)
        {
            _context.Set<T>().Add(item);
            return Save() > 0;
        }

        /// <summary>
        /// Liste halinde modelleri database'e aktarır.
        /// </summary>
        /// <param name="items">Model alır</param>
        /// <returns></returns>
        public bool Add(List<T> items)
        {
            _context.Set<T>().AddRange(items);
            return Save() > 0;
        }

        /// <summary>
        /// Sorguya göre veritabanında var mı yok mu diye kontrol eder. Bool döndürür.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool Any(Expression<Func<T, bool>> exp) => _context.Set<T>().Any(exp);

        /// <summary>
        /// Databasede bulunan Statüsü Active olan entityleri listeler
        /// </summary>
        /// <returns></returns>
        public List<T> GetActive() => _context.Set<T>().Where(x => x.Status == Core.Enum.Status.Active).ToList();

        /// <summary>
        /// Her şeyi getirir.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll() => _context.Set<T>().ToList();

        /// <summary>
        /// Sorguya göre Entityi döndürür.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetByDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).FirstOrDefault();

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Sorguya göre Liste döndürür Entity içerir.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<T> GetDefault(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).ToList();

        /// <summary>
        /// Gelen Entitynin Statusünü Deleted olarak değiştirir.Kalıcı olarak silmez.
        /// </summary>
        /// <param name="item">Entity</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            item.Status = Core.Enum.Status.Delete;
            return Update(item);
        }

        /// <summary>
        /// Gelen ID'ye göre Entitynin statusünü Delete yapar. 
        /// Transaction :Birbirini izleyen işlemlerin herhangi birinde hata olması durumunda yapılan tüm işlemlerim geri alınmasını sağlar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Remove(Guid id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T deleted = GetByID(id);
                    deleted.Status = Core.Enum.Status.Delete;
                    ts.Complete();
                    return Update(deleted);
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Sorguya göre Hepsini Siler
        /// Transaction :Birbirini izleyen işlemlerin herhangi birinde hata olması durumunda yapılan tüm işlemlerim geri alınmasını sağlar.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp);
                    int count = 0;


                    foreach (var item in collection)
                    {
                        item.Status = Core.Enum.Status.Delete;
                        bool opResult = Update(item);
                        if (opResult) count++;
                    }

                    if (collection.Count == count) ts.Complete();
                    else return false;
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Veritabanına kaydeder.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return _context.SaveChanges();
        }


        /// <summary>
        /// Gelen Entityi Günceller
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Update(T item)
        {
            try
            {
                _context.Set<T>().Update(item);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public void DeleteAll(List<T> items)
        {
            _context.RemoveRange(items);
        }

        /// <summary>
        /// Resim kontrolü yapar.
        /// </summary>
        /// <param name="postedFile"></param>
        /// <returns></returns>
        public bool IsImage(IFormFile postedFile)
        {
            if (postedFile == null)
                return true;
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (
                !string.Equals(postedFile.ContentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(postedFile.ContentType, "image/jfif", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var postedFileExtension = Path.GetExtension(postedFile.FileName);
            if (!string.Equals(postedFileExtension, ".jpg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".png", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".gif", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jpeg", StringComparison.OrdinalIgnoreCase)
                && !string.Equals(postedFileExtension, ".jfif", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }
        public bool Status(T item)
        {
            item.Status = Core.Enum.Status.Active;
            return Update(item);
        }


        /// <summary>
        /// Captcha kontrol eden method.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsCheckCaptcha()
        {
            var postData = new List<KeyValuePair<string, string>>()
             {
                      new KeyValuePair<string, string>("secret", "6LeVJe8aAAAAAE0LPiaGkVdKrWWLf-dfjvnbzZBi"),
                      new KeyValuePair<string, string>("remoteip", _httpContext.HttpContext.Connection.RemoteIpAddress.ToString()),
                      new KeyValuePair<string, string>("response", _httpContext.HttpContext.Request.Form["g-recaptcha-response"])
             };

            var client = new HttpClient();
            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));

            var o = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

            return (bool)o["success"];
        }


        /// <summary>
        /// Sorguya göre Entitynin ID'sini döndürür.
        /// </summary>
        /// <param name="exp">Sorgu</param>
        /// <returns></returns>
        public Guid GetByDefaultOutID(Expression<Func<T, bool>> exp) => _context.Set<T>().Where(exp).Select(x => x.ID).FirstOrDefault();

    }

}
