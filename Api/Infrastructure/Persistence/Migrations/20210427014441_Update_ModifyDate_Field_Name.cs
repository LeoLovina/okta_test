using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Update_ModifyDate_Field_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeModifyDate",
                table: "Pings",
                newName: "ModifyDate");

            migrationBuilder.RenameColumn(
                name: "DateTimeModifyDate",
                table: "Computers",
                newName: "ModifyDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Pings",
                newName: "DateTimeModifyDate");

            migrationBuilder.RenameColumn(
                name: "ModifyDate",
                table: "Computers",
                newName: "DateTimeModifyDate");
        }
    }
}
