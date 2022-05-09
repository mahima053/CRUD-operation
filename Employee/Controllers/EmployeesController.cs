using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.EmployeeData;
using EmployeeRegistrationCRUD.Mediator;
using EmployeeRegistrationCRUD.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmp() => await _mediator.Send(new GetEmpRequest());


        [HttpGet("{id}")]
        public async Task<Employee> GetEmp(Guid id) => await _mediator.Send(new GetEmpByIdRequest { Id = id });


        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
        {
            try
            {      
                var createdEmpId = await _mediator.Send(addEmployeeRequest);
                return CreatedAtAction(nameof(GetEmp), new { id = createdEmpId }, null);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            await _mediator.Send(new DeleteEmployeeRequest { Id = id });
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(Guid id, UpdateEmployeeRequest request)
        {
            request.Id = id;
            return Ok(await _mediator.Send(request));
        }

    }
}
