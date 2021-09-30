using Application;
using AutoMapper;
using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    class UserRepository : IUsersRepository
    {
       
        private readonly ReviewNowContext _dbContext;
  
        public UserRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;
          
        }

        public async Task<User> AddAsync(User user)
        {
           
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public void Delete(Guid userId)
        {
            _dbContext.Users.RemoveRange(_dbContext.Users.Where(x => x.Id == userId));
            _dbContext.SaveChanges();
        }

        public bool Find(Guid userId)
        {
            List<User> list = _dbContext.Users.Where(x => x.Id == userId).ToList();
            return (!(list.Count == 0));
        }

        public ICollection<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }
        public ICollection<User> GetAll(int number,int pageNumber)
        {
            return _dbContext.Users.Skip((number - 1) * pageNumber).Take(pageNumber).ToList();
        }

    }
}
