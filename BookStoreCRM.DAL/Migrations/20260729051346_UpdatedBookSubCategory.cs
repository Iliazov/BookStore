using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreCRM.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBookSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_SubCategory_SubCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Categories_CategoryId",
                table: "SubCategory");

            migrationBuilder.RenameColumn(
                name: "CreatedAd",
                table: "Books",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubCategoryId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SubCategory_SubCategoryId",
                table: "Books",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Categories_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_SubCategory_SubCategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Categories_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Books",
                newName: "CreatedAd");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubCategoryId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_SubCategory_SubCategoryId",
                table: "Books",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Categories_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
