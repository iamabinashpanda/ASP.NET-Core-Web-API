using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.NET_Core_Web_API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdataforregionsanddifficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1a66c0c7-2154-4175-9452-fbdd13961cc7"), "R4", "Region 4", "https://example.com/region4-image.jpg" },
                    { new Guid("3834b42f-b6aa-47f5-8da3-e6fa262f1d49"), "R5", "Region 5", "https://example.com/region5-image.jpg" },
                    { new Guid("a7f027c3-aea1-4af8-a756-a05409334e59"), "R2", "Region 2", "https://example.com/region2-image.jpg" },
                    { new Guid("d25b5e29-6ed4-49b9-8b49-f675c5763c10"), "R1", "Region 1", "https://example.com/region1-image.jpg" },
                    { new Guid("fd8b8ef3-d85c-4c16-9e09-d12e41d20763"), "R3", "Region 3", "https://example.com/region3-image.jpg" }
                });

            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("38e794c0-6acc-45af-a403-b46eb05a07a1"), "Hard" },
                    { new Guid("509cc4c3-0ee9-4a90-8ffa-4fa335691cce"), "Medium" },
                    { new Guid("d000c5d0-96a2-48c6-b68a-8a49619851eb"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a66c0c7-2154-4175-9452-fbdd13961cc7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3834b42f-b6aa-47f5-8da3-e6fa262f1d49"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a7f027c3-aea1-4af8-a756-a05409334e59"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d25b5e29-6ed4-49b9-8b49-f675c5763c10"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fd8b8ef3-d85c-4c16-9e09-d12e41d20763"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("38e794c0-6acc-45af-a403-b46eb05a07a1"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("509cc4c3-0ee9-4a90-8ffa-4fa335691cce"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("d000c5d0-96a2-48c6-b68a-8a49619851eb"));
        }
    }
}
