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
        public DbSet<OrderParts> OrderParts { get; set; }
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
            
            var comp1 = new Computer
            {
                Name = "Sample PC", Model = "abc-123", OwnerId = 1
            };
            var comp2 = new Computer
            {
                Name = "Sample PC", Model = "abc-124", OwnerId = 2
            };
            var ord1 = new Order
            {
                CreationDate = DateTime.Now, OwnerId = 1, RepairPrice = 9999
            };
            var ord2 = new Order
            {
                CreationDate = DateTime.Now, OwnerId = 2, RepairPrice = 999
            };
            var part1 = new Part
            {
                ManufactureDate = DateTime.Now.AddDays(-10), Name = "Sample part"
            };
            var part2 = new Part
            {
                ManufactureDate = DateTime.Now.AddDays(-9), Name = "Sample part #2"
            };
            var part3 = new Part
            {
                ManufactureDate = DateTime.Now.AddDays(-8), Name = "Sample part #3"
            };
            var owner1 = new Owner
            {
                FirstName = "Vasia", LastName = "Pupkin", SecondName = "Yaroslavovych"
            };
            var owner2 = new Owner
            {
                FirstName = "Sample", LastName = "User", SecondName = "#2"
            };
            var cp1 = new ComputerParts
            {
                PartId = 1, ComputerId = 1
            };
            var cp2 = new ComputerParts
            {
                PartId = 1, ComputerId = 2
            };
            var cp3 = new ComputerParts
            {
                PartId = 2, ComputerId = 1
            };
            var cp4 = new ComputerParts
            {
                PartId = 3, ComputerId = 2
            };
            var op1 = new OrderParts
            {
                OrderId = 1, PartId = 1
            };
            var op2 = new OrderParts
            {
                OrderId = 2, PartId = 2
            };

            modelBuilder.Entity<Computer>().HasData(comp1, comp2);
            modelBuilder.Entity<Order>().HasData(ord1, ord2);
            modelBuilder.Entity<Part>().HasData(part1, part2, part3);
            modelBuilder.Entity<Owner>().HasData(owner1, owner2);
            modelBuilder.Entity<ComputerParts>().HasData(cp1, cp2, cp3, cp4);
            modelBuilder.Entity<OrderParts>().HasData(op1, op2);
        }
    }
}