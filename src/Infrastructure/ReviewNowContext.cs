using CountryData.Standard;
using Domain;
using Domain.NormalDomain;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure
{
    public class ReviewNowContext : DbContext
    {

        public ReviewNowContext(DbContextOptions<ReviewNowContext> options) : base(options)
        {

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Domain.NormalDomain.Country> Countries { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<WrapperStringPath> WrapperStringPaths { get; set; }
        public DbSet<WrapperStringPathReview> WrapperStringPathsReview { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new PlaceConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new WrapperStringPathConfig());
            modelBuilder.ApplyConfiguration(new WrapperStringPathReviewConfig());
            var helper = new CountryHelper();
            var data = helper.GetCountryData();

            var countriesData = data.Select(c => c.CountryName).ToList();
            var countriesDatashortName = data.Select(c => c.CountryShortCode).ToList();
            int i = 0;
            foreach (var country in countriesData)
            {
                var id = System.Guid.NewGuid();
                modelBuilder.Entity<Domain.NormalDomain.Country>().HasData(
            new Domain.NormalDomain.Country()
            {
                Id = id,
                Name = country,
                ShortName = countriesDatashortName[i],
                AddedDateTime = DateTime.Now
            }
            );
                var regions = helper.GetRegionByCountryCode(countriesDatashortName[i]);
                foreach (var region in regions)
                {
                    modelBuilder.Entity<City>().HasData(
                        new City()
                        {
                            Id = System.Guid.NewGuid(),
                            Name = region.Name,
                            CountryId = id,
                            AddedDateTime = DateTime.Now
                        }
                        );
                }
                i++;
            }
        }


    }
}
