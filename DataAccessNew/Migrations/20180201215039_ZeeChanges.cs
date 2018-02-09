using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccessNew.Migrations
{
    public partial class ZeeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contracts");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Deliverables",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatusId",
                table: "Contracts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Deliverables");

            migrationBuilder.AlterColumn<int>(
                name: "ApprovalStatusId",
                table: "Contracts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contracts",
                nullable: false,
                defaultValue: 0);
        }
    }
}
