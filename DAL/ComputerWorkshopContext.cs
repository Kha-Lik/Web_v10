﻿using System;
using System.Collections.Generic;
using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ComputerWorkshopContext : IdentityDbContext<User>
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<ComputerParts> ComputerParts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public ComputerWorkshopContext(DbContextOptions<ComputerWorkshopContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
    
        }
    }
}