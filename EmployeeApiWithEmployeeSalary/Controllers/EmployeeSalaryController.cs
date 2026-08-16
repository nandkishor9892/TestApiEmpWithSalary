using Azure;
using EmployeeApiWithEmployeeSalary.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace EmployeeApiWithEmployeeSalary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IEmployeeSalary productService;

        public EmployeeSalaryController(IEmployeeSalary productService)
        {
            this.productService = productService;
        }

        

        [HttpGet("getEmployeetbyid")]
        public async Task<IEnumerable<Employee>> GetEmployeeByIdAsync(int Id)
        {
            try
            {
                var response = await productService.GetEmployeeByIdAsync(Id);

                //string jsonString = JsonSerializer.Serialize(response);
                //List<EmployeeWithSalary> objlist = JsonSerializer.Deserialize<List<EmployeeWithSalary>>(jsonString);

                //    response = (IEnumerable<EmployeeWithSalary>) objlist.Select(e => new { e.emp_id, e.name, e.TotalSalary }).ToList();

                if (response == null)
                {
                    return null;
                }
                
                
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("getEmployeetbysalary")]
        public async Task<IEnumerable<Employee>> GetEmployeeBySalaryAsync()
        {
            try
            {
                var response = await productService.GetEmployeeBySalaryAsync();

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpPost("addEmployee")]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeWithSalary product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await productService.AddEmployeeAsync(product);
                if(response > 0)
                {
                    string jsonString = $"{{\"empid\": {response}, \"name\": \"{product.name}\"}}";
                    return Ok(jsonString);
                }
                else
                {
                    return BadRequest();
                }
              
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> UpdateEmployeeAsync(EmployeeWithSalary product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await productService.UpdateEmployeeAsync(product);
                if (result > 0)
                {
                    string jsonString = $"{{\"empid\": {product.emp_id}, \"name\": \"{product.name}\"}}";
                    return Ok(jsonString);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                throw;
            }
        }

      
    }
}
