using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.StaticHelpers;

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
        public async Task<User> Login(string name, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Name == name);

            if (user == null)
                return null;

            if (!SecurePassword.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }
        public void Remove(User user)
        {
            context.Remove(user);
        }
    }
}
