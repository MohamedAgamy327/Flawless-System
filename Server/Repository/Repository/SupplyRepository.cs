using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly ApplicationContext context;
        public SupplyRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Supply> Add(Supply supply)
        {
            await context.Supplys.AddAsync(supply);
            return supply;
        }
        public Supply Edit(Supply supply)
        {
            context.Entry(supply).State = EntityState.Modified;
            return supply;
        }
        public async Task<Supply> Get(int id)
        {
            return await context.Supplys.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Supply>> Get()
        {
            return await context.Supplys.ToListAsync();
        }
        public void Remove(Supply supply)
        {
            context.Remove(supply);
        }
    }
}
