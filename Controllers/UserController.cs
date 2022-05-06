using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.EmployeeData;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public IActionResult Login() => View();

        [Route("api/users")]
        [HttpPost]
        public async Task<IActionResult> Login(Login usermodel)
        {
            if(ModelState.IsValid)
            {
                var result = await _userRepository.CreateUserAsync(usermodel);
                if(!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }
                ModelState.Clear();
            }
            return View();
        }
    }
}
