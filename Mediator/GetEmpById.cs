using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Employee_RegistrationCRUD.Models;
using MediatR;

namespace Employee_RegistrationCRUD.Mediator
{
    public class GetEmpById
    {
        public class Query : IRequest<Employee>
        {
            public Guid Id { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, Employee>
        {
            private readonly EmployeeContext _db;

            public QueryHandler(EmployeeContext db) => _db = db;
            public async Task<Employee> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Employees.FindAsync(request.Id);
            }
        }
    }
}
