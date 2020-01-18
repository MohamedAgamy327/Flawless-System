using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICheckingItemRepository
    {
        void Remove(int checkingId);
        Task<IEnumerable<CheckingItem>> Get(int checkingId);
        void Add(ICollection<CheckingItem> checkingItems);
    }
}
