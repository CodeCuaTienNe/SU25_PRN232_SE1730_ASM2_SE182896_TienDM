using Microsoft.AspNetCore.Mvc;
using DNATestingSystem.Services.TienDM;
using DNATestingSystem.Repository.TienDM.Models;

namespace DNATestingSystem.GraphQLAPIServices.TienDM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsTienDmController : ControllerBase
    {
        private readonly IServiceProviders _serviceProviders;

        public AppointmentsTienDmController(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        /// <summary>
        /// Example REST endpoint using ServiceProviders
        /// GET api/example/users
        /// </summary>
        [HttpGet("users")]
        public async Task<ActionResult<List<SystemUserAccount>>> GetUsers()
        {
            try
            {
                var users = await _serviceProviders.SystemUserAccountService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Example REST endpoint for appointments
        /// GET api/example/appointments
        /// </summary>
        [HttpGet("appointments")]
        public async Task<ActionResult<List<AppointmentsTienDm>>> GetAppointments()
        {
            try
            {
                var appointments = await _serviceProviders.AppointmentsTienDmService.GetAllAsync();
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Example REST endpoint for services
        /// GET api/example/services
        /// </summary>
        [HttpGet("services")]
        public async Task<ActionResult<List<ServicesNhanVt>>> GetServices()
        {
            try
            {
                var services = await _serviceProviders.ServicesNhanVtService.GetAllAsync();
                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Get appointment by ID
        /// GET api/AppointmentsTienDm/{id}
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentsTienDm>> GetAppointmentById(int id)
        {
            try
            {
                var appointment = await _serviceProviders.AppointmentsTienDmService.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Create new appointment
        /// POST api/AppointmentsTienDm
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> CreateAppointment([FromBody] AppointmentsTienDm appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest("Appointment data is required.");
                }

                appointment.CreatedDate = DateTime.Now;
                appointment.ModifiedDate = DateTime.Now;

                var result = await _serviceProviders.AppointmentsTienDmService.CreateAsync(appointment);

                if (result > 0)
                {
                    return Ok(result);
                }

                return BadRequest("Failed to create appointment.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Update existing appointment
        /// PUT api/AppointmentsTienDm
        /// </summary>
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAppointment([FromBody] AppointmentsTienDm appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest("Appointment data is required.");
                }

                appointment.ModifiedDate = DateTime.Now;

                var result = await _serviceProviders.AppointmentsTienDmService.UpdateAsync(appointment);

                if (result > 0)
                {
                    return Ok(result);
                }

                return BadRequest("Failed to update appointment.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
