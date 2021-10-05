using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure
{
    class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(30);

            builder.HasMany<Place>(x => x.Places)
                .WithMany(y => y.Categories);

            builder.Property(e => e.AddedDateTime)
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(e => e.UpdatedDateTime)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
