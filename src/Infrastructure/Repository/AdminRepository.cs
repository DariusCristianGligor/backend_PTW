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
    class AdminRepository : IAdminRepository
    {
        private readonly ReviewNowContext _dbContext;
   

        public AdminRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;
             
        }
     
        public  void Delete(Guid adminId)
        {
            _dbContext.Admins.RemoveRange(_dbContext.Admins.Where(x => x.Id == adminId));
             _dbContext.SaveChanges();
        }
        public bool Find(Guid adminId)
        {
            List<Admin> list = _dbContext.Admins.Where(x => x.Id == adminId).ToList();
            return (!(list.Count==0));
        }

        public ICollection<Admin> GetAll()
        {
            return _dbContext.Admins.ToList();
        }
        public ICollection<Admin> GetAll(int page,int pageSize)
        {
            return _dbContext.Admins.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
        
        public async Task<Admin> AddAsync(Admin admin)
        {
            await _dbContext.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
            return admin;
        }
    }
}
