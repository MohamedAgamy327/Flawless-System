using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class FrequencyRepository : IFrequencyRepository
    {
        private readonly ApplicationContext context;
        public FrequencyRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Frequency> Add(Frequency frequency)
        {
            await context.Frequencys.AddAsync(frequency);
            return frequency;
        }
        public Frequency Edit(Frequency frequency)
        {
            context.Entry(frequency).State = EntityState.Modified;
            return frequency;
        }
        public async Task<Frequency> Get(int id)
        {
            return await context.Frequencys.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Frequency>> Get()
        {
            return await context.Frequencys.ToListAsync();
        }
        public void Remove(Frequency frequency)
        {
            context.Remove(frequency);
        }
    }
}
