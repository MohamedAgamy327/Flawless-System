using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<Patient> Add(Patient patient);
        Patient Edit(Patient patient);
        void Remove(Patient patient);
        Task<Patient> Get(string telephone);
        Task<Patient> Get(int id);
        Task<IEnumerable<Patient>> Get();
    }
}
