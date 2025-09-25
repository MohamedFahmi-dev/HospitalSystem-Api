using FluentValidation;
using Hospital.core.Features.MedicalRecord.Command.Model;

namespace Hospital.core.Features.MedicalRecord.Command.Validator
{
    public class UpdateMedicalRecordValidator : AbstractValidator<UpdateMedicalRecordCommand>
    {
        public UpdateMedicalRecordValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Medical record ID is required")
                .GreaterThan(0).WithMessage("Invalid medical record ID");

            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("Patient ID is required")
                .GreaterThan(0).WithMessage("Invalid patient ID");

            RuleFor(x => x.VisitDate)
                .NotEmpty().WithMessage("Visit date is required")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Visit date cannot be in the future");

            RuleFor(x => x.Diagnosis)
                .NotEmpty().WithMessage("Diagnosis is required")
                .MaximumLength(500).WithMessage("Diagnosis cannot exceed 500 characters")
                .MinimumLength(3).WithMessage("Diagnosis must be at least 3 characters");

            RuleFor(x => x.Prescription)
                .NotEmpty().WithMessage("Prescription is required")
                .MaximumLength(1000).WithMessage("Prescription cannot exceed 1000 characters")
                .MinimumLength(3).WithMessage("Prescription must be at least 3 characters");

            RuleFor(x => x.Notes)
                .MaximumLength(2000).WithMessage("Notes cannot exceed 2000 characters")
                .When(x => !string.IsNullOrEmpty(x.Notes));
        }
    }
}
