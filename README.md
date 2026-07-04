📦 Sistema de Inventario Web
Sistema de gestión de inventarios multi-almacén con soporte para consignaciones, desarrollado con ASP.NET Core MVC (.NET 8), siguiendo los principios de Clean Architecture.

📋 Características Principales
📦 Gestión de Productos
CRUD completo de productos con categorías y unidades de medida

Doble precio de venta: Minorista (obligatorio) y Mayorista (opcional)

Precio de costo opcional

Cálculo automático de márgenes de ganancia para ambos precios

Historial completo de cambios de precios con registro de variaciones

Alertas visuales de stock bajo con indicadores de color

📏 Unidades de Medida
Nomenclador gestionable de unidades (Unidad, Kg, Litro, Metro, Caja, Docena, etc.)

CRUD completo con abreviatura personalizable

Asignación de unidad a cada producto

Visualización de unidad en listados y reportes

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

🤝 Consignaciones
Entrega de productos a vendedores o mercados externos

Control de productos entregados, vendidos y devueltos

Registro de ventas por producto con precios unitarios

Registro de devoluciones con reintegro automático al almacén

Generación automática de movimientos de almacén (salida al consignar, entrada al devolver)

Estados: Pendiente, Parcial, Completada

Trazabilidad completa de cada producto consignado

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

Admin: Acceso total, gestión de usuarios, eliminación de registros

Gerente: Gestión de productos, precios, almacenes, consignaciones, reportes

Operador: Registro de movimientos y consignaciones

Consulta: Acceso de solo lectura

Constantes de roles para evitar strings repetidos

Políticas de autorización centralizadas

Activación y desactivación de usuarios

Cambio de contraseñas por administrador

🚚 Gestión de Proveedores
CRUD completo de proveedores

Validación de RUC único

Búsqueda por nombre, RUC o email

🏗️ Arquitectura del Proyecto
text
InventarioWeb/
├── 📁 InventarioWeb.Core/              # Capa de Dominio
│   ├── Constants/
│   │   ├── Roles.cs                    # Constantes de roles
│   │   └── Policies.cs                 # Constantes de políticas
│   ├── Entities/
│   │   ├── Producto.cs                 # PrecioMinorista, PrecioMayorista, UnidadMedida
│   │   ├── Categoria.cs
│   │   ├── UnidadMedida.cs             # Unidades de medida gestionables
│   │   ├── Almacen.cs
│   │   ├── StockAlmacen.cs
│   │   ├── Movimiento.cs
│   │   ├── MovimientoDetalle.cs
│   │   ├── Consignacion.cs
│   │   ├── ConsignacionDetalle.cs
│   │   ├── HistorialPrecio.cs
│   │   ├── Proveedor.cs
│   │   ├── ApplicationUser.cs
│   │   └── ApplicationRole.cs
│   ├── DTOs/
│   │   ├── ProductoDto.cs
│   │   ├── CambioPrecioDto.cs
│   │   ├── UnidadMedidaDto.cs
│   │   ├── AlmacenDto.cs
│   │   ├── StockAlmacenDto.cs
│   │   ├── MovimientoDto.cs
│   │   ├── ConsignacionDto.cs
│   │   ├── ProveedorDto.cs
│   │   └── AuthDto.cs
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── IProductoRepository.cs
│   │   ├── ICategoriaRepository.cs
│   │   ├── IUnidadMedidaRepository.cs
│   │   ├── IAlmacenRepository.cs
│   │   ├── IStockAlmacenRepository.cs
│   │   ├── IMovimientoRepository.cs
│   │   ├── IConsignacionRepository.cs
│   │   ├── IConsignacionDetalleRepository.cs
│   │   ├── IProveedorRepository.cs
│   │   ├── IHistorialPrecioRepository.cs
│   │   └── IUnitOfWork.cs
│   └── Mappings/
│       ├── ProductoMapping.cs
│       ├── CategoriaMapping.cs
│       ├── UnidadMedidaMapping.cs
│       ├── AlmacenMapping.cs
│       ├── StockAlmacenMapping.cs
│       ├── MovimientoMapping.cs
│       ├── ConsignacionMapping.cs
│       ├── HistorialPrecioMapping.cs
│       └── ProveedorMapping.cs
│
├── 📁 InventarioWeb.Infrastructure/    # Capa de Infraestructura
│   ├── Data/
│   │   ├── AppDbContext.cs
│   │   └── UnitOfWork.cs
│   ├── Repositories/
│   │   ├── Repository.cs
│   │   ├── ProductoRepository.cs
│   │   ├── CategoriaRepository.cs
│   │   ├── UnidadMedidaRepository.cs
│   │   ├── AlmacenRepository.cs
│   │   ├── StockAlmacenRepository.cs
│   │   ├── MovimientoRepository.cs
│   │   ├── ConsignacionRepository.cs
│   │   ├── ConsignacionDetalleRepository.cs
│   │   ├── ProveedorRepository.cs
│   │   └── HistorialPrecioRepository.cs
│   └── Services/
│       ├── AuthService.cs
│       ├── IdentitySeedService.cs
│       └── ReportService.cs
│
└── 📁 InventarioWeb.Web/              # Capa de Presentación
    ├── Controllers/
    │   ├── HomeController.cs
    │   ├── AccountController.cs
    │   ├── AdminController.cs
    │   ├── ProductosController.cs
    │   ├── CategoriasController.cs
    │   ├── UnidadesMedidaController.cs
    │   ├── AlmacenesController.cs
    │   ├── MovimientosController.cs
    │   ├── ConsignacionesController.cs
    │   ├── ProveedoresController.cs
    │   ├── ReportesController.cs
    │   └── GraficosController.cs
    ├── Views/
    │   ├── Home/
    │   ├── Account/
    │   ├── Admin/
    │   ├── Productos/
    │   ├── Categorias/
    │   ├── UnidadesMedida/
    │   ├── Almacenes/
    │   ├── Movimientos/
    │   ├── Consignaciones/
    │   ├── Proveedores/
    │   ├── Reportes/
    │   ├── Graficos/
    │   └── Shared/
    └── wwwroot/
