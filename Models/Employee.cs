using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Employee_RegistrationCRUD.Models
{
    public class Employee
    {


        public Guid Id { get; set; }

        [JsonPropertyName("First_Name")]
        public string FirstName { get; set; }

        [JsonPropertyName("Last_Name")]
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }


        [JsonPropertyName("Contact_Number")]
        public int ContactNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
