using Blog_App.Data;
using Blog_App.Models;

namespace Blog_App.Seeders
{
    public class BlogSeeder
    {
        public static void SeedBlogPosts(ApplicationDbContext context)
        {
            if(context.BlogPosts.Any())
            {
                return; // DB has been seeded
            }
            var posts = new List<BlogPost>
            {
                new BlogPost
                {
                    Title = "Getting Started with ASP.NET Core",
                    Content = "ASP.NET Core is a cross-platform, high-performance framework for building modern web applications. In this article, we'll explore the fundamentals of ASP.NET Core and how to get started with building your first web application. We'll cover topics like MVC pattern, dependency injection, and middleware.",
                    Author = "Ahmed Mohamed",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new BlogPost
                {
                    Title = "Understanding Entity Framework Core",
                    Content = "Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations. In this post, we'll dive deep into EF Core features and best practices for working with databases in your .NET applications.",
                    Author = "Sara Ali",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new BlogPost
                {
                    Title = "Best Practices for Clean Code",
                    Content = "Writing clean, maintainable code is essential for any software project. This article covers important principles like SOLID, DRY, and KISS. We'll also discuss naming conventions, code organization, and how to write code that other developers will thank you for.",
                    Author = "Omar Hassan",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new BlogPost
                {
                    Title = "Introduction to Dependency Injection",
                    Content = "Dependency Injection is a design pattern that helps create loosely coupled code. It's a core feature of ASP.NET Core and makes your applications more testable and maintainable. Learn how to leverage DI to build better applications.",
                    Author = "Fatima Ibrahim",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new BlogPost
                {
                    Title = "Building RESTful APIs with .NET",
                    Content = "REST APIs are the backbone of modern web applications. In this comprehensive guide, we'll learn how to build robust, scalable RESTful APIs using ASP.NET Core. Topics include routing, HTTP methods, status codes, and API versioning.",
                    Author = "Khaled Mahmoud",
                    CreatedAt = DateTime.Now
                }

            };
            context.BlogPosts.AddRange(posts);
            context.SaveChanges();
        }
    }
}
