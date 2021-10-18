using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repository
{
    public class WrapperPlaceRepository : IWrapperPlaceRepository
    {
        private readonly ReviewNowContext _dbContext;

        public WrapperPlaceRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void Add(WrapperStringPath wrapperStringPath)
        {
            _dbContext.WrapperStringPaths.Add(wrapperStringPath);
        }

        IQueryable<WrapperStringPath> IWrapperPlaceRepository.GetAll(Guid placeId)
        {
          return  _dbContext.WrapperStringPaths.Where(x => x.PlaceId == placeId);
        }
    }

}
