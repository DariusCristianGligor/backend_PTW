using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.NormalDomain;

namespace Infrastructure
{
    class CountryConfig : IEntityTypeConfiguration<Domain.NormalDomain.Country>
    {
        public void Configure(EntityTypeBuilder<Domain.NormalDomain.Country> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasMany<City>(x => x.Cities);
            //.WithOne(c => c.Country)
            //.HasForeignKey(c=>c.CountryId);
            builder.Property(e => e.AddedDateTime)
               .IsRequired()
               .ValueGeneratedOnAdd();
        }
    }
}
