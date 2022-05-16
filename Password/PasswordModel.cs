using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Password
{
    public class PasswordModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid User_Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime Expiry_Date { get; set; }
        public DateTime Created_On { get; set; }
        public Guid Created_By { get; set; }

        public DateTime Updated_On { get; set; }
        public Guid Updated_By { get; set; }

        public string Token { get; set; }


    }
}
