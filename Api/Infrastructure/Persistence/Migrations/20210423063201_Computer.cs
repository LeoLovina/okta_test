using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Computer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modifier = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    DateTimeModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");
        }
    }
}
