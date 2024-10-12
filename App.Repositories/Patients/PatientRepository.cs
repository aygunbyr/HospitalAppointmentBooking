using App.Models.Models;
using App.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Patients
{
    public class PatientRepository : GenericRepository<Patient, Guid>, IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Patient>> GetAllWithAppointmentsAsync()
        {
            return _context.Patients.Include(x => x.Appointments)!.ThenInclude(a => a.Doctor).ToListAsync();
        }

        public Task<Patient?> GetByIdWithAppointmentsAsync(Guid id)
        {
            return _context.Patients.Include(x => x.Appointments)!.ThenInclude(a => a.Doctor).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
