using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tesodev.Core.Entity.Concrete;

namespace Tesodev.Entities.Entities
{
    public class ShoppingCart : SideEntity
    {
        public Guid CustomerID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        
    }
}
