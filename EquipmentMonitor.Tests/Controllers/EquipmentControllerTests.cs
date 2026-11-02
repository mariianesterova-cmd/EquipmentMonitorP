using EquipmentMonitor.Controllers;
using EquipmentMonitor.Data;
using EquipmentMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EquipmentMonitor.Tests.Controllers
{
    public class EquipmentControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task Index_ReturnsViewResult_WithListOfEquipment()
        {
            var context = GetInMemoryDbContext();
            var controller = new EquipmentController(context);

            var result = await controller.Index(null, null);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Equipment>>(viewResult.ViewData.Model);
            Assert.NotEmpty(model);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WhenIdIsNull()
        {
            var context = GetInMemoryDbContext();
            var controller = new EquipmentController(context);

            var result = await controller.Edit(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            var context = GetInMemoryDbContext();
            var controller = new EquipmentController(context);
            var newEquipment = new Equipment
            {
                Name = "Осцилограф",
                InventoryNumber = "INV-999",
                Location = "Ауд. 101",
                Status = EquipmentStatus.Working
            };

            var result = await controller.Create(newEquipment);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}