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

            var Employee = _empRepo.GetEmployee(request.Id);
    
            {
                Employee.FirstName = request.FirstName;
                Employee.Age = request.Age;
                Employee.City = request.City;
                Employee.ContactNumber = request.ContactNumber;
                Employee.Gender = request.Gender;
                Employee.LastName = request.LastName;
                Employee.State = request.State;

                _empRepo.EditEmployee(Employee);
                return Employee.Id;
            }
        }
    }
}
