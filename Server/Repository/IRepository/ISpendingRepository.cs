using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ISpendingRepository
    {
        Task<Spending> Add(Spending spending);
        Spending Edit(Spending spending);
        void Remove(Spending spending);
        Task<Spending> Get(int id);
        Task<IEnumerable<Spending>> Get();
    }
}
