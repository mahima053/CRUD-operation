using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace EmployeeRegistrationCRUD.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string First_Name { get; set; }

      //  [JsonPropertyName("Last_Name")]
        public string Last_Name { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

        public int Contact_Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}
