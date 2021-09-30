using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IReviewRepository
    {
        Task<Review> AddAsync(Review review);
        void Delete(Guid idReview);
        ICollection<Review> GetAllReviewByPlaceId(Guid placeId);
        bool Find(Guid reviewId);
    }
}
