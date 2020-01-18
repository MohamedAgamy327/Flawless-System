using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationContext context;
        public TestRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public async Task<Test> Add(Test test)
        {
            await context.Tests.AddAsync(test);
            return test;
        }
        public Test Edit(Test test)
        {
            context.Entry(test).State = EntityState.Modified;
            return test;
        }
        public async Task<Test> Get(int id)
        {
            return await context.Tests.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Test>> Get()
        {
            return await context.Tests.ToListAsync();
        }
        public void Remove(Test test)
        {
            context.Remove(test);
        }
    }
}
