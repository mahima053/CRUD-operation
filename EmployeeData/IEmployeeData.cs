using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_RegistrationCRUD.Models;

namespace Employee_RegistrationCRUD.EmployeeData
{
    public  interface IEmployeeData
    {
        List<Employee> GetEmployee();

        Employee GetEmployee(Guid Id);
        Employee AddEmployee(Employee employee);
        void  DeleteEmployee(Employee employee);

        Employee EditEmployee(Employee employee);

    }
}
