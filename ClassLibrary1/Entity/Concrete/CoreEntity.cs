using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Entity.Abstract;
using Tesodev.Core.Enum;

namespace Tesodev.Core.Entity.Concrete
{
    public class CoreEntity : IEntity<Guid>
    {
        //Customer-Order
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Status Status { get; set; }
    }
}
