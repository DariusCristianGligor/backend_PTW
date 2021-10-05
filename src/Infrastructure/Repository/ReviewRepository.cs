using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewRepository : IReviewRepository
    {


        private readonly ReviewNowContext _dbContext;
        IRecomandationService _recomandationService;
        public ReviewRepository(ReviewNowContext dbContext, IRecomandationService recomandationService)
        {

            _dbContext = dbContext;
            _recomandationService = recomandationService;
        }

        public async Task<EntityEntry<Review>> AddAsync(Review review)
        {

            EntityEntry<Review> reviewFromDb = await _dbContext.Reviews.AddAsync(review);
            Place place = _dbContext.Places.Find(review.PlaceId);
            _recomandationService.RecalculateRating(place, review.Stars);
            await _dbContext.SaveChangesAsync();
            return reviewFromDb;
        }

        public void Delete(Guid reviewId)
        {
            _dbContext.Reviews.RemoveRange(_dbContext.Reviews.Where(x => x.Id == reviewId));
            Review review = _dbContext.Reviews.Find(reviewId);
            Place place = _dbContext.Places.Find(review.PlaceId);
            _recomandationService.RecalculateRatingDeleted(place, review.Stars);
            _dbContext.SaveChanges();
        }

        public bool Find(Guid reviewId)
        {
            return (!(_dbContext.Reviews.Find(reviewId) == null));
        }

        public IQueryable<Review> GetAllReviewByPlaceId(Guid placeId)
        {
            return _dbContext.Reviews.Where(x => x.PlaceId == placeId);
        }
        public IQueryable<Review> GetAllReviewByPlaceId(Guid placeId, int page, int pageSize)
        {
            return _dbContext.Reviews.Where(x => x.PlaceId == placeId).Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}
