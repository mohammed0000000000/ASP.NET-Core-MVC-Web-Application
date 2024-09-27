using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class fixidentityerorinmodelContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 27, 11, 48, 54, 579, DateTimeKind.Local).AddTicks(8214),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 26, 12, 25, 20, 937, DateTimeKind.Local).AddTicks(8212));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 26, 12, 25, 20, 937, DateTimeKind.Local).AddTicks(8212),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 9, 27, 11, 48, 54, 579, DateTimeKind.Local).AddTicks(8214));
        }
    }
}
