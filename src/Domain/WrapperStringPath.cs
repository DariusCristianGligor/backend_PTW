using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WrapperStringPath
    {
       public  Guid Id { set; get; }

        public string Url { set; get; }

        public Guid PlaceId { set; get; }
        public Place Place { get; set; }
    }
}
