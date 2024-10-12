using App.Models.Dtos.Patients;
using App.Repositories.Patients;
using FluentValidation;

namespace App.Services.Patients
{
    public class CreatePatientRequestValidator : AbstractValidator<CreatePatientRequest>
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatientRequestValidator(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Patient's full name cannot be empty.")
                .Length(2, 30).WithMessage("Patient's full name must be at least 2 and at most 30 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Patient's phone cannot be empty.");

            RuleFor(x => x.CitizenId)
                .NotEmpty().WithMessage("Citizen ID is required.");
        }
    }
}
