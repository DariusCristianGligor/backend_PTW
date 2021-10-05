using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IAdminRepository
    {
        IQueryable<Admin> GetAll();
        void Delete(Guid adminId);
        Task<EntityEntry<Admin>> AddAsync(Admin admin);
        bool Find(Guid adminId);
    }
}
