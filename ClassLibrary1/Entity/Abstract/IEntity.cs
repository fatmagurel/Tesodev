using System;
using System.Collections.Generic;
using System.Text;

namespace Tesodev.Core.Entity.Abstract
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
