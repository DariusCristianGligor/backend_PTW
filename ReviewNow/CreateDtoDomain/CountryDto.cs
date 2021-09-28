using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class CountryDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 character.")]
        public string Name { set; get; }
        [Required]
        [StringLength(5, ErrorMessage = "ShortName length can't be more than 5 character.")]
        public string ShortName { set; get; }
        public ICollection<City> Cities { set; get; }
    }
}
