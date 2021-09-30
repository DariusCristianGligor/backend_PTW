using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Config
{
    class AdminConfig
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
