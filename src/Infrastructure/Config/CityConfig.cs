using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasOne<Domain.NormalDomain.Country>(e => e.Country);
         
            builder.HasMany<Place>(e => e.Places)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);
  
            builder.Property(e => e.AddedDateTime)
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(e => e.AddedDateTime)
                .IsRequired()
               .ValueGeneratedOnAdd();
        }


    }
}
