using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Login;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeRegistrationCRUD.Password.Repository
{
    public class UserRepo : IUserRepo
    {
        private EmployeeContext _employeeContext;

        public UserRepo(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;

        }

    public async Task<PasswordModel> CreateUserPassword(PasswordModel model)
        { 
            model.Id = Guid.NewGuid();
            await _employeeContext.passwordModels.AddAsync(model);
            await _employeeContext.SaveChangesAsync();
            return model;
        }

 

        /*   public Task<string> GenerateToken(LoginModel login)
           {
               // throw new NotImplementedException();
              var tokenHandler = new JwtSecurityTokenHandler();
               var tokenKey = Encoding.UTF8.GetBytes(_employeeContext["JWT:Key"]);
               var tokenDescriptor = new SecurityTokenDescriptor
               {
                   Subject = new ClaimsIdentity(new Claim[]
                 {
                new Claim(ClaimTypes.Email, login.Email)
                 }),
                   Expires = DateTime.UtcNow.AddMinutes(10),
                   SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
               };
               var token = tokenHandler.CreateToken(tokenDescriptor);
             //  return new Tokens { Token = tokenHandler.WriteToken(token) };

           } 


       }*/

        public async Task<List<PasswordModel>> GetUser()
        {
            return await _employeeContext.passwordModels.ToListAsync();
        }

     

        public async Task<PasswordModel> GetUser(Guid id)
        {
            var user = await _employeeContext.passwordModels.FindAsync(id);
            return user;
        }

        public async Task<PasswordModel> Login(LoginModel login)
        {
            var user = _employeeContext.passwordModels
               .Where(p => p.Email == login.Email && p.Password == login.Password)
                .SingleOrDefaultAsync();
            if (user != null)
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_employeeContext["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                  {
                new Claim(ClaimTypes.Email, login.Email)
                  }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new PasswordModel { Token = tokenHandler.WriteToken(token) };
            }
        } 

    }
    }
