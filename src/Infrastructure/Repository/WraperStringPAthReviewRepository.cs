using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class WraperStringPAthReviewRepository: IWrapperStringPathReviewRepository
    {
        private readonly ReviewNowContext _dbContext;

        public WraperStringPAthReviewRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void Add(WrapperStringPathReview wrapperStringPathReview)
        {
            _dbContext.WrapperStringPathsReview.Add(wrapperStringPathReview);
        }

        public IQueryable<WrapperStringPathReview> GetAll(Guid reviewId)
        {
            return _dbContext.WrapperStringPathsReview.Where(x => x.ReviewId == reviewId);
        }
    }
}
