using EquipmentMonitor.Models;
using System.ComponentModel.DataAnnotations;

namespace EquipmentMonitor.Tests
{
    public class EquipmentModelTests
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
    }
}