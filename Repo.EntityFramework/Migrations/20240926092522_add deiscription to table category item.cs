using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class adddeiscriptiontotablecategoryitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 25, 20, 937, DateTimeKind.Local).AddTicks(8212),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 19, 31, 612, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CategoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CategoryItems");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 19, 31, 612, DateTimeKind.Local).AddTicks(7841),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 25, 20, 937, DateTimeKind.Local).AddTicks(8212));
        }
    }
}
