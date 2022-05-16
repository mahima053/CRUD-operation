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
    public class UpdateEmployeeRequest : Employee,IRequest<Guid>
    {
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

            var Employee = await _empRepo.GetEmployee(request.Id);
    
            {
                Employee.First_Name = request.First_Name;
                Employee.Age = request.Age;
                Employee.City = request.City;
                Employee.Contact_Number = request.Contact_Number;
                Employee.Gender = request.Gender;
                Employee.Last_Name = request.Last_Name;
                Employee.State = request.State;

               await _empRepo.EditEmployee(Employee);
                return Employee.Id;
             
             
            }
        }
    }
}
