using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NormalDomain
{
    public class City
    {
        public Guid Id { set; get; }
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 character.")]
        public string Name { set; get; }

        [Required]
        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Place> Places { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
