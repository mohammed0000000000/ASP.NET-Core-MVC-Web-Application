using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class makedefaultitemdatareleasedgeneratebysystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 19, 31, 612, DateTimeKind.Local).AddTicks(7841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 17, 7, 167, DateTimeKind.Local).AddTicks(5412));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 17, 7, 167, DateTimeKind.Local).AddTicks(5412),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 19, 31, 612, DateTimeKind.Local).AddTicks(7841));
        }
    }
}
