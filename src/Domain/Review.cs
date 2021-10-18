using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NormalDomain
{
    public enum Price
    {
        Cheap,
        Affordable,
        Expensive
    }
    public class Review
    {
        public Guid Id { get; set; }
        [Range(0, 5, ErrorMessage = "Rating must be between zero and five")]
        public int Stars { get; set; }
        public Price CostOfPlace { get; set; }
        public Guid PlaceId { get; set; }
        public string Description { get; set;}
        public Place Place { get; set; }
        public ICollection<WrapperStringPathReview> ImagePaths { get; set; }
        //public User User { get; set; } 
        //public Guid UserId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

    }
}
