using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreCRM.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedAtFieldToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAd",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAd",
                table: "Books");
        }
    }
}
