using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class WaitingRepository : IWaitingRepository
    {
        private readonly ApplicationContext context;
        public WaitingRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Waiting> Add(Waiting waiting)
        {
            await context.Waitings.AddAsync(waiting);
            return waiting;
        }
        public Waiting Edit(Waiting waiting)
        {
            context.Entry(waiting).State = EntityState.Modified;
            return waiting;
        }
        public async Task<Waiting> Get(int id)
        {
            return await context.Waitings.Include(p => p.Patient).AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Waiting>> Get()
        {
            return await context.Waitings.Where(w => w.CanceledDate == null && w.EnteredDate == null && w.FinishedDate == null).Include(p => p.Patient).AsNoTracking().OrderBy(o => o.Order).ThenBy(o => o.Id).ToListAsync();
        }

        public async Task<int> GetLastOrder()
        {
            return await context.Waitings.OrderByDescending(o => o.Order).ThenByDescending(o => o.Id).Select(p => new int?(p.Order)).FirstOrDefaultAsync() ?? 0;
        }

        public void Remove(Waiting waiting)
        {
            context.Remove(waiting);
        }
    }
}
