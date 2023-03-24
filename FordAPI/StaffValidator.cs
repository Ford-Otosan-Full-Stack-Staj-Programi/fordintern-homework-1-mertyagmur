using FluentValidation;
using FordInternHW1.Data.Model;

namespace FordInternHW1.Web
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator() 
        {
            RuleFor(s => s.FirstName).NotEmpty().NotNull().WithMessage("First name is required.");
            RuleFor(s => s.LastName).NotEmpty().NotNull().WithMessage("Last name is required.");
            RuleFor(s => s.Email).EmailAddress().WithMessage("Invalid Email Address.");
            RuleFor(s => s.Phone).MinimumLength(10).WithMessage("Phone number cannot be less than 10 characters.");
            RuleFor(s => s.Phone).MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");
            RuleFor(s => s.DateOfBirth).Must(IsValidDate).WithMessage("Invalid birth date.");
            RuleFor(s => s.AddressLine1).MinimumLength(10).WithMessage("Address cannot be less than 10 characters.");
            RuleFor(s => s.AddressLine1).MaximumLength(100).WithMessage("Address cannot exceed 100 characters.");
            RuleFor(s => s.City).MinimumLength(2).WithMessage("City cannot be less than 2 characters.");
            RuleFor(s => s.City).MaximumLength(100).WithMessage("City cannot exceed 100 characters.");
            RuleFor(s => s.Country).MinimumLength(2).WithMessage("Country cannot be less than 2 characters.");
            RuleFor(s => s.Country).MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");
            RuleFor(s => s.Province).MinimumLength(2).WithMessage("Province cannot be less than 2 characters.");
            RuleFor(s => s.Province).MaximumLength(100).WithMessage("Province cannot exceed 100 characters.");
        }

        private bool IsValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }
    }
}
