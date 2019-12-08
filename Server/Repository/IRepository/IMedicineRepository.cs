using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IMedicineRepository
    {
        Task<Medicine> Add(Medicine medicine);
        Medicine Edit(Medicine medicine);
        void Remove(Medicine medicine);
        Task<Medicine> Get(int id);
        Task<IEnumerable<Medicine>> Get();
    }
}
