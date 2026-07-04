using InventarioWeb.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventarioWeb.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedCategorias(modelBuilder);
        SeedUnidadesMedida(modelBuilder);
        SeedAlmacenes(modelBuilder);
        SeedProductos(modelBuilder);
        SeedStocks(modelBuilder);
        SeedProveedores(modelBuilder);
    }

    private static void SeedCategorias(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nombre = "Electrónicos", Descripcion = "Dispositivos electrónicos y gadgets", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 2, Nombre = "Muebles", Descripcion = "Muebles de oficina y hogar", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 3, Nombre = "Suministros", Descripcion = "Suministros de oficina y papelería", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 4, Nombre = "Alimentos", Descripcion = "Productos alimenticios y bebidas", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 5, Nombre = "Limpieza", Descripcion = "Productos de limpieza e higiene", Activo = true, FechaCreacion = DateTime.Now },
            new Categoria { Id = 6, Nombre = "Ferretería", Descripcion = "Herramientas y materiales de construcción", Activo = true, FechaCreacion = DateTime.Now }
        );
    }

    private static void SeedUnidadesMedida(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UnidadMedida>().HasData(
            new UnidadMedida { Id = 1, Nombre = "Unidad", Abreviatura = "U", Descripcion = "Unidad individual", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 2, Nombre = "Kilogramo", Abreviatura = "Kg", Descripcion = "Peso en kilogramos", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 3, Nombre = "Litro", Abreviatura = "L", Descripcion = "Volumen en litros", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 4, Nombre = "Metro", Abreviatura = "m", Descripcion = "Longitud en metros", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 5, Nombre = "Caja", Abreviatura = "Cja", Descripcion = "Caja o paquete cerrado", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 6, Nombre = "Docena", Abreviatura = "Doc", Descripcion = "Conjunto de 12 unidades", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 7, Nombre = "Par", Abreviatura = "Par", Descripcion = "Conjunto de 2 unidades", Activo = true, FechaCreacion = DateTime.Now },
            new UnidadMedida { Id = 8, Nombre = "Rollo", Abreviatura = "Rol", Descripcion = "Rollo completo", Activo = true, FechaCreacion = DateTime.Now }
        );
    }

    private static void SeedAlmacenes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacen>().HasData(
            new Almacen { Id = 1, Nombre = "Almacén Central", Codigo = "ALM-CENTRAL", Tipo = "ALMACEN", Direccion = "Calle Principal #100", Encargado = "Carlos López", Telefono = "555-0101", Activo = true, FechaCreacion = DateTime.Now },
            new Almacen { Id = 2, Nombre = "Mercado Norte", Codigo = "MER-NORTE", Tipo = "MERCADO", Direccion = "Av. Norte #200", Encargado = "María García", Telefono = "555-0202", Activo = true, FechaCreacion = DateTime.Now },
            new Almacen { Id = 3, Nombre = "Mercado Sur", Codigo = "MER-SUR", Tipo = "MERCADO", Direccion = "Av. Sur #300", Encargado = "Pedro Martínez", Telefono = "555-0303", Activo = true, FechaCreacion = DateTime.Now },
            new Almacen { Id = 4, Nombre = "Mercado Este", Codigo = "MER-ESTE", Tipo = "MERCADO", Direccion = "Calle Este #400", Encargado = "Ana Rodríguez", Telefono = "555-0404", Activo = true, FechaCreacion = DateTime.Now },
            new Almacen { Id = 5, Nombre = "Almacén Secundario", Codigo = "ALM-SEC", Tipo = "ALMACEN", Direccion = "Zona Industrial #500", Encargado = "Luis Sánchez", Telefono = "555-0505", Activo = true, FechaCreacion = DateTime.Now }
        );
    }

    private static void SeedProductos(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>().HasData(
            // Electrónicos (1-5)
            new Producto { Id = 1, Codigo = "ELE-001", Nombre = "Laptop HP 15\"", Descripcion = "Laptop HP 15.6 pulgadas, 8GB RAM, 256GB SSD", PrecioCosto = 650.00m, PrecioVentaMinorista = 899.99m, PrecioVentaMayorista = 799.99m, CategoriaId = 1, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 2, Codigo = "ELE-002", Nombre = "Monitor Dell 24\"", Descripcion = "Monitor Dell 24 pulgadas Full HD", PrecioCosto = 200.00m, PrecioVentaMinorista = 349.99m, PrecioVentaMayorista = 299.99m, CategoriaId = 1, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 3, Codigo = "ELE-003", Nombre = "Teclado Inalámbrico", Descripcion = "Teclado inalámbrico Bluetooth multimedia", PrecioCosto = 25.00m, PrecioVentaMinorista = 49.99m, PrecioVentaMayorista = 39.99m, CategoriaId = 1, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 4, Codigo = "ELE-004", Nombre = "Mouse Óptico USB", Descripcion = "Mouse óptico USB ergonómico 1200dpi", PrecioCosto = 10.00m, PrecioVentaMinorista = 24.99m, PrecioVentaMayorista = 19.99m, CategoriaId = 1, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 5, Codigo = "ELE-005", Nombre = "Audífonos Bluetooth", Descripcion = "Audífonos inalámbricos con micrófono y cancelación de ruido", PrecioCosto = 35.00m, PrecioVentaMinorista = 79.99m, PrecioVentaMayorista = 59.99m, CategoriaId = 1, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },

            // Muebles (6-9)
            new Producto { Id = 6, Codigo = "MUE-001", Nombre = "Escritorio Ejecutivo", Descripcion = "Escritorio de madera 120x60cm con cajones", PrecioCosto = 250.00m, PrecioVentaMinorista = 499.99m, PrecioVentaMayorista = 399.99m, CategoriaId = 2, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 7, Codigo = "MUE-002", Nombre = "Silla de Oficina", Descripcion = "Silla ergonómica con soporte lumbar ajustable", PrecioCosto = 150.00m, PrecioVentaMinorista = 299.99m, PrecioVentaMayorista = 249.99m, CategoriaId = 2, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 8, Codigo = "MUE-003", Nombre = "Estantería Metálica", Descripcion = "Estantería 5 niveles 180x90x40cm", PrecioCosto = 100.00m, PrecioVentaMinorista = 199.99m, PrecioVentaMayorista = 159.99m, CategoriaId = 2, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 9, Codigo = "MUE-004", Nombre = "Archivador 3 Cajones", Descripcion = "Archivador metálico con llave de seguridad", PrecioCosto = 80.00m, PrecioVentaMinorista = 159.99m, PrecioVentaMayorista = 129.99m, CategoriaId = 2, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },

            // Suministros (10-14)
            new Producto { Id = 10, Codigo = "SUM-001", Nombre = "Papel Bond A4", Descripcion = "Resma de papel bond A4 500 hojas 75g", PrecioCosto = 3.50m, PrecioVentaMinorista = 7.99m, PrecioVentaMayorista = 5.99m, CategoriaId = 3, UnidadMedidaId = 5, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 11, Codigo = "SUM-002", Nombre = "Bolígrafos Azules", Descripcion = "Caja de 12 bolígrafos azules punto fino", PrecioCosto = 2.00m, PrecioVentaMinorista = 4.99m, PrecioVentaMayorista = 3.99m, CategoriaId = 3, UnidadMedidaId = 5, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 12, Codigo = "SUM-003", Nombre = "Cuaderno Universitario", Descripcion = "Cuaderno 100 hojas rayado tamaño carta", PrecioCosto = 1.50m, PrecioVentaMinorista = 3.99m, PrecioVentaMayorista = 2.99m, CategoriaId = 3, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 13, Codigo = "SUM-004", Nombre = "Tinta para Impresora", Descripcion = "Cartucho de tinta negra compatible HP", PrecioCosto = 15.00m, PrecioVentaMinorista = 34.99m, PrecioVentaMayorista = 24.99m, CategoriaId = 3, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 14, Codigo = "SUM-005", Nombre = "Cinta Adhesiva", Descripcion = "Cinta adhesiva transparente 12mm x 33m", PrecioCosto = 0.50m, PrecioVentaMinorista = 1.49m, PrecioVentaMayorista = 0.99m, CategoriaId = 3, UnidadMedidaId = 8, Activo = true, FechaCreacion = DateTime.Now },

            // Alimentos (15-18)
            new Producto { Id = 15, Codigo = "ALI-001", Nombre = "Café Molido", Descripcion = "Café molido premium 500g", PrecioCosto = 8.00m, PrecioVentaMinorista = 14.99m, PrecioVentaMayorista = 11.99m, CategoriaId = 4, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 16, Codigo = "ALI-002", Nombre = "Azúcar Blanca", Descripcion = "Azúcar blanca refinada 1Kg", PrecioCosto = 1.00m, PrecioVentaMinorista = 2.49m, PrecioVentaMayorista = 1.99m, CategoriaId = 4, UnidadMedidaId = 2, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 17, Codigo = "ALI-003", Nombre = "Agua Mineral", Descripcion = "Botella de agua mineral sin gas 500ml", PrecioCosto = 0.30m, PrecioVentaMinorista = 0.99m, PrecioVentaMayorista = 0.75m, CategoriaId = 4, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 18, Codigo = "ALI-004", Nombre = "Galletas Surtidas", Descripcion = "Paquete de galletas surtidas 400g", PrecioCosto = 2.50m, PrecioVentaMinorista = 4.99m, PrecioVentaMayorista = 3.99m, CategoriaId = 4, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },

            // Limpieza (19-22)
            new Producto { Id = 19, Codigo = "LIM-001", Nombre = "Detergente Líquido", Descripcion = "Detergente líquido multiusos 1L", PrecioCosto = 2.00m, PrecioVentaMinorista = 4.99m, PrecioVentaMayorista = 3.99m, CategoriaId = 5, UnidadMedidaId = 3, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 20, Codigo = "LIM-002", Nombre = "Cloro Concentrado", Descripcion = "Cloro concentrado 1L", PrecioCosto = 1.00m, PrecioVentaMinorista = 2.49m, PrecioVentaMayorista = 1.99m, CategoriaId = 5, UnidadMedidaId = 3, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 21, Codigo = "LIM-003", Nombre = "Papel Higiénico", Descripcion = "Paquete de 4 rollos doble hoja", PrecioCosto = 1.50m, PrecioVentaMinorista = 3.99m, PrecioVentaMayorista = 2.99m, CategoriaId = 5, UnidadMedidaId = 5, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 22, Codigo = "LIM-004", Nombre = "Jabón de Manos", Descripcion = "Jabón líquido antibacterial 500ml", PrecioCosto = 2.00m, PrecioVentaMinorista = 4.49m, PrecioVentaMayorista = 3.49m, CategoriaId = 5, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },

            // Ferretería (23-25)
            new Producto { Id = 23, Codigo = "FER-001", Nombre = "Martillo de Acero", Descripcion = "Martillo de acero forjado mango de madera", PrecioCosto = 8.00m, PrecioVentaMinorista = 15.99m, PrecioVentaMayorista = 12.99m, CategoriaId = 6, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 24, Codigo = "FER-002", Nombre = "Cinta Métrica 5m", Descripcion = "Cinta métrica retráctil 5 metros", PrecioCosto = 3.00m, PrecioVentaMinorista = 7.99m, PrecioVentaMayorista = 5.99m, CategoriaId = 6, UnidadMedidaId = 1, Activo = true, FechaCreacion = DateTime.Now },
            new Producto { Id = 25, Codigo = "FER-003", Nombre = "Cable Eléctrico #12", Descripcion = "Cable eléctrico calibre 12 por metro", PrecioCosto = 0.50m, PrecioVentaMinorista = 1.49m, PrecioVentaMayorista = 0.99m, CategoriaId = 6, UnidadMedidaId = 4, Activo = true, FechaCreacion = DateTime.Now }
        );
    }

    private static void SeedStocks(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StockAlmacen>().HasData(
            // Almacén Central (1) - Electrónicos
            new StockAlmacen { Id = 1, ProductoId = 1, AlmacenId = 1, StockActual = 15, StockMinimo = 5, StockMaximo = 30, Ubicacion = "A-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 2, ProductoId = 2, AlmacenId = 1, StockActual = 10, StockMinimo = 3, StockMaximo = 20, Ubicacion = "A-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 3, ProductoId = 3, AlmacenId = 1, StockActual = 50, StockMinimo = 10, StockMaximo = 100, Ubicacion = "A-03", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 4, ProductoId = 4, AlmacenId = 1, StockActual = 75, StockMinimo = 15, StockMaximo = 150, Ubicacion = "A-03", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 5, ProductoId = 5, AlmacenId = 1, StockActual = 30, StockMinimo = 8, StockMaximo = 60, Ubicacion = "A-04", FechaCreacion = DateTime.Now, Activo = true },

            // Almacén Central (1) - Muebles
            new StockAlmacen { Id = 6, ProductoId = 6, AlmacenId = 1, StockActual = 5, StockMinimo = 2, StockMaximo = 10, Ubicacion = "B-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 7, ProductoId = 7, AlmacenId = 1, StockActual = 8, StockMinimo = 3, StockMaximo = 15, Ubicacion = "B-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 8, ProductoId = 8, AlmacenId = 1, StockActual = 4, StockMinimo = 2, StockMaximo = 8, Ubicacion = "B-03", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 9, ProductoId = 9, AlmacenId = 1, StockActual = 6, StockMinimo = 2, StockMaximo = 12, Ubicacion = "B-04", FechaCreacion = DateTime.Now, Activo = true },

            // Mercado Norte (2)
            new StockAlmacen { Id = 10, ProductoId = 1, AlmacenId = 2, StockActual = 3, StockMinimo = 2, StockMaximo = 10, Ubicacion = "E-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 11, ProductoId = 2, AlmacenId = 2, StockActual = 2, StockMinimo = 1, StockMaximo = 5, Ubicacion = "E-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 12, ProductoId = 4, AlmacenId = 2, StockActual = 20, StockMinimo = 5, StockMaximo = 40, Ubicacion = "E-03", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 13, ProductoId = 19, AlmacenId = 2, StockActual = 60, StockMinimo = 15, StockMaximo = 120, Ubicacion = "L-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 14, ProductoId = 20, AlmacenId = 2, StockActual = 45, StockMinimo = 10, StockMaximo = 90, Ubicacion = "L-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 15, ProductoId = 21, AlmacenId = 2, StockActual = 90, StockMinimo = 20, StockMaximo = 180, Ubicacion = "L-03", FechaCreacion = DateTime.Now, Activo = true },

            // Mercado Sur (3) - Suministros
            new StockAlmacen { Id = 16, ProductoId = 10, AlmacenId = 3, StockActual = 100, StockMinimo = 20, StockMaximo = 200, Ubicacion = "S-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 17, ProductoId = 11, AlmacenId = 3, StockActual = 80, StockMinimo = 15, StockMaximo = 150, Ubicacion = "S-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 18, ProductoId = 12, AlmacenId = 3, StockActual = 150, StockMinimo = 30, StockMaximo = 300, Ubicacion = "S-03", FechaCreacion = DateTime.Now, Activo = true },

            // Mercado Este (4) - Alimentos
            new StockAlmacen { Id = 19, ProductoId = 15, AlmacenId = 4, StockActual = 25, StockMinimo = 5, StockMaximo = 50, Ubicacion = "D-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 20, ProductoId = 16, AlmacenId = 4, StockActual = 40, StockMinimo = 10, StockMaximo = 80, Ubicacion = "D-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 21, ProductoId = 17, AlmacenId = 4, StockActual = 200, StockMinimo = 50, StockMaximo = 400, Ubicacion = "D-03", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 22, ProductoId = 18, AlmacenId = 4, StockActual = 30, StockMinimo = 8, StockMaximo = 60, Ubicacion = "D-04", FechaCreacion = DateTime.Now, Activo = true },

            // Almacén Secundario (5) - Ferretería
            new StockAlmacen { Id = 23, ProductoId = 23, AlmacenId = 5, StockActual = 12, StockMinimo = 3, StockMaximo = 25, Ubicacion = "F-01", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 24, ProductoId = 24, AlmacenId = 5, StockActual = 20, StockMinimo = 5, StockMaximo = 40, Ubicacion = "F-02", FechaCreacion = DateTime.Now, Activo = true },
            new StockAlmacen { Id = 25, ProductoId = 25, AlmacenId = 5, StockActual = 100, StockMinimo = 20, StockMaximo = 200, Ubicacion = "F-03", FechaCreacion = DateTime.Now, Activo = true }
        );
    }

    private static void SeedProveedores(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proveedor>().HasData(
            new Proveedor { Id = 1, Nombre = "TechSupply S.A.", RUC = "12345678901", Direccion = "Av. Tecnológica #100", Telefono = "555-1001", Email = "ventas@techsupply.com", Activo = true, FechaCreacion = DateTime.Now },
            new Proveedor { Id = 2, Nombre = "Muebles & Más", RUC = "23456789012", Direccion = "Calle Carpinteros #200", Telefono = "555-1002", Email = "info@mueblesymas.com", Activo = true, FechaCreacion = DateTime.Now },
            new Proveedor { Id = 3, Nombre = "Distribuidora Papelera", RUC = "34567890123", Direccion = "Av. Papel #300", Telefono = "555-1003", Email = "pedidos@distpapelera.com", Activo = true, FechaCreacion = DateTime.Now },
            new Proveedor { Id = 4, Nombre = "Alimentos del Sur", RUC = "45678901234", Direccion = "Zona Industrial #400", Telefono = "555-1004", Email = "contacto@alimentosdelsur.com", Activo = true, FechaCreacion = DateTime.Now },
            new Proveedor { Id = 5, Nombre = "CleanPro S.A.", RUC = "56789012345", Direccion = "Parque Industrial #500", Telefono = "555-1005", Email = "ventas@cleanpro.com", Activo = true, FechaCreacion = DateTime.Now }
        );
    }
}