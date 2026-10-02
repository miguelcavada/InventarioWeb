using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AgregaMotivoSalidaMovimiento : Migration
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
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "Almacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8376));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(7955));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(7964));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(7968));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8850));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "Conversiones",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8861));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8420));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8455));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8461));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8490));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8495));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8506));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8521));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8531));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8537));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8541));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8546));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8551));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8561));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8566));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8570));

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8575));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8805));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "Proveedores",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8813));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8640));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8645));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8649));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8653));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8668));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8672));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8711));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 19,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 20,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 21,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 22,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 23,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 24,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "StockAlmacenes",
                keyColumn: "Id",
                keyValue: 25,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8253));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8257));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 6,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8260));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 7,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8264));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 8,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 9,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 10,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 11,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 12,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 13,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 14,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 15,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 16,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8296));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 17,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "UnidadesMedida",
                keyColumn: "Id",
                keyValue: 18,
                column: "FechaCreacion",
                value: new DateTime(2026, 10, 2, 13, 36, 11, 976, DateTimeKind.Local).AddTicks(8303));
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
