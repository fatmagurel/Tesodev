using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tesodev.Core.Entity.Concrete;

namespace Tesodev.Core.Mapping
{
    public class SideMap<T> : IEntityTypeConfiguration<T> where T : SideEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).HasColumnName("ID");
        }
    }
}
