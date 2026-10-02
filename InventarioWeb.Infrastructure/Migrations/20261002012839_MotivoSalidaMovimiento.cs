using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MotivoSalidaMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MotivoSalida",
                table: "Movimientos",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(241));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(249));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(256));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 538, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 538, DateTimeKind.Local).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 538, DateTimeKind.Local).AddTicks(9649));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 538, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 538, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 538, DateTimeKind.Local).AddTicks(9668));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(970));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(981));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(986));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(992));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(998));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(381));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(408));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(425));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(441));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(467));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(483));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(491));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(506));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(530));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(553));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(561));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(569));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(898));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(910));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(921));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(650));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(667));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(692));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(697));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(764));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(770));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(775));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(780));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(797));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(808));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(814));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(820));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(825));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(69));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(89));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(95));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(107));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(125));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(141));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(153));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 1, 21, 28, 38, 539, DateTimeKind.Local).AddTicks(170));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotivoSalida",
                table: "Movimientos");

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7944));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7562));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7579));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8402));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8411));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8415));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8001));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8007));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8012));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8017));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8022));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8048));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8064));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8129));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8139));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8144));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8359));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8366));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8226));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8234));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8287));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8291));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8294));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7789));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7793));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7808));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7811));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7852));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7856));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7867));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7871));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 8, 5, 17, 0, 23, 521, DateTimeKind.Local).AddTicks(7888));
        }
    }
}
