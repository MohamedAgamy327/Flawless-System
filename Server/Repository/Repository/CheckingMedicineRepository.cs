using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CheckingMedicineRepository : ICheckingMedicineRepository
    {
        private readonly ApplicationContext context;
        public CheckingMedicineRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async void Add(ICollection<CheckingMedicine> checkingMedicines)
        {
            await context.CheckingMedicines.AddRangeAsync(checkingMedicines);
        }
        public async Task<IEnumerable<CheckingMedicine>> Get(int checkingId)
        {
            return await context.CheckingMedicines.Include(i => i.Medicine).Include(k => k.Frequency).Include(p => p.Medicine.MedicineType).Where(w => w.CheckingId == checkingId).ToListAsync();
        }
        public void Remove(int checkingId)
        {
            context.RemoveRange(context.CheckingMedicines.Where(r => r.CheckingId == checkingId));
        }
    }
}
