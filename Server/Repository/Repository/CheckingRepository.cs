using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CheckingRepository : ICheckingRepository
    {
        private readonly ApplicationContext context;
        public CheckingRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Checking> Add(Checking checking)
        {
            await context.Checkings.AddAsync(checking);
            return checking;
        }
        public Checking Edit(Checking checking)
        {
            context.Entry(checking).State = EntityState.Modified;
            return checking;
        }
        public async Task<Checking> Get(int id)
        {
            return await context.Checkings.Include(d=>d.CheckingItems).AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Checking>> Get()
        {
            return await context.Checkings.ToListAsync();
        }
        public async Task<IEnumerable<Checking>> GetForPatient(int patientId)
        {
            return await context.Checkings.Where(w => w.PatientId == patientId).ToListAsync();
        }
        public void Remove(Checking checking)
        {
            context.Remove(checking);
        }
    }
}
