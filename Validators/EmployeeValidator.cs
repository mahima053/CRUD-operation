using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_RegistrationCRUD.Models;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Employee_RegistrationCRUD.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            _ = RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("{PropertyName} should be not empty. NEVER!")
                .Length(2, 25)
                .Must(IsValidName).WithMessage("{PropertyName} should be all letters.");

            RuleFor(x => x.Age).InclusiveBetween(18, 60);
            RuleFor(X => X.Id).NotNull();
            

        }
        private bool IsValidName(string First_Name)
        {
            return First_Name.All(Char.IsLetter);
        }


    }
}
