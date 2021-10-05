using Domain.NormalDomain;

namespace Application
{
    public interface IRecomandationService
    {
        void RecalculateRating(Place place, int stars);
        void RecalculateRatingDeleted(Place place, int stars);
    }
}
