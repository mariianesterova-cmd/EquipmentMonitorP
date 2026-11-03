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

        // GET: Equipment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            // Виправлено: Асинхронна перевірка дубліката інвентарного номера
            if (await _context.Equipments.AnyAsync(e => e.InventoryNumber == equipment.InventoryNumber))
            {
                ModelState.AddModelError("InventoryNumber", "Обладнання ц таким інвентарним номером вже існує!");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(equipment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Сталася помилка при збереженні в базу даних.");
                }
            }
            return View(equipment);
        }

        // GET: Equipment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: Equipment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Equipments.AnyAsync(e => e.Id == equipment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(equipment);
        }
    }
}
