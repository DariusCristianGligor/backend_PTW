using Domain.NormalDomain;

namespace Application.Services
{
    class RecomandationServices : IRecomandationService
    {
        public void RecalculateRating(Place place, int stars)
        {
            place.NumberOfReview += 1;
            place.AvgStars = (--place.NumberOfReview * place.AvgStars + stars) / (place.NumberOfReview);
            place.Rating = (float)((place.AvgStars * 0.9) + (place.NumberOfReview * 0.1));
        }


        public void RecalculateRatingDeleted(Place place, int stars)
        {
            place.NumberOfReview -= 1;
            place.AvgStars = (++place.NumberOfReview * place.AvgStars - stars) / (place.NumberOfReview);
            place.Rating = (float)((place.AvgStars * 0.9) + (place.NumberOfReview * 0.1));
        }
    }
}
