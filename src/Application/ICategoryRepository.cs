using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Task<EntityEntry<Category>> CreateAsync(Category category);
        void Delete(Guid categoryid);
        bool Find(Guid categoryId);
    }
}
