using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public interface IEmployeeRepository
    {

        Task<List<Employee>> GetEmployee();

        Task<Employee> GetEmployee(Guid Id);
        Task<Employee> AddEmployee(Employee employee);
        Task DeleteEmployee(Task<Employee> employee);

        Task<Employee> EditEmployee(Employee employee);
    }
}
