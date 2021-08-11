using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesodev.Core.Entity.Abstract;
using Tesodev.Core.Entity.Concrete;

namespace Tesodev.Entities.Entities
{
    public class Address : SideEntity
    {
        [Display(Name ="Adres Satırı")]
        public string? AddressLine { get; set; }

        [Display(Name ="Şehir")]
        [Required(ErrorMessage ="Şehir boş geçilemez!")]
        public string City { get; set; }

        [Display(Name = "Ülke")]
        [Required(ErrorMessage = "Ülke boş geçilemez!")]
        public string Country { get; set; }

        [Display(Name = "İl Kodu")]
        [Required(ErrorMessage = "İl kodu boş geçilemez!")]
        public int CityCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}
