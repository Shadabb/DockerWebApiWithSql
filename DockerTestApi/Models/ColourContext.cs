
using Microsoft.EntityFrameworkCore;

namespace DockerTestApi.Models
{
    public class ColourContext : DbContext
    {
        public ColourContext(DbContextOptions<ColourContext> options) : base(options)
        {

        }

        public DbSet<colour> Colours { get; set; }
    }
}