using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;

namespace EmployeeRegistrationCRUD.Password.MediatR
{
    public class GetUserByIdRequest :  IRequest<PasswordModel> {
        public Guid Id { get; set; }
    }
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, PasswordModel>
    {
        private readonly IUserRepo userRepo;
    
        public GetUserByIdHandler(IUserRepo userRepository )
        {
            userRepo = userRepository;
        }

        public async Task<PasswordModel> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            return await userRepo.GetUser(request.Id);
        }
    }
    
}
