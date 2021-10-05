using Application;
using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    class AdminRepository : IAdminRepository
    {
        private readonly ReviewNowContext _dbContext;


        public AdminRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;

        }

        public void Delete(Guid adminId)
        {
            _dbContext.Admins.RemoveRange(_dbContext.Admins.Where(x => x.Id == adminId));
            _dbContext.SaveChanges();
        }
        public bool Find(Guid adminId)
        {
            return (!(_dbContext.Admins.Find(adminId) == null));
        }

        public IQueryable<Admin> GetAll()
        {
            return _dbContext.Admins;
        }
        public IQueryable<Admin> GetAll(int page, int pageSize)
        {
            return _dbContext.Admins.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public async Task<EntityEntry<Admin>> AddAsync(Admin admin)
        {
            EntityEntry<Admin> admin2 = await _dbContext.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
            return admin2;
        }
    }
}
