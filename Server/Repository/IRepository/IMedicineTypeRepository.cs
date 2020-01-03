using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IMedicineTypeRepository
    {
        Task<MedicineType> Add(MedicineType medicineType);
        MedicineType Edit(MedicineType medicineType);
        void Remove(MedicineType medicineType);
        Task<MedicineType> Get(int id);
        Task<IEnumerable<MedicineType>> Get();
    }
}
