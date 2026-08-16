using System.ComponentModel.DataAnnotations;

namespace EmployeeApiWithEmployeeSalary
{
    public class Employee
    {
        [Key]
        public int emp_id { get; set; }      
        public string name { get; set; }       
        public decimal TotalSalary { get; set; }
    }
}