🛠️ Tecnologías Utilizadas
Tecnología	Uso
.NET 8.0	Framework principal
ASP.NET Core MVC 8.0	Aplicación web
Entity Framework Core 8.0	ORM
ASP.NET Core Identity 8.0	Autenticación y roles
SQLite	Base de datos (archivo único, sin servidor)
Bootstrap 5.3	Framework CSS responsivo
Bootstrap Icons 1.11	Iconografía
Chart.js 4.4	Gráficos estadísticos dinámicos
ClosedXML	Generación de reportes Excel
QuestPDF	Generación de reportes PDF
BCrypt.Net	Hash seguro de contraseñas
📋 Requisitos Previos
.NET 8 SDK

Visual Studio 2022 o VS Code

Nota: No necesitas instalar ningún servidor de base de datos. SQLite se almacena en un archivo local.

⚡ Instalación Rápida
1. Clonar el repositorio
bash
git clone https://github.com/tu-usuario/sistema-inventario-web.git
cd sistema-inventario-web
2. Ejecutar la aplicación
bash
cd InventarioWeb.Web
dotnet run
La base de datos SQLite se crea automáticamente con datos de prueba.

3. Acceder al sistema
text
http://localhost:5000
👥 Usuarios de Prueba
Rol	Email	Contraseña	Permisos
Admin	admin@inventario.com	Admin123!	Acceso total, gestión de usuarios
Gerente	gerente@inventario.com	Gerente123!	Gestión de productos, precios, almacenes, consignaciones
Operador	operador@inventario.com	Operador123!	Registro de movimientos y consignaciones
Consulta	consulta@inventario.com	Consulta123!	Solo lectura
💰 Lógica de Precios
Estructura de Precios
Cada producto maneja:

PrecioCosto (opcional): Costo de compra/fabricación

PrecioVentaMinorista (obligatorio): Precio de venta al por menor

PrecioVentaMayorista (opcional): Precio de venta al por mayor

Márgenes de Ganancia
Margen Minorista: ((PrecioMinorista - Costo) / Costo) × 100

Margen Mayorista: ((PrecioMayorista - Costo) / Costo) × 100

Colores: Verde ≥ 30%, Amarillo 15-29%, Rojo < 15%, Gris sin costo

Historial de Cambios
Registro automático de cada modificación de precios

Almacena: precios anteriores, nuevos, variación, motivo, fecha y usuario

🤝 Flujo de Consignaciones
Crear consignación: Seleccionar almacén, ingresar vendedor, agregar productos

Sistema genera salida automática del almacén

Registrar ventas: Producto por producto, cantidad vendida

Registrar devoluciones: Producto por producto, cantidad devuelta

Sistema genera entrada automática al almacén

Estados: Pendiente → Parcial → Completada

📊 Permisos por Rol
Módulo	Consulta	Operador	Gerente	Admin
Dashboard	✅	✅	✅	✅
Productos (ver)	✅	✅	✅	✅
Productos (crear/editar)	❌	❌	✅	✅
Productos (eliminar)	❌	❌	❌	✅
Cambiar precios	❌	❌	✅	✅
Movimientos (ver)	✅	✅	✅	✅
Movimientos (crear)	❌	✅	✅	✅
Traslados	❌	❌	✅	✅
Consignaciones (ver)	✅	✅	✅	✅
Consignaciones (gestionar)	❌	✅	✅	✅
Almacenes (ver)	✅	✅	✅	✅
Almacenes (gestionar)	❌	❌	✅	✅
Proveedores (ver)	✅	✅	✅	✅
Proveedores (gestionar)	❌	❌	✅	✅
Categorías/Unidades (gestionar)	❌	❌	✅	✅
Reportes/Gráficos	✅	✅	✅	✅
Usuarios	❌	❌	❌	✅
📦 Publicación
bash
dotnet publish -c Release -o ./publicado
cd publicado
dotnet InventarioWeb.Web.dll
📄 Licencia
MIT

📧 Contacto
Project Link: https://github.com/miguelcavada/sistema-inventario-web
