﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Source.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Challenge> Challenges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodenationContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
