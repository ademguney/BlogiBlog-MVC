using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogi.Persistence.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Host = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SslEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UseDefaultCredentials = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailConfigs", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StringResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringResources_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageAlt = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DisplayCount = table.Column<int>(type: "int", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture", "Name" },
                values: new object[,]
                {
                    { 1, "tr-TR", "Türkçe" },
                    { 2, "en-ENG", "English (United States)" }
                });

            migrationBuilder.InsertData(
                table: "MailConfigs",
                columns: new[] { "Id", "Email", "FullName", "Host", "Password", "Port", "SslEnabled", "UseDefaultCredentials" },
                values: new object[] { 1, "blogi@blog.com", "BlogiBlog", "smtp.gmail.com", "HsXmu9qftDs5Fy1u+Bo0VarB768HDmePGDVlrh/PGMNCKHh0k9zMrILBN0V5vfjB", 587, false, false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Photo", "Surname" },
                values: new object[] { 1, "blogi@blog.com", "BLOGI", "c3ZEPQeWmJ/L5jqWgLVZ8WMOlm74QhrMDK8NFiycjRXPRYLVJvOniHlR4Ti7cORK", null, "BLOG" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "LanguageId", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "asp.net core mvc", 1, ".Net Core", "net-core" },
                    { 2, "asp.net core mvc", 2, ".Net Core", "net-core" },
                    { 3, "solid principles", 1, "Design Pattern", "design-pattern" },
                    { 4, "solid principles", 2, "Design Pattern", "design-pattern" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 1, "page_language_button_create", 1, "Yeni Dil Oluştur" },
                    { 2, "page_language_button_create", 2, "Create New Language" },
                    { 3, "page_language_button_delete", 1, "Sil" },
                    { 4, "page_language_button_delete", 2, "Delete" },
                    { 5, "page_language_button_update", 1, "Güncelle" },
                    { 6, "page_language_button_update", 2, "Update" },
                    { 7, "page_language_label_list", 1, "Dil listesi..." },
                    { 8, "page_language_label_list", 2, "Language list..." }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "C#" },
                    { 2, 2, "Csharp" },
                    { 3, 2, "SQL" },
                    { 4, 2, "JavaScript" },
                    { 5, 2, "Html" },
                    { 6, 2, "Css" },
                    { 7, 2, "Vue" },
                    { 8, 2, "Angular" },
                    { 9, 2, "React" },
                    { 10, 2, "Design Pattern" },
                    { 11, 1, "C#" },
                    { 12, 1, "Csharp" },
                    { 13, 1, "SQL" },
                    { 14, 1, "JavaScript" },
                    { 15, 1, "Html" },
                    { 16, 1, "Css" },
                    { 17, 1, "Vue" },
                    { 18, 1, "Angular" },
                    { 19, 1, "React" },
                    { 20, 1, "Design Pattern" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedById", "CreationTime", "DisplayCount", "Image", "ImageAlt", "IsPublished", "LanguageId", "MetaDescription", "MetaKeywords", "Slug", "Title", "UserId" },
                values: new object[] { 1, 1, "Test_Content", 1, new DateTime(2022, 11, 7, 17, 15, 36, 118, DateTimeKind.Utc).AddTicks(7807), 0, null, "blogiBlog", true, 1, "is an open source multi language blog project Blog BLOG", "blogiblog,open source, blog project", "test-content", "Test_Title", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LanguageId",
                table: "Categories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LanguageId",
                table: "Posts",
                column: "LanguageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_StringResources_LanguageId",
                table: "StringResources",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_LanguageId",
                table: "Tags",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailConfigs");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "StringResources");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
