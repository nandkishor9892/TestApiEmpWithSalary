namespace EmployeeApiWithEmployeeSalary.Repositories
{
    public interface IEmployeeSalary
    {
      
        public Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int Id);
        public Task<int> AddEmployeeAsync(EmployeeWithSalary employees);
        public Task<int> UpdateEmployeeAsync(EmployeeWithSalary employees);
        public Task<IEnumerable<Employee>> GetEmployeeBySalaryAsync();

    }
}
