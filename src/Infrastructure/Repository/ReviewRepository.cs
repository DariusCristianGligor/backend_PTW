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
            await _dbContext.SaveChangesAsync();
            return reviewFromDb;
        }

        public void Delete(Guid reviewId)
        {
            _dbContext.Reviews.RemoveRange(_dbContext.Reviews.Where(x => x.Id == reviewId));
            _dbContext.SaveChanges();
        }

        public Review Find(Guid reviewId)
        {
            return _dbContext.Reviews.Find(reviewId);
        }

        public IQueryable<Review> GetAllReviewByPlaceId(Guid placeId)
        {
            return _dbContext.Reviews.Where(x => x.PlaceId == placeId);
        }
        public IQueryable<Review> GetAllReviewByPlaceId(Guid placeId, int page, int pageSize)
        {
            return _dbContext.Reviews.OrderBy(x=>x.AddedDateTime).Where(x => x.PlaceId == placeId).Skip((page - 1) * pageSize).Take(pageSize);
        }

        public int GetNumberOfReview(Guid placeId)
        {
            return _dbContext.Reviews.Where(x=>x.PlaceId==placeId).Count();
        }
    }
}
