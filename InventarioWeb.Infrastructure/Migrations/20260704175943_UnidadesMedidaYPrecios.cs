using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventarioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnidadesMedidaYPrecios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecioVenta",
                table: "Productos",
                newName: "PrecioVentaMinorista");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioVentaMayorista",
                table: "Productos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnidadMedidaId",
                table: "Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abreviatura = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9110));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9114));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(8881));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(8885));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "PrecioVentaMayorista", "UnidadMedidaId" },
                values: new object[] { new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9069), 1100.00m, 1 });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "PrecioVentaMayorista", "UnidadMedidaId" },
                values: new object[] { new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9075), 450.00m, 1 });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "Id", "Abreviatura", "Activo", "Descripcion", "FechaCreacion", "FechaModificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "U", true, "Unidad individual", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9145), null, "Unidad" },
                    { 2, "Kg", true, "Peso en kilogramos", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9148), null, "Kilogramo" },
                    { 3, "L", true, "Volumen en litros", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9152), null, "Litro" },
                    { 4, "m", true, "Longitud en metros", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9156), null, "Metro" },
                    { 5, "Cja", true, "Caja o paquete", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9159), null, "Caja" },
                    { 6, "Doc", true, "Conjunto de 12 unidades", new DateTime(2026, 7, 4, 13, 59, 42, 767, DateTimeKind.Local).AddTicks(9214), null, "Docena" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_UnidadMedidaId",
                table: "Productos",
                column: "UnidadMedidaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_UnidadesMedida_UnidadMedidaId",
                table: "Productos",
                column: "UnidadMedidaId",
                principalTable: "UnidadesMedida",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_UnidadesMedida_UnidadMedidaId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropIndex(
                name: "IX_Productos_UnidadMedidaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "PrecioVentaMayorista",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "UnidadMedidaId",
                table: "Productos");

            migrationBuilder.RenameColumn(
                name: "PrecioVentaMinorista",
                table: "Productos",
                newName: "PrecioVenta");

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(479));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 13, 16, 30, 619, DateTimeKind.Local).AddTicks(484));
        }
    }
}
