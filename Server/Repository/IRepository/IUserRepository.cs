using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        User Edit(User user);
        void Remove(User user);
        Task<User> Login(string username, string password);
        Task<User> Get(int id);
        Task<IEnumerable<User>> Get();
    }
}
