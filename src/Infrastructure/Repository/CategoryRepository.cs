using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {

         private readonly ReviewNowContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryRepository(ReviewNowContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ICollection<Category> GetAll() => _dbContext.Categories.ToList();
        public ICollection<Category> GetAll(int page,int pageSize) => _dbContext.Categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();
       
        public void Delete(Guid categoryId)
        {
            _dbContext.Categories.RemoveRange(_dbContext.Categories.Where(x => x.Id == categoryId));
           _dbContext.SaveChanges();
        }

        public bool Find(Guid categoryId)
        {
            List<Category> list = _dbContext.Categories.Where(x => x.Id == categoryId).ToList();
            return (!(list.Count == 0));
        }


        public async Task<Category> CreateAsync(Category category)
        {
            //Category category = _mapper.Map<Category>(categoryDto);
           await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
