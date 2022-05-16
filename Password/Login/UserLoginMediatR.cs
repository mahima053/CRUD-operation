using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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
             /*   var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_employeecontext["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
             new Claim(ClaimTypes.Email, result.Email)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new LoginModel { Token = tokenHandler.WriteToken(token) }; */

            }
            else
            {
                throw new NullReferenceException("null");
            }
        }

    /*    private string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", User_Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        } */

    }
}

