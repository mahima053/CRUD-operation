using System;
using Employee_RegistrationCRUD.EmployeeData;
using Employee_RegistrationCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_RegistrationCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;

        }

        [HttpGet]

        public IActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployee());
        }

       [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);
            if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"employee with id: (Id) was not found");
        }

        [HttpPost]
       
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, value: employee);
        }
    }
}
