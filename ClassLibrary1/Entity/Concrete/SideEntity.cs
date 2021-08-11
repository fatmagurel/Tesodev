using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tesodev.Core.Entity.Abstract;
using Tesodev.Core.Enum;

namespace Tesodev.Core.Entity.Concrete
{
    public class SideEntity : IEntity<Guid>
    {
        //Product-Address
        public Guid ID { get; set; }
        public Status Status { get; set; }
    }
}
