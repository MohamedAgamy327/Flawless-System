using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationContext context;
        public PatientRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Patient> Add(Patient patient)
        {
            await context.Patients.AddAsync(patient);
            return patient;
        }
        public Patient Edit(Patient patient)
        {
            context.Entry(patient).State = EntityState.Modified;
            return patient;
        }
        public async Task<Patient> Get(int id)
        {
            return await context.Patients.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Patient>> Get()
        {
            return await context.Patients.ToListAsync();
        }
        public async Task<Patient> Get(string telephone)
        {
            return await context.Patients.AsNoTracking().FirstOrDefaultAsync(s => s.Telephone == telephone);
        }
        public void Remove(Patient patient)
        {
            context.Remove(patient);
        }
    }
}
