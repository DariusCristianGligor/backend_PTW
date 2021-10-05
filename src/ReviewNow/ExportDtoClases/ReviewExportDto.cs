using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.ExportDtoClases
{
    public class ReviewExportDto
    {
        public Guid Id { get; set; }
  
        public int Stars { get; set; }
        public Price CostOfPlace { get; set; }
        public Guid PlaceId { get; set; }
        public Place Place { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
