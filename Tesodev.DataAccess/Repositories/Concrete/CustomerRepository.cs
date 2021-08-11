using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Tesodev.DataAccess.Context;
using Tesodev.Entities.Entities;

namespace Tesodev.DataAccess.Repositories.Concrete
{
    public class CustomerRepository : Repository<Customer>
    {

        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;

        public CustomerRepository(ProjectContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        /// <summary>
        /// Email ve Sifre dogrulugunu kontrol eder.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckCredential(string email, string password)
        {
            return Any(x => x.Email == email && x.Password == password);
        }

        /// <summary>
        /// Kimlik doğrulamak için ClaimsPrincipal döndüren method.
        /// <br/>Kullanım Şekli : await HttpContext.SignInAsync(LoginClaims(entity))
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        public ClaimsPrincipal LoginClaims(Customer customer)
        {
            var claims = new List<Claim>//Kimlik doğrulama
                {
                    new Claim(ClaimTypes.Name, customer.Email)
                };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            return principal;
        }

        
        public Customer CreateCustomer(Customer customer, Guid id)
        {
            customer.AddressID = id;
            customer.Status = Core.Enum.Status.Active;
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            return customer;
        }
    }
}
