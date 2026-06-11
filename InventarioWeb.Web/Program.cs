using InventarioWeb.Core.Entities;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using InventarioWeb.Infrastructure.Repositories;
using InventarioWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===== IDENTITY =====
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.User.RequireUniqueEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();

// Configurar cookies de autenticación
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ===== POLÍTICAS DE AUTORIZACIÓN =====
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireGerenteRole", policy => policy.RequireRole("Admin", "Gerente"));
    options.AddPolicy("RequireOperadorRole", policy => policy.RequireRole("Admin", "Gerente", "Operador"));
});

// ===== MVC =====
builder.Services.AddControllersWithViews();

// ===== BASE DE DATOS =====
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== BASE DE DATOS MYSQL =====
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MariaDbServerVersion(ServerVersion.AutoDetect(connectionString)); // Cambia según tu versión de MySQL

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion, mySqlOptions =>
    {
        mySqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        );
    })
);

// ===== SERVICIOS =====
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IIdentitySeedService, IdentitySeedService>();

var app = builder.Build();

// ===== MIDDLEWARE =====
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ===== INICIALIZAR BD Y SEED =====
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.EnsureCreatedAsync();

    var seedService = scope.ServiceProvider.GetRequiredService<IIdentitySeedService>();
    await seedService.SeedAsync();
}

app.Run();