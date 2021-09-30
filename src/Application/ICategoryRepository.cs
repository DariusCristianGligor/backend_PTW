using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetAll();
        Task<Category> CreateAsync(Category category);
        void Delete(Guid categoryid);
        bool Find(Guid categoryId);
    }
}
