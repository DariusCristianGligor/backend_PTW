using Domain.NormalDomain;
using System;

namespace Application
{
    public interface IRecomandationService
    {
        void RecalculateRating(Guid placeId, int stars);

        void RecalculateRatingDeleted(Guid placeId, int stars);
    }
}
