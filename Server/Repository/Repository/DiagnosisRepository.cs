using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private readonly ApplicationContext context;
        public DiagnosisRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Diagnosis> Add(Diagnosis diagnosis)
        {
            await context.Diagnosiss.AddAsync(diagnosis);
            return diagnosis;
        }
        public Diagnosis Edit(Diagnosis diagnosis)
        {
            context.Entry(diagnosis).State = EntityState.Modified;
            return diagnosis;
        }
        public async Task<Diagnosis> Get(int id)
        {
            return await context.Diagnosiss.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Diagnosis>> Get()
        {
            return await context.Diagnosiss.ToListAsync();
        }
        public void Remove(Diagnosis diagnosis)
        {
            context.Remove(diagnosis);
        }
    }
}
