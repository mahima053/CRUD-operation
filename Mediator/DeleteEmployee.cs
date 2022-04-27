using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using MediatR;

namespace EmployeeRegistrationCRUD.Mediator
{
    public class DeleteEmployeeRequest : IRequest
    {
            public Guid Id { get; set; }
       
        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeRequest, Unit>
        {
            private readonly EmployeeContext _db;

            public DeleteEmployeeHandler(EmployeeContext db) => _db = db;
            public async Task<Unit> Handle(DeleteEmployeeRequest request, CancellationToken cancellationToken)
            {
                var Employee = await _db.Employees.FindAsync(request.Id);
                if (Employee == null) return Unit.Value;

                _db.Employees.Remove(Employee);
                await _db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
