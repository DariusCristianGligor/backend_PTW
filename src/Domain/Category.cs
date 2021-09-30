using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NormalDomain
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 character.")]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Description length can't be more than 1000 character.")]
        public string Description { get; set; }

        public DateTime AddedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }
        public ICollection<Place> Places { get; set; }
    }
}
