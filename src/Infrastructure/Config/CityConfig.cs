using CountryData.Standard;
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
    class CityConfig: IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne<Domain.NormalDomain.Country>(e => e.Country);
            //.WithMany(c => c.Cities)
            //.HasForeignKey(e=>e.CountryId);

            builder.HasMany<Place>(e => e.Places)
                .WithOne(x => x.City)
                .HasForeignKey(x=>x.CityId);
            //fluent api.ef core
            builder.Property(e => e.AddedDateTime)
               .IsRequired()
               .ValueGeneratedOnAdd();
            builder.Property(e => e.AddedDateTime)
                .IsRequired()
               .ValueGeneratedOnAdd();
        }


    }
}
