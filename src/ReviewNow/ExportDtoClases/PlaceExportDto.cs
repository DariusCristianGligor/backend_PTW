using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.ExportDtoClases
{
    public class PlaceExportDto
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

       
        public string Address { set; get; }

        public float Rating { set; get; }

        public float AvgStars { set; get; }

        public int NumberOfReview { set; get; }

        public Guid CityId { set; get; }

        public City City { set; get; }

        public ICollection<Review> Reviews { set; get; }
        public ICollection<string> ImagePaths { set; get; }

        public ICollection<Category> Categories { set; get; }
        public DateTime AddedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
