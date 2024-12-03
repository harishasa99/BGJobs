using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Projekat2.Models;
using Projekat2.Services;

namespace Projekat2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OsobeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly CleanInactiveUsersService _cleanupService;

        public OsobeController(AppDbContext context, CleanInactiveUsersService cleanupService)
        {
            _context = context;
            _cleanupService = cleanupService;
        }

        [HttpGet]
        public IActionResult GetOsobe()
        {
            var osobe = _context.Osobe.ToList();
            return Ok(osobe);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOsoba([FromBody] Osoba osoba)
        {
            if (osoba == null)
            {
                return BadRequest("Podaci o osobi nisu validni");
            }

            _context.Osobe.Add(osoba);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOsobe), new { id = osoba.Id }, osoba);
        }


        // POST: /osobe/cleanup
        [HttpPost("cleanup")]
        public async Task<IActionResult> CleanupInactiveUsers()
        {
            await _cleanupService.CleanInactiveUsers();
            return Ok("Posao čišćenja korisnika pokrenut");
        }

    }
}
