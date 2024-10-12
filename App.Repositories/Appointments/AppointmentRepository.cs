using App.Models.Models;
using App.Repositories.Shared;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories.Appointments
{
    public class AppointmentRepository : GenericRepository<Appointment, Guid>, IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<Appointment?> GetByIdWithDetailsAsync(Guid id)
        {
            return _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient).FirstOrDefaultAsync(x=>x.Id == id);
        }

        public Task<List<Appointment>> GetAllWithDetailsAsync()
        {
            return _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
        }
    }
}
