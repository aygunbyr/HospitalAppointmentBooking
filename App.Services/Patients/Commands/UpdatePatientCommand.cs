using App.Models.Models;
using App.Repositories.Patients;

namespace App.Services.Patients.Commands
{
    public class UpdatePatientCommand : ICommand
    {
        private readonly Patient _patient;
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientCommand(Patient patient, IPatientRepository patientRepository)
        {
            _patient = patient;
            _patientRepository = patientRepository;
        }

        public Task ExecuteAsync()
        {
            _patientRepository.Update(_patient);
            return Task.CompletedTask;
        }
    }
}
