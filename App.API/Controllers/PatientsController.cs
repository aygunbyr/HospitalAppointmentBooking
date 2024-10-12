using App.Models.Dtos.Patients;
using App.Services.Patients;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : CustomControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _patientService.GetAllAsync());
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> GetAllWithAppointments()
        {
            return CreateActionResult(await _patientService.GetAllWithAppointmentsAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CreateActionResult(await _patientService.GetByIdAsync(id));
        }

        [HttpGet("{id:Guid}/appointments")]
        public async Task<IActionResult> GetByIdWithAppointments(Guid id)
        {
            return CreateActionResult(await _patientService.GetByIdWithAppointmentsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientRequest request)
        {
            return CreateActionResult(await _patientService.CreateAsync(request));
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePatientRequest request)
        {
            return CreateActionResult(await _patientService.UpdateAsync(id, request));
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CreateActionResult(await _patientService.DeleteAsync(id));
        }
    }
}
