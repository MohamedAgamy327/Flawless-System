using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IDiagnosisRepository
    {
        Task<Diagnosis> Add(Diagnosis diagnosis);
        Diagnosis Edit(Diagnosis diagnosis);
        void Remove(Diagnosis diagnosis);
        Task<Diagnosis> Get(int id);
        Task<IEnumerable<Diagnosis>> Get();
    }
}
