using Microsoft.AspNetCore.Authentication;
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
    public class LoginController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressRepository _addressRepository;
        public LoginController(ProjectContext _context, IHttpContextAccessor httpContext)
        {
            _customerRepository = new CustomerRepository(_context, httpContext);
            _addressRepository = new AddressRepository(_context, httpContext);
        }
        //Kullanıcı kayıt
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Customer customer)
        {
            Address address = _addressRepository.CreateAddress();
            _addressRepository.Add(address);
            _customerRepository.Add(_customerRepository.CreateCustomer(customer, address.ID));
            return RedirectToAction("Login", "Login");

        }

        //Login sayfası
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Customer customer, string email)
        {
            //email, şifre ve captcha doğru ise giriş yapar.
            if (_customerRepository.CheckCredential(email, customer.Password) && await _customerRepository.IsCheckCaptcha())
            {

                await HttpContext.SignInAsync(_customerRepository.LoginClaims(customer));//Claims ile kimlik doğrulama yapar.
                HttpContext.Session.SetString("CustomerID", _customerRepository.GetByDefaultOutID(x => x.Email == customer.Email).ToString());

                return RedirectToAction("Index", "Home");
            }
            else//Bilgiler doğru değilse
            {
                if (!_customerRepository.CheckCredential(email, customer.Password))//Email veya şifre hatalı ise
                {
                    ViewBag.Hata = "Hatalı giriş lütfen tekrar deneyin...";
                }
                else//Captcha doğrulanmadıysa
                {
                    ViewBag.HataCaptcha = "Captcha doğrulanmadı...";
                }
                return View(customer);
            }
        }
    }
}
