using FluentValidation;
using Hospital.core.Features.Appointment.Command.Model;

namespace Hospital.core.Features.Appointment.Command.validator
{
    public class UpdateAppointmentValidation : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentValidation()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Appointment ID is required")
           .GreaterThan(0).WithMessage("Invalid appointment ID");

            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("Patient ID is required")
                .GreaterThan(0).WithMessage("Invalid patient ID");

            RuleFor(x => x.DoctorId)
                .NotEmpty().WithMessage("Doctor ID is required")
                .GreaterThan(0).WithMessage("Invalid doctor ID");

            RuleFor(x => x.AppointmentDate)
                .NotEmpty().WithMessage("Appointment date is required")
                .GreaterThan(DateTime.Now).WithMessage("Appointment must be scheduled for future date");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid appointment status");

            RuleFor(x => x.Reason)
                .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters")
                .When(x => !string.IsNullOrEmpty(x.Reason));
        }
    }
}
