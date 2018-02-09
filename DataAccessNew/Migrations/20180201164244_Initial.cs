using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAccessNew.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnticipatedAudiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnticipatedAudiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChargeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FiscalYear = table.Column<int>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false),
                    PeriodNumber = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    SubPeriodNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPeriods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisibilityLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisibilityLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BadgeId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    EmployeeTypeId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    TaskOrderId = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Abstract = table.Column<string>(nullable: false),
                    AnticipatedAudienceId = table.Column<int>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateSignedBySponsor = table.Column<DateTime>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    FundingAmount = table.Column<decimal>(nullable: false),
                    FundingCategoryId = table.Column<int>(nullable: true),
                    Objective = table.Column<string>(nullable: false),
                    ProjectNumber = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TaskNumber = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    VisibilityLevelId = table.Column<int>(nullable: false),
                    ApprovalStatusId = table.Column<int>(nullable: true),
                    DateApproval = table.Column<DateTime>(nullable: true),
                    DatePlacedOnContract = table.Column<DateTime>(nullable: true),
                    SponsorId = table.Column<int>(nullable: true),
                    TaskId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Contracts_TaskOrderId",
                        column: x => x.TaskOrderId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_AnticipatedAudiences_AnticipatedAudienceId",
                        column: x => x.AnticipatedAudienceId,
                        principalTable: "AnticipatedAudiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_FundingCategories_FundingCategoryId",
                        column: x => x.FundingCategoryId,
                        principalTable: "FundingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_VisibilityLevels_VisibilityLevelId",
                        column: x => x.VisibilityLevelId,
                        principalTable: "VisibilityLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ApprovalStatuses_ApprovalStatusId",
                        column: x => x.ApprovalStatusId,
                        principalTable: "ApprovalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TasksBase",
                columns: table => new
                {
                    Budget = table.Column<decimal>(nullable: true),
                    TaskId = table.Column<Guid>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    TaskOrderId = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    IDACoreArea = table.Column<int>(nullable: false),
                    ShortTitle = table.Column<string>(nullable: true),
                    TaskLeaderId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TasksBase_TasksBase_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TasksBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TasksBase_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TasksBase_Contracts_TaskOrderId",
                        column: x => x.TaskOrderId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TasksBase_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TasksBase_Employees_TaskLeaderId",
                        column: x => x.TaskLeaderId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LaborCharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActualHours = table.Column<double>(nullable: true),
                    ChargeCode = table.Column<string>(nullable: true),
                    ChargedAmount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    EstimatedHours = table.Column<double>(nullable: false),
                    PayPeriodId = table.Column<int>(nullable: false),
                    TaskBaseClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaborCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaborCharges_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaborCharges_PayPeriods_PayPeriodId",
                        column: x => x.PayPeriodId,
                        principalTable: "PayPeriods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LaborCharges_TasksBase_TaskBaseClassId",
                        column: x => x.TaskBaseClassId,
                        principalTable: "TasksBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NonLaborCharges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActualDate = table.Column<DateTime>(nullable: true),
                    ChargeCode = table.Column<string>(nullable: true),
                    ChargeTypeId = table.Column<int>(nullable: false),
                    ChargedAmount = table.Column<decimal>(nullable: false),
                    EstimatedAmount = table.Column<decimal>(nullable: false),
                    PlannedDate = table.Column<DateTime>(nullable: false),
                    TaskBaseClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonLaborCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonLaborCharges_ChargeType_ChargeTypeId",
                        column: x => x.ChargeTypeId,
                        principalTable: "ChargeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NonLaborCharges_TasksBase_TaskBaseClassId",
                        column: x => x.TaskBaseClassId,
                        principalTable: "TasksBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    DeliverableId = table.Column<Guid>(nullable: false),
                    ActualNumPages = table.Column<int>(nullable: true),
                    EstimatedNumPages = table.Column<int>(nullable: true),
                    NonLaborChargeId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.DeliverableId);
                    table.ForeignKey(
                        name: "FK_Publications_NonLaborCharges_NonLaborChargeId",
                        column: x => x.NonLaborChargeId,
                        principalTable: "NonLaborCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliverables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: true),
                    CurrentStatus = table.Column<string>(nullable: false),
                    DateDelivered = table.Column<DateTime>(nullable: true),
                    DateEstimatedDue = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Formal = table.Column<bool>(nullable: false),
                    FormatId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    PublicationId = table.Column<Guid>(nullable: true),
                    TaskBaseClassId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliverables_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliverables_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverables_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deliverables_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "DeliverableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deliverables_TasksBase_TaskBaseClassId",
                        column: x => x.TaskBaseClassId,
                        principalTable: "TasksBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_TaskOrderId",
                table: "Contracts",
                column: "TaskOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_AnticipatedAudienceId",
                table: "Contracts",
                column: "AnticipatedAudienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FundingCategoryId",
                table: "Contracts",
                column: "FundingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_VisibilityLevelId",
                table: "Contracts",
                column: "VisibilityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ApprovalStatusId",
                table: "Contracts",
                column: "ApprovalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SponsorId",
                table: "Contracts",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_ContractId",
                table: "Deliverables",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_FormatId",
                table: "Deliverables",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_ProductTypeId",
                table: "Deliverables",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_PublicationId",
                table: "Deliverables",
                column: "PublicationId",
                unique: true,
                filter: "[PublicationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_TaskBaseClassId",
                table: "Deliverables",
                column: "TaskBaseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborCharges_EmployeeId",
                table: "LaborCharges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborCharges_PayPeriodId",
                table: "LaborCharges",
                column: "PayPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_LaborCharges_TaskBaseClassId",
                table: "LaborCharges",
                column: "TaskBaseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_NonLaborCharges_ChargeTypeId",
                table: "NonLaborCharges",
                column: "ChargeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NonLaborCharges_TaskBaseClassId",
                table: "NonLaborCharges",
                column: "TaskBaseClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_NonLaborChargeId",
                table: "Publications",
                column: "NonLaborChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_TaskId",
                table: "TasksBase",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_EmployeeId",
                table: "TasksBase",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_TaskOrderId",
                table: "TasksBase",
                column: "TaskOrderId",
                unique: true,
                filter: "[TaskOrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_DivisionId",
                table: "TasksBase",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksBase_TaskLeaderId",
                table: "TasksBase",
                column: "TaskLeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliverables");

            migrationBuilder.DropTable(
                name: "LaborCharges");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "PayPeriods");

            migrationBuilder.DropTable(
                name: "NonLaborCharges");

            migrationBuilder.DropTable(
                name: "ChargeType");

            migrationBuilder.DropTable(
                name: "TasksBase");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "AnticipatedAudiences");

            migrationBuilder.DropTable(
                name: "FundingCategories");

            migrationBuilder.DropTable(
                name: "VisibilityLevels");

            migrationBuilder.DropTable(
                name: "ApprovalStatuses");

            migrationBuilder.DropTable(
                name: "Sponsors");
        }
    }
}
