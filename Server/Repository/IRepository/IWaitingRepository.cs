using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IWaitingRepository
    {
        Task<Waiting> Add(Waiting waiting);
        Waiting Edit(Waiting waiting);
        void Remove(Waiting waiting);
        Task<Waiting> Get(int id);
        Task<int> GetLastOrder();
        Task<IEnumerable<Waiting>> Get();
    }
}
