using Domain;
using Domain.NormalDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUsersRepository
    {
        ICollection<User> GetAll();
        
        void Delete(Guid userId);
        Task<User> AddAsync(User user);
        bool Find(Guid userId);
    }
}
