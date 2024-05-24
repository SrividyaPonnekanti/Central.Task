using Central.Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Central.Task.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegistrationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration([FromBody] Registrations registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newRegistration = new Registrations
                {
                    FirstName = registration.FirstName,
                    LastName = registration.LastName,
                    Email = registration.Email,
                    Company = registration.Company,
                    Title = registration.Title,
                    Questions = registration.Questions,
                    WebinarTopic = registration.WebinarTopic

                };

                _context.Registrations.Add(newRegistration);
                await _context.SaveChangesAsync();


                // return CreatedAtAction(nameof(CreateRegistration), new { id = newRegistration.Id }, newRegistration);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error when saving: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }

            return Ok(new { message = "Registration successful" });
        }


    }

}
