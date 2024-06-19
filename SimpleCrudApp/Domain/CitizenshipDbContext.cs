using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace SimpleCrudApp.Domain
{
    public class CitizenshipDbContext: DbContext
    {

        public CitizenshipDbContext(DbContextOptions<CitizenshipDbContext> options) : base(options)
        {

        }
       public DbSet<CitizenShip> Citizenship { get; set; } 



    }
}
