📦 Sistema de Inventario Web
Sistema de gestión de inventarios multi-almacén desarrollado con ASP.NET Core MVC (.NET 8), siguiendo los principios de Clean Architecture.

https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet
https://img.shields.io/badge/C%2523-239120?style=flat&logo=csharp
https://img.shields.io/badge/Bootstrap-5.3-7952B3?style=flat&logo=bootstrap
https://img.shields.io/badge/Chart.js-4.4-FF6384?style=flat&logo=chartdotjs
https://img.shields.io/badge/SQL%2520Server-2019-CC2927?style=flat&logo=microsoftsqlserver
https://img.shields.io/badge/MySQL-8.0-4479A1?style=flat&logo=mysql

📋 Características Principales
📦 Gestión de Productos
CRUD completo de productos con categorías

Precio de costo opcional y precio de venta obligatorio

Cálculo automático de márgenes de ganancia

Historial completo de cambios de precios con registro de variaciones

Alertas visuales de stock bajo con indicadores de color

🏪 Múltiples Almacenes y Mercados
Soporte para almacenes y mercados como tipos de ubicación

Stock independiente por cada ubicación

Control de stock mínimo y máximo por almacén

Ubicación física dentro del almacén (pasillo, estante)

Vista de inventario actual filtrada por almacén

↔️ Movimientos de Inventario
Entradas: Ingreso de productos al almacén con actualización automática de stock

Salidas: Egreso de productos con validación de stock disponible

Traslados: Movimiento de productos entre almacenes con transferencia de stock

Registro detallado de cada movimiento con productos, cantidades y precios

📊 Dashboard y Gráficos Estadísticos
KPIs en tiempo real: stock normal, stock bajo, sin stock, inactivos

Gráfico de productos por categoría (Dona)

Gráfico de stock por almacén (Barras horizontal)

Gráfico de movimientos mensuales - Entradas vs Salidas (Líneas)

Gráfico de estado general del inventario (Dona)

Top 10 productos más movidos por cantidad (Barras)

Todos los gráficos generados dinámicamente con Chart.js

📋 Reportes Exportables
Excel: Catálogo de productos, movimientos por tipo y fecha, stock bajo, inventario por almacén

PDF: Catálogo de productos, comprobantes de movimiento, inventario por almacén

Filtros por tipo de movimiento, rango de fechas y almacén

Reportes con formato profesional: colores, totales, indicadores visuales

👥 Gestión de Usuarios con Roles
Autenticación segura con ASP.NET Core Identity

4 roles predefinidos con permisos específicos:

Admin: Acceso total al sistema, gestión de usuarios, eliminación de registros

Gerente: Gestión de productos, precios, almacenes, reportes

Operador: Registro de movimientos de inventario (entradas, salidas, traslados)

Consulta: Acceso de solo lectura a todo el sistema

Activación y desactivación de usuarios

Cambio de contraseñas por administrador

Protección de rutas por rol con atributos [Authorize]

🚚 Gestión de Proveedores
CRUD completo de proveedores

Validación de RUC único

Búsqueda por nombre, RUC o email

Registro de dirección, teléfono y datos de contacto

🏗️ Arquitectura del Proyecto
El proyecto sigue los principios de Clean Architecture con tres capas bien definidas:

