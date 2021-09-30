using Domain;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasMany<Review>(e => e.Reviews)
                 .WithOne(c => c.User)
                 .HasForeignKey(c => c.UserId);
            builder.Property(e => e.AddedDateTime)
               .IsRequired()
               .ValueGeneratedOnAdd();
        }
    }
}
