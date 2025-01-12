using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuelChampion.Api.Migrations
{
    /// <inheritdoc />
    public partial class _120120251428 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
