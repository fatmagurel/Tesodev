using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tesodev.DataAccess.Context;
using Tesodev.DataAccess.Repositories.Concrete;
using Tesodev.Entities.Entities;

namespace Tesodev.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("[area]/[controller]/[action]")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;
        private readonly CustomerRepository _customerRepository;
        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly AddressRepository _addressRepository;

        public HomeController(ProjectContext _context, IHttpContextAccessor httpContext)
        {
            _productRepository = new ProductRepository(_context, httpContext);
            _orderRepository = new OrderRepository(_context, httpContext);
            _customerRepository = new CustomerRepository(_context, httpContext);
            _shoppingCartRepository = new ShoppingCartRepository(_context, httpContext);
            _addressRepository = new AddressRepository(_context, httpContext);
        }

        //Anasayfa
        public IActionResult Index()
        {
            return View(_productRepository.GetActive());
        }

        //Sepet sayfası
        [HttpGet]
        public IActionResult ShoppingCart()
        {
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetDefault(x => x.CustomerID == Guid.Parse(HttpContext.Session.GetString("CustomerID")) && x.Status == Core.Enum.Status.None);

            ViewBag.Total = _shoppingCartRepository.TotalPrice(Guid.Parse(HttpContext.Session.GetString("CustomerID")));
            return View(shoppingCarts);
        }

        //Sepettekileri Order tablosuna kaydeder.
        [HttpPut]
        public IActionResult OrderSave(Guid id)
        {
            //sipariş listesi getirilir.
            List<ShoppingCart> shoppingCarts = _shoppingCartRepository.GetDefault(x => x.CustomerID == Guid.Parse(HttpContext.Session.GetString("CustomerID")) && x.Status == Core.Enum.Status.None);
            ShoppingConfirm(shoppingCarts);
            
            for (int i = 0; i < shoppingCarts.Count; i++)
            {
                Order order = new Order();
                order.CustomerID = Guid.Parse(HttpContext.Session.GetString("CustomerID"));
                order.Quantity = shoppingCarts[i].Quantity;
                order.Price = shoppingCarts[i].Price;
                order.ProductID = _productRepository.GetByDefaultOutID(x => x.Name == shoppingCarts[i].ProductName);
                order.CreatedAt = DateTime.Now;
                order.UpdatedAt = DateTime.Now;
                order.Status = Core.Enum.Status.Active;
                order.AddressID = id;
                _orderRepository.Add(order);
            }
            return RedirectToAction("ShoppingCart", "Home");
        }

        //sepettekileri onaylar
        public List<ShoppingCart> ShoppingConfirm(List<ShoppingCart> shoppingCarts)
        {
            foreach (var item in shoppingCarts)
            {
                item.Status = Core.Enum.Status.Active;
                _shoppingCartRepository.Update(item);
            }
            return shoppingCarts;
        }

        //Sipariş Ekleme
        [HttpPost]
        public IActionResult ShoppingCartAdd(Product product, int quantity)
        {
            if (_shoppingCartRepository.Any(x => x.CustomerID == Guid.Parse(HttpContext.Session.GetString("CustomerID")) && x.Status == Core.Enum.Status.None && x.ProductName == product.Name))//eğer böyle bir ürün sepette varsa
            {
                Guid CustomerID = Guid.Parse(HttpContext.Session.GetString("CustomerID"));              
                ShoppingCart shoppingCart1 = _shoppingCartRepository.GetByDefault(x => x.ProductName == product.Name && x.CustomerID == Guid.Parse(HttpContext.Session.GetString("CustomerID")));
                _shoppingCartRepository.ShoppingCartUpdate(product, quantity, CustomerID, shoppingCart1);
            }
            else//yeni bir ürün ise
            {
                Product product1 = _productRepository.GetByDefault(x => x.ID == product.ID);
                ShoppingCart shoppingCart = new ShoppingCart();
                shoppingCart.CustomerID = Guid.Parse(HttpContext.Session.GetString("CustomerID"));
                shoppingCart.Quantity = quantity;
                shoppingCart.ProductName = product1.Name;
                shoppingCart.Price = product1.Price;
                shoppingCart.Status = Core.Enum.Status.None;
                shoppingCart.TotalPrice = product1.Price * quantity;
                _shoppingCartRepository.Add(shoppingCart);
            }
            return RedirectToAction("Index", "Home");
        }

        //Sepetten ürün silme
        [Route("~/User/Home/DeleteShopping/{id}")]
        public IActionResult DeleteShopping(Guid id)
        {
            ShoppingCart shoppingCart = _shoppingCartRepository.GetByID(id);
            _shoppingCartRepository.Remove(shoppingCart);
            return RedirectToAction("ShoppingCart", "Home");
        }

        //Sipariş Listesi
        [HttpGet]
        public IActionResult Orders()
        {
            List<Order> orders = _orderRepository.GetDefault(x => x.CustomerID == Guid.Parse(HttpContext.Session.GetString("CustomerID")));

            ViewBag.Total = _orderRepository.TotalPrice(Guid.Parse(HttpContext.Session.GetString("CustomerID")));

            List<Product> products = _productRepository.GetAll();
            List<Address> addresses = _addressRepository.GetAll();
            return View(Tuple.Create<List<Order>, List<Product>, List<Address>>(orders, products, addresses));
        }

        //Adres bilgileri
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Information(Address address)
        {
            Customer customer = _customerRepository.GetByID(Guid.Parse(HttpContext.Session.GetString("CustomerID")));
            Address address1 = _addressRepository.GetByDefault(x => x.ID == customer.AddressID);
            address1.AddressLine = address.AddressLine;
            address1.City = address.City;
            address1.Country = address.Country;
            address1.CityCode = address.CityCode;
            address1.Status = Core.Enum.Status.Active;
            _addressRepository.Update(address1);

            OrderSave(address1.ID);
            return RedirectToAction("ShoppingCart", "Home");
        }
        //Çıkış
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
    }
}
