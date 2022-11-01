﻿// <auto-generated />
using Blogi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blogi.Persistence.Migrations
{
    [DbContext(typeof(BlogiBlogDbContext))]
    partial class BlogiBlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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
                            Name = "Türkçe"
                        },
                        new
                        {
                            Id = 2,
                            Culture = "en-ENG",
                            Name = "English (United States)"
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
                            Email = "blogi_blog@gmail.com",
                            FullName = "BlogiBlog",
                            Host = "smtp.gmail.com",
                            Password = "69uWlKOKMmaRsiCn+cNEbWCk+9WX7n+3cMscCZL3dPAcSipNFwmjYlf7MOrGXTbG",
                            Port = 587,
                            SslEnabled = false,
                            UseDefaultCredentials = false
                        });
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
                            Value = "Dil listesi..."
                        },
                        new
                        {
                            Id = 8,
                            Key = "page_language_label_list",
                            LanguageId = 2,
                            Value = "Language list..."
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

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Tags", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 2,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            LanguageId = 2,
                            Name = "Csharp"
                        },
                        new
                        {
                            Id = 3,
                            LanguageId = 2,
                            Name = "SQL"
                        },
                        new
                        {
                            Id = 4,
                            LanguageId = 2,
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = 5,
                            LanguageId = 2,
                            Name = "Html"
                        },
                        new
                        {
                            Id = 6,
                            LanguageId = 2,
                            Name = "Css"
                        },
                        new
                        {
                            Id = 7,
                            LanguageId = 2,
                            Name = "Vue"
                        },
                        new
                        {
                            Id = 8,
                            LanguageId = 2,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 9,
                            LanguageId = 2,
                            Name = "React"
                        },
                        new
                        {
                            Id = 10,
                            LanguageId = 2,
                            Name = "Design Pattern"
                        },
                        new
                        {
                            Id = 11,
                            LanguageId = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 12,
                            LanguageId = 1,
                            Name = "Csharp"
                        },
                        new
                        {
                            Id = 13,
                            LanguageId = 1,
                            Name = "SQL"
                        },
                        new
                        {
                            Id = 14,
                            LanguageId = 1,
                            Name = "JavaScript"
                        },
                        new
                        {
                            Id = 15,
                            LanguageId = 1,
                            Name = "Html"
                        },
                        new
                        {
                            Id = 16,
                            LanguageId = 1,
                            Name = "Css"
                        },
                        new
                        {
                            Id = 17,
                            LanguageId = 1,
                            Name = "Vue"
                        },
                        new
                        {
                            Id = 18,
                            LanguageId = 1,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 19,
                            LanguageId = 1,
                            Name = "React"
                        },
                        new
                        {
                            Id = 20,
                            LanguageId = 1,
                            Name = "Design Pattern"
                        });
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

            modelBuilder.Entity("Blogi.Domain.Entities.Language", b =>
                {
                    b.Navigation("StringResources");
                });
#pragma warning restore 612, 618
        }
    }
}
