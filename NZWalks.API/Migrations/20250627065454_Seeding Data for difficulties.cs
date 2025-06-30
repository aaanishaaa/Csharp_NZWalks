using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDatafordifficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("84ecf802-3408-404d-bbe8-85cb6df3adc6"), "Easy" },
                    { new Guid("a9403e47-6262-47c1-b189-cfa8cca9ecee"), "Medium" },
                    { new Guid("ccd67c75-1395-448d-8792-db5b19019914"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "SP", "Southern Plains", "https://example.com/images/region1.jpg" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "EV", "Eastern Valley", "https://example.com/images/region2.jpg" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "WH", "Western Hills", "https://example.com/images/region3.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("84ecf802-3408-404d-bbe8-85cb6df3adc6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a9403e47-6262-47c1-b189-cfa8cca9ecee"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ccd67c75-1395-448d-8792-db5b19019914"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}
