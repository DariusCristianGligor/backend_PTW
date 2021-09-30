using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 character.")]
        public string Name { set; get; }

        [EmailAddress]
        public string Mail { set; get; }

        public ICollection<Review> Reviews { set; get; }
    }
}
