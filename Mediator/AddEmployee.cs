using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.EmployeeData;
using EmployeeRegistrationCRUD.Mediator;
using EmployeeRegistrationCRUD.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationCRUD.Mediator
{

    public class AddEmployeeRequest  : Employee, IRequest<Guid> 

    {

    }

        public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, Guid> 
        {
            private readonly IEmployeeRepository _empRepo;
            public AddEmployeeHandler(IEmployeeRepository employeeRepository)
            {
                _empRepo = employeeRepository;
            }

            public async Task<Guid> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
            {

                var emp = new Employee
                {
                    First_Name = request.First_Name,
                    Last_Name = request.Last_Name,
                    Age = request.Age,
                    City = request.City,
                    Contact_Number = request.Contact_Number,
                    Gender = request.Gender,
                    State = request.State
                };
                await _empRepo.AddEmployee(emp);

                return emp.Id;
            
        }
    }
}

    

