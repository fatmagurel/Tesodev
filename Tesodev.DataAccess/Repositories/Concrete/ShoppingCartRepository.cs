using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.DataAccess.Context;
using Tesodev.Entities.Entities;

namespace Tesodev.DataAccess.Repositories.Concrete
{
    public class ShoppingCartRepository : SideRepository<ShoppingCart>
    {
        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;

        public ShoppingCartRepository(ProjectContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        //sepetteki sipariş toplam tutarı
        public double TotalPrice(Guid id)
        {
            List<ShoppingCart> shoppingCarts = GetDefault(x => x.CustomerID == id && x.Status == Core.Enum.Status.None);
            double toplam = 0;
            for (int i = 0; i < shoppingCarts.Count; i++)
            {
                toplam += shoppingCarts[i].TotalPrice;
            }
            return toplam;
        }

        public void ShoppingCartUpdate(Product product, int quantity, Guid id, ShoppingCart shoppingCart)
        {
            ShoppingCart shoppingCart1 = shoppingCart;
            shoppingCart1.CustomerID = id;
            shoppingCart1.Quantity += quantity;
            shoppingCart1.ProductName = product.Name;
            shoppingCart1.Price = product.Price;
            shoppingCart1.Status = Core.Enum.Status.None;
            shoppingCart1.TotalPrice = product.Price * shoppingCart1.Quantity;
            _context.Update(shoppingCart1);
        }
    }
}
