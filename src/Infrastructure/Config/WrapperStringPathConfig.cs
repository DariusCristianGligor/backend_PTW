using Domain;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Config
{
    class WrapperStringPathConfig : IEntityTypeConfiguration<WrapperStringPath>
    {

        public void Configure(EntityTypeBuilder<WrapperStringPath> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasOne<Place>(e => e.Place).WithMany(x => x.ImagePaths);
        }
    }
}
