using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANCSG.Infra.Data.Migrations
{
    public partial class ValueObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_Email",
                schema: "Send-Grid",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Email",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Contact",
                schema: "Send-Grid",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Send-Grid",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "CRMUF",
                schema: "Send-Grid",
                table: "Doctors",
                newName: "CrmUf");

            migrationBuilder.RenameColumn(
                name: "CRMNumber",
                schema: "Send-Grid",
                table: "Doctors",
                newName: "CrmNumber");

            migrationBuilder.RenameColumn(
                name: "Contact",
                schema: "Send-Grid",
                table: "Doctors",
                newName: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Send-Grid",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Send-Grid",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Send-Grid",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Send-Grid",
                table: "Doctors",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "CrmUf",
                schema: "Send-Grid",
                table: "Doctors",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<long>(
                name: "CrmNumber",
                schema: "Send-Grid",
                table: "Doctors",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Send-Grid",
                table: "Doctors",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                schema: "Send-Grid",
                table: "Patients",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_CrmNumber",
                schema: "Send-Grid",
                table: "Doctors",
                column: "CrmNumber",
                unique: true,
                filter: "[CrmNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                schema: "Send-Grid",
                table: "Doctors",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_Email",
                schema: "Send-Grid",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_CrmNumber",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_Email",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Send-Grid",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Send-Grid",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Send-Grid",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "CrmUf",
                schema: "Send-Grid",
                table: "Doctors",
                newName: "CRMUF");

            migrationBuilder.RenameColumn(
                name: "CrmNumber",
                schema: "Send-Grid",
                table: "Doctors",
                newName: "CRMNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Send-Grid",
                table: "Doctors",
                newName: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Send-Grid",
                table: "Patients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                schema: "Send-Grid",
                table: "Patients",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Send-Grid",
                table: "Patients",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "Send-Grid",
                table: "Doctors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CRMUF",
                schema: "Send-Grid",
                table: "Doctors",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CRMNumber",
                schema: "Send-Grid",
                table: "Doctors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Send-Grid",
                table: "Doctors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                schema: "Send-Grid",
                table: "Patients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                schema: "Send-Grid",
                table: "Doctors",
                column: "Email",
                unique: true);
        }
    }
}
