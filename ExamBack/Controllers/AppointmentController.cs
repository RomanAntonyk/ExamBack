using ExamBack.DTO;
using ExamBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private DataContext _dataContext;

        public AppointmentController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> Get()
        {
            var appointments = await _dataContext.Appointments.Include(a=>a.Patient).ToListAsync();
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Create(AppointmentDTO appointmentDTO)
        {
            var patient = await _dataContext.Patients.FindAsync(appointmentDTO.PatientId);
            if(patient == null)
            {
                return BadRequest("Patient with id not found");
            }
            var appointment = new Appointment { Date = appointmentDTO.Date, Patient = patient };
            _dataContext.Appointments.Add(appointment);
            await _dataContext.SaveChangesAsync();
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> Delete(int id)
        {
            var appointment = _dataContext.Appointments.Find(id);
            if (appointment == null) {
                return BadRequest("Appointment not found");

            }
            _dataContext.Appointments.Remove(appointment);
            await _dataContext.SaveChangesAsync();
            return Ok(appointment);
        }
    }
}
