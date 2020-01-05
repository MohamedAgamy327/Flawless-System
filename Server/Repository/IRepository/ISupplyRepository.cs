using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ISupplyRepository
    {
        Task<Supply> Add(Supply supply);
        Supply Edit(Supply supply);
        void Remove(Supply supply);
        Task<Supply> Get(int id);
        Task<IEnumerable<Supply>> Get();
    }
}
