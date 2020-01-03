using Data.SeedData;
using Domain.Entities;
using Domain.EntitiesMap;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserMap(modelBuilder.Entity<User>());
            new ItemMap(modelBuilder.Entity<Item>());
            new TestMap(modelBuilder.Entity<Test>());
            new PatientMap(modelBuilder.Entity<Patient>());
            new SpendingMap(modelBuilder.Entity<Spending>());
            new MedicineMap(modelBuilder.Entity<Medicine>());
            new FrequencyMap(modelBuilder.Entity<Frequency>());
            new MedicineTypeMap(modelBuilder.Entity<MedicineType>());

            modelBuilder.Seed();
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Spending> Spendings { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Frequency> Frequencys { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }

    }
}
