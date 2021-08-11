using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tesodev.DataAccess.Context;
using Tesodev.DataAccess.Repositories.Concrete;
using Tesodev.Entities.Entities;

namespace Tesodev.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class HomeController : Controller
    {
        private ProductRepository _productRepository;
        private OrderRepository _orderRepository;

        public HomeController(ProjectContext context, IHttpContextAccessor httpContext)
        {
            _orderRepository = new OrderRepository(context, httpContext);
            _productRepository = new ProductRepository(context, httpContext);
        }

        
        public IActionResult Index()
        {
            return View(_productRepository.GetActive());
        }

        //Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product, IFormFile ImageUrl)
        {
            if (ImageUrl == null)
            {
                TempData["IsImage"] = "Lütfen resim yükleyiniz";
                return RedirectToAction("Index", "Home");
            }
                //resim yükleme
            var uzanti = Path.GetExtension(ImageUrl.FileName);
            var yeniResimAd = Guid.NewGuid() + uzanti;
            var yuklenecekYer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/products/" + yeniResimAd);
            var stream = new FileStream(yuklenecekYer, FileMode.Create);
            ImageUrl.CopyTo(stream);
            product.ImageUrl = yeniResimAd;
           
            product.Status = Core.Enum.Status.Active;

            _productRepository.Add(product);
            return RedirectToAction("Index", "Home");

        }

        //Delete
        [Route("~/Admin/Home/Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            Product product = _productRepository.GetByID(id);
            _productRepository.Remove(product);
            return RedirectToAction("Index", "Home");
        }

        //Siparişleri Listele
        [HttpGet]
        public IActionResult Orders()
        {
            return View(_orderRepository.GetAll());
        }

        //Sipariş Onaylama
        [HttpPost]
        public IActionResult OrderConfirm(Guid id)
        {
            Order order = _orderRepository.GetByID(id);
            _orderRepository.Status(order);
            return RedirectToAction("Orders", "Home");
        }

        //Sipariş Reddetme
        [Route("~/Admin/Home/OrderDelete/{id}")]
        public IActionResult OrderDelete(Guid id)
        {
            Order order = _orderRepository.GetByID(id);
            _orderRepository.Remove(order);
            return RedirectToAction("Orders", "Home");
        }

        //Çıkış
        [HttpGet]
        public IActionResult LogOut()
        {
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
