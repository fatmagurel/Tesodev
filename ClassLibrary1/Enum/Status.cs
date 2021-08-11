using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tesodev.Core.Enum
{
    public enum Status
    {
        [Display(Name ="Sipariş Onaylanmadı")]
        None = 0,
        [Display(Name ="Sipariş Onaylandı")]
        Active = 1,
        Delete = 2
    }
}
