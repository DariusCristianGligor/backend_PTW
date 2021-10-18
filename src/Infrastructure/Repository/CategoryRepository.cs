using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ReviewNowContext _dbContext;

        public CategoryRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Category> GetAll() => _dbContext.Categories;
        public IQueryable<Category> GetAll(int page, int pageSize) => _dbContext.Categories.OrderBy(x=>x.Name).Skip((page - 1) * pageSize).Take(pageSize);
        public int GetNumberOfCategory()
        {
            return _dbContext.Categories.Count();
        }

        public void Delete(Guid categoryId)
        {
            _dbContext.Categories.RemoveRange(_dbContext.Categories.Where(x => x.Id == categoryId));
            _dbContext.SaveChanges();
        }

        public bool Find(Guid Id)
        {

            if (_dbContext.Categories.Find(Id) == null)
                return false;
            return true;
        }


        public async Task<EntityEntry<Category>> CreateAsync(Category category)
        {
            EntityEntry<Category> categoryFromDb = await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return categoryFromDb;
        }

        public IQueryable<Category> GetAllByPlaceID(Guid placeId)
        {
            return _dbContext.Categories.Where(x => x.Places.Any(x=> x.Id == placeId));
        }
    }
}
