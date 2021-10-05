using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewNow.ExportDtoClases
{
    public class CategoryExportDto
    {
        public Guid Id { get; set; }
      
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
