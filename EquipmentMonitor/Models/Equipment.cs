using System.ComponentModel.DataAnnotations;

namespace EquipmentMonitor.Models
{
    public enum EquipmentStatus
    {
        Working,        // Працює
        UnderMaintenance, // На обслуговуванні
        Broken          // Несправне
    }

    public class Equipment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Вкажіть назву обладнання")]
        [Display(Name = "Назва обладнання")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вкажіть інвентарний номер")]
        [Display(Name = "Інвентарний номер")]
        public string InventoryNumber { get; set; } = string.Empty;

        [Display(Name = "Місце розташування")]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Дата придбання")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [Display(Name = "Статус")]
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Working;
    }
}