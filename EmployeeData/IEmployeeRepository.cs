using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployee();

        Employee GetEmployee(Guid Id);
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

    }
}
