using Application;
using Domain;
using Domain.NormalDomain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewRepository : IReviewRepository
    {
       

        private readonly ReviewNowContext _dbContext;

        public ReviewRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
  
        public async Task<Review> AddAsync(Review review)
        {
            
            await _dbContext.Reviews.AddAsync(review);
            var recomandationService = new RecomandationServiceRepository(_dbContext);
            recomandationService.RecalculateRating(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }

        public void Delete(Guid reviewId)
        {
            //return db.Reviews.Where(p =>p.Place.Id == placeId).ToList();
            //return db.Reviews.Where(p =>p.Place == place).ToList();
            //return _dbcontext.Reviews.Where(p =>p.Place == place).ToList();
            //_dbContext.Reviews.Remove();
            _dbContext.Reviews.RemoveRange(_dbContext.Reviews.Where(x => x.Id == reviewId).ToList());
            var recomandationService = new RecomandationServiceRepository(_dbContext);
            recomandationService.RecalculateRatingDeleted(reviewId);
            _dbContext.SaveChanges();
        }

        public bool Find(Guid reviewId)
        {
            List<Review> list = _dbContext.Reviews.Where(x => x.Id == reviewId).ToList();
            return (!(list.Count == 0));
        }

        public ICollection<Review> GetAllReviewByPlaceId(Guid placeId)
        {
            return _dbContext.Reviews.Where(x => x.PlaceId == placeId).ToList();
        }
        public ICollection<Review> GetAllReviewByPlaceId(Guid placeId,int page,int pageSize)
        {
            return _dbContext.Reviews.Where(x => x.PlaceId == placeId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
