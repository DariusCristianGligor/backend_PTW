using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.CreateDtoDomain
{
    public class RegisterDto
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }
        public ICollection<Review> Reviews { set; get; }
    }
}
