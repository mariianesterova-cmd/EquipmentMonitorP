using EquipmentMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EquipmentMonitor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Додаємо початкові тестові дані (Seed Data) для показу
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "ПК лабораторний Dell", InventoryNumber = "INV-001", Location = "Ауд. 302", Status = EquipmentStatus.Working, PurchaseDate = DateTime.Now.AddYears(-1) },
                new Equipment { Id = 2, Name = "Мікроскоп оптичний", InventoryNumber = "INV-002", Location = "Лаб. 104", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = DateTime.Now.AddYears(-2) },
                new Equipment { Id = 3, Name = "3D-принтер Creality", InventoryNumber = "INV-003", Location = "Ауд. 305", Status = EquipmentStatus.Broken, PurchaseDate = DateTime.Now.AddMonths(-6) }
            );
        }
    }
}