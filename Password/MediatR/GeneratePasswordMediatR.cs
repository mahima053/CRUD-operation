using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;

namespace EmployeeRegistrationCRUD.Password
{
    public class GeneratePasswordMediatR : PasswordModel, IRequest<Guid>
    {

    }

    public class GeneratePasswordHandler : IRequestHandler<GeneratePasswordMediatR, Guid>
    {

        private readonly IUserRepo userRepo;
        public GeneratePasswordHandler(IUserRepo userRepository)
        {
            userRepo = userRepository;    }
        public async Task<Guid> Handle(GeneratePasswordMediatR request, CancellationToken cancellationToken)
        {
            var user = new PasswordModel
            {
                Email = request.Email,
                Password = request.Password,
                User_Id = request.User_Id,
                Expiry_Date = DateTime.UtcNow.AddHours(24),
           //   Expiry_Date = Convert.ToDateTime(DateTimeOffset.Now.AddDays(1)),
                Created_On = DateTime.Now,
                Updated_On = DateTime.Now

            };

            await userRepo.CreateUserPassword(user);
            return user.Id;

                }
    }
}
