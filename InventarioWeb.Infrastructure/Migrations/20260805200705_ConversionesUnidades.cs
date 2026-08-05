using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventarioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConversionesUnidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UnidadOrigenId = table.Column<int>(type: "int", nullable: false),
                    UnidadDestinoId = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Activo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversiones_UnidadesMedida_UnidadDestinoId",
                        column: x => x.UnidadDestinoId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversiones_UnidadesMedida_UnidadOrigenId",
                        column: x => x.UnidadOrigenId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5919));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5635));

            migrationBuilder.InsertData(
                table: "Conversiones",
                columns: new[] { "Id", "Activo", "Descripcion", "Factor", "FechaCreacion", "FechaModificacion", "UnidadDestinoId", "UnidadOrigenId" },
                values: new object[,]
                {
                    { 1, true, "1 Kg = 1000 g", 1m, new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6418), null, 1, 2 },
                    { 2, true, "1 L = 1000 ml", 1000m, new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6424), null, 1, 3 },
                    { 3, true, "1 Docena = 12 Unidades", 12m, new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6428), null, 1, 6 },
                    { 4, true, "1 Par = 2 Unidades", 2m, new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6431), null, 1, 7 },
                    { 5, true, "1 Caja = 24 Unidades", 24m, new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6435), null, 1, 5 }
                });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6018));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6046));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6062));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6088));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6122));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6132));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6136));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6141));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6371));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6376));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6208));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6215));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6267));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6295));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6306));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6309));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6313));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(6316));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5853));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 16, 7, 3, 253, DateTimeKind.Local).AddTicks(5870));

            migrationBuilder.CreateIndex(
                name: "IX_Conversiones_UnidadDestinoId",
                table: "Conversiones",
                column: "UnidadDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversiones_UnidadOrigenId_UnidadDestinoId",
                table: "Conversiones",
                columns: new[] { "UnidadOrigenId", "UnidadDestinoId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conversiones");

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8557));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8562));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8571));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8164));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8175));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8178));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8625));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8646));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8652));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8688));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8708));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8740));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8974));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8879));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8883));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8908));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8922));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8929));

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
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 7, 4, 16, 17, 15, 973, DateTimeKind.Local).AddTicks(8468));
        }
    }
}
