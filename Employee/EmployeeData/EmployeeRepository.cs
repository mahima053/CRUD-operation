using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;

        }
        public   async Task<Employee> AddEmployee(Employee employee)
        {
           employee.Id = Guid.NewGuid();
          await  _employeeContext.Employees.AddAsync(employee);
            await _employeeContext.SaveChangesAsync();
            return employee;
        }

       public async Task DeleteEmployee(Task<Employee> employee)
        {
            _employeeContext.Employees.Remove(await employee);
            await _employeeContext.SaveChangesAsync();
        }


        public async Task<Employee> EditEmployee(Employee employee)
        {
            var existingEmployee = _employeeContext.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {

                _employeeContext.Employees.Update(existingEmployee);
                await _employeeContext.SaveChangesAsync();

            }
            return (employee);
        }

        public async Task<List<Employee>> GetEmployee()
        {
           
            return await _employeeContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(Guid Id)
        {
            var employee =  await _employeeContext.Employees.FindAsync(Id);
            return employee;
            
        }

       
    }
}
