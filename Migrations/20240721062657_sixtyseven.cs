using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pharma.Migrations
{
    /// <inheritdoc />
    public partial class sixtyseven : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SalesDate",
                table: "SalesDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesDate",
                table: "SalesDetails");
        }
    }
}
