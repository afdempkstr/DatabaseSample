namespace EFCodeFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Departments.Add(new Department()
                {
                    Name = "Λογιστήριο",
                    Location = "1ος όροφος"
                });

                employeeContext.SaveChanges();
            }

            using (var employeeContext = new EmployeeContext())
            {
                employeeContext.Database.ExecuteSqlCommand("select getdate()");
            }

        }
    }
}
