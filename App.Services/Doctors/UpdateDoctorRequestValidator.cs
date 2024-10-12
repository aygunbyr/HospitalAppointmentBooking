using App.Models.Dtos.Doctors;
using App.Repositories.Doctors;
using FluentValidation;

namespace App.Services.Doctors
{
    public class UpdateDoctorRequestValidator : AbstractValidator<UpdateDoctorRequest>
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorRequestValidator(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Doctor's name cannot be empty.")
                .Length(2, 30).WithMessage("Doctor's name must be at least 2 and at most 30 characters.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Doctor's branch name cannot be empty.");
        }
    }
}
