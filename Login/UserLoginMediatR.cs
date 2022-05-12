using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;

namespace EmployeeRegistrationCRUD.Login
{
    public class UserLoginMediatRRequest : LoginModel,IRequest<Guid>{}
    public class UserLoginHandler : IRequestHandler<UserLoginMediatRRequest, Guid>
    {
        private readonly IUserRepo userRepo;
        public UserLoginHandler(IUserRepo userRepository)
        {
            userRepo = userRepository;
        }
    public async Task<Guid> Handle(UserLoginMediatRRequest request, CancellationToken cancellationToken)
        {
            var result = await userRepo.Login(request);
            if (result != null)
            {
                return result.User_Id;
            }
            else
            {
                throw new NullReferenceException("null");
            }
        }
    }
}
