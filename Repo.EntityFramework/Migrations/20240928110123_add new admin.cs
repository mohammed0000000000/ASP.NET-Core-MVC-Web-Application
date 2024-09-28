using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using TechWebApplication.Models.Auth;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class addnewadmin : Migration
    {
        /// <inheritdoc />
        const string ADMIN_USER_GUID = "7000fc77-4c83-4cf8-8d0c-92818c31d08d";
        const string ADMIN_ROLE_GUID = "6bf4c3ff-440f-4fda-bc12-d231dbf728a4";

        protected override void Up(MigrationBuilder migrationBuilder) {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var pass = passwordHasher.HashPassword(null, "Password100!");
            migrationBuilder.InsertData(
                    table: "AspNetUsers",
                    columns: new[]
                    {
                        "Id", "FirstName", "LastName", "Address1", "Address2", "PostCode",
                        "UserName", "NormalizedUserName", "Email", "NormalizedEmail",
                        "EmailConfirmed", "PasswordHash", "SecurityStamp",
                        "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed",
                        "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount"
                                },
                                values: new object[]
                                {
                        "7000fc77-4c83-4cf8-8d0c-92818c31d08d",     // Id
                        "Admin",                       // FirstName
                        "User",                        // LastName
                        "123 Admin St",                // Address1
                        null,                          // Address2 (can be null)
                        "12345",                       // PostCode
                        "admin@tech.co.uk",           // UserName
                        "ADMIN@TECH.CO.UK",           // NormalizedUserName
                        "admin@tech.co.uk",           // Email
                        "ADMIN@TECH.CO.UK",           // NormalizedEmail
                        true,                          // EmailConfirmed
                        $"{pass}",        // PasswordHash (replace with a hashed password)
                        Guid.NewGuid().ToString(),     // SecurityStamp
                        Guid.NewGuid().ToString(),     // ConcurrencyStamp
                        null,                          // PhoneNumber (optional)
                        false,                         // PhoneNumberConfirmed
                        false,                         // TwoFactorEnabled
                        null,                          // LockoutEnd
                        false,                         // LockoutEnabled
                        0                              // AccessFailedCount
                                }
                );


            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id = '{ADMIN_USER_GUID}'");
        }

    }
}