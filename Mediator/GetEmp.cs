using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using EmployeeRegistrationCRUD.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRegistrationCRUD.Mediator
{
    public class GetEmpRequest : IRequest<IEnumerable<Employee>> { }



    public class GetEmpHandler : IRequestHandler<GetEmpRequest, IEnumerable<Employee>>
        {
            private readonly EmployeeContext _db;
            public GetEmpHandler(EmployeeContext db) => _db = db;

            public async Task<IEnumerable<Employee>> Handle(GetEmpRequest request, CancellationToken cancellationToken)
            {
                return await _db.Employees.ToListAsync(cancellationToken);
            }
        }
    }

