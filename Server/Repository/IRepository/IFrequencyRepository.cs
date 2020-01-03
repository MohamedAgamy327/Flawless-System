using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IFrequencyRepository
    {
        Task<Frequency> Add(Frequency frequency);
        Frequency Edit(Frequency frequency);
        void Remove(Frequency frequency);
        Task<Frequency> Get(int id);
        Task<IEnumerable<Frequency>> Get();
    }
}
