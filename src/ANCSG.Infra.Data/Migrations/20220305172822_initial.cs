using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANCSG.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Send-Grid");

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Send-Grid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRMUF = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CRMNumber = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Contact = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "Send-Grid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Contact = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExams",
                schema: "Send-Grid",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExams_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "Send-Grid",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalExams_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "Send-Grid",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                schema: "Send-Grid",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExams_DoctorId",
                schema: "Send-Grid",
                table: "MedicalExams",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExams_PatientId",
                schema: "Send-Grid",
                table: "MedicalExams",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                schema: "Send-Grid",
                table: "Patients",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalExams",
                schema: "Send-Grid");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Send-Grid");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "Send-Grid");
        }
    }
}
