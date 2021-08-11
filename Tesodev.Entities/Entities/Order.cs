using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesodev.Core.Entity.Concrete;
using Tesodev.Core.Enum;

namespace Tesodev.Entities.Entities
{
    public class Order : CoreEntity
    {
        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Display(Name = "Adet")]
        [Required(ErrorMessage = "Adet boş geçilemez!")]
        public int Quantity { get; set; }

        [Display(Name = "Fiyat")]
        public double Price { get; set; }

        public Guid AddressID { get; set; }
        public virtual Address Address { get; set; }

        public Guid ProductID { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
