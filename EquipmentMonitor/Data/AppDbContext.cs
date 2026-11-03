using EquipmentMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EquipmentMonitor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Початкові тестові дані (Seed Data) — 77 об'єктів обладнання
            modelBuilder.Entity<Equipment>().HasData(
                new Equipment { Id = 1, Name = "ПК лабораторний Dell", InventoryNumber = "INV-001", Location = "Ауд. 302", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 11, 3) },
                new Equipment { Id = 2, Name = "Мікроскоп оптичний", InventoryNumber = "INV-002", Location = "Лаб. 104", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2024, 11, 3) },
                new Equipment { Id = 3, Name = "3D-принтер Creality", InventoryNumber = "INV-003", Location = "Ауд. 305", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2026, 5, 3) },
                new Equipment { Id = 4, Name = "Осцилограф Rigol", InventoryNumber = "INV-004", Location = "Лаб. 102", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 2, 15) },
                new Equipment { Id = 5, Name = "Мультиметр Fluke", InventoryNumber = "INV-005", Location = "Лаб. 102", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 8, 20) },
                new Equipment { Id = 6, Name = "Проектор Epson", InventoryNumber = "INV-006", Location = "Ауд. 401", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 9, 10) },
                new Equipment { Id = 7, Name = "Сервер HP ProLiant", InventoryNumber = "INV-007", Location = "Серверна 201", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 1, 12) },
                new Equipment { Id = 8, Name = "Маршрутизатор Cisco 2901", InventoryNumber = "INV-008", Location = "Серверна 201", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2021, 5, 18) },
                new Equipment { Id = 9, Name = "Комутатор TP-Link 24-Port", InventoryNumber = "INV-009", Location = "Ауд. 302", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 11, 5) },
                new Equipment { Id = 10, Name = "Ноутбук Lenovo ThinkPad", InventoryNumber = "INV-010", Location = "Деканат", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 3, 22) },
                new Equipment { Id = 11, Name = "Паяльна станція Quick", InventoryNumber = "INV-011", Location = "Лаб. 105", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 4, 30) },
                new Equipment { Id = 12, Name = "Лабораторний БЖ Korad", InventoryNumber = "INV-012", Location = "Лаб. 105", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2023, 7, 14) },
                new Equipment { Id = 13, Name = "Генератор сигналів Siglent", InventoryNumber = "INV-013", Location = "Лаб. 102", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 1, 19) },
                new Equipment { Id = 14, Name = "Планшет Apple iPad Air", InventoryNumber = "INV-014", Location = "Ауд. 308", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 6, 1) },
                new Equipment { Id = 15, Name = "Сканер планшетний Mustek", InventoryNumber = "INV-015", Location = "Бібліотека", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2020, 10, 10) },
                new Equipment { Id = 16, Name = "БФП Canon i-SENSYS", InventoryNumber = "INV-016", Location = "Кафедра", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2023, 12, 5) },
                new Equipment { Id = 17, Name = "ДБЖ APC Smart-UPS", InventoryNumber = "INV-017", Location = "Серверна 201", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 4, 17) },
                new Equipment { Id = 18, Name = "Монітор Samsung 27\"", InventoryNumber = "INV-018", Location = "Ауд. 302", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 9, 1) },
                new Equipment { Id = 19, Name = "Веб-камера Logitech C920", InventoryNumber = "INV-019", Location = "Ауд. 401", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 3, 11) },
                new Equipment { Id = 20, Name = "Графічний планшет Wacom", InventoryNumber = "INV-020", Location = "Лаб. 208", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 2, 20) },
                new Equipment { Id = 21, Name = "ПК навчальний HP ProDesk", InventoryNumber = "INV-021", Location = "Ауд. 301", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 11, 10) },
                new Equipment { Id = 22, Name = "ПК навчальний HP ProDesk", InventoryNumber = "INV-022", Location = "Ауд. 301", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 11, 10) },
                new Equipment { Id = 23, Name = "ПК навчальний HP ProDesk", InventoryNumber = "INV-023", Location = "Ауд. 301", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2023, 11, 10) },
                new Equipment { Id = 24, Name = "ПК навчальний HP ProDesk", InventoryNumber = "INV-024", Location = "Ауд. 301", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 11, 10) },
                new Equipment { Id = 25, Name = "Спектрометр оптичний", InventoryNumber = "INV-025", Location = "Фіз. лаб. 1", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2021, 4, 12) },
                new Equipment { Id = 26, Name = "Лазерний дальномір Bosch", InventoryNumber = "INV-026", Location = "Ауд. 204", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 8, 15) },
                new Equipment { Id = 27, Name = "Плотер Roland Camm-1", InventoryNumber = "INV-027", Location = "Ауд. 305", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2019, 6, 20) },
                new Equipment { Id = 28, Name = "Тепловізор FLIR E4", InventoryNumber = "INV-028", Location = "Лаб. 102", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 1, 11) },
                new Equipment { Id = 29, Name = "Контролер Arduino Mega 2560", InventoryNumber = "INV-029", Location = "Лаб. робототехніки", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 10, 5) },
                new Equipment { Id = 30, Name = "Мікрокомп'ютер Raspberry Pi 4", InventoryNumber = "INV-030", Location = "Лаб. робототехніки", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 10, 5) },
                new Equipment { Id = 31, Name = "Набір датчиків Vernier", InventoryNumber = "INV-031", Location = "Фіз. лаб. 2", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2022, 3, 14) },
                new Equipment { Id = 32, Name = "Світловий мікроскоп Zeiss", InventoryNumber = "INV-032", Location = "Лаб. 104", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2020, 12, 1) },
                new Equipment { Id = 33, Name = "Аналізатор спектру Hantek", InventoryNumber = "INV-033", Location = "Лаб. 102", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 5, 18) },
                new Equipment { Id = 34, Name = "Мікрофонний масив Rode", InventoryNumber = "INV-034", Location = "Медіастудія", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 3, 10) },
                new Equipment { Id = 35, Name = "Акустична система Yamaha", InventoryNumber = "INV-035", Location = "Актовий зал", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2021, 9, 1) },
                new Equipment { Id = 36, Name = "Інтерактивна дошка SMART", InventoryNumber = "INV-036", Location = "Ауд. 210", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2018, 11, 20) },
                new Equipment { Id = 37, Name = "VR-шолом Meta Quest 2", InventoryNumber = "INV-037", Location = "Лаб. 208", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 2, 28) },
                new Equipment { Id = 38, Name = "VR-шолом Meta Quest 2", InventoryNumber = "INV-038", Location = "Лаб. 208", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 2, 28) },
                new Equipment { Id = 39, Name = "Мережеве сховище Synology NAS", InventoryNumber = "INV-039", Location = "Серверна 201", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 6, 14) },
                new Equipment { Id = 40, Name = "Сенсорний термінал POS", InventoryNumber = "INV-040", Location = "Їдальня", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 1, 25) },
                new Equipment { Id = 41, Name = "ПК навчальний Lenovo Legion", InventoryNumber = "INV-041", Location = "Лаб. 208", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 4, 15) },
                new Equipment { Id = 42, Name = "ПК навчальний Lenovo Legion", InventoryNumber = "INV-042", Location = "Лаб. 208", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 4, 15) },
                new Equipment { Id = 43, Name = "ПК навчальний Lenovo Legion", InventoryNumber = "INV-043", Location = "Лаб. 208", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2024, 4, 15) },
                new Equipment { Id = 44, Name = "ПК навчальний Lenovo Legion", InventoryNumber = "INV-044", Location = "Лаб. 208", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 4, 15) },
                new Equipment { Id = 45, Name = "3D-сканер Shining 3D", InventoryNumber = "INV-045", Location = "Ауд. 305", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 5, 12) },
                new Equipment { Id = 46, Name = "Лазерний гравер Atomstack", InventoryNumber = "INV-046", Location = "Майстерня 101", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2023, 9, 30) },
                new Equipment { Id = 47, Name = "Токарний верстат з ЧПК", InventoryNumber = "INV-047", Location = "Майстерня 101", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2021, 2, 18) },
                new Equipment { Id = 48, Name = "Фрезерний верстат CNC 3018", InventoryNumber = "INV-048", Location = "Майстерня 101", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 10, 04) },
                new Equipment { Id = 49, Name = "Роботизована рука Dobot", InventoryNumber = "INV-049", Location = "Лаб. робототехніки", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 12, 01) },
                new Equipment { Id = 50, Name = "Квадрокоптер DJI Mavic 3", InventoryNumber = "INV-050", Location = "Лаб. робототехніки", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 1, 20) },
                new Equipment { Id = 51, Name = "Принтер етикеток Zebra", InventoryNumber = "INV-051", Location = "Склад", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 8, 14) },
                new Equipment { Id = 52, Name = "Сканер штрих-кодів Datalogic", InventoryNumber = "INV-052", Location = "Склад", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 8, 14) },
                new Equipment { Id = 53, Name = "ТЕРМОПРИНТЕР Xprinter", InventoryNumber = "INV-053", Location = "Бібліотека", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 11, 22) },
                new Equipment { Id = 54, Name = "Сервер Dell PowerEdge", InventoryNumber = "INV-054", Location = "Серверна 201", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 07, 19) },
                new Equipment { Id = 55, Name = "Міжмережевий екран Fortinet", InventoryNumber = "INV-055", Location = "Серверна 201", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 08, 05) },
                new Equipment { Id = 56, Name = "Оптичний рефлектометр", InventoryNumber = "INV-056", Location = "Мережева лаб.", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2023, 03, 17) },
                new Equipment { Id = 57, Name = "Зварювальний апарат ВОЛЗ", InventoryNumber = "INV-057", Location = "Мережева лаб.", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 03, 17) },
                new Equipment { Id = 58, Name = "ПК викладача Asus ROG", InventoryNumber = "INV-058", Location = "Кафедра", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 02, 11) },
                new Equipment { Id = 59, Name = "Монітор LG UltraWide 34\"", InventoryNumber = "INV-059", Location = "Кафедра", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 02, 11) },
                new Equipment { Id = 60, Name = "Проектор BenQ 4K", InventoryNumber = "INV-060", Location = "Акт. зал", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 09, 25) },
                new Equipment { Id = 61, Name = "Мікшерний пульт Soundcraft", InventoryNumber = "INV-061", Location = "Акт. зал", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2021, 11, 14) },
                new Equipment { Id = 62, Name = "Радіомікрофон Shure BLX", InventoryNumber = "INV-062", Location = "Акт. зал", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2022, 05, 09) },
                new Equipment { Id = 63, Name = "Радіомікрофон Shure BLX", InventoryNumber = "INV-063", Location = "Акт. зал", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 05, 09) },
                new Equipment { Id = 64, Name = "Відеокалун Blackmagic Studio", InventoryNumber = "INV-064", Location = "Медіастудія", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 10, 30) },
                new Equipment { Id = 65, Name = "Освітлювальний комплект Godox", InventoryNumber = "INV-065", Location = "Медіастудія", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 10, 30) },
                new Equipment { Id = 66, Name = "Хромакей фон GreenBean", InventoryNumber = "INV-066", Location = "Медіастудія", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 01, 15) },
                new Equipment { Id = 67, Name = "Електронний ваттметр", InventoryNumber = "INV-067", Location = "Лаб. 105", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2022, 04, 03) },
                new Equipment { Id = 68, Name = "Частотомір Ч3-63", InventoryNumber = "INV-068", Location = "Лаб. 102", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2017, 09, 12) },
                new Equipment { Id = 69, Name = "Аналоговий осцилограф С1-65", InventoryNumber = "INV-069", Location = "Лаб. 102", Status = EquipmentStatus.Broken, PurchaseDate = new DateTime(2015, 05, 20) },
                new Equipment { Id = 70, Name = "Мікроскоп металографічний", InventoryNumber = "INV-070", Location = "Лаб. 104", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2020, 11, 01) },
                new Equipment { Id = 71, Name = "Сушильна шафа SNOL", InventoryNumber = "INV-071", Location = "Хім. лаб.", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2021, 08, 19) },
                new Equipment { Id = 72, Name = "Магнітна мішалка MSH-300", InventoryNumber = "INV-072", Location = "Хім. лаб.", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2023, 06, 07) },
                new Equipment { Id = 73, Name = "Аналітичні ваги Ohaus", InventoryNumber = "INV-073", Location = "Хім. лаб.", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 01, 28) },
                new Equipment { Id = 74, Name = "Дистилятор води ДЕ-4", InventoryNumber = "INV-074", Location = "Хім. лаб.", Status = EquipmentStatus.UnderMaintenance, PurchaseDate = new DateTime(2019, 10, 14) },
                new Equipment { Id = 75, Name = "Кліматична камера Memmert", InventoryNumber = "INV-075", Location = "НДІ Лабораторія", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 04, 02) },
                new Equipment { Id = 76, Name = "Віброметр цифровий VBR-10", InventoryNumber = "INV-076", Location = "НДІ Лабораторія", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2024, 11, 11) },
                new Equipment { Id = 77, Name = "Акустичний анемометр", InventoryNumber = "INV-077", Location = "Метеостанція", Status = EquipmentStatus.Working, PurchaseDate = new DateTime(2025, 06, 18) }
            );
        }
    }
}