using System;
using System.Collections.Generic;
using Employee_RegistrationCRUD.Models;

namespace Employee_RegistrationCRUD.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private readonly List<Employee> employees;
        private List<Employee> employee = new List<Employee>()
        {
            new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Mahima",
                LastName = "Saxena",
                Age = 22,
                City = "Garh",
                Gender = "Female",
                State = "U.P",
                ContactNumber = 921221
            },
             new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = "Ayushi",
                LastName = "Sharma",
                Age = 22,
                City = "Meerut",
                Gender = "Female",
                State = "U.P",
                ContactNumber = 9218881
            }

        };
        public Employee AddEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Employee EditEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public List<Employee> GetEmployee()
        {
            return employees;
        }
  

        public Employee GetEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }

    }
}
