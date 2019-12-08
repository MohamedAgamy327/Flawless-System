using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IItemRepository
    {
        Task<Item> Add(Item item);
        Item Edit(Item item);
        void Remove(Item item);
        Task<Item> Get(int id);
        Task<IEnumerable<Item>> Get();
    }
}
