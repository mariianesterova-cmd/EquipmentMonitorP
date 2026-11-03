using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EquipmentMonitor.Controllers;
using EquipmentMonitor.Data; // Перевірте назву вашого DbContext
using EquipmentMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EquipmentMonitor.Tests
{
    public class EquipmentTests
    {
        // 1. ТЕСТ ВАЛІДАЦІЇ: Порожня назва (Edge Case #2)
        [Fact]
        public void Equipment_Validation_Should_Fail_When_Name_Is_Empty()
        {
            // Arrange
            var equipment = new Equipment
            {
                Name = "",
                InventoryNumber = "TEST-999",
                Location = "Lab",
                Status = EquipmentStatus.Working
            };

            var validationContext = new ValidationContext(equipment);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(equipment, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Name"));
        }

        // 2. ТЕСТ ВАЛІДАЦІЇ: Перевищення довжини назви (Edge Case #2)-
        [Fact]
        public void Equipment_Validation_Should_Fail_When_Name_Exceeds_MaxLength()
        {
            // Arrange (Граничний випадок: назва понад 500 символів)
            var equipment = new Equipment
            {
                Name = new string('A', 501),
                InventoryNumber = "TEST-001",
                Location = "Room 101",
                Status = EquipmentStatus.Working
            };

            var validationContext = new ValidationContext(equipment);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(equipment, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
        }

        // Допоміжний метод для створення БД в пам'яті (InMemory)
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        // 3. ТЕСТ КОНТРОЛЕРА: Успішний пошук через LINQ-
        [Fact]
        public async Task Index_Returns_Filtered_Equipment_By_Search_String()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            context.Equipments.AddRange(
                new Equipment { Id = 1, Name = "Oscilloscope Tektronix", InventoryNumber = "INV-01", Location = "Lab 1", Status = EquipmentStatus.Working },
                new Equipment { Id = 2, Name = "Multimeter Fluke", InventoryNumber = "INV-02", Location = "Lab 2", Status = EquipmentStatus.Working }
            );
            await context.SaveChangesAsync();

            var controller = new EquipmentController(context);

            // Act
            var result = await controller.Index("Oscilloscope", null) as ViewResult;
            var model = result?.Model as IEnumerable<Equipment>;

            // Assert
            Assert.NotNull(model);
            Assert.Single(model);
            Assert.Equal("Oscilloscope Tektronix", model.First().Name);
        }

        // 4. ТЕСТ КОНТРОЛЕРА: Неіснуючий елемент (Edge Case #4)
        [Fact]
        public async Task Index_Returns_Empty_List_When_Search_Item_Not_Found()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            context.Equipments.Add(new Equipment { Id = 1, Name = "Printer", InventoryNumber = "PR-01", Location = "Office", Status = EquipmentStatus.Working });
            await context.SaveChangesAsync();

            var controller = new EquipmentController(context);

            // Act
            var result = await controller.Index("XYZ-9999-NOTEXIST", null) as ViewResult;
            var model = result?.Model as IEnumerable<Equipment>;

            // Assert
            Assert.NotNull(model);
            Assert.Empty(model);
        }
    }
}