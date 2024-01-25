using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class PlaceholderContext : DbContext
    {
        public PlaceholderContext(DbContextOptions<PlaceholderContext> options) : base(options)
        {
        }

        public DbSet<Placeholder> Placeholder { get; set; }
    }
}
