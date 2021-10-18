using Domain.NormalDomain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
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
        public string Description { get; set; }
        public Guid CityId { set; get; }
        public List<IFormFile> Images { get; set; }
        public IFormFile Categories { set; get; }
    }
}
