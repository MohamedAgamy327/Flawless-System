using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICheckingMedicineRepository
    {
        void Remove(int checkingId);
        Task<IEnumerable<CheckingMedicine>> Get(int checkingId);
        void Add(ICollection<CheckingMedicine> checkingMedicines);
    }
}
