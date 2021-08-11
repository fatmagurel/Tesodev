using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Mapping;
using Tesodev.Entities.Entities;

namespace Tesodev.Entities.Mapping
{
    public class OrderMap : CoreMap<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Quantity).IsRequired(true);
            builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            
            base.Configure(builder);
        }
    }
}