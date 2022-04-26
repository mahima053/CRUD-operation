using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Employee_RegistrationCRUD.Models;
using MediatR;

namespace Employee_RegistrationCRUD.Mediator
{
    public class DeleteEmployee
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly EmployeeContext _db;

            public CommandHandler(EmployeeContext db) => _db = db;
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
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
