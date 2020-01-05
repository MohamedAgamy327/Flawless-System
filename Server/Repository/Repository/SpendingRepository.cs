using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SpendingRepository : ISpendingRepository
    {
        private readonly ApplicationContext context;
        public SpendingRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Spending> Add(Spending spending)
        {
            await context.Spendings.AddAsync(spending);
            return spending;
        }
        public Spending Edit(Spending spending)
        {
            context.Entry(spending).State = EntityState.Modified;
            return spending;
        }
        public async Task<Spending> Get(int id)
        {
            return await context.Spendings.Include(i=>i.User).AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Spending>> Get()
        {
            return await context.Spendings.Include(i => i.User).ToListAsync();
        }
        public void Remove(Spending spending)
        {
            context.Remove(spending);
        }
    }
}
