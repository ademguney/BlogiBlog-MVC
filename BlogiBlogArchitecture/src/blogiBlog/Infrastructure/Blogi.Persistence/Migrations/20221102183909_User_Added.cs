using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogi.Persistence.Migrations
{
    public partial class User_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MailConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "blogi@blog.com", "MR5CPXT0HEfV7lpwCGEdhPQZlrbqXeUIWSAUS6Zn3eU2MCXPt8RScDGthtjzzBJQ" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Photo", "Surname" },
                values: new object[] { 1, "blogi@blog.com", "BLOGI", "BfcAugaoDnosJfiD02Xoqxagd2YPBlsseVxwfpkYjReWnOIwt9x9ZnZFSsOP3Kmc", null, "BLOG" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "MailConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "blogi_blog@gmail.com", "EHPjrx047JJP7qSKThZ3v1vC1t+rxCsoqHj8M12uPXf6MxMTmNWJhqUZpICrKkKJ" });
        }
    }
}
