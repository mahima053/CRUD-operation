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
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Age = request.Age,
                    City = request.City,
                    ContactNumber = request.ContactNumber,
                    Gender = request.Gender,
                    State = request.State
                };
                _empRepo.AddEmployee(emp);

                return emp.Id;
            
        }
    }
}

    

