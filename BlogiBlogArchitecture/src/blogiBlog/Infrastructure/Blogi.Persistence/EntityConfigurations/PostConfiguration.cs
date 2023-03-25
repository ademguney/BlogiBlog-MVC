namespace Blogi.Persistence.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(u => u.UserId);
            builder.Property(u => u.LanguageId);
            builder.Property(u => u.CategoryId);
            builder.Property(u => u.Title).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Content).IsRequired(true);
            builder.Property(u => u.Slug).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.Image).IsRequired(false);
            builder.Property(u => u.ImageAlt).IsRequired(true).HasMaxLength(255);           
            builder.Property(u => u.IsPublished).IsRequired(true);
            builder.Property(u => u.MetaKeywords).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.MetaDescription).IsRequired(true).HasMaxLength(500);
            builder.Property(u => u.UpdatedById).IsRequired(false);
            builder.Property(u => u.CreatedById).IsRequired(true);
            builder.Property(i => i.CreationDate).IsRequired(true);
            builder.Property(i => i.UpdationDate).IsRequired(false);


            builder.HasOne(u => u.Users);
            builder.HasOne(u => u.Categories);
            builder.HasOne(u => u.Languages).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.PostTags).WithOne().OnDelete(DeleteBehavior.Restrict).HasForeignKey(x=>x.PostId);
            builder.HasMany(u => u.Comments).WithOne(x => x.Posts).OnDelete(DeleteBehavior.Restrict).HasForeignKey(x => x.PostId);

            builder.HasData(
                new Post
                {
                    Id = 1,
                    LanguageId = 1,
                    CategoryId = 1,
                    UserId = 1,
                    Title = "Blogi Blog, Nedir?",
                    Content = "<h2 dir=\"auto\" style=\"text-align: center;\"tabindex=\"-1\">Blogi Blog Open Source Multi Language Blog Project</h2>\r\n<p>An Open-Source multi language blogging platform built with <strong>Onion Architecture</strong> In Asp.net Core MVC With <strong>CQRS</strong>.</p>\r\n<p>&nbsp;&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Used Technologies</h2>\r\n<ul dir=\"auto\">\r\n<li>CQRS</li>\r\n<li>.NET CORE 6</li>\r\n<li>SOLID Principles</li>\r\n<li>Asp.net Core MVC</li>\r\n<li>Repository Pattern</li>\r\n<li>MediatR version=\"11.0.0\"</li>\r\n<li>AutoMapper version=\"12.0.0\"</li>\r\n<li>FluentValidation version=\"11.2.2\"</li>\r\n<li>EntityFrameworkCore version=\"6.0.10\"</li>\r\n</ul>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Give a Star!</h2>\r\n<p>If you like or are using this project to learn or start your solution, please give it a star. Thanks!</p>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">License</h2>\r\n<p>This blog is open-sourced software licensed under the&nbsp;<a href=\"http://opensource.org/licenses/MIT\" rel=\"nofollow\">MIT license</a>.</p>",
                    Slug = "blogi-blog-acik-kaynak",
                    Image = null,
                    ImageAlt = "blogiBlog",                   
                    MetaKeywords = "blogiblog,open source, blog project",
                    MetaDescription = "is an open source multi language blog project Blog BLOG",
                    CountOfView = 1,
                    IsPublished = true,
                    CreatedById = 1,
                    CreationDate = DateTime.UtcNow

                },
                 new Post
                 {
                     Id = 2,
                     LanguageId = 2,
                     CategoryId = 1,
                     UserId = 1,
                     Title = "Blogi Blog?",
                     Content = "<h2 dir=\"auto\" style=\"text-align: center;\"tabindex=\"-1\">Blogi Blog Open Source Multi Language Blog Project</h2>\r\n<p>An Open-Source multi language blogging platform built with <strong>Onion Architecture</strong> In Asp.net Core MVC With <strong>CQRS</strong>.</p>\r\n<p>&nbsp;&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Used Technologies</h2>\r\n<ul dir=\"auto\">\r\n<li>CQRS</li>\r\n<li>.NET CORE 6</li>\r\n<li>SOLID Principles</li>\r\n<li>Asp.net Core MVC</li>\r\n<li>Repository Pattern</li>\r\n<li>MediatR version=\"11.0.0\"</li>\r\n<li>AutoMapper version=\"12.0.0\"</li>\r\n<li>FluentValidation version=\"11.2.2\"</li>\r\n<li>EntityFrameworkCore version=\"6.0.10\"</li>\r\n</ul>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">Give a Star!</h2>\r\n<p>If you like or are using this project to learn or start your solution, please give it a star. Thanks!</p>\r\n<p>&nbsp;</p>\r\n<h2 dir=\"auto\" tabindex=\"-1\">License</h2>\r\n<p>This blog is open-sourced software licensed under the&nbsp;<a href=\"http://opensource.org/licenses/MIT\" rel=\"nofollow\">MIT license</a>.</p>",
                     Slug = "blogi-blog-open-source",
                     Image = null,
                     ImageAlt = "blogiBlog",
                     MetaKeywords = "blogiblog,open source, blog project",
                     MetaDescription = "is an open source multi language blog project Blog BLOG",
					 CountOfView = 1,
					 IsPublished = true,
                     CreatedById = 1,
                     CreationDate = DateTime.UtcNow

                 });
        }
    }
}
