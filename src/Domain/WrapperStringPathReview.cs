using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WrapperStringPathReview
    {   
        public Guid Id { set; get; }

        public string Url { set; get; }
        public Guid ReviewId { set; get; }
        public Review Review { get; set; }
    }
}
