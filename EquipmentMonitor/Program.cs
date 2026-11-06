using EquipmentMonitor.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси MVC
builder.Services.AddControllersWithViews();

// Автоматично визначаємо безпечний шлях поза OneDrive у системній папці TEMP
var tempFolder = Path.GetTempPath();
var dbPath = Path.Combine(tempFolder, "equipment_monitor_local.db");

// Налаштування SQLite з використанням безпечного шляху
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

var app = builder.Build();

// Автоматичне створення бази даних при запуску
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Equipment}/{action=Index}/{id?}");

app.Run();
