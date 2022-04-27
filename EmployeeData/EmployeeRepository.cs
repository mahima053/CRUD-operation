using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeRegistrationCRUD.Models;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;

        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                _employeeContext.Employees.Update(existingEmployee);
                _employeeContext.SaveChanges();

            }
            return employee;
        }

        public List<Employee> GetEmployee()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee GetEmployee(Guid Id)
        {
            var employee = _employeeContext.Employees.Find(Id);
            return employee;
        }
    }
}
