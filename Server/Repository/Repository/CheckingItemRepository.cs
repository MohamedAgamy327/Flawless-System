using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class CheckingItemRepository : ICheckingItemRepository
    {
        private readonly ApplicationContext context;
        public CheckingItemRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async void Add(ICollection<CheckingItem> checkingItems)
        {
            await context.CheckingItems.AddRangeAsync(checkingItems);
        }
        public async Task<IEnumerable<CheckingItem>> Get(int checkingId)
        {
            return await context.CheckingItems.Include(i => i.Item).Where(w => w.CheckingId == checkingId).ToListAsync();
        }
        public void Remove(int checkingId)
        {
            context.RemoveRange(context.CheckingItems.Where(r => r.CheckingId == checkingId));
        }
    }
}
