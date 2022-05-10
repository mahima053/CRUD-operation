using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;

namespace EmployeeRegistrationCRUD.Login
{
    public class UserLoginRequest : LoginModel,IRequest<Guid>{}
    public class UserLoginHandler : IRequestHandler<UserLoginRequest, Guid>
    {
        private readonly IUserRepo userRepo;
        public UserLoginHandler(IUserRepo userRepository)
        {
            userRepo = userRepository;
        }
    public async Task<Guid> Handle(UserLoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

        }
    }
}
