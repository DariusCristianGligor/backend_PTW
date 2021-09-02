using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace ReviewNow
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static ICollection<Category> GetAllCategories(ReviewNowContext dbContext)
        {
            var categoryRepository = new CategoryRepository(dbContext);
            return categoryRepository.GetAll();
        }
        public static void AddPlace(ReviewNowContext dbContext, Place place)
        {
            var placeRepository = new PlaceRepository(dbContext);
            placeRepository.AddPlace(place);
        }
        public static void AddPlace(ReviewNowContext dbContext, Place place, Review review)
        {
            var placeRepository = new PlaceRepository(dbContext);
            placeRepository.AddPlace(place);
            var reviewRepostory = new ReviewRepository(dbContext);
            reviewRepostory.Add(review);
        }
        public static ICollection<Place> GetAllPlacesByCityId(ReviewNowContext dbContext, Guid city)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCityId(city);
        }
        public static ICollection<Place> GetAllPlacesByCityIdAndCategoryId(ReviewNowContext dbContext, Guid city, ICollection<Guid> categories)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCityIdAndCategoryId(city, categories);
        }
        public static ICollection<Place> GetAllPlacesByCategory(ReviewNowContext dbContext, ICollection<Guid> categories)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCategoryId(categories);
        }
        public static ICollection<Place> GetAllPlacesByCategoryIdAndCountryId(ReviewNowContext dbContext, ICollection<Guid> categories, Guid CountryId)
        {
            var placeRepository = new PlaceRepository(dbContext);
            return placeRepository.GetAllByCategoryIdAndCountryId(categories, CountryId);
        }

    }
}
