using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<PasswordModel>>GetUser() => await _mediator.Send(new GetUserRequest());

        [HttpPost]
       public async Task<ActionResult> CreatePass([FromBody] GeneratePasswordMediatR generatePasswordMediatR)
              {
                  var createPass = await _mediator.Send(generatePasswordMediatR);
            return CreatedAtAction(nameof(GetUser), new { id = createPass }, null);
              }
              
    }
}
