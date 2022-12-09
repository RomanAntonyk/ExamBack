using ExamBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private DataContext _dataContext;

        public PatientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> Get()
        {
            var patients = await _dataContext.Patients.ToListAsync();
            return Ok(patients);
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> Create(Patient patient)
        {
            _dataContext.Patients.Add(patient);
            await _dataContext.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> Delete(int id)
        {
            var patient = await _dataContext.Patients.FindAsync(id);
            if(patient == null)
            {
                return BadRequest("Patient not found");
            }
            _dataContext.Patients.Remove(patient);
            await _dataContext.SaveChangesAsync();
            return Ok(patient);
        }
    }
}
