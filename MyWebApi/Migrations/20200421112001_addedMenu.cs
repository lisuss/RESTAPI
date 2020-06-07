using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApi.Migrations
{
    public partial class addedMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Menuid",
                table: "PostTags",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Menues",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    MealId = table.Column<string>(nullable: true),
                    MaterialGroup = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Discounted = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    changeable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menues", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_Menuid",
                table: "PostTags",
                column: "Menuid");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Menues_Menuid",
                table: "PostTags",
                column: "Menuid",
                principalTable: "Menues",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Menues_Menuid",
                table: "PostTags");

            migrationBuilder.DropTable(
                name: "Menues");

            migrationBuilder.DropIndex(
                name: "IX_PostTags_Menuid",
                table: "PostTags");

            migrationBuilder.DropColumn(
                name: "Menuid",
                table: "PostTags");
        }
    }
}
