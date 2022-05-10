using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Login;
using EmployeeRegistrationCRUD.Models;
using EmployeeRegistrationCRUD.Password;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationCRUD.Models
{
    public class EmployeeContext :DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PasswordModel> passwordModels { get; set; }

       // public DbSet<LoginModel> loginModels { get; set; }
    }

}
