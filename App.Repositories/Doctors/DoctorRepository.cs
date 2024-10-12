using App.Models.Models;
using App.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Doctors
{
    public class DoctorRepository : GenericRepository<Doctor, int>, IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context) : base(context)
        {
            _context = context;            
        }

        public Task<List<Doctor>> GetAllWithAppointmentsAsync()
        {
            return _context.Doctors.Include(x => x.Appointments)!.ThenInclude(a => a.Patient).ToListAsync();
        }

        public Task<Doctor?> GetByIdWithAppointmentsAsync(int id)
        {
            return _context.Doctors.Include(x => x.Appointments)!.ThenInclude(a => a.Patient).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
