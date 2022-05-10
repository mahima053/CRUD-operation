using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Login;

namespace EmployeeRegistrationCRUD.Password.Repository
{
    public interface IUserRepo
    {
        Task<List<PasswordModel>> GetUser();
        Task<PasswordModel> GetUser(Guid id);
        Task<PasswordModel> CreateUserPassword(PasswordModel model);
        Task<LoginModel> CreateUser(LoginModel model);
    }
}
