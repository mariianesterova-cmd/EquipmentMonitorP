using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EquipmentMonitor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    InventoryNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "InventoryNumber", "Location", "Name", "PurchaseDate", "Status" },
                values: new object[,]
                {
                    { 1, "INV-001", "Ауд. 302", "ПК лабораторний Dell", new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, "INV-002", "Лаб. 104", "Мікроскоп оптичний", new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "INV-003", "Ауд. 305", "3D-принтер Creality", new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, "INV-004", "Лаб. 102", "Осцилограф Rigol", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 5, "INV-005", "Лаб. 102", "Мультиметр Fluke", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 6, "INV-006", "Ауд. 401", "Проектор Epson", new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 7, "INV-007", "Серверна 201", "Сервер HP ProLiant", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 8, "INV-008", "Серверна 201", "Маршрутизатор Cisco 2901", new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "INV-009", "Ауд. 302", "Комутатор TP-Link 24-Port", new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 10, "INV-010", "Деканат", "Ноутбук Lenovo ThinkPad", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 11, "INV-011", "Лаб. 105", "Паяльна станція Quick", new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 12, "INV-012", "Лаб. 105", "Лабораторний БЖ Korad", new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, "INV-013", "Лаб. 102", "Генератор сигналів Siglent", new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 14, "INV-014", "Ауд. 308", "Планшет Apple iPad Air", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 15, "INV-015", "Бібліотека", "Сканер планшетний Mustek", new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, "INV-016", "Кафедра", "БФП Canon i-SENSYS", new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 17, "INV-017", "Серверна 201", "ДБЖ APC Smart-UPS", new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 18, "INV-018", "Ауд. 302", "Монітор Samsung 27\"", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 19, "INV-019", "Ауд. 401", "Веб-камера Logitech C920", new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 20, "INV-020", "Лаб. 208", "Графічний планшет Wacom", new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 21, "INV-021", "Ауд. 301", "ПК навчальний HP ProDesk", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 22, "INV-022", "Ауд. 301", "ПК навчальний HP ProDesk", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 23, "INV-023", "Ауд. 301", "ПК навчальний HP ProDesk", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 24, "INV-024", "Ауд. 301", "ПК навчальний HP ProDesk", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 25, "INV-025", "Фіз. лаб. 1", "Спектрометр оптичний", new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 26, "INV-026", "Ауд. 204", "Лазерний дальномір Bosch", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 27, "INV-027", "Ауд. 305", "Плотер Roland Camm-1", new DateTime(2019, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, "INV-028", "Лаб. 102", "Тепловізор FLIR E4", new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 29, "INV-029", "Лаб. робототехніки", "Контролер Arduino Mega 2560", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 30, "INV-030", "Лаб. робототехніки", "Мікрокомп'ютер Raspberry Pi 4", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 31, "INV-031", "Фіз. лаб. 2", "Набір датчиків Vernier", new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 32, "INV-032", "Лаб. 104", "Світловий мікроскоп Zeiss", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 33, "INV-033", "Лаб. 102", "Аналізатор спектру Hantek", new DateTime(2024, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 34, "INV-034", "Медіастудія", "Мікрофонний масив Rode", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 35, "INV-035", "Актовий зал", "Акустична система Yamaha", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 36, "INV-036", "Ауд. 210", "Інтерактивна дошка SMART", new DateTime(2018, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 37, "INV-037", "Лаб. 208", "VR-шолом Meta Quest 2", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 38, "INV-038", "Лаб. 208", "VR-шолом Meta Quest 2", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 39, "INV-039", "Серверна 201", "Мережеве сховище Synology NAS", new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 40, "INV-040", "Їдальня", "Сенсорний термінал POS", new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 41, "INV-041", "Лаб. 208", "ПК навчальний Lenovo Legion", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 42, "INV-042", "Лаб. 208", "ПК навчальний Lenovo Legion", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 43, "INV-043", "Лаб. 208", "ПК навчальний Lenovo Legion", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 44, "INV-044", "Лаб. 208", "ПК навчальний Lenovo Legion", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 45, "INV-045", "Ауд. 305", "3D-сканер Shining 3D", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 46, "INV-046", "Майстерня 101", "Лазерний гравер Atomstack", new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 47, "INV-047", "Майстерня 101", "Токарний верстат з ЧПК", new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 48, "INV-048", "Майстерня 101", "Фрезерний верстат CNC 3018", new DateTime(2022, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 49, "INV-049", "Лаб. робототехніки", "Роботизована рука Dobot", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 50, "INV-050", "Лаб. робототехніки", "Квадрокоптер DJI Mavic 3", new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 51, "INV-051", "Склад", "Принтер етикеток Zebra", new DateTime(2022, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 52, "INV-052", "Склад", "Сканер штрих-кодів Datalogic", new DateTime(2022, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 53, "INV-053", "Бібліотека", "ТЕРМОПРИНТЕР Xprinter", new DateTime(2023, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 54, "INV-054", "Серверна 201", "Сервер Dell PowerEdge", new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 55, "INV-055", "Серверна 201", "Міжмережевий екран Fortinet", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 56, "INV-056", "Мережева лаб.", "Оптичний рефлектометр", new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, "INV-057", "Мережева лаб.", "Зварювальний апарат ВОЛЗ", new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 58, "INV-058", "Кафедра", "ПК викладача Asus ROG", new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 59, "INV-059", "Кафедра", "Монітор LG UltraWide 34\"", new DateTime(2025, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 60, "INV-060", "Акт. зал", "Проектор BenQ 4K", new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 61, "INV-061", "Акт. зал", "Мікшерний пульт Soundcraft", new DateTime(2021, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 62, "INV-062", "Акт. зал", "Радіомікрофон Shure BLX", new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 63, "INV-063", "Акт. зал", "Радіомікрофон Shure BLX", new DateTime(2022, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 64, "INV-064", "Медіастудія", "Відеокалун Blackmagic Studio", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 65, "INV-065", "Медіастудія", "Освітлювальний комплект Godox", new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 66, "INV-066", "Медіастудія", "Хромакей фон GreenBean", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 67, "INV-067", "Лаб. 105", "Електронний ваттметр", new DateTime(2022, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 68, "INV-068", "Лаб. 102", "Частотомір Ч3-63", new DateTime(2017, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 69, "INV-069", "Лаб. 102", "Аналоговий осцилограф С1-65", new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 70, "INV-070", "Лаб. 104", "Мікроскоп металографічний", new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, "INV-071", "Хім. лаб.", "Сушильна шафа SNOL", new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 72, "INV-072", "Хім. лаб.", "Магнітна мішалка MSH-300", new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 73, "INV-073", "Хім. лаб.", "Аналітичні ваги Ohaus", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 74, "INV-074", "Хім. лаб.", "Дистилятор води ДЕ-4", new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, "INV-075", "НДІ Лабораторія", "Кліматична камера Memmert", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 76, "INV-076", "НДІ Лабораторія", "Віброметр цифровий VBR-10", new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 77, "INV-077", "Метеостанція", "Акустичний анемометр", new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipments");
        }
    }
}
