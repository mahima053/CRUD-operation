using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;

namespace EmployeeRegistrationCRUD.Password
{
    public class GetUserRequest : IRequest<IEnumerable<PasswordModel>> { }

    public class GetUserHandler : IRequestHandler<GetUserRequest, IEnumerable<PasswordModel>>
    {
        private readonly IUserRepo userRepo;
        public GetUserHandler(IUserRepo userRepository)
        {
            userRepo = userRepository;
        }

        public async Task<IEnumerable<PasswordModel>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            return await userRepo.GetUser();

    }
}
}
