using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_RegistrationCRUD.EmployeeData;
using Employee_RegistrationCRUD.Mediator;
using Employee_RegistrationCRUD.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Employee_RegistrationCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
       /*  private IEmployeeRepository _employeeData;

        public EmployeesController(IEmployeeRepository employeeData)
          {
              _employeeData = employeeData;

          }*/
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmp() => await _mediator.Send(new GetEmp.Query());


        [HttpGet("{id}")]
        public async Task<Employee> GetEmp(Guid id) => await _mediator.Send(new GetEmpById.Query { Id = id });


        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] Add_Employee.Command command)
        {
            var createdEmpId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmp), new { id = createdEmpId }, null);
        }


        [HttpDelete("{Id}")]

        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            await _mediator.Send(new DeleteEmployee.Command{Id = id});
            return NoContent();
        }

       /* [HttpGet]

        public IActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployee());
        }

       [HttpGet("{Id}")]
        //[Route("api/[controller]")]

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
        [HttpDelete("{Id}")]
        //Route("api/[Employees]/{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();

            }
            return NotFound($"employee with id: (Id) was not found");
        }
        [HttpPatch("{Id}")]
        // [Route("api/[Employees]/{Id}")]

        public IActionResult EditEmployee(Guid Id, Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(Id);

            if (existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);
                
            }
            return Ok(employee);
        }*/
        
    }
}
