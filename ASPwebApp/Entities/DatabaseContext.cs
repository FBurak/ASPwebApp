using ASPwebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPwebApp.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<AnaBilimDali> AnaBilimDallari { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<CalismaSaatleri> CalismaSaatleri { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // İlişkileri belirtmek için Fluent API kullanın
            modelBuilder.Entity<Poliklinik>()
                .HasOne(p => p.AnaBilimDali)
                .WithMany(abd => abd.Poliklinikler)
                .HasForeignKey(p => p.AnaBilimDaliId);

            modelBuilder.Entity<Doktor>()
                .HasOne(d => d.Poliklinik)
                .WithMany(p => p.Doktorlar)
                .HasForeignKey(d => d.PoliklinikId);

            modelBuilder.Entity<CalismaSaatleri>()
                .HasOne(cs => cs.Doktor)
                .WithMany(d => d.CalismaSaatleri)
                .HasForeignKey(cs => cs.DoktorId);

            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Doktor)
                .WithMany(d => d.Randevular)
                .HasForeignKey(r => r.DoktorId);

            // Diğer ilişkileri ekleyin

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
