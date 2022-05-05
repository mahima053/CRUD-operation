using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationCRUD.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
       /* [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] 
        }*/
       [HttpPost("authenticate")]

        public IActionResult Authenticate([FromBody] Login login)
        {
            return Ok();
        }
    }
}
