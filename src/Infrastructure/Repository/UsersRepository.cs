using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {

        private readonly ReviewNowContext _dbContext;

        public UsersRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<EntityEntry<User>> CreateAsync(User user)
        {
            EntityEntry<User> userFromDb = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return userFromDb;
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

        public IQueryable<User> GetAll()
        {
            return _dbContext.Users;
        }
        public IQueryable<User> GetAll(int number, int pageNumber)
        {
            return _dbContext.Users.Skip((number - 1) * pageNumber).Take(pageNumber);
        }

        public User GetById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetByMail(string mail)
        {
            return _dbContext.Users.FirstOrDefault(User => User.Mail == mail);
        }
    }
}
