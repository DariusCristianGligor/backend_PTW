using Domain;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class PlaceConfig: IEntityTypeConfiguration<Place>
    {
       
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.AddedDateTime)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UpdatedDateTime)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate(); 

            builder.Property(c => c.Name)
                .HasMaxLength(30);

            builder.HasMany<Review>(e => e.Reviews)
                .WithOne(c => c.Place)
                .HasForeignKey(c=>c.PlaceId);

            //builder.HasMany(e => e.Categories);
            builder.HasOne<City>(c => c.City)
                .WithMany(x => x.Places)
                .HasForeignKey(c=>c.CityId);

            builder.HasMany<Category>(c => c.Categories)
                .WithMany(x => x.Places);
        }
    }
}
