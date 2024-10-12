using App.Models.Dtos.Appointments;
using App.Services.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : CustomControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentsService)
        {
            _appointmentService = appointmentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithDetails()
        {
            return CreateActionResult(await _appointmentService.GetAllWithDetailsAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdWithDetails(Guid id)
        {
            return CreateActionResult(await _appointmentService.GetByIdWithDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentRequest request)
        {
            return CreateActionResult(await _appointmentService.CreateAsync(request));
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAppointmentRequest request)
        {
            return CreateActionResult(await _appointmentService.UpdateAsync(id, request));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CreateActionResult(await _appointmentService.DeleteAsync(id));
        }
    }
}
