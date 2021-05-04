using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class SetupRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PingId",
                table: "Computers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PingId",
                table: "Computers",
                column: "PingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Pings_PingId",
                table: "Computers",
                column: "PingId",
                principalTable: "Pings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Pings_PingId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_PingId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "PingId",
                table: "Computers");
        }
    }
}
