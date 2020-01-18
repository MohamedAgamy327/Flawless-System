using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MedicineTypeRepository : IMedicineTypeRepository
    {
        private readonly ApplicationContext context;
        public MedicineTypeRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<MedicineType> Add(MedicineType medicineType)
        {
            await context.MedicineTypes.AddAsync(medicineType);
            return medicineType;
        }
        public MedicineType Edit(MedicineType medicineType)
        {
            context.Entry(medicineType).State = EntityState.Modified;
            return medicineType;
        }
        public async Task<MedicineType> Get(int id)
        {
            return await context.MedicineTypes.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<MedicineType>> Get()
        {
            return await context.MedicineTypes.ToListAsync();
        }
        public void Remove(MedicineType medicineType)
        {
            context.Remove(medicineType);
        }
    }
}
