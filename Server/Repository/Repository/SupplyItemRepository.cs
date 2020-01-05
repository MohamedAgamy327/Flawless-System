using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class SupplyItemRepository : ISupplyItemRepository
    {
        private readonly ApplicationContext context;
        public SupplyItemRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SupplyItem>> Get(int supplyId)
        {
            return await context.SupplysItems.Include(w => w.Item).Where(w => w.SupplyId == supplyId).ToListAsync();
        }

    }
}
