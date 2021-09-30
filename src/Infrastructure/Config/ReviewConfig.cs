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
    class ReviewConfig : IEntityTypeConfiguration<Review>
    {

        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.AddedDateTime)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(e=>e.UpdatedDateTime)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate();

            builder.HasKey(x => x.Id);

            builder.HasOne<Place>(x => x.Place)
                .WithMany(y => y.Reviews)
                .HasForeignKey(y => y.PlaceId);

            builder.HasOne<User>(x => x.User)
                .WithMany(y => y.Reviews)
                .HasForeignKey(y => y.UserId);
        }


    }
}
