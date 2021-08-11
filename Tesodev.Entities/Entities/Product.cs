using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesodev.Core.Entity.Abstract;
using Tesodev.Core.Entity.Concrete;

namespace Tesodev.Entities.Entities
{
    public class Product : SideEntity
    {
        [Display(Name = "Ürün İsmi")]
        [Required(ErrorMessage = "İsim boş geçilemez!")]
        public string Name { get; set; }

        [Display(Name ="Fotoğraf")]
        [Required(ErrorMessage ="Fotoğraf boş geçilemez!")]
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public virtual Order Order { get; set; }



    }
}
