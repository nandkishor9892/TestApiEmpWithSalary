using Microsoft.EntityFrameworkCore;

namespace EmployeeApiWithEmployeeSalary.Data
{
    public class EmployeeAndSalaryDbContex : DbContext
    {
        private readonly IConfiguration Configuration;

        public EmployeeAndSalaryDbContex(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<EmployeeWithSalary> EmployeeWithSalaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
