using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.NormalDomain
{
    public class Admin
    {
        public Guid Id { set; get; }

        [Required]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 character.")]
        public string Name { set; get; }

        [Required]
        [Phone]
        public string PhoneNumber { set; get; }

        [Required]
        public string Address { set; get; }
        

        [EmailAddress]
        public string Mail { set; get; }
    }
}
