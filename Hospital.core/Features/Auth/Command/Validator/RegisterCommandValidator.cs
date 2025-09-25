using FluentValidation;
using Hospital.core.Features.Auth.Command.Model;

namespace Hospital.core.Features.Auth.Command.Validator
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");

            RuleFor(x => x.Role)
                .Must(BeValidRole).WithMessage("Invalid role. Must be Admin, Doctor, Nurse, or Patient");
        }
        private bool BeValidRole(string role)
        {
            var validRoles = new[] { "Admin", "Doctor", "Nurse", "Patient" };
            return validRoles.Contains(role);
        }

    }
}
