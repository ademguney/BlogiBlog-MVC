using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogi.Persistence.Migrations
{
    public partial class Tag_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "MailConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "edH3YTav2q/sjbIGo8yirB8H1+FPjzdjqW+6hW+ZWUjWTDPjzlco8GDOreEJp6K9");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Csharp" },
                    { 3, "SQL" },
                    { 4, "JavaScript" },
                    { 5, "Html" },
                    { 6, "Css" },
                    { 7, "Vue" },
                    { 8, "Angular" },
                    { 9, "React" },
                    { 10, "Design Pattern" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.UpdateData(
                table: "MailConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "Zci5rfPjWMrks1rK4ECRsvrRCYUZnTSCVxsQtK+QaAXgRmUQmZFBB0SlPi5GKOlW");
        }
    }
}
