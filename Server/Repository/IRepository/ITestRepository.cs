using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ITestRepository
    {
        Task<Test> Add(Test test);
        Test Edit(Test test);
        void Remove(Test test);
        Task<Test> Get(int id);
        Task<IEnumerable<Test>> Get();
    }
}
