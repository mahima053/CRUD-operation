using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Password;
using EmployeeRegistrationCRUD.Password.Login;
using EmployeeRegistrationCRUD.Password.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeRegistrationCRUD.Login
{
    public class UserLoginMediatRRequest : LoginModel,IRequest<Tokens>{}
    public class UserLoginHandler : IRequestHandler<UserLoginMediatRRequest, Tokens>
    {
        private readonly IUserRepo userRepo;
        private readonly IConfiguration configuration;
        public UserLoginHandler(IUserRepo userRepository,IConfiguration config)
        {
            userRepo = userRepository;
            configuration = config;
        }
        public async Task<Tokens> Handle(UserLoginMediatRRequest request, CancellationToken cancellationToken)
        {
            var result = await userRepo.Login(request);
            if (result != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
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
                return new Tokens { Token = tokenHandler.WriteToken(token) }; 

            }
            else
            {
                throw new NullReferenceException("null");
            }
        }
            
    }
}

