using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly ApplicationContext context;

        public MedicineRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<Medicine> Add(Medicine medicine)
        {
            await context.Medicines.AddAsync(medicine);
            return medicine;
        }
        public Medicine Edit(Medicine medicine)
        {
            context.Entry(medicine).State = EntityState.Modified;
            return medicine;
        }
        public async Task<Medicine> Get(int id)
        {
            return await context.Medicines.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Medicine>> Get()
        {
            return await context.Medicines.ToListAsync();
        }

        public void Remove(Medicine medicine)
        {
            context.Remove(medicine);
        }
    }
}
