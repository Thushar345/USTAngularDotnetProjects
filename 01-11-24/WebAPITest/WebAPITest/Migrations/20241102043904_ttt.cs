using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPITest.Migrations
{
    /// <inheritdoc />
    public partial class ttt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Colour", "Name", "Price", "Weight" },
                values: new object[] { new Guid("13881881-a9a9-4041-849c-060992f13545"), "White", "Rice", 30, 100m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13881881-a9a9-4041-849c-060992f13545"));
        }
    }
}
