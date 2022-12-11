using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogi.Persistence.Migrations
{
    public partial class InitDb : Migration
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
                name: "WebSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacebookUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    YouTubeUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MediumUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GithubUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsDisplayFacebbokUrl = table.Column<bool>(type: "bit", nullable: false),
                    IsDisplayTwitterUrl = table.Column<bool>(type: "bit", nullable: false),
                    IsDisplayInstagramUrl = table.Column<bool>(type: "bit", nullable: false),
                    IsDisplayYouTubeUrl = table.Column<bool>(type: "bit", nullable: false),
                    IsDisplayMediumUrl = table.Column<bool>(type: "bit", nullable: false),
                    IsDisplayGithubUrl = table.Column<bool>(type: "bit", nullable: false),
                    IsDisplayLinkedinUrl = table.Column<bool>(type: "bit", nullable: false),
                    WebSiteUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abouts_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Languages_LanguageId",
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
                    Name = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublish = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, "tr-TR", "Turkish" },
                    { 2, "en-US", "English" }
                });

            migrationBuilder.InsertData(
                table: "MailConfigs",
                columns: new[] { "Id", "Email", "FullName", "Host", "Password", "Port", "SslEnabled", "UseDefaultCredentials" },
                values: new object[] { 1, "blogi@blog.com", "BlogiBlog", "smtp.gmail.com", "x4Bv5taY+v4UUtPqaOt56StJ+XfYx52OE7voN3H7ByBVe8kvdyoTNj1113AQgre2", 587, false, false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Photo", "Surname" },
                values: new object[] { 1, "blogi@blog.com", "BLOGI", "jUmK8bJpansi0tu9lJS/DYFdqvAcwoD6HSk2P22T6LqObXG8oJ7YlV81OYrTy/mh", null, "BLOG" });

            migrationBuilder.InsertData(
                table: "WebSettings",
                columns: new[] { "Id", "Author", "FacebookUrl", "GithubUrl", "InstagramUrl", "IsDisplayFacebbokUrl", "IsDisplayGithubUrl", "IsDisplayInstagramUrl", "IsDisplayLinkedinUrl", "IsDisplayMediumUrl", "IsDisplayTwitterUrl", "IsDisplayYouTubeUrl", "LinkedinUrl", "MediumUrl", "MetaDescription", "MetaKeywords", "Slogan", "Title", "TwitterUrl", "WebSiteUrl", "YouTubeUrl" },
                values: new object[] { 1, "Adem Guney", "https://github.com/ademguney/BlogiBlog-MVC", "https://github.com/ademguney", "https://github.com/ademguney/BlogiBlog-MVC", true, true, true, true, true, true, true, "https://www.linkedin.com/in/ademguney/", "https://github.com/ademguney/BlogiBlog-MVC", "Blogi Blog open source multi language web blog project.", "open source, blogi blog, blogiblog, web project, multi language", "SEMICOLON, PRIME SUSPECT;", "Senior Software Developer Adem GUNEY", "https://twitter.com/AdemGuneyii", "https://www.guneyadem.com/", "https://www.youtube.com/@ademguney" });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "LanguageId", "MetaDescription", "MetaKeywords", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "Selamlar, Ben Adem!", 1, "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.", "open source, blogi blog, blogiblog, web project, multi language", "hakkimda", "Yazilimci :) Adem GUNEY" },
                    { 2, "He, I'm Adem :)", 2, "Blogi Blog open source multi language web blog project.", "open source, blogi blog, blogiblog, web project, multi language", "about-me", "Senior Software Developer Adem GUNEY" }
                });

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
                table: "Contacts",
                columns: new[] { "Id", "Content", "Email", "LanguageId", "Location", "MetaDescription", "MetaKeywords", "Phone", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "iletisim bilgilerim", "guneyadem63@gmail.com", 1, "Turkiye/SanliUrfa", "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.", "open source, blogi blog, blogiblog, web project, multi language", "0090 (XXX) 000 00 00", "iletisim", "Gel Gel Ne Olursan Ol Yine Gel, Mevlana!" },
                    { 2, "my contact information", "guneyadem63@gmail.com", 2, "Turkey/SanliUrfa", "Blogi Blog open source multi language web blog project.", "open source, blogi blog, blogiblog, web project, multi language", "0090 (XXX) 000 00 00", "contact", "Come, come, whoever you are, Jelaluddin Rumi!" }
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
                    { 7, "page_language_label_list", 1, "Dil Listesi" },
                    { 8, "page_language_label_list", 2, "Language List" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "LanguageId", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, 2, "Csharp", "c-sharp" },
                    { 2, 2, "Csharp", "c-sharp" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedById", "CreationDate", "DisplayCount", "Image", "ImageAlt", "IsPublished", "LanguageId", "MetaDescription", "MetaKeywords", "Slug", "Title", "UpdatedById", "UpdationDate", "UserId" },
                values: new object[] { 1, 1, "Blogi blog an open source project.", 1, new DateTime(2022, 12, 11, 9, 31, 46, 956, DateTimeKind.Utc).AddTicks(6537), 0, null, "blogiBlog", true, 1, "is an open source multi language blog project Blog BLOG", "blogiblog,open source, blog project", "test-content", "Multi Language Blogi Blog", null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_LanguageId",
                table: "Abouts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LanguageId",
                table: "Categories",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostsId",
                table: "Comments",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LanguageId",
                table: "Contacts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_LanguageId",
                table: "Posts",
                column: "LanguageId");

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
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "MailConfigs");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "StringResources");

            migrationBuilder.DropTable(
                name: "WebSettings");

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
