using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistrationCRUD.Models
{
    public class Login
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy  { get; set; }

        public  DateTime UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
    }
}
