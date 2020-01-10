using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ISupplyItemRepository
    {
        Task<IEnumerable<SupplyItem>> Get(int supplyId);
        void Remove(int supplyId);
        Task Add(ICollection<SupplyItem> supplyItems);
    }
}
