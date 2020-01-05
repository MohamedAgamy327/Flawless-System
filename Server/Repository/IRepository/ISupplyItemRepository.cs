using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ISupplyItemRepository
    {
        Task<IEnumerable<SupplyItem>> Get(int supplyId);
    }
}
