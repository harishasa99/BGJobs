using Microsoft.EntityFrameworkCore;
using Projekat2.Models;

namespace Projekat2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Osoba> Osobe { get; set; } 
    }
}
