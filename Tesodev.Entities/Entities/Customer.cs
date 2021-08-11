using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesodev.Core.Entity.Concrete;

namespace Tesodev.Entities.Entities
{
    public class Customer : CoreEntity
    {
        [Display(Name = "Müşteri Adı")]
        [Required(ErrorMessage = "İsim boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez!")]
        public string Email { get; set; }
        public string Password { get; set; }

        public Guid AddressID { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
