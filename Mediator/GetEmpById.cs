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
    public class GetEmpByIdRequest : IRequest<Employee>
    {
       
            public Guid Id { get; set; }
        }
        public class GetEmpByIdHandler : IRequestHandler<GetEmpByIdRequest, Employee>
        {
            private readonly IEmployeeRepository _empRepo;

        public GetEmpByIdHandler(IEmployeeRepository employeeRepository)
        {
            _empRepo = employeeRepository;
        }
            public async Task<Employee> Handle(GetEmpByIdRequest request, CancellationToken cancellationToken)
            {
           
            return  _empRepo.GetEmployee(request.Id);
            }
        }   
}
