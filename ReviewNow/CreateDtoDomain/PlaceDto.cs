using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PlaceDto
    {
        public string Name { set; get; }
        [Required]
        [StringLength(100, ErrorMessage = "Address length can't be more than 100 character.")]
        public string Address { set; get; }
        public float Rating { set; get; }
        [Range(0, 5, ErrorMessage = "Rating must be between zero and five")]
        public float AvgStars { set; get; }
        public int NumberOfReview { set; get; }
        public Guid CityId { set; get; }
        public City City { set; get; }
        public ICollection<Review> Reviews { set; get; }
        public ICollection<Category> Categories { set; get; }
    }
}
