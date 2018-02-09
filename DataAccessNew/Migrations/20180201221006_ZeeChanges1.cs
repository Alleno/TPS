using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccessNew.Migrations
{
    public partial class ZeeChanges1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDACoreArea",
                table: "TasksBase",
                newName: "SFRDProgramAreaId");

            migrationBuilder.AddColumn<int>(
                name: "IDACoreAreaId",
                table: "TasksBase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CRPCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRPCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDACoreAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDACoreAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SFRDProgramAreas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SFRDProgramAreas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_IDACoreAreaId",
                table: "TasksBase",
                column: "IDACoreAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_SFRDProgramAreaId",
                table: "TasksBase",
                column: "SFRDProgramAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TasksBase_IDACoreAreas_IDACoreAreaId",
                table: "TasksBase",
                column: "IDACoreAreaId",
                principalTable: "IDACoreAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TasksBase_SFRDProgramAreas_SFRDProgramAreaId",
                table: "TasksBase",
                column: "SFRDProgramAreaId",
                principalTable: "SFRDProgramAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TasksBase_IDACoreAreas_IDACoreAreaId",
                table: "TasksBase");

            migrationBuilder.DropForeignKey(
                name: "FK_TasksBase_SFRDProgramAreas_SFRDProgramAreaId",
                table: "TasksBase");

            migrationBuilder.DropTable(
                name: "CRPCategories");

            migrationBuilder.DropTable(
                name: "IDACoreAreas");

            migrationBuilder.DropTable(
                name: "SFRDProgramAreas");

            migrationBuilder.DropIndex(
                name: "IX_TasksBase_IDACoreAreaId",
                table: "TasksBase");

            migrationBuilder.DropIndex(
                name: "IX_TasksBase_SFRDProgramAreaId",
                table: "TasksBase");

            migrationBuilder.DropColumn(
                name: "IDACoreAreaId",
                table: "TasksBase");

            migrationBuilder.RenameColumn(
                name: "SFRDProgramAreaId",
                table: "TasksBase",
                newName: "IDACoreArea");
        }
    }
}
