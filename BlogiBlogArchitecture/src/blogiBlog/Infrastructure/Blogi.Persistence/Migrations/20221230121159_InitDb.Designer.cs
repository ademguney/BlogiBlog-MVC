﻿// <auto-generated />
using System;
using Blogi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogi.Persistence.Migrations
{
    [DbContext(typeof(BlogiBlogDbContext))]
    [Migration("20221230121159_InitDb")]
    partial class InitDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Blogi.Domain.Entities.About", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaKeywords")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Abouts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Selamlar, Ben Adem!",
                            LanguageId = 1,
                            MetaDescription = "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.",
                            MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language",
                            Slug = "hakkimda",
                            Title = "Yazilimci :) Adem GUNEY"
                        },
                        new
                        {
                            Id = 2,
                            Content = "He, I'm Adem :)",
                            LanguageId = 2,
                            MetaDescription = "Blogi Blog open source multi language web blog project.",
                            MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language",
                            Slug = "about-me",
                            Title = "Senior Software Developer Adem GUNEY"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "asp.net core mvc",
                            LanguageId = 1,
                            Name = ".Net Core",
                            Slug = "net-core"
                        },
                        new
                        {
                            Id = 2,
                            Description = "asp.net core mvc",
                            LanguageId = 2,
                            Name = ".Net Core",
                            Slug = "net-core"
                        },
                        new
                        {
                            Id = 3,
                            Description = "solid principles",
                            LanguageId = 1,
                            Name = "Design Pattern",
                            Slug = "design-pattern"
                        },
                        new
                        {
                            Id = 4,
                            Description = "solid principles",
                            LanguageId = 2,
                            Name = "Design Pattern",
                            Slug = "design-pattern"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsPublish")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments", (string)null);
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaKeywords")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Contacts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "iletisim bilgilerim",
                            Email = "guneyadem63@gmail.com",
                            LanguageId = 1,
                            Location = "Turkiye/SanliUrfa",
                            MetaDescription = "Blogi Blog acik kaynak kodlu cok dil destegi bulunan web blog projesidir.",
                            MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language",
                            Phone = "0090 (XXX) 000 00 00",
                            Slug = "iletisim",
                            Title = "Gel Gel Ne Olursan Ol Yine Gel, Mevlana!"
                        },
                        new
                        {
                            Id = 2,
                            Content = "my contact information",
                            Email = "guneyadem63@gmail.com",
                            LanguageId = 2,
                            Location = "Turkey/SanliUrfa",
                            MetaDescription = "Blogi Blog open source multi language web blog project.",
                            MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language",
                            Phone = "0090 (XXX) 000 00 00",
                            Slug = "contact",
                            Title = "Come, come, whoever you are, Jelaluddin Rumi!"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Culture = "tr-TR",
                            Name = "Turkish"
                        },
                        new
                        {
                            Id = 2,
                            Culture = "en-US",
                            Name = "English"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.MailSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("SslEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("UseDefaultCredentials")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("MailConfigs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "blogi@blog.com",
                            FullName = "BlogiBlog",
                            Host = "smtp.gmail.com",
                            Password = "sSFUaY25ArFeHs6ttu+RFCh37T0pXL8OzuGyrpLFhUrEzcttjL+EL+K/5F/+CaG0",
                            Port = 587,
                            SslEnabled = false,
                            UseDefaultCredentials = false
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageAlt")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaKeywords")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Content = "Blogi blog an open source project.",
                            CreatedById = 1,
                            CreationDate = new DateTime(2022, 12, 30, 12, 11, 58, 864, DateTimeKind.Utc).AddTicks(7301),
                            ImageAlt = "blogiBlog",
                            IsPublished = true,
                            LanguageId = 1,
                            MetaDescription = "is an open source multi language blog project Blog BLOG",
                            MetaKeywords = "blogiblog,open source, blog project",
                            Slug = "test-content",
                            Title = "Multi Language Blogi Blog",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.PostTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags", (string)null);
                });

            modelBuilder.Entity("Blogi.Domain.Entities.StringResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("StringResources", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Key = "page_language_button_create",
                            LanguageId = 1,
                            Value = "Yeni Dil Oluştur"
                        },
                        new
                        {
                            Id = 2,
                            Key = "page_language_button_create",
                            LanguageId = 2,
                            Value = "Create New Language"
                        },
                        new
                        {
                            Id = 3,
                            Key = "page_language_button_delete",
                            LanguageId = 1,
                            Value = "Sil"
                        },
                        new
                        {
                            Id = 4,
                            Key = "page_language_button_delete",
                            LanguageId = 2,
                            Value = "Delete"
                        },
                        new
                        {
                            Id = 5,
                            Key = "page_language_button_update",
                            LanguageId = 1,
                            Value = "Güncelle"
                        },
                        new
                        {
                            Id = 6,
                            Key = "page_language_button_update",
                            LanguageId = 2,
                            Value = "Update"
                        },
                        new
                        {
                            Id = 7,
                            Key = "page_language_label_list",
                            LanguageId = 1,
                            Value = "Dil Listesi"
                        },
                        new
                        {
                            Id = 8,
                            Key = "page_language_label_list",
                            LanguageId = 2,
                            Value = "Language List"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Tags", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 1,
                            Name = "Csharp",
                            Slug = "c-sharp"
                        },
                        new
                        {
                            Id = 2,
                            LanguageId = 2,
                            Name = "Csharp",
                            Slug = "c-sharp"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "blogi@blog.com",
                            Name = "BLOGI",
                            Password = "c3G8C3H2/hjcWX3MkWEyS0oENDxON2dLAqCC46P5c4hybW7HP1W8WU/qxkxQqPWe",
                            Surname = "BLOG"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.WebSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("FacebookUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("GithubUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("InstagramUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsDisplayFacebbokUrl")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisplayGithubUrl")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisplayInstagramUrl")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisplayLinkedinUrl")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisplayMediumUrl")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisplayTwitterUrl")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDisplayYouTubeUrl")
                        .HasColumnType("bit");

                    b.Property<string>("LinkedinUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MediumUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("MetaKeywords")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Slogan")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Title")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TwitterUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("WebSiteUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("YouTubeUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("WebSettings", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Adem Guney",
                            FacebookUrl = "https://github.com/ademguney/BlogiBlog-MVC",
                            GithubUrl = "https://github.com/ademguney",
                            InstagramUrl = "https://github.com/ademguney/BlogiBlog-MVC",
                            IsDisplayFacebbokUrl = true,
                            IsDisplayGithubUrl = true,
                            IsDisplayInstagramUrl = true,
                            IsDisplayLinkedinUrl = true,
                            IsDisplayMediumUrl = true,
                            IsDisplayTwitterUrl = true,
                            IsDisplayYouTubeUrl = true,
                            LinkedinUrl = "https://www.linkedin.com/in/ademguney/",
                            MediumUrl = "https://github.com/ademguney/BlogiBlog-MVC",
                            MetaDescription = "Blogi Blog open source multi language web blog project.",
                            MetaKeywords = "open source, blogi blog, blogiblog, web project, multi language",
                            Slogan = "SEMICOLON, PRIME SUSPECT;",
                            Title = "Senior Software Developer Adem GUNEY",
                            TwitterUrl = "https://twitter.com/AdemGuneyii",
                            WebSiteUrl = "https://www.guneyadem.com/",
                            YouTubeUrl = "https://www.youtube.com/@ademguney"
                        });
                });

            modelBuilder.Entity("Blogi.Domain.Entities.About", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Language", "Languages")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Category", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Language", "Languages")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Comment", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Post", "Posts")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Contact", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Language", "Languages")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Post", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Category", "Categories")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blogi.Domain.Entities.Language", "Languages")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Blogi.Domain.Entities.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Languages");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.PostTags", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Post", null)
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Blogi.Domain.Entities.Tag", "Tags")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.StringResource", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Language", "Languages")
                        .WithMany("StringResources")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Tag", b =>
                {
                    b.HasOne("Blogi.Domain.Entities.Language", "Languages")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Languages");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Category", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Language", b =>
                {
                    b.Navigation("StringResources");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostTags");
                });

            modelBuilder.Entity("Blogi.Domain.Entities.Tag", b =>
                {
                    b.Navigation("PostTags");
                });
#pragma warning restore 612, 618
        }
    }
}