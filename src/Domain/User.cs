using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.NormalDomain
{
    public  class User
    {   public Guid Id { set; get; }
        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 character.")]
        public string Name { set; get; }

        [EmailAddress]
        public string Mail { set; get; }

        [Required]
        [Phone]
        public string PhoneNumber { set; get; }

        [JsonIgnore]
        public string Password { set; get; }

        public ICollection<Review> Reviews { set; get; }
        public DateTime AddedDateTime { get; set; }
    }
}
