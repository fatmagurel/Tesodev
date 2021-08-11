using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tesodev.DataAccess.Context;
using Tesodev.Entities.Entities;

namespace Tesodev.DataAccess.Repositories.Concrete
{
    public class ProductRepository : SideRepository<Product>
    {
        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;
        public ProductRepository(ProjectContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Resim yüklemk için bir resim yolu oluşturur
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string ImageUpload(IFormFile ImageUrl)
        {
            string imagePath = string.Empty;

            if (ImageUrl.ContentType.Contains("image"))
            {
                if (ImageUrl.Length <= 2097152)
                {
                    var path = Path.GetExtension(ImageUrl.FileName);
                    var newPictureName = Guid.NewGuid() + path;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\products\\" + newPictureName);
                    var stream = new FileStream(location, FileMode.Create);
                    ImageUrl.CopyTo(stream);
                    imagePath = location.Substring(location.IndexOf("wwwroot\\img\\products\\"));
                }
            }
            return imagePath;
        }
    }
}
