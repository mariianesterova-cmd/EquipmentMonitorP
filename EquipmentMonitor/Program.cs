using EquipmentMonitor.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси MVC
builder.Services.AddControllersWithViews();

// Налаштування SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Автоматичне створення бази даних при запуску
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>(); // Замініть YourDbContextName на реальну назву вашого контексту бази даних (наприклад, ApplicationDbContext)
    context.Database.EnsureCreated(); // або context.Database.Migrate();
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