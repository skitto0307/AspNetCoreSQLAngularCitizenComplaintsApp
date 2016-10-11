using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CitizenComplaintsAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizen",
                columns: table => new
                {
                    CitizenId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 64, nullable: false),
                    Address2 = table.Column<string>(maxLength: 64, nullable: true),
                    City = table.Column<string>(maxLength: 35, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 254, nullable: true),
                    Enabled = table.Column<bool>(nullable: false, defaultValue: true),
                    FirstName = table.Column<string>(maxLength: 35, nullable: false),
                    LastName = table.Column<string>(maxLength: 35, nullable: false),
                    MiddleInitial = table.Column<string>(maxLength: 1, nullable: true),
                    PhoneDay = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneEvening = table.Column<string>(maxLength: 20, nullable: true),
                    PhoneFax = table.Column<string>(maxLength: 10, nullable: true),
                    StateId = table.Column<string>(maxLength: 2, nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizen", x => x.CitizenId);
                });

            migrationBuilder.CreateTable(
                name: "IssueType",
                columns: table => new
                {
                    IssueTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DisplayName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueType", x => x.IssueTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Complaint",
                columns: table => new
                {
                    ComplaintId = table.Column<Guid>(nullable: false),
                    CitizenId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false, defaultValue: true),
                    IssueTypeId = table.Column<int>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaint", x => x.ComplaintId);
                    table.ForeignKey(
                        name: "FK_Complaint_Citizen_CitizenId",
                        column: x => x.CitizenId,
                        principalTable: "Citizen",
                        principalColumn: "CitizenId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Complaint_IssueType_IssueTypeId",
                        column: x => x.IssueTypeId,
                        principalTable: "IssueType",
                        principalColumn: "IssueTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintDescription",
                columns: table => new
                {
                    ComplaintId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintDescription", x => x.ComplaintId);
                    table.ForeignKey(
                        name: "FK_ComplaintDescription_Complaint_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaint",
                        principalColumn: "ComplaintId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationAddress",
                columns: table => new
                {
                    LocationAddressId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 64, nullable: false),
                    Address2 = table.Column<string>(maxLength: 64, nullable: true),
                    City = table.Column<string>(maxLength: 30, nullable: false),
                    ComplaintId = table.Column<Guid>(nullable: false),
                    StateId = table.Column<string>(maxLength: 2, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationAddress", x => x.LocationAddressId);
                    table.ForeignKey(
                        name: "FK_LocationAddress_Complaint_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaint",
                        principalColumn: "ComplaintId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_CitizenId",
                table: "Complaint",
                column: "CitizenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Complaint_IssueTypeId",
                table: "Complaint",
                column: "IssueTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintDescription_ComplaintId",
                table: "ComplaintDescription",
                column: "ComplaintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationAddress_ComplaintId",
                table: "LocationAddress",
                column: "ComplaintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplaintDescription");

            migrationBuilder.DropTable(
                name: "LocationAddress");

            migrationBuilder.DropTable(
                name: "Complaint");

            migrationBuilder.DropTable(
                name: "Citizen");

            migrationBuilder.DropTable(
                name: "IssueType");
        }
    }
}
