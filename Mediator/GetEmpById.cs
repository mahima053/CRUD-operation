using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
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
            private readonly EmployeeContext _db;

        public GetEmpByIdHandler(EmployeeContext db) => _db = db;
            public async Task<Employee> Handle(GetEmpByIdRequest request, CancellationToken cancellationToken)
            {
                return await _db.Employees.FindAsync(request.Id);
            }
        }   
}
