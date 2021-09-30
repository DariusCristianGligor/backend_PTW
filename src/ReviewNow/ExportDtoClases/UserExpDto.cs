using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.ExportDtoClases
{
    public class UserExpDto
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public string Mail { set; get; }

        public ICollection<Review> Reviews { set; get; }
    }
}
