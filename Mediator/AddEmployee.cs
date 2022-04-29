using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.EmployeeData;
using EmployeeRegistrationCRUD.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationCRUD.Mediator
{

    public class AddEmployeeRequest : IRequest<Guid>

    {
        // [BindProperties]

        public Guid Id { get; set; }
        [JsonPropertyName("First_Name")]
        public string FirstName { get; set; }

        [JsonPropertyName("Last_Name")]
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }


        [JsonPropertyName("Contact_Number")]
        public int ContactNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }

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

                //await _db.Employees.AddAsync(entity, cancellationToken);
                //await _db.SaveChangesAsync(cancellationToken);
                //   _employeeContext.Employees.Add(employee);
                //   _employeeContext.SaveChanges();
                //   return employee;


            
        }
    }
}

    

