using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationCRUD.Models
{
    public class EmployeeContext : IdentityDbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }

}
