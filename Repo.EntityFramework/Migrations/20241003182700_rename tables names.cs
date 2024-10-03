using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class renametablesnames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_Categories_CategoryId",
                table: "CategoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_MediTypes_MediaTypeId",
                table: "CategoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItems_CategoryItemId",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategories_AspNetUsers_UserId",
                table: "UserCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategories_Categories_CategoryId",
                table: "UserCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCategories",
                table: "UserCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediTypes",
                table: "MediTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItems",
                table: "CategoryItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "UserCategories",
                newName: "UserCategory");

            migrationBuilder.RenameTable(
                name: "MediTypes",
                newName: "MediType");

            migrationBuilder.RenameTable(
                name: "CategoryItems",
                newName: "CategoryItem");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_UserCategories_UserId",
                table: "UserCategory",
                newName: "IX_UserCategory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCategories_CategoryId",
                table: "UserCategory",
                newName: "IX_UserCategory_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItems_MediaTypeId",
                table: "CategoryItem",
                newName: "IX_CategoryItem_MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItems_CategoryId",
                table: "CategoryItem",
                newName: "IX_CategoryItem_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItem",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 3, 21, 26, 59, 226, DateTimeKind.Local).AddTicks(614),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 10, 2, 22, 10, 2, 374, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCategory",
                table: "UserCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediType",
                table: "MediType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItem_MediType_MediaTypeId",
                table: "CategoryItem",
                column: "MediaTypeId",
                principalTable: "MediType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content",
                column: "CategoryItemId",
                principalTable: "CategoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategory_AspNetUsers_UserId",
                table: "UserCategory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategory_Category_CategoryId",
                table: "UserCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_Category_CategoryId",
                table: "CategoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItem_MediType_MediaTypeId",
                table: "CategoryItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Content_CategoryItem_CategoryItemId",
                table: "Content");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategory_AspNetUsers_UserId",
                table: "UserCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCategory_Category_CategoryId",
                table: "UserCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCategory",
                table: "UserCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediType",
                table: "MediType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItem",
                table: "CategoryItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "UserCategory",
                newName: "UserCategories");

            migrationBuilder.RenameTable(
                name: "MediType",
                newName: "MediTypes");

            migrationBuilder.RenameTable(
                name: "CategoryItem",
                newName: "CategoryItems");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_UserCategory_UserId",
                table: "UserCategories",
                newName: "IX_UserCategories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCategory_CategoryId",
                table: "UserCategories",
                newName: "IX_UserCategories_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItem_MediaTypeId",
                table: "CategoryItems",
                newName: "IX_CategoryItems_MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItem_CategoryId",
                table: "CategoryItems",
                newName: "IX_CategoryItems_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeItemReleased",
                table: "CategoryItems",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 2, 22, 10, 2, 374, DateTimeKind.Local).AddTicks(7030),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2024, 10, 3, 21, 26, 59, 226, DateTimeKind.Local).AddTicks(614));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCategories",
                table: "UserCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediTypes",
                table: "MediTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItems",
                table: "CategoryItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_Categories_CategoryId",
                table: "CategoryItems",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_MediTypes_MediaTypeId",
                table: "CategoryItems",
                column: "MediaTypeId",
                principalTable: "MediTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Content_CategoryItems_CategoryItemId",
                table: "Content",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategories_AspNetUsers_UserId",
                table: "UserCategories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCategories_Categories_CategoryId",
                table: "UserCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
