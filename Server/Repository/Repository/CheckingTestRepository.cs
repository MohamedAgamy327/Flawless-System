using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CheckingTestRepository : ICheckingTestRepository
    {
        private readonly ApplicationContext context;
        public CheckingTestRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async void Add(ICollection<CheckingTest> checkingTests)
        {
            await context.CheckingTests.AddRangeAsync(checkingTests);
        }
        public async Task<IEnumerable<CheckingTest>> Get(int checkingId)
        {
            return await context.CheckingTests.Include(i => i.Test).Where(w => w.CheckingId == checkingId).ToListAsync();
        }
        public void Remove(int checkingId)
        {
            context.RemoveRange(context.CheckingTests.Where(r => r.CheckingId == checkingId));
        }
    }
}
