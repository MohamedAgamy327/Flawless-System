using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Password;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<User> Add(User user)
        {
            await context.Users.AddAsync(user);
            return user;
        }
        public User Edit(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            return user;
        }
        public async Task<User> Get(int id)
        {
            return await context.Users.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> Login(string username, string password)
        {
            var optionUser = await context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (optionUser == null)
                return null;

            if (!SecurePassword.VerifyPasswordHash(password, optionUser.PasswordHash, optionUser.PasswordSalt))
                return null;

            return optionUser;
        }

        public void Remove(User user)
        {
            context.Remove(user);
        }
    }
}
