using Microsoft.EntityFrameworkCore;

namespace ASPwebApp.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Departman> Departmans { get; set; }

    }
    
}
