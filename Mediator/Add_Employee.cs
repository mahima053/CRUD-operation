using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Employee_RegistrationCRUD.Models;
using MediatR;

namespace Employee_RegistrationCRUD.Mediator
{
    public class Add_Employee
    {
        public class Command : IRequest<Guid>
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
        public class CommandHandler : IRequestHandler<Command, Guid>
        {
            private readonly EmployeeContext _db;
            public CommandHandler(EmployeeContext db) => _db = db;

            public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Age = request.Age,
                    City = request.City,
                    ContactNumber = request.ContactNumber,
                    Gender = request.Gender,
                    State = request.State
                };

                await _db.Employees.AddAsync(entity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }

    }
}
