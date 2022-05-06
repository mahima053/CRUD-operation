using System.Threading.Tasks;
using EmployeeRegistrationCRUD.Models;
using Microsoft.AspNetCore.Identity;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(Login userModel);
    }
}