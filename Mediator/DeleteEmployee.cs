using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.EmployeeData;
using EmployeeRegistrationCRUD.Models;
using MediatR;

namespace EmployeeRegistrationCRUD.Mediator
{
    public class DeleteEmployeeRequest : IRequest
    {
            public Guid Id { get; set; }
       
        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, Unit>
        {
            private readonly IEmployeeRepository _empRepo;

            public DeleteEmployeeHandler(IEmployeeRepository employeeRepository)
            {
                _empRepo = employeeRepository;
            }
            public async Task<Unit> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
            {
                var employee =  _empRepo.GetEmployee(request.Id);
                if(employee != null)
                {
                    await _empRepo.DeleteEmployee(employee);
                }

                return Unit.Value;

         
            }
        }
    }
}
