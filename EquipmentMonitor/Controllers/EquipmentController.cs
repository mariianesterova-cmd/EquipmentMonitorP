using EquipmentMonitor.Data;
using EquipmentMonitor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitor.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly AppDbContext _context;

        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

        // Відображення списку, фільтрації та статистики
        public async Task<IActionResult> Index(string searchString, EquipmentStatus? statusFilter)
        {
            var query = _context.Equipments.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.Name.Contains(searchString) || e.InventoryNumber.Contains(searchString));
            }

            if (statusFilter.HasValue)
            {
                query = query.Where(e => e.Status == statusFilter.Value);
            }

            // Статистика для карток зверху
            ViewBag.TotalCount = await _context.Equipments.CountAsync();
            ViewBag.WorkingCount = await _context.Equipments.CountAsync(e => e.Status == EquipmentStatus.Working);
            ViewBag.MaintenanceCount = await _context.Equipments.CountAsync(e => e.Status == EquipmentStatus.UnderMaintenance);
            ViewBag.BrokenCount = await _context.Equipments.CountAsync(e => e.Status == EquipmentStatus.Broken);

            return View(await query.ToListAsync());
        }

        // Форма створення
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }
    }
}