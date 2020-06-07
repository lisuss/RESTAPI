using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApi.Migrations
{
    public partial class changedMenuestoMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Menues_Menuid",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menues",
                table: "Menues");

            migrationBuilder.RenameTable(
                name: "Menues",
                newName: "Menus");

            migrationBuilder.AlterColumn<string>(
                name: "Menuid",
                table: "PostTags",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Menus",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Menus_Menuid",
                table: "PostTags",
                column: "Menuid",
                principalTable: "Menus",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Menus_Menuid",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menues");

            migrationBuilder.AlterColumn<Guid>(
                name: "Menuid",
                table: "PostTags",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "Menues",
                type: "char(36)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menues",
                table: "Menues",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Menues_Menuid",
                table: "PostTags",
                column: "Menuid",
                principalTable: "Menues",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
