using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventarioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatosPruebaSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Direccion", "Encargado", "FechaCreacion", "Telefono" },
                values: new object[] { "Calle Principal #100", "Carlos López", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8557), "555-0101" });

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Direccion", "Encargado", "FechaCreacion", "Telefono" },
                values: new object[] { "Av. Norte #200", "María García", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8562), "555-0202" });

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Direccion", "Encargado", "FechaCreacion", "Telefono" },
                values: new object[] { "Av. Sur #300", "Pedro Martínez", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8566), "555-0303" });

            migrationBuilder.InsertData(
                table: "Almacenes",
                columns: new[] { "Id", "Activo", "Codigo", "Descripcion", "Direccion", "Encargado", "FechaCreacion", "FechaModificacion", "Nombre", "Telefono", "Tipo" },
                values: new object[,]
                {
                    { 4, true, "MER-ESTE", null, "Calle Este #400", "Ana Rodríguez", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8571), null, "Mercado Este", "555-0404", "MERCADO" },
                    { 5, true, "ALM-SEC", null, "Zona Industrial #500", "Luis Sánchez", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8575), null, "Almacén Secundario", "555-0505", "ALMACEN" }
                });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Dispositivos electrónicos y gadgets", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Muebles de oficina y hogar", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Suministros de oficina y papelería", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8168) });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 4, true, "Productos alimenticios y bebidas", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8171), null, "Alimentos" },
                    { 5, true, "Productos de limpieza e higiene", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8175), null, "Limpieza" },
                    { 6, true, "Herramientas y materiales de construcción", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8178), null, "Ferretería" }
                });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Codigo", "Descripcion", "FechaCreacion", "Nombre", "PrecioCosto", "PrecioVentaMayorista", "PrecioVentaMinorista" },
                values: new object[] { "ELE-001", "Laptop HP 15.6 pulgadas, 8GB RAM, 256GB SSD", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8625), "Laptop HP 15\"", 650.00m, 799.99m, 899.99m });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoriaId", "Codigo", "Descripcion", "FechaCreacion", "Nombre", "PrecioCosto", "PrecioVentaMayorista", "PrecioVentaMinorista" },
                values: new object[] { 1, "ELE-002", "Monitor Dell 24 pulgadas Full HD", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8633), "Monitor Dell 24\"", 200.00m, 299.99m, 349.99m });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Activo", "CategoriaId", "Codigo", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre", "PrecioCosto", "PrecioVentaMayorista", "PrecioVentaMinorista", "UnidadMedidaId" },
                values: new object[,]
                {
                    { 3, true, 1, "ELE-003", "Teclado inalámbrico Bluetooth multimedia", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8640), null, "Teclado Inalámbrico", 25.00m, 39.99m, 49.99m, 1 },
                    { 4, true, 1, "ELE-004", "Mouse óptico USB ergonómico 1200dpi", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8646), null, "Mouse Óptico USB", 10.00m, 19.99m, 24.99m, 1 },
                    { 5, true, 1, "ELE-005", "Audífonos inalámbricos con micrófono y cancelación de ruido", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8652), null, "Audífonos Bluetooth", 35.00m, 59.99m, 79.99m, 1 },
                    { 6, true, 2, "MUE-001", "Escritorio de madera 120x60cm con cajones", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8658), null, "Escritorio Ejecutivo", 250.00m, 399.99m, 499.99m, 1 },
                    { 7, true, 2, "MUE-002", "Silla ergonómica con soporte lumbar ajustable", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8663), null, "Silla de Oficina", 150.00m, 249.99m, 299.99m, 1 },
                    { 8, true, 2, "MUE-003", "Estantería 5 niveles 180x90x40cm", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8668), null, "Estantería Metálica", 100.00m, 159.99m, 199.99m, 1 },
                    { 9, true, 2, "MUE-004", "Archivador metálico con llave de seguridad", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8673), null, "Archivador 3 Cajones", 80.00m, 129.99m, 159.99m, 1 },
                    { 10, true, 3, "SUM-001", "Resma de papel bond A4 500 hojas 75g", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8678), null, "Papel Bond A4", 3.50m, 5.99m, 7.99m, 5 },
                    { 11, true, 3, "SUM-002", "Caja de 12 bolígrafos azules punto fino", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8683), null, "Bolígrafos Azules", 2.00m, 3.99m, 4.99m, 5 },
                    { 12, true, 3, "SUM-003", "Cuaderno 100 hojas rayado tamaño carta", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8688), null, "Cuaderno Universitario", 1.50m, 2.99m, 3.99m, 1 },
                    { 13, true, 3, "SUM-004", "Cartucho de tinta negra compatible HP", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8694), null, "Tinta para Impresora", 15.00m, 24.99m, 34.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "Activo", "Direccion", "Email", "FechaCreacion", "FechaModificacion", "Nombre", "RUC", "Telefono" },
                values: new object[,]
                {
                    { 1, true, "Av. Tecnológica #100", "ventas@techsupply.com", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8974), null, "TechSupply S.A.", "12345678901", "555-1001" },
                    { 2, true, "Calle Carpinteros #200", "info@mueblesymas.com", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8978), null, "Muebles & Más", "23456789012", "555-1002" },
                    { 3, true, "Av. Papel #300", "pedidos@distpapelera.com", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8981), null, "Distribuidora Papelera", "34567890123", "555-1003" },
                    { 4, true, "Zona Industrial #400", "contacto@alimentosdelsur.com", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8985), null, "Alimentos del Sur", "45678901234", "555-1004" },
                    { 5, true, "Parque Industrial #500", "ventas@cleanpro.com", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8988), null, "CleanPro S.A.", "56789012345", "555-1005" }
                });

            migrationBuilder.InsertData(
                table: "StockAlmacenes",
                columns: new[] { "Id", "Activo", "AlmacenId", "FechaCreacion", "FechaModificacion", "ProductoId", "StockActual", "StockMaximo", "StockMinimo", "Ubicacion" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8841), null, 1, 15, 30, 5, "A-01" },
                    { 2, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8845), null, 2, 10, 20, 3, "A-02" },
                    { 10, true, 2, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8876), null, 1, 3, 10, 2, "E-01" },
                    { 11, true, 2, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8879), null, 2, 2, 5, 1, "E-02" }
                });

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8447));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Caja o paquete cerrado", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8457) });

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "Id", "Abreviatura", "Activo", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 7, "Par", true, "Conjunto de 2 unidades", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8465), null, "Par" },
                    { 8, "Rol", true, "Rollo completo", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8468), null, "Rollo" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Activo", "CategoriaId", "Codigo", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre", "PrecioCosto", "PrecioVentaMayorista", "PrecioVentaMinorista", "UnidadMedidaId" },
                values: new object[,]
                {
                    { 14, true, 3, "SUM-005", "Cinta adhesiva transparente 12mm x 33m", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8699), null, "Cinta Adhesiva", 0.50m, 0.99m, 1.49m, 8 },
                    { 15, true, 4, "ALI-001", "Café molido premium 500g", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8703), null, "Café Molido", 8.00m, 11.99m, 14.99m, 1 },
                    { 16, true, 4, "ALI-002", "Azúcar blanca refinada 1Kg", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8708), null, "Azúcar Blanca", 1.00m, 1.99m, 2.49m, 2 },
                    { 17, true, 4, "ALI-003", "Botella de agua mineral sin gas 500ml", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8714), null, "Agua Mineral", 0.30m, 0.75m, 0.99m, 1 },
                    { 18, true, 4, "ALI-004", "Paquete de galletas surtidas 400g", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8719), null, "Galletas Surtidas", 2.50m, 3.99m, 4.99m, 1 },
                    { 19, true, 5, "LIM-001", "Detergente líquido multiusos 1L", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8725), null, "Detergente Líquido", 2.00m, 3.99m, 4.99m, 3 },
                    { 20, true, 5, "LIM-002", "Cloro concentrado 1L", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8730), null, "Cloro Concentrado", 1.00m, 1.99m, 2.49m, 3 },
                    { 21, true, 5, "LIM-003", "Paquete de 4 rollos doble hoja", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8735), null, "Papel Higiénico", 1.50m, 2.99m, 3.99m, 5 },
                    { 22, true, 5, "LIM-004", "Jabón líquido antibacterial 500ml", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8740), null, "Jabón de Manos", 2.00m, 3.49m, 4.49m, 1 },
                    { 23, true, 6, "FER-001", "Martillo de acero forjado mango de madera", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8744), null, "Martillo de Acero", 8.00m, 12.99m, 15.99m, 1 },
                    { 24, true, 6, "FER-002", "Cinta métrica retráctil 5 metros", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8749), null, "Cinta Métrica 5m", 3.00m, 5.99m, 7.99m, 1 },
                    { 25, true, 6, "FER-003", "Cable eléctrico calibre 12 por metro", new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8755), null, "Cable Eléctrico #12", 0.50m, 0.99m, 1.49m, 4 }
                });

            migrationBuilder.InsertData(
                table: "StockAlmacenes",
                columns: new[] { "Id", "Activo", "AlmacenId", "FechaCreacion", "FechaModificacion", "ProductoId", "StockActual", "StockMaximo", "StockMinimo", "Ubicacion" },
                values: new object[,]
                {
                    { 3, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8849), null, 3, 50, 100, 10, "A-03" },
                    { 4, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8853), null, 4, 75, 150, 15, "A-03" },
                    { 5, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8856), null, 5, 30, 60, 8, "A-04" },
                    { 6, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8860), null, 6, 5, 10, 2, "B-01" },
                    { 7, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8864), null, 7, 8, 15, 3, "B-02" },
                    { 8, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8867), null, 8, 4, 8, 2, "B-03" },
                    { 9, true, 1, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8872), null, 9, 6, 12, 2, "B-04" },
                    { 12, true, 2, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8883), null, 4, 20, 40, 5, "E-03" },
                    { 16, true, 3, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8897), null, 10, 100, 200, 20, "S-01" },
                    { 17, true, 3, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8901), null, 11, 80, 150, 15, "S-02" },
                    { 18, true, 3, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8904), null, 12, 150, 300, 30, "S-03" },
                    { 13, true, 2, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8886), null, 19, 60, 120, 15, "L-01" },
                    { 14, true, 2, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8890), null, 20, 45, 90, 10, "L-02" },
                    { 15, true, 2, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8894), null, 21, 90, 180, 20, "L-03" },
                    { 19, true, 4, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8908), null, 15, 25, 50, 5, "D-01" },
                    { 20, true, 4, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8911), null, 16, 40, 80, 10, "D-02" },
                    { 21, true, 4, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8915), null, 17, 200, 400, 50, "D-03" },
                    { 22, true, 4, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8918), null, 18, 30, 60, 8, "D-04" },
                    { 23, true, 5, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8922), null, 23, 12, 25, 3, "F-01" },
                    { 24, true, 5, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8925), null, 24, 20, 40, 5, "F-02" },
                    { 25, true, 5, new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8929), null, 25, 100, 200, 20, "F-03" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Direccion", "Encargado", "FechaCreacion", "Telefono" },
                values: new object[] { "Calle Principal #123", null, new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9105), null });

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Direccion", "Encargado", "FechaCreacion", "Telefono" },
                values: new object[] { "Av. Norte #456", null, new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9110), null });

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Direccion", "Encargado", "FechaCreacion", "Telefono" },
                values: new object[] { "Av. Sur #789", null, new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9114), null });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Productos electrónicos", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(8876) });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Muebles de oficina", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Suministros de oficina", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(8885) });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Codigo", "Descripcion", "FechaCreacion", "Nombre", "PrecioCosto", "PrecioVentaMayorista", "PrecioVentaMinorista" },
                values: new object[] { "PROD-001", "Laptop HP 15 pulgadas", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9069), "Laptop HP", 800.00m, 1100.00m, 1200.00m });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoriaId", "Codigo", "Descripcion", "FechaCreacion", "Nombre", "PrecioCosto", "PrecioVentaMayorista", "PrecioVentaMinorista" },
                values: new object[] { 2, "PROD-002", "Escritorio ejecutivo", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9075), "Escritorio", 300.00m, 450.00m, 500.00m });

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9152));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Descripcion", "FechaCreacion" },
                values: new object[] { "Caja o paquete", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9159) });

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9214));
        }
    }
}
