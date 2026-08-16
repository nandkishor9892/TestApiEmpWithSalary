using System.ComponentModel.DataAnnotations;

namespace EmployeeApiWithEmployeeSalary
{
    public class EmployeeWithSalary
    {
        [Key]
        public int emp_id { get; set; }
        public long mobile { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public decimal incentive { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
