using InventarioWeb.Application.Services;
using InventarioWeb.Core.Interfaces;
using InventarioWeb.Infrastructure.Data;
using InventarioWeb.Infrastructure.Repositories;
using InventarioWeb.Infrastructure.Services;
using InventarioWeb.WinForms.Forms;
using InventarioWeb.WinForms.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace InventarioWeb.WinForms
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Configuración
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Servicios
            var services = new ServiceCollection();
            ConfigureServices(services, configuration);
            ServiceProvider = services.BuildServiceProvider();

            // Inicializar base de datos (crear si no existe)
            InitializeDatabase();

            // Iniciar con Login
            var login = ServiceProvider.GetRequiredService<FrmLogin>();
            System.Windows.Forms.Application.Run(login);
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // ===== CONFIGURACIÓN (necesario para AuthService) =====
            services.AddSingleton<IConfiguration>(configuration);

            // ===== LOGGING (necesario para Identity) =====
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
                builder.SetMinimumLevel(LogLevel.Warning);
            });

            // Base de datos SQLite
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // Servicios de negocio (reutilizados de Infrastructure)
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<IStockAlmacenRepository, StockAlmacenRepository>();
            services.AddScoped<IConsignacionService, ConsignacionService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IAlmacenService, AlmacenService>();
            services.AddScoped<IProveedorService, ProveedorService>();
            services.AddScoped<IUnidadMedidaService, UnidadMedidaService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddScoped<IIdentitySeedService, IdentitySeedService>();

            // Identity
            services.AddIdentity<InventarioWeb.Core.Entities.ApplicationUser,
                                 InventarioWeb.Core.Entities.ApplicationRole>(options =>
                                 {
                                     options.Password.RequiredLength = 6;
                                     options.Password.RequireDigit = true;
                                     options.Password.RequireLowercase = true;
                                     options.Password.RequireUppercase = true;
                                     options.Password.RequireNonAlphanumeric = false;
                                     options.User.RequireUniqueEmail = true;
                                 })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IWinFormsAuthService, WinFormsAuthService>();

            // Formularios
            services.AddTransient<FrmLogin>();
            services.AddTransient<FrmMain>();
            services.AddTransient<FrmProductos>();
            services.AddTransient<FrmProductoEdit>();
            services.AddTransient<FrmCategorias>();
            services.AddTransient<FrmCategoriaEdit>();
            services.AddTransient<FrmUnidadesMedida>();
            services.AddTransient<FrmUnidadMedidaEdit>();
            services.AddTransient<FrmAlmacenes>();
            services.AddTransient<FrmAlmacenEdit>();
            services.AddTransient<FrmAlmacenInventario>();
            services.AddTransient<FrmMovimientos>();
            services.AddTransient<FrmMovimientoEdit>();
            services.AddTransient<FrmMovimientoDetalle>();
            services.AddTransient<FrmAlmacenes>();
            services.AddTransient<FrmProveedores>();
            services.AddTransient<FrmProveedorEdit>();
            services.AddTransient<FrmConsignaciones>();
            services.AddTransient<FrmConsignacionEdit>();
            services.AddTransient<FrmConsignacionDetalle>();
            services.AddTransient<FrmCantidadDialog>();
            services.AddTransient<FrmUsuarios>();
            services.AddTransient<FrmUsuarioEdit>();
            services.AddTransient<FrmCambiarPasswordDialog>();
            services.AddTransient<FrmReportes>();
            services.AddTransient<FrmGraficos>();
            services.AddTransient<FrmCambioPrecio>();
            services.AddTransient<FrmHistorialPrecios>();
            services.AddTransient<FrmInventarioDiario>();
        }

        private static void InitializeDatabase()
        {
            using var scope = ServiceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            // Crear la base de datos si no existe
            context.Database.EnsureCreated();

            // Ejecutar seed de usuarios
            var seedService = scope.ServiceProvider.GetRequiredService<IIdentitySeedService>();
            seedService.SeedAsync().Wait();
        }
    }
}