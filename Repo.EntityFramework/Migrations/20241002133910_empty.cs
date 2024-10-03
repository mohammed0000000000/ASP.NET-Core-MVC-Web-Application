using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using TechWebApplication.Models.Auth;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class empty : Migration
    {
        /// <inheritdoc />
        const string ADMIN_USER_GUID = "ecf92011-7678-4ba4-9e87-d32f1ea541de";
        const string ADMIN_ROLE_GUID = "4cc78c0a-5598-4d56-be43-b9dc2fcd3d21";
        protected override void Up(MigrationBuilder migrationBuilder) {
            var haser = new PasswordHasher<ApplicationUser>();
            var passwordHass = haser.HashPassword(null, "Password100!");
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "FirstName", "LastName", "Address1", "Address2", "PostCode", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
                values: new object[] {
                    $"{ADMIN_USER_GUID}",
                    "Peka",
                    "Doe",
                    "123 Main St",
                    "Apt 4B",
                    "12345",
                    "pekadoe",
                    "PEKADOE",
                    "admin@tec.co.uk",
                    "ADMIN@TEC.CO.UK",
                    "admin@tec.co.uk",
                    "ADMIN@TEC.CO.UK",
                    true,
                    $"{passwordHass}",
                    "",
                    "",
                    null,
                    false,
                    false,
                    null,
                    true,
                    0
                }
            );
            //[Id] NVARCHAR(450) NOT NULL,
            //[Name]             NVARCHAR(256) NULL,
            //[NormalizedName] NVARCHAR(256) NULL,
            //[ConcurrencyStamp] NVARCHAR(MAX) NULL,

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "Name", "NormalizedName" },
            //    values: new object[] { $"{ADMIN_ROLE_GUID}", "admin", "ADMIN" }
            //);
            migrationBuilder.InsertData(
                   table: "AspNetUserRoles",
                   columns: new[] { "UserId", "RoleId" },
                   values: new object[] { $"{ADMIN_USER_GUID}", $"{ADMIN_ROLE_GUID}" }
               );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = {ADMIN_USER_GUID} AND RoleId = {ADMIN_ROLE_GUID}");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = {ADMIN_USER_GUID}");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = {ADMIN_ROLE_GUID}");
        }
    }
}
