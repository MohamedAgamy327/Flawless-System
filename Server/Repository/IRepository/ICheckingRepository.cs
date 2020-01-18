using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface ICheckingRepository
    {
        Task<Checking> Add(Checking checking);
        Checking Edit(Checking checking);
        void Remove(Checking checking);
        Task<Checking> Get(int id);
        Task<IEnumerable<Checking>> GetForPatient(int patientId);
        Task<IEnumerable<Checking>> Get();
    }
}
