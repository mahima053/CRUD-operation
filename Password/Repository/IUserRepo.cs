using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Password.Repository
{
    public interface IUserRepo
    {
        Task<List<PasswordModel>> GetUser();

        Task<PasswordModel> CreateUserPassword(PasswordModel model);
    }
}
