using App.Models.Models;
using App.Repositories.Patients;

namespace App.Services.Patients.Commands
{
    public class DeletePatientCommand : ICommand
    {
        private readonly Patient _patient;
        private readonly IPatientRepository _patientRepository;

        public DeletePatientCommand(Patient patient, IPatientRepository patientRepository)
        {
            _patient = patient;
            _patientRepository = patientRepository;
        }

        public Task ExecuteAsync()
        {
            _patientRepository.Delete(_patient);
            return Task.CompletedTask;
        }
    }
}
