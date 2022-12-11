using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Akadimi.WidgetEngine.Migrations
{
    public partial class Add_AuthorId_To_Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                schema: "BookStore",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                schema: "BookStore",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                schema: "BookStore",
                table: "Books",
                column: "AuthorId",
                principalSchema: "BookStore",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                schema: "BookStore",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                schema: "BookStore",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                schema: "BookStore",
                table: "Books");
        }
    }
}
