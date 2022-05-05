using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy  { get; set; }

        public  DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
