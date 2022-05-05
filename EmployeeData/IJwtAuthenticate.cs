using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.EmployeeData
{
    public interface IJwtAuthenticate
    {

        string Authenticate(string username, string password);
 

    }
}