text
InventarioWeb/
├── 📁 InventarioWeb.Core/              # Capa de Dominio
│   ├── Entities/                       # Entidades de negocio
│   │   ├── Producto.cs                 # Producto con precio costo opcional
│   │   ├── Categoria.cs                # Categoría de productos
│   │   ├── Almacen.cs                  # Almacén o Mercado
│   │   ├── StockAlmacen.cs             # Stock por producto y almacén
│   │   ├── Movimiento.cs               # Entrada, Salida o Traslado
│   │   ├── MovimientoDetalle.cs        # Detalle de cada movimiento
│   │   ├── HistorialPrecio.cs          # Registro de cambios de precio
│   │   ├── Proveedor.cs                # Proveedor de productos
│   │   ├── ApplicationUser.cs          # Usuario del sistema (Identity)
│   │   └── ApplicationRole.cs          # Rol del sistema (Identity)
│   ├── DTOs/                           # Objetos de transferencia de datos
│   │   ├── ProductoDto.cs
│   │   ├── CambioPrecioDto.cs
│   │   ├── HistorialPrecioDto.cs
│   │   ├── AlmacenDto.cs
│   │   ├── StockAlmacenDto.cs
│   │   ├── MovimientoDto.cs
│   │   ├── MovimientoDetalleDto.cs
│   │   ├── ProveedorDto.cs
│   │   └── AuthDto.cs
│   ├── Interfaces/                     # Contratos de repositorios
│   │   ├── IRepository.cs              # Repositorio genérico
│   │   ├── IProductoRepository.cs
│   │   ├── ICategoriaRepository.cs
│   │   ├── IAlmacenRepository.cs
│   │   ├── IStockAlmacenRepository.cs
│   │   ├── IMovimientoRepository.cs
│   │   ├── IProveedorRepository.cs
│   │   ├── IHistorialPrecioRepository.cs
│   │   └── IUnitOfWork.cs              # Patrón Unit of Work
│   └── Mappings/                       # Mapeos manuales Entidad ↔ DTO
│       ├── ProductoMapping.cs
│       ├── CategoriaMapping.cs
│       ├── AlmacenMapping.cs
│       ├── StockAlmacenMapping.cs
│       ├── MovimientoMapping.cs
│       ├── HistorialPrecioMapping.cs
│       └── ProveedorMapping.cs
│
├── 📁 InventarioWeb.Infrastructure/    # Capa de Infraestructura
│   ├── Data/
│   │   ├── AppDbContext.cs             # Contexto de EF Core + Identity
│   │   └── UnitOfWork.cs              # Implementación de Unit of Work
│   ├── Repositories/                   # Implementación de repositorios
│   │   ├── Repository.cs              # Repositorio genérico base
│   │   ├── ProductoRepository.cs
│   │   ├── CategoriaRepository.cs
│   │   ├── AlmacenRepository.cs
│   │   ├── StockAlmacenRepository.cs
│   │   ├── MovimientoRepository.cs
│   │   ├── ProveedorRepository.cs
│   │   └── HistorialPrecioRepository.cs
│   └── Services/                       # Servicios de infraestructura
│       ├── AuthService.cs             # Autenticación y gestión de usuarios
│       ├── IdentitySeedService.cs     # Datos semilla de usuarios y roles
│       └── ReportService.cs           # Generación de Excel (ClosedXML) y PDF (QuestPDF)
│
└── 📁 InventarioWeb.Web/              # Capa de Presentación
    ├── Controllers/
    │   ├── HomeController.cs           # Dashboard principal con KPIs
    │   ├── AccountController.cs        # Login, Logout, Registro
    │   ├── AdminController.cs          # Gestión de usuarios (solo Admin)
    │   ├── ProductosController.cs      # CRUD + Cambio de precios + Historial
    │   ├── CategoriasController.cs     # CRUD de Categorías
    │   ├── AlmacenesController.cs      # CRUD de Almacenes y Mercados
    │   ├── MovimientosController.cs    # Entradas, Salidas, Traslados
    │   ├── ProveedoresController.cs    # CRUD de Proveedores
    │   ├── ReportesController.cs       # Reportes Excel, PDF e Inventario por Almacén
    │   └── GraficosController.cs       # Datos JSON para gráficos Chart.js
    ├── Views/
    │   ├── Home/                       # Dashboard
    │   ├── Account/                    # Login, Registro, Acceso Denegado
    │   ├── Admin/                      # Gestión de usuarios
    │   ├── Productos/                  # CRUD + CambioPrecio + HistorialPrecios
    │   ├── Categorias/                 # CRUD
    │   ├── Almacenes/                  # CRUD + Details con inventario
    │   ├── Movimientos/                # Index, Create, Details
    │   ├── Proveedores/                # CRUD
    │   ├── Reportes/                   # Centro de reportes + InventarioAlmacen
    │   ├── Graficos/                   # Gráficos estadísticos
    │   └── Shared/                     # Layout, Validaciones
    └── wwwroot/                        # Archivos estáticos (CSS, JS)
🛠️ Tecnologías Utilizadas
Tecnología	Uso en el proyecto
.NET 8.0	Framework principal de desarrollo
ASP.NET Core MVC 8.0	Aplicación web con patrón MVC
Entity Framework Core 8.0	ORM para acceso a datos
ASP.NET Core Identity 8.0	Autenticación, autorización y gestión de roles
SQL Server 2019+	Base de datos principal
MySQL 8.0+	Base de datos alternativa soportada
Bootstrap 5.3	Framework CSS para interfaz responsiva
Bootstrap Icons 1.11	Iconografía del sistema
Chart.js 4.4	Gráficos estadísticos dinámicos
ClosedXML 0.102	Generación de reportes Excel
QuestPDF 2023.12	Generación de reportes PDF
BCrypt.Net 4.0	Hash seguro de contraseñas
📋 Requisitos Previos
.NET 8 SDK

SQL Server Express (recomendado) o MySQL 8.0+

Visual Studio 2022 o VS Code

⚡ Instalación Rápida
1. Clonar el repositorio
bash
git clone https://github.com/tu-usuario/sistema-inventario-web.git
cd sistema-inventario-web
2. Configurar la base de datos
Editar el archivo InventarioWeb.Web/appsettings.json:

