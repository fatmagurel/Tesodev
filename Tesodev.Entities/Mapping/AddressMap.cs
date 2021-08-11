using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Mapping;
using Tesodev.Entities.Entities;

namespace Tesodev.Entities.Mapping
{
    public class AddressMap : SideMap<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.AddressLine).HasMaxLength(70);
            builder.Property(x => x.City).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.Country).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.CityCode).IsRequired(true);

            base.Configure(builder);
        }
    }
}
