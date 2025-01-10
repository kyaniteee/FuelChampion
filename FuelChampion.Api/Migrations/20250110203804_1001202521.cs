using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuelChampion.Api.Migrations
{
    /// <inheritdoc />
    public partial class _1001202521 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "597032b5-8d43-4531-8b71-4793ca625423");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7c4508c-d87d-42c2-ab59-bebebb643a4d");

            migrationBuilder.AlterColumn<int>(
                name: "Voivodeship",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99eb4504-4d5a-47e8-b003-3d9610c48c68", null, "Admin", "ADMIN" },
                    { "c00b6e04-c665-4e51-80d2-2a44b975f648", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("062f2ad9-ef51-4293-bdef-1ff6c79f5634"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("c2936301-f3b9-4e50-b016-0e70e35e6ec1"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99eb4504-4d5a-47e8-b003-3d9610c48c68");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c00b6e04-c665-4e51-80d2-2a44b975f648");

            migrationBuilder.AlterColumn<string>(
                name: "Voivodeship",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "597032b5-8d43-4531-8b71-4793ca625423", null, "User", "USER" },
                    { "c7c4508c-d87d-42c2-ab59-bebebb643a4d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("9a0dd9c6-0cba-413f-ac45-be87c498f42e"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("cb6aedbc-9333-442e-9e56-8b7a9c8f0e87"));
        }
    }
}