Para SQL Server:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=InventarioDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
Para MySQL:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=InventarioDB;User=root;Password=TuContraseña;"
  }
}
3. Ejecutar la aplicación
bash
cd InventarioWeb.Web
dotnet run
La base de datos se crea automáticamente con datos de prueba al iniciar la aplicación.

4. Acceder al sistema
Abrir el navegador en: https://localhost:5001 o http://localhost:5000

👥 Usuarios de Prueba
Rol	Email	Contraseña	Permisos
Admin	admin@inventario.com	Admin123!	Acceso total, gestión de usuarios
Gerente	gerente@inventario.com	Gerente123!	Gestión de productos, precios, almacenes
Operador	operador@inventario.com	Operador123!	Registro de movimientos
Consulta	consulta@inventario.com	Consulta123!	Solo lectura
📖 Lógica de Precios
Estructura de Precios
Cada producto maneja dos precios:

PrecioCosto (decimal?, opcional): Lo que cuesta comprar/fabricar el producto. Puede ser NULL si no se conoce.

PrecioVenta (decimal, obligatorio): Precio al que se vende al cliente.

Cálculo del Margen de Ganancia
Fórmula: ((PrecioVenta - PrecioCosto) / PrecioCosto) × 100

Solo se calcula si PrecioCosto tiene valor y es mayor a 0

Indicadores de color: Verde ≥ 30%, Amarillo 15-29%, Rojo < 15%, Gris sin costo

Historial de Cambios
Cada modificación de precio queda registrada automáticamente

Se almacena: precio anterior, precio nuevo, variación, porcentaje, motivo, fecha y usuario

El historial se puede consultar desde cada producto

Valor del Inventario
Fórmula: StockTotal × PrecioCosto

Solo se calcula para productos que tienen precio de costo definido

Permisos para Cambiar Precios
Admin: Puede cambiar precios

Gerente: Puede cambiar precios

Operador: No puede cambiar precios

Consulta: No puede cambiar precios

📊 Módulo de Gráficos
El sistema incluye análisis estadístico con los siguientes gráficos generados dinámicamente:

Productos por Categoría (Gráfico de Dona) - Distribución de productos en cada categoría

Stock por Almacén (Barras Horizontal) - Unidades totales por ubicación

Movimientos Mensuales (Líneas) - Comparativa de entradas vs salidas por mes

Estado del Inventario (Dona) - Stock normal, bajo, sin stock e inactivos

Top 10 Productos Más Movidos (Barras) - Productos con mayor rotación

Los datos se obtienen desde controladores JSON y se renderizan con Chart.js.

📋 Módulo de Reportes
El Centro de Reportes permite generar:

Reportes de Productos
Excel: Catálogo completo con códigos, nombres, categorías, precios, stock total y estado

PDF: Versión imprimible del catálogo de productos

Reportes de Stock Bajo
Excel: Productos con stock por debajo del mínimo, con diferencias y estados

Reportes de Inventario por Almacén
Vista previa: Consulta en pantalla del inventario actual de un almacén específico

Excel: Exportación con código, producto, categoría, stock, mínimo, máximo, ubicación y estado

PDF: Versión imprimible con formato profesional

Reportes de Movimientos
Excel: Historial de entradas, salidas y traslados con filtros por tipo y rango de fechas

🔒 Seguridad
Autenticación con ASP.NET Core Identity usando cookies

Contraseñas hasheadas con BCrypt

Protección contra CSRF con tokens antifalsificación

Autorización por roles en controladores y acciones

Rutas protegidas con atributos [Authorize]

Soft delete (baja lógica) en todas las entidades

🧪 Pruebas
bash
# Ejecutar pruebas unitarias
dotnet test
🤝 Contribuir
Haz Fork del proyecto

Crea tu rama de funcionalidad (git checkout -b feature/NuevaFuncionalidad)

Realiza tus cambios y haz commit (git commit -m 'Agrega nueva funcionalidad')

Sube los cambios a tu fork (git push origin feature/NuevaFuncionalidad)

Abre un Pull Request

📄 Licencia
Este proyecto está bajo la Licencia MIT. Consulta el archivo LICENSE para más detalles.

✨ Créditos
Librerías utilizadas:
Bootstrap - Framework CSS responsivo

Bootstrap Icons - Biblioteca de iconos

Chart.js - Gráficos dinámicos

ClosedXML - Generación de archivos Excel

QuestPDF - Generación de documentos PDF

BCrypt.Net - Hash de contraseñas

📧 Contacto
Project Link: https://github.com/miguelcavada/InventarioWeb

🚀 Funcionalidades Futuras
API REST con JWT para consumo móvil

Notificaciones por email para stock bajo

Código de barras para productos

Auditoría completa de acciones de usuarios

Módulo de compras a proveedores

Integración con sistemas ERP externos
