using Domain;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Config
{
    class WrapperStringPathReviewConfig : IEntityTypeConfiguration<WrapperStringPathReview>
    {
        public void Configure(EntityTypeBuilder<WrapperStringPathReview> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasOne<Review>(e => e.Review).WithMany(x => x.ImagePaths);
        }
    }
}