using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.EmployeeData;
using EmployeeRegistrationCRUD.Models;
using MediatR;

namespace EmployeeRegistrationCRUD.Mediator
{
    public class UpdateEmployeeRequest : IRequest<Guid>
    {
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
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeRequest, Guid>
    {
        private IEmployeeRepository _empRepo;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _empRepo = employeeRepository;
        }
        public async Task<Guid> Handle(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            //   var Employee = await db.Employees.FindAsync(request.Id);

            var Employee = _empRepo.GetEmployee(request.Id);
    
            {
                Employee.FirstName = request.FirstName;
                Employee.Age = request.Age;
                Employee.City = request.City;
                Employee.ContactNumber = request.ContactNumber;
                Employee.Gender = request.Gender;
                Employee.LastName = request.LastName;
                Employee.State = request.State;

                // await db.SaveChangesAsync();
                _empRepo.EditEmployee(Employee);
                return Employee.Id;
            }
        }
    }
}
