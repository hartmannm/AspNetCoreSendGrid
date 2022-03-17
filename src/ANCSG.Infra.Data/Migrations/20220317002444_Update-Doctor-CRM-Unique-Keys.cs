using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANCSG.Infra.Data.Migrations
{
    public partial class UpdateDoctorCRMUniqueKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_CrmNumber",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CrmUf_CrmNumber",
                schema: "Send-Grid",
                table: "Doctors",
                columns: new[] { "CrmUf", "CrmNumber" },
                unique: true,
                filter: "[CrmUf] IS NOT NULL AND [CrmNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Doctors_CrmUf_CrmNumber",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CrmNumber",
                schema: "Send-Grid",
                table: "Doctors",
                column: "CrmNumber",
                unique: true,
                filter: "[CrmNumber] IS NOT NULL");
        }
    }
}
