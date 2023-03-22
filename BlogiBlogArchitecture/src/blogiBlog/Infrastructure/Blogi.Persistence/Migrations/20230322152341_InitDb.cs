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
                name: "VisitorInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorInformation", x => x.Id);
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
                    CountOfView = table.Column<int>(type: "int", nullable: false),
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
                    CountOfView = table.Column<int>(type: "int", nullable: false),
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
                    MetaKeywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CountOfView = table.Column<int>(type: "int", nullable: false),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                values: new object[] { 1, "blogi@blog.com", "BlogiBlog", "smtp.gmail.com", "P8KyqfWtLmjDkWLgvoQcFwdCNt3Kk8ooqX5Pl8DxFt0p0YjYa5E+AS6b7SHUp9AY", 587, false, false });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Photo", "Surname" },
                values: new object[] { 1, "blogi@blog.com", "BLOGI", "UjGefTguKJsKJFeTv0e8Jj/Oo59djUw1xujNsTNFQb5KoqvwMZfG+2QUe8oh3plY", null, "BLOG" });

            migrationBuilder.InsertData(
                table: "WebSettings",
                columns: new[] { "Id", "Author", "FacebookUrl", "GithubUrl", "InstagramUrl", "IsDisplayFacebbokUrl", "IsDisplayGithubUrl", "IsDisplayInstagramUrl", "IsDisplayLinkedinUrl", "IsDisplayMediumUrl", "IsDisplayTwitterUrl", "IsDisplayYouTubeUrl", "LinkedinUrl", "MediumUrl", "MetaDescription", "MetaKeywords", "Slogan", "Title", "TwitterUrl", "WebSiteUrl", "YouTubeUrl" },
                values: new object[] { 1, "Adem Guney", "https://github.com/ademguney/BlogiBlog-MVC", "https://github.com/ademguney", "https://github.com/ademguney/BlogiBlog-MVC", true, true, true, true, true, true, true, "https://www.linkedin.com/in/ademguney/", "https://github.com/ademguney/BlogiBlog-MVC", "Blogi Blog open source multi language web blog project.", "open source, blogi blog, blogiblog, web project, multi language", "SEMICOLON, PRIME SUSPECT;", "Senior Software Developer Adem GUNEY", "https://twitter.com/AdemGuneyii", "https://www.guneyadem.com/", "https://www.youtube.com/@ademguney" });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Content", "CountOfView", "LanguageId", "MetaDescription", "MetaKeywords", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "Selamlar, Ben Adem!", 1, 1, "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.", "open source, blogi blog, blogiblog, web project, multi language", "hakkimda", "Yazilimci :) Adem GUNEY" },
                    { 2, "He, I'm Adem :)", 1, 2, "Blogi Blog open source multi language web blog project.", "open source, blogi blog, blogiblog, web project, multi language", "about-me", "Senior Software Developer Adem GUNEY" }
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
                columns: new[] { "Id", "Content", "CountOfView", "Email", "LanguageId", "Location", "MetaDescription", "MetaKeywords", "Phone", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "iletisim bilgilerim", 1, "guneyadem63@gmail.com", 1, "Turkiye", "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.", "open source, blogi blog, blogiblog, web project, multi language", "0090 (XXX) 000 00 00", "iletisim", "Gel Gel Ne Olursan Ol Yine Gel, Mevlana!" },
                    { 2, "my contact information", 1, "guneyadem63@gmail.com", 2, "Turkey", "Blogi Blog open source multi language web blog project.", "open source, blogi blog, blogiblog, web project, multi language", "0090 (XXX) 000 00 00", "contact", "Come, come, whoever you are, Jelaluddin Rumi!" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 1, "page_language_label_create_new_language", 1, "Yeni Dil Oluştur" },
                    { 2, "page_language_label_create_new_language", 2, "Create New Language" },
                    { 3, "page_language_button_delete", 1, "Sil" },
                    { 4, "page_language_button_delete", 2, "Delete" },
                    { 5, "page_language_button_update", 1, "Güncelle" },
                    { 6, "page_language_button_update", 2, "Update" },
                    { 7, "page_language_label_list", 1, "Dil Listesi" },
                    { 8, "page_language_label_list", 2, "Language List" },
                    { 9, "bread_crumb_home", 1, "Ana sayfa" },
                    { 10, "bread_crumb_home", 2, "Home" },
                    { 11, "bread_crumb_back_to_home", 1, "Ana sayfaya geri dön" },
                    { 12, "bread_crumb_back_to_home", 2, "Back to Home" },
                    { 13, "footer_description", 1, "Blogi Blog" },
                    { 14, "footer_description", 2, "footer" },
                    { 15, "datatable_default_label_update", 1, "Güncelle" },
                    { 16, "datatable_default_label_update", 2, "Update" },
                    { 17, "page_tag_label_tag_list", 1, "Etiket Listesi" },
                    { 18, "page_tag_label_tag_list", 2, "Tag List" },
                    { 19, "page_tag_label_create_new_tag", 1, "Yeni Etiket Oluştur" },
                    { 20, "page_tag_label_create_new_tag", 2, "Create New Tag" },
                    { 23, "datatable_default_label_tag_name", 1, "Etiket Adı" },
                    { 25, "page_default_back_to_list", 1, "Listeye geri dön" },
                    { 26, "page_default_back_to_list", 2, "Back to List" },
                    { 27, "page_default_label_home", 1, "Ana sayfa" },
                    { 28, "page_default_label_home", 2, "Home" },
                    { 29, "page_tag_label_language", 1, "Dil" },
                    { 30, "page_default_label_language", 2, "Language" },
                    { 31, "page_default_label_select_language", 1, "Dil Seçiniz" },
                    { 32, "page_default_label_select_language", 2, "Select Language" },
                    { 33, "page_tag_label_tag_name", 1, "Etiket Adı" },
                    { 34, "page_tag_label_tag_name", 2, "Tag Name" },
                    { 35, "page_default_button_create", 1, "Kaydet" },
                    { 36, "page_default_button_create", 2, "Create" },
                    { 37, "page_default_button_update", 1, "Güncelle" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 38, "page_default_button_update", 2, "Update" },
                    { 39, "page_category_label_category_list", 1, "Kategori Listesi" },
                    { 40, "page_category_label_category_list", 2, "Category List" },
                    { 41, "page_category_label_create_new_category", 1, "Yeni Kategori Oluştur" },
                    { 42, "page_category_label_create_new_category", 2, "Create New Category" },
                    { 43, "datatable_default_label_language", 1, "Dil" },
                    { 44, "datatable_default_label_language", 2, "Language" },
                    { 45, "datatable_default_label_category_name", 1, "Kategori Adı" },
                    { 46, "datatable_default_label_category_name", 2, "Category Name" },
                    { 47, "datatable_default_label_description", 1, "Açıklama" },
                    { 48, "datatable_default_label_description", 2, "Description" },
                    { 49, "datatable_default_label_slug", 1, "Seo Url" },
                    { 50, "datatable_default_label_slug", 2, "Slug" },
                    { 51, "page_category_label_category_name", 1, "Kategori Adı" },
                    { 52, "page_category_label_category_name", 2, "Category Name" },
                    { 53, "page_category_label_description", 1, "Açıklama" },
                    { 54, "page_category_label_description", 2, "Description" },
                    { 55, "page_default_label_slug", 1, "Seo Url" },
                    { 56, "datatable_default_label_tag_name", 2, "Tag Name" },
                    { 57, "datatable_default_label_delete", 1, "Sil" },
                    { 58, "datatable_default_label_delete", 2, "Delete" },
                    { 59, "page_default_label_language", 1, "Dil" },
                    { 60, "page_default_label_slug", 2, "Slug" },
                    { 61, "page_account_label_show_password", 1, "Şifreyi göster" },
                    { 62, "page_account_label_show_password", 2, "Show Password" },
                    { 63, "page_account_label_password", 1, "Parola" },
                    { 64, "page_account_label_password", 2, "Password" },
                    { 65, "page_account_label_email", 1, "Email" },
                    { 66, "page_account_label_email", 2, "Email" },
                    { 67, "page_account_label_surname", 1, "Soyad" },
                    { 68, "page_account_label_surname", 2, "Surname" },
                    { 69, "page_account_label_name", 1, "Ad" },
                    { 70, "page_account_label_name", 2, "Name" },
                    { 71, "top_menu_logout", 1, "Çıkış Yap" },
                    { 72, "top_menu_logout", 2, "Logout" },
                    { 73, "top_menu_profile", 1, "Hesabım" },
                    { 74, "top_menu_profile", 2, "Profile" },
                    { 75, "left_menu_label_blog", 1, "Blog" },
                    { 76, "left_menu_label_blog", 2, "Blog" },
                    { 77, "left_menu_label_post", 1, "Makaleler" },
                    { 78, "left_menu_label_post", 2, "Post" },
                    { 79, "left_menu_a_default_label_list", 1, "Liste" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 80, "left_menu_a_default_label_list", 2, "List" },
                    { 81, "left_menu_a_default_label_create", 1, "Oluştur" },
                    { 82, "left_menu_a_default_label_create", 2, "Create" },
                    { 83, "left_menu_label_mail_setting", 1, "Mail Ayarı" },
                    { 84, "left_menu_label_mail_setting", 2, "Mail Setting" },
                    { 85, "left_menu_a_mail_setting_configure", 1, "Yapılandır" },
                    { 86, "left_menu_a_mail_setting_configure", 2, "Configure" },
                    { 87, "left_menu_label_string_resource", 1, "Dil Detayları" },
                    { 88, "left_menu_label_string_resource", 2, "String Resource" },
                    { 89, "left_menu_label_language", 1, "Dil" },
                    { 90, "left_menu_label_language", 2, "Language" },
                    { 91, "left_menu_label_system_config", 1, "Sistem Ayarı" },
                    { 92, "left_menu_label_system_config", 2, "System Configuration" },
                    { 93, "left_menu_label_tag", 1, "Etiketler" },
                    { 94, "left_menu_label_tag", 2, "Tags" },
                    { 95, "left_menu_label_category", 1, "Kategoriler" },
                    { 96, "left_menu_label_category", 2, "Categories" },
                    { 97, "left_menu_label_comment", 1, "Yorumlar" },
                    { 98, "left_menu_label_comment", 2, "Comments" },
                    { 99, "page_login_label_welcome", 1, "Blogi Blog'a Hoş Geldiniz" },
                    { 100, "page_login_label_welcome", 2, "Welcome To Blogi Blog" },
                    { 101, "page_login_label_description", 1, "Blogi Blog açık kaynak kodlu birden fazla dili destekleyen web blog projesidir." },
                    { 102, "page_login_label_description", 2, "Blogi Blog is an open source web blog project that supports multiple languages." },
                    { 103, "page_login_label_login_title", 1, "Hesabınıza giriş yapın" },
                    { 104, "page_login_label_login_title", 2, "Login into your account" },
                    { 105, "page_login_label_keep_me", 1, "Oturumumu açık tut" },
                    { 106, "page_login_label_keep_me", 2, "Keep me logged in" },
                    { 107, "page_login_label_forgot_pass", 1, "Parolanızı mı unuttunuz ?" },
                    { 108, "page_login_label_forgot_pass", 2, "Forgot password ?" },
                    { 109, "page_login_button_login", 1, "Giriş Yap" },
                    { 110, "page_login_button_login", 2, "Login" },
                    { 111, "page_login_label_for_recover_pass", 1, "Şifrenizi kurtarmak için" },
                    { 112, "page_login_label_for_recover_pass", 2, "For recover your password" },
                    { 113, "page_login_button_send_mail", 1, "Bana email gönder" },
                    { 114, "page_login_button_send_mail", 2, "Send me Email" },
                    { 115, "page_mail_setting_label_host", 1, "Host" },
                    { 116, "page_mail_setting_label_host", 2, "Host" },
                    { 117, "page_mail_setting_label_port", 1, "Port" },
                    { 118, "page_mail_setting_label_port", 2, "Port" },
                    { 119, "page_mail_setting_label_full_name", 1, "Ad Soyad" },
                    { 120, "page_mail_setting_label_full_name", 2, "Name Surname" },
                    { 121, "page_mail_setting_label_mail", 1, "Email" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 122, "page_mail_setting_label_mail", 2, "Email" },
                    { 123, "page_mail_setting_label_password", 1, "Parola" },
                    { 124, "page_mail_setting_label_password", 2, "Password" },
                    { 125, "page_mail_setting_label_show_password", 1, "Parolayı Göster" },
                    { 126, "page_mail_setting_label_show_password", 2, "Show Password" },
                    { 127, "page_mail_setting_label_ssl_enable", 1, "SSL Etkin" },
                    { 128, "page_mail_setting_label_ssl_enable", 2, "SSL Enabled" },
                    { 129, "page_mail_setting_label_use_defaul_credentials", 1, "Varsayılan Kimlik Bilgilerini Kullan" },
                    { 130, "page_mail_setting_label_use_defaul_credentials", 2, "Use Default Credentials" },
                    { 131, "datatable_default_label_culture", 1, "Kod" },
                    { 132, "datatable_default_label_culture", 2, "Culture" },
                    { 133, "page_language_label_culture", 1, "Kod" },
                    { 134, "page_language_label_culture", 2, "Culture" },
                    { 135, "datatable_default_label_title", 1, "Başlık" },
                    { 136, "datatable_default_label_title", 2, "Title" },
                    { 137, "datatable_default_label__display_count", 1, "Görüntülenme Sayısı" },
                    { 138, "datatable_default_label__display_count", 2, "Display Count" },
                    { 139, "datatable_default_label_puslished", 1, "Yayınlandı mı?" },
                    { 140, "datatable_default_label_puslished", 2, "Is Published?" },
                    { 141, "datatable_default_label_creation_date", 1, "Oluşturulma Tarihi" },
                    { 142, "datatable_default_label_creation_date", 2, "Creation Date" },
                    { 143, "datatable_default_label_updation_date", 1, "Güncelleme Tarihi" },
                    { 144, "datatable_default_label_updation_date", 2, "Updation Date" },
                    { 145, "page_post_label_list", 1, "Makale Listesi" },
                    { 146, "page_post_label_list", 2, "Post List" },
                    { 147, "page_post_label_create_new_post", 1, "Yeni Makale Oluştur" },
                    { 148, "page_post_label_create_new_post", 2, "Create New Post" },
                    { 149, "page_post_label_header_image", 1, "Kapak Resmi" },
                    { 150, "page_post_label_header_image", 2, "Header Image" },
                    { 151, "page_post_label_image", 1, "Resim" },
                    { 152, "page_post_label_image", 2, "Image" },
                    { 153, "page_post_label_image_alt", 1, "Resim Açıklaması" },
                    { 154, "page_post_label_image_alt", 2, "Image Alt" },
                    { 155, "page_post_label_seo", 1, "SEO" },
                    { 156, "page_post_label_seo", 2, "SEO" },
                    { 157, "page_post_label_tags", 1, "Etiketler" },
                    { 158, "page_post_label_tags", 2, "Tags" },
                    { 159, "page_post_label_meta_keywords", 1, "Anahtar Kelimeler" },
                    { 160, "page_post_label_meta_keywords", 2, "Meta Keywords" },
                    { 161, "page_post_label_meta_description", 1, "Meta Açıklaması" },
                    { 162, "page_post_label_meta_description", 2, "Meta Description" },
                    { 163, "page_post_label_url", 1, "Seo Url" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 164, "page_post_label_url", 2, "Slug" },
                    { 165, "page_post_label_post", 1, "MAKALE" },
                    { 166, "page_post_label_post", 2, "POST" },
                    { 167, "page_default_label_category", 1, "Kategori" },
                    { 168, "page_default_label_category", 2, "Category" },
                    { 169, "page_default_label_select_category", 1, "Kategori Seç" },
                    { 170, "page_default_label_select_category", 2, "Select Category" },
                    { 171, "page_post_label_title", 1, "Makale Başlığı" },
                    { 172, "page_post_label_title", 2, "Post Title" },
                    { 173, "page_post_label_is_published", 1, "Yayınlansın mı?" },
                    { 174, "page_post_label_is_published", 2, "Is Published?" },
                    { 175, "datatable_default_label_answer", 1, "Cevapla" },
                    { 176, "datatable_default_label_answer", 2, "Answer" },
                    { 177, "datatable_default_label_email", 1, "Email" },
                    { 178, "datatable_default_label_email", 2, "Email" },
                    { 179, "datatable_default_label_name_surname", 1, "Ad Soyad" },
                    { 180, "datatable_default_label_name_surname", 2, "Name Surname" },
                    { 181, "page_comment_label_list", 1, "Yorum Listesi" },
                    { 182, "page_comment_label_list", 2, "Comment List" },
                    { 183, "blog_ui_navbar_home", 1, "Anasayfa" },
                    { 184, "blog_ui_navbar_home", 2, "Home" },
                    { 185, "blog_ui_navbar_about", 1, "Hakkımda" },
                    { 186, "blog_ui_navbar_about", 2, "About" },
                    { 187, "blog_ui_navbar_contact", 1, "İletişim" },
                    { 188, "blog_ui_navbar_contact", 2, "Contact" },
                    { 189, "blog_ui_category", 1, "Kategoriler" },
                    { 190, "blog_ui_category", 2, "Category" },
                    { 191, "blog_ui_popular_tags", 1, "Popüler Etiketler" },
                    { 192, "blog_ui_popular_tags", 2, "Popular Tags" },
                    { 193, "blog_ui_place_holder_search", 1, "Arama..." },
                    { 194, "blog_ui_place_holder_search", 2, "Search..." },
                    { 195, "blog_ui_articles", 1, "Makaleler" },
                    { 196, "blog_ui_articles", 2, "Articles" },
                    { 197, "blog_ui_blog_and_news", 1, "Blog & Makaleler" },
                    { 198, "blog_ui_blog_and_news", 2, "Blog & News" },
                    { 199, "blog_ui_follow_us", 1, "Bizi takip edin" },
                    { 200, "blog_ui_follow_us", 2, "Follow Us" },
                    { 201, "blog_ui_footer_title", 1, "Açık Kaynak, Birden Fazla Dil Destekleyen Blog Projesi" },
                    { 202, "blog_ui_footer_title", 2, " an Open Source Multi Language Blog Project" },
                    { 203, "blog_ui_contact_information", 1, "İletişim Bilgileri" },
                    { 204, "blog_ui_contact_information", 2, "Contact information" },
                    { 205, "blog_ui_contact_phone", 1, "Tel" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 206, "blog_ui_contact_phone", 2, "Phone" },
                    { 207, "blog_ui_contact_email", 1, "Email" },
                    { 208, "blog_ui_contact_email", 2, "Email" },
                    { 209, "blog_ui_contact_form", 1, "İletişim formu" },
                    { 210, "blog_ui_contact_form", 2, "Contact form" },
                    { 211, "blog_ui_contact_description", 1, "E-posta hesabınız yayımlanmayacak. Gerekli alanlar işaretlendi *" },
                    { 212, "blog_ui_contact_description", 2, "Your email address will not be published. Required fields are marked *" },
                    { 213, "left_menu_label_pages", 1, "Sayfalar" },
                    { 214, "left_menu_label_pages", 2, "Pages" },
                    { 215, "left_menu_label_about", 1, "Hakkımda" },
                    { 216, "left_menu_label_about", 2, "About" },
                    { 217, "left_menu_label_contact", 1, "İletişim" },
                    { 218, "left_menu_label_contact", 2, "Contact" },
                    { 219, "left_menu_label_web_settings", 1, "Web Ayarı" },
                    { 220, "left_menu_label_web_settings", 2, "Web Setting" },
                    { 221, "page_web_setting_label_show_linkedin", 1, "Linkedin Gösterilsin mi?" },
                    { 222, "page_web_setting_label_show_linkedin", 2, "Show Linkedin" },
                    { 223, "page_web_setting_label_show_github", 1, "Github Gösterilsin mi?" },
                    { 224, "page_web_setting_label_show_github", 2, "Show Github?" },
                    { 225, "page_web_setting_label_show_medium", 1, "Medium Gösterilsin mi?" },
                    { 226, "page_web_setting_label_show_medium", 2, "Show Medium?" },
                    { 227, "page_web_setting_label_show_youtube", 1, "YouTube Gösterilsin mi?" },
                    { 228, "page_web_setting_label_show_youtube", 2, "Show YouTube?" },
                    { 229, "page_web_setting_label_show_instagram", 1, "Instagram Gösterilsin mi?" },
                    { 230, "page_web_setting_label_show_instagram", 2, "Show Instagram?" },
                    { 231, "page_web_setting_label_show_twitter", 1, "Twitter Gösterilsin mi?" },
                    { 232, "page_web_setting_label_show_twitter", 2, "Show Twitter" },
                    { 233, "page_web_setting_label_show_facebook", 1, "Facebook Gösterilsin mi?" },
                    { 234, "page_web_setting_label_show_facebook", 2, "Show Facebook?" },
                    { 235, "page_web_setting_label_social_site_link", 1, "Sosyal Site Bağlantıları" },
                    { 236, "page_web_setting_label_social_site_link", 2, "Social Site Links" },
                    { 237, "page_web_setting_label_meta_configuration", 1, "Meta Yapılandırılmısı" },
                    { 238, "page_web_setting_label_meta_configuration", 2, "Meta Configuration" },
                    { 239, "page_web_setting_label_meta_description", 1, "Meta Açıklaması" },
                    { 240, "page_web_setting_label_meta_description", 2, "Meta Description" },
                    { 241, "page_web_setting_label_meta_keywords", 1, "Anahtar Kelimeler" },
                    { 242, "page_web_setting_label_meta_keywords", 2, "Meta Keywords" },
                    { 243, "page_web_setting_label_author", 1, "Yazar" },
                    { 244, "page_web_setting_label_author", 2, "Author" },
                    { 245, "page_web_setting_label_title", 1, "Başlık" },
                    { 246, "page_web_setting_label_title", 2, "Title" },
                    { 247, "page_contact_label_phone", 1, "Telefon" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "Key", "LanguageId", "Value" },
                values: new object[,]
                {
                    { 248, "page_contact_label_phone", 2, "Phone" },
                    { 249, "page_contact_label_location", 1, "Lokasyon" },
                    { 250, "page_contact_label_location", 2, "Location" },
                    { 251, "blog_ui_post_leave_comment", 1, "Yorum Yap" },
                    { 252, "blog_ui_post_leave_comment", 2, "Leave a Comment" },
                    { 253, "blog_ui_post_write_comment", 1, "Yorum Yaz..." },
                    { 254, "blog_ui_post_write_comment", 2, "Write Comment..." },
                    { 255, "blog_ui_post_name_surname", 1, "Ad Soyad" },
                    { 256, "blog_ui_post_name_surname", 2, "Name Surname" },
                    { 257, "blog_ui_post_email", 1, "Email" },
                    { 258, "blog_ui_post_email", 2, "Email" },
                    { 259, "blog_ui_post_post_comment", 1, "Yorumu Gönder" },
                    { 260, "blog_ui_post_post_comment", 2, "Post Comment" },
                    { 261, "blog_ui_post_comments", 1, "Yorumlar" },
                    { 262, "blog_ui_post_comments", 2, "Comments" },
                    { 263, "blog_ui_articles_count_comment", 1, "Yorum" },
                    { 264, "blog_ui_articles_count_comment", 2, "Comments" },
                    { 265, "blog_ui_articles_count_view", 1, "Görüntülenme" },
                    { 266, "blog_ui_articles_count_view", 2, "Views" },
                    { 267, "blog_ui_contact_send_message", 1, "Mesajı Gönder" },
                    { 268, "blog_ui_contact_send_message", 2, "Send Message" },
                    { 269, "blog_ui_post_reply", 1, "Cevapla" },
                    { 270, "blog_ui_post_reply", 2, "Reply" },
                    { 271, "page_home_label_read_article", 1, "Bu yıl en çok okunan 10 makale." },
                    { 272, "page_home_label_read_article", 2, "Top 10 most read articles this year." },
                    { 273, "page_home_label_count_of_tag", 1, "Etiket Sayısı" },
                    { 274, "page_home_label_count_of_tag", 2, "Count of Tag" },
                    { 275, "page_home_label_count_of_comment", 1, "Yorum Sayısı" },
                    { 276, "page_home_label_count_of_comment", 2, "Count of Comment" },
                    { 277, "page_home_label_count_of_category", 1, "Kategori Sayısı" },
                    { 278, "page_home_label_count_of_category", 2, "Count of Category" },
                    { 279, "page_home_label_count_of_article", 1, "Makale Sayısı" },
                    { 280, "page_home_label_count_of_article", 2, "Count of Article" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "LanguageId", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, 1, "Csharp", "c-sharp" },
                    { 2, 2, "Csharp", "c-sharp" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CountOfView", "CreatedById", "CreationDate", "Image", "ImageAlt", "IsPublished", "LanguageId", "MetaDescription", "MetaKeywords", "Slug", "Title", "UpdatedById", "UpdationDate", "UserId" },
                values: new object[] { 1, 1, "<h2 dir=\"auto\" style=\"text-align: center;\"tabindex=\"-1\">Blogi Blog Open Source Multi Language Blog Project</h2>\r\n<p>An Open-Source multi language blogging platform built with <strong>Onion Architecture</strong> In Asp.net Core MVC With <strong>CQRS</strong>.</p>\r\n<p>&nbsp;&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Used Technologies</h2>\r\n<ul dir=\"auto\">\r\n<li>CQRS</li>\r\n<li>.NET CORE 6</li>\r\n<li>SOLID Principles</li>\r\n<li>Asp.net Core MVC</li>\r\n<li>Repository Pattern</li>\r\n<li>MediatR version=\"11.0.0\"</li>\r\n<li>AutoMapper version=\"12.0.0\"</li>\r\n<li>FluentValidation version=\"11.2.2\"</li>\r\n<li>EntityFrameworkCore version=\"6.0.10\"</li>\r\n</ul>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Give a Star!</h2>\r\n<p>If you like or are using this project to learn or start your solution, please give it a star. Thanks!</p>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">License</h2>\r\n<p>This blog is open-sourced software licensed under the&nbsp;<a href=\"http://opensource.org/licenses/MIT\" rel=\"nofollow\">MIT license</a>.</p>", 1, 1, new DateTime(2023, 3, 22, 15, 23, 40, 991, DateTimeKind.Utc).AddTicks(6419), null, "blogiBlog", true, 1, "is an open source multi language blog project Blog BLOG", "blogiblog,open source, blog project", "blogi-blog-acik-kaynak", "Blogi Blog?", null, null, 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Content", "CountOfView", "CreatedById", "CreationDate", "Image", "ImageAlt", "IsPublished", "LanguageId", "MetaDescription", "MetaKeywords", "Slug", "Title", "UpdatedById", "UpdationDate", "UserId" },
                values: new object[] { 2, 1, "<h2 dir=\"auto\" style=\"text-align: center;\"tabindex=\"-1\">Blogi Blog Open Source Multi Language Blog Project</h2>\r\n<p>An Open-Source multi language blogging platform built with <strong>Onion Architecture</strong> In Asp.net Core MVC With <strong>CQRS</strong>.</p>\r\n<p>&nbsp;&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Used Technologies</h2>\r\n<ul dir=\"auto\">\r\n<li>CQRS</li>\r\n<li>.NET CORE 6</li>\r\n<li>SOLID Principles</li>\r\n<li>Asp.net Core MVC</li>\r\n<li>Repository Pattern</li>\r\n<li>MediatR version=\"11.0.0\"</li>\r\n<li>AutoMapper version=\"12.0.0\"</li>\r\n<li>FluentValidation version=\"11.2.2\"</li>\r\n<li>EntityFrameworkCore version=\"6.0.10\"</li>\r\n</ul>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Give a Star!</h2>\r\n<p>If you like or are using this project to learn or start your solution, please give it a star. Thanks!</p>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">License</h2>\r\n<p>This blog is open-sourced software licensed under the&nbsp;<a href=\"http://opensource.org/licenses/MIT\" rel=\"nofollow\">MIT license</a>.</p>", 1, 1, new DateTime(2023, 3, 22, 15, 23, 40, 991, DateTimeKind.Utc).AddTicks(6423), null, "blogiBlog", true, 2, "is an open source multi language blog project Blog BLOG", "blogiblog,open source, blog project", "blogi-blog-open-source", "Blogi Blog?", null, null, 1 });

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
                name: "VisitorInformation");

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
