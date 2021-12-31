using Domain.NormalDomain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application
{
    public interface IUsersRepository
    {
        void Delete(Guid userId);

        Task<EntityEntry<User>> CreateAsync(User user);

        bool Find(Guid userId);
        User GetByMail(string mail);

        User GetById(Guid id);

    }
}
