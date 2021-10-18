using Domain.NormalDomain;
using System;

namespace Application.Services
{
    public class RecomandationServices : IRecomandationService
    {
        IPlaceRepository _placeRepository;

        public RecomandationServices(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public void RecalculateRating(Guid placeId, int stars)
        {
            Place place = _placeRepository.FindByPlaceId(placeId);
            place.AvgStars = (place.AvgStars * place.NumberOfReview+stars)/(place.NumberOfReview+1);
            place.Rating = (90*(place.AvgStars)+10*(place.NumberOfReview))/100;
            place.NumberOfReview++;
            _placeRepository.UpdatePlace(place);
        }
        public void RecalculateRatingDeleted(Guid placeId, int stars)
        {
            Place place = _placeRepository.FindByPlaceId(placeId);
            place.NumberOfReview -= 1;
            place.AvgStars = (++place.NumberOfReview * place.AvgStars - stars) / (place.NumberOfReview);
            place.Rating = (float)((place.AvgStars * 0.9) + (place.NumberOfReview * 0.1));
            _placeRepository.UpdatePlace(place);
        }
    }
}
