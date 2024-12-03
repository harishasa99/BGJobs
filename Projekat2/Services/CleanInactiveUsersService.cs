using Microsoft.EntityFrameworkCore;

namespace Projekat2.Services
{
    public class CleanInactiveUsersService
    {
        private readonly AppDbContext _context;

        public CleanInactiveUsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CleanInactiveUsers()
        {
            var sixMonthsAgo = DateTime.Now.AddMonths(-6);

            var inactiveUsers = _context.Osobe
                .Where(o => o.DatumVremePoslednjegLogovanja < sixMonthsAgo)
                .ToList();

            if (inactiveUsers.Any())
            {
                _context.Osobe.RemoveRange(inactiveUsers);
                await _context.SaveChangesAsync();
            }
        }
    }
}
