using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class addmediatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table:"MediType",
            columns:new []{ "Id", "Title", "ThumbnailImagePath" },
            values:new object[]{1, "Video","VideoImage.jpeg"}
            );
            migrationBuilder.InsertData(
            table: "MediType",
            columns: new[] { "Id", "Title", "ThumbnailImagePath" },
            values: new object[] { 2, "Article", "ArticleImage.jpeg" }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from MediType where Id = 1");
            migrationBuilder.Sql("delete from MediType where Id = 2");
        }
    }
}
