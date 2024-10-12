using App.Models.Dtos.Doctors;
using App.Services.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : CustomControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _doctorService.GetAllAsync());
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllWithAppointments()
        {
            return CreateActionResult(await _doctorService.GetAllWithAppointmentsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _doctorService.GetByIdAsync(id));
        }

        [HttpGet("{id:int}/appointments")]
        public async Task<IActionResult> GetByIdWithAppointments(int id)
        {
            return CreateActionResult(await _doctorService.GetByIdWithAppointmentsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorRequest request)
        {
            return CreateActionResult(await _doctorService.CreateAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorRequest request)
        {
            return CreateActionResult(await _doctorService.UpdateAsync(id, request));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _doctorService.DeleteAsync(id));
        }
    }
}
