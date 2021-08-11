using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.DataAccess.Context;
using Tesodev.Entities.Entities;

namespace Tesodev.DataAccess.Repositories.Concrete
{
    public class OrderRepository : Repository<Order>
    {

        private readonly ProjectContext _context;
        private IHttpContextAccessor _httpContext;

        public OrderRepository(ProjectContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        //sipariş toplam tutarı
        public double TotalPrice(Guid id)
        {
            List<Order> orders = GetDefault(x => x.CustomerID == id);
            double toplam = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                toplam += orders[i].Price;
            }
            return toplam;
        }

    }
}
