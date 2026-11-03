using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EquipmentMonitor.Controllers;
using EquipmentMonitor.Data;
using EquipmentMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EquipmentMonitor.Tests
{
    public class EquipmentTests
    {
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

        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Унікальна БД для кожного тесту
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task Index_Returns_Filtered_Equipment_By_Search_String()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            context.Equipments.AddRange(
                new Equipment { Name = "Oscilloscope Tektronix", InventoryNumber = "INV-01", Location = "Lab 1", Status = EquipmentStatus.Working },
                new Equipment { Name = "Multimeter Fluke", InventoryNumber = "INV-02", Location = "Lab 2", Status = EquipmentStatus.Working }
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

        [Fact]
        public async Task Index_Returns_Empty_List_When_Search_Item_Not_Found()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            context.Equipments.Add(new Equipment { Name = "Printer", InventoryNumber = "PR-01", Location = "Office", Status = EquipmentStatus.Working });
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