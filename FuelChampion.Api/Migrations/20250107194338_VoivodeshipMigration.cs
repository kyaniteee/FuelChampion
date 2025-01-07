using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FuelChampion.Api.Migrations
{
    /// <inheritdoc />
    public partial class VoivodeshipMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "211e38fa-a88e-4dc8-be64-1495d6901207");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49a5ee71-e1fa-4453-ad53-f55203f05a53");

            migrationBuilder.AddColumn<string>(
                name: "Voivodeship",
                table: "GasStations",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84acc185-9da8-49ee-9510-9d29536ea7f7", null, "User", "USER" },
                    { "e1495046-28e0-4191-a32b-6e5725ff054b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 6,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "GasStations",
                keyColumn: "Id",
                keyValue: 7,
                column: "Voivodeship",
                value: "Lubelskie");

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("299c3312-fe27-4c4a-9d59-3d79fc37f35b"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("4fc7398e-e750-4a0b-8ca3-10ab95ffbfc6"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84acc185-9da8-49ee-9510-9d29536ea7f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1495046-28e0-4191-a32b-6e5725ff054b");

            migrationBuilder.DropColumn(
                name: "Voivodeship",
                table: "GasStations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "211e38fa-a88e-4dc8-be64-1495d6901207", null, "User", "USER" },
                    { "49a5ee71-e1fa-4453-ad53-f55203f05a53", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 1,
                column: "UserId",
                value: new Guid("e0544c1a-898a-4449-b2b9-33b93d5da266"));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Invoice_id",
                keyValue: 2,
                column: "UserId",
                value: new Guid("5f4455aa-6a9c-41d2-896b-9bbcc5416768"));
        }
    }
}
