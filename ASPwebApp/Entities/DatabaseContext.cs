﻿using Microsoft.EntityFrameworkCore;

namespace ASPwebApp.Entities
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }    

        public DbSet<Makeapm> Makeapms { get; set; }


    }
    
}
