using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuelChampion.Api.Migrations
{
    /// <inheritdoc />
    public partial class _120120251437 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42979059-504b-499b-b6c0-46da9a11bcea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8ba7319-a6a0-4c57-8529-106ddf8f6190");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e5fae11a-a8ce-4769-9b2e-b8f8871a04dd", null, "Admin", "ADMIN" },
                    { "f1ed103e-7451-4c2f-9739-68be6e0f7c51", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("6ff8423f-631d-41a3-9c4b-1e706809cb84"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("e0bd7101-ecfa-47fc-bc09-b5b87ffa2a4e"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5fae11a-a8ce-4769-9b2e-b8f8871a04dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1ed103e-7451-4c2f-9739-68be6e0f7c51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42979059-504b-499b-b6c0-46da9a11bcea", null, "User", "USER" },
                    { "d8ba7319-a6a0-4c57-8529-106ddf8f6190", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("4213a1fa-e290-444d-b11d-2bbbd8d75804"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("fd387e4b-f3b5-4321-bec2-d41995efd9bf"));
        }
    }
}
