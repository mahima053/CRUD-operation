using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Login;
using EmployeeRegistrationCRUD.Password.MediatR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationCRUD.Password
{
    [Route("api/users")]
    [ApiController]
    public class PasswordController : Controller

    {
        private readonly IMediator _mediator;
        public PasswordController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        [Route("password")]
        public async Task<IEnumerable<PasswordModel>> GetUser() => await _mediator.Send(new GetUserRequest());

        [HttpGet("{id}")]
        [Route("password")]
        public async Task<PasswordModel> GetUser(Guid id) => await _mediator.Send(new GetUserByIdRequest { Id = id });

        [HttpPost]
        [Route("password")]
        public async Task<ActionResult> CreatePass([FromBody] GeneratePasswordMediatR generatePasswordMediatR)
        {
            var createPass = await _mediator.Send(generatePasswordMediatR);
            return CreatedAtAction(nameof(GetUser), new { id = createPass },null);
        }

        [HttpPost]
        [Route("Login")]
        //POST :  /api/users/login

        public async Task<IActionResult> Login([FromBody] UserLoginMediatRRequest userLoginMediatRRequest)
        {
            try
            {
                var id = await _mediator.Send(userLoginMediatRRequest);
                return Ok(id);
                
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        } 
    } 
}
