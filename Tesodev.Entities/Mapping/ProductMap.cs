using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Mapping;
using Tesodev.Entities.Entities;

namespace Tesodev.Entities.Mapping
{
    public class ProductMap : SideMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ImageUrl).IsRequired(true);
            builder.Property(x => x.Price).IsRequired(true);

            base.Configure(builder);
        }
    }
}
