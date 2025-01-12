using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuelChampion.Api.Migrations
{
    /// <inheritdoc />
    public partial class _120120251420 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fde280d-b3ea-49ba-b5de-d336bf6caca5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c154cbe-bd98-4488-b579-e7a1000e696d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b30fb8a9-cd9b-4c7a-9995-b626815e657f", null, "Admin", "ADMIN" },
                    { "ee0a0b5f-22d0-4e75-85ed-78da999db905", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("a5660a54-eac7-4eac-9505-86eb259225db"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("c1651a12-85e0-45b6-b415-b87b80ec0fc3"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b30fb8a9-cd9b-4c7a-9995-b626815e657f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee0a0b5f-22d0-4e75-85ed-78da999db905");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fde280d-b3ea-49ba-b5de-d336bf6caca5", null, "User", "USER" },
                    { "4c154cbe-bd98-4488-b579-e7a1000e696d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("97bec6ea-36e9-4a4b-b476-5f66b835ba4e"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("9d672cb8-4922-4d66-875e-1057fb170ce7"));
        }
    }
}
