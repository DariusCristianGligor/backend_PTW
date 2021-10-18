using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IReviewRepository
    {
        Task<EntityEntry<Review>> AddAsync(Review review);

        void Delete(Guid idReview);

        IQueryable<Review> GetAllReviewByPlaceId(Guid placeId);

        IQueryable<Review> GetAllReviewByPlaceId(Guid placeId, int page, int pageSize);

        Review Find(Guid reviewId);
        int GetNumberOfReview(Guid placeId);
    }
}
