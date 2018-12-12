using System.Data.Entity;

namespace EFCodeFirstSample
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=connectionString")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

    }
}
