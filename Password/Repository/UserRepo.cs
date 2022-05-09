using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationCRUD.Password.Repository
{
    public class UserRepo : IUserRepo
    {
        private EmployeeContext _employeeContext;

        public UserRepo(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;

        }

        public async Task<PasswordModel> CreateUserPassword(PasswordModel model)
        {
            model.Id = Guid.NewGuid();
            await _employeeContext.passwordModels.AddAsync(model);
            await _employeeContext.SaveChangesAsync();
            return model;

        }

        public async Task<List<PasswordModel>> GetUser()
        {
            return await _employeeContext.passwordModels.ToListAsync();

        }
    }
    }
