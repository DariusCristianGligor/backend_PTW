using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAdminRepository
    {
        ICollection<Admin> GetAll();
        void Delete(Guid adminId);
        Task<Admin> AddAsync(Admin admin);
        bool Find(Guid adminId);
    }
}
