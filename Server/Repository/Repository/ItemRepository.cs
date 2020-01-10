using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationContext context;
        public ItemRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Item> Add(Item item)
        {
            await context.Items.AddAsync(item);
            return item;
        }
        public Item Edit(Item item)
        {
            var local = context.Set<Item>().Local.FirstOrDefault(entry => entry.Id.Equals(item.Id));
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(item).State = EntityState.Modified;
            return item;
        }
        public async Task<Item> Get(int id)
        {
            return await context.Items.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Item>> Get()
        {
            return await context.Items.ToListAsync();
        }
        public void Remove(Item item)
        {
            context.Remove(item);
        }
    }
}
