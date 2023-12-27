using ASPwebApp.Models;
using HospitalAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ASPwebApp.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

     

    }
    
}
