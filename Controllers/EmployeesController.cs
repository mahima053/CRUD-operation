﻿using System;
using Employee_RegistrationCRUD.EmployeeData;
using Employee_RegistrationCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_RegistrationCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;

        }

        [HttpGet]

        public IActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployee());
        }

       [HttpGet("{Id}")]
        //[Route("api/[controller]")]

        public IActionResult GetEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);
            if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"employee with id: (Id) was not found");
        }

        [HttpPost]
       
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, value: employee);
        }
        [HttpDelete("{Id}")]
        //Route("api/[Employees]/{Id}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var employee = _employeeData.GetEmployee(Id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();

            }
            return NotFound($"employee with id: (Id) was not found");
        }
        [HttpPatch("{Id}")]
        // [Route("api/[Employees]/{Id}")]

        public IActionResult EditEmployee(Guid Id, Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(Id);

            if (existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);
                
            }
            return Ok(employee);
        }
    }
}
