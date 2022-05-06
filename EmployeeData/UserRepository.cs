using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(Login userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email




            };
            var result =  await   _userManager.CreateAsync(user, userModel.Password);
            return result;
        }
    }
}