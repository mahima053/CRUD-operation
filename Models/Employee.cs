using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_RegistrationCRUD.Models
{
    public class Employee
    {
        
    
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int ContactNumber { get; set; }
        public string City { get; set; }
        public string   State { get; set; }
    }
}
