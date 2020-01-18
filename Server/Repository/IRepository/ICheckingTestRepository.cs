using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICheckingTestRepository
    {
        void Remove(int checkingId);
        Task<IEnumerable<CheckingTest>> Get(int checkingId);
        void Add(ICollection<CheckingTest> checkingTests);
    }
}
