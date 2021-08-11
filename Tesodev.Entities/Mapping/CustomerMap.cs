using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Mapping;
using Tesodev.Entities.Entities;

namespace Tesodev.Entities.Mapping
{
    public class CustomerMap : CoreMap<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Email).IsRequired(true);

            builder.HasMany(x => x.Orders).WithOne(x => x.Customer).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);

            base.Configure(builder);
        }
    }
}