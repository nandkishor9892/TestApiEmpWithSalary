using EmployeeApiWithEmployeeSalary.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata;

namespace EmployeeApiWithEmployeeSalary.Repositories
{
    public class EmployeeSalary : IEmployeeSalary
    {
        private readonly EmployeeAndSalaryDbContex _dbContext;

        public EmployeeSalary(EmployeeAndSalaryDbContex dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int empid)
        {
            var param = new SqlParameter("@empid", empid);

            var employeeDetails = await Task.Run(() => _dbContext.Employees
                            .FromSqlRaw(@"exec GetEmpSalaryDetail @empid", param).ToListAsync());

            return employeeDetails;
        }

        public async Task<int> AddEmployeeAsync(EmployeeWithSalary product)
        {
            var lastInsertedIdParam = new SqlParameter
            {
                ParameterName = "@empid",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
         
            var nameParam = new SqlParameter("@name", product.name);
            var mobileParam = new SqlParameter("@mobile", product.mobile);
            var emailParam = new SqlParameter("@email", product.email);
            var addressParam = new SqlParameter("@address", product.address);
            var salaryParam = new SqlParameter("@salary", product.salary);
            var incentiveParam = new SqlParameter("@incentive", product.incentive);


            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec SaveEmployee @name , @mobile, @email, @address,@salary,@incentive,@empid output ", nameParam, mobileParam, emailParam, addressParam, salaryParam, incentiveParam, lastInsertedIdParam));

            return (int) lastInsertedIdParam.Value;
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeWithSalary product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@empid", product.emp_id));
            parameter.Add(new SqlParameter("@name", product.name));
            parameter.Add(new SqlParameter("@mobile", product.mobile));
            parameter.Add(new SqlParameter("@email", product.email));
            parameter.Add(new SqlParameter("@address", product.address));
            parameter.Add(new SqlParameter("@salary", product.salary));
            parameter.Add(new SqlParameter("@incentive", product.incentive));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateEmployee @empid, @name, @mobile, @email, @address,@salary,@incentive", parameter.ToArray()));
            return result;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeBySalaryAsync()
        {

            var employeeDetails = await Task.Run(() => _dbContext.Employees
                            .FromSqlRaw(@"exec GetHighestSalary").ToListAsync());
            return employeeDetails;
        }
    }
}
