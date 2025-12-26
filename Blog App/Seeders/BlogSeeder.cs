using Blog_App.Data;
using Blog_App.Models;

namespace Blog_App.Seeders
{
    public static class BlogSeeder
    {
        public static void SeedBlogPosts(ApplicationDbContext context)
        {
            // لو فيه بيانات مش هنضيف تاني
            if (context.BlogPosts.Any())
            {
                return;
            }

            var posts = new List<BlogPost>
            {
                // Technology Posts
                new BlogPost
                {
                    Title = "Getting Started with ASP.NET Core",
                    Content = "ASP.NET Core is a cross-platform, high-performance framework for building modern web applications. In this comprehensive guide, we'll explore the fundamentals of ASP.NET Core and how to get started with building your first web application. We'll cover topics like MVC pattern, dependency injection, middleware, and routing. ASP.NET Core provides a clean and modular architecture that makes it easy to build maintainable applications. The framework supports both Windows and Linux platforms, making it versatile for various deployment scenarios. With built-in support for modern development practices like dependency injection and configuration management, ASP.NET Core has become the go-to choice for enterprise applications.",
                    Author = "Ahmed Mohamed",
                    CreatedAt = DateTime.Now.AddDays(-30)
                },
                new BlogPost
                {
                    Title = "Understanding Entity Framework Core",
                    Content = "Entity Framework Core is a modern object-database mapper for .NET applications. It supports LINQ queries, change tracking, updates, and schema migrations. In this post, we'll dive deep into EF Core features and best practices for working with databases in your .NET applications. We'll explore code-first and database-first approaches, understand how to configure relationships between entities, and learn about performance optimization techniques. Entity Framework Core offers a powerful abstraction over database operations, allowing developers to work with data using strongly-typed C# objects. We'll also discuss common pitfalls and how to avoid them when working with EF Core in production environments.",
                    Author = "Sara Ali",
                    CreatedAt = DateTime.Now.AddDays(-28)
                },
                new BlogPost
                {
                    Title = "Modern JavaScript ES6+ Features",
                    Content = "JavaScript has evolved significantly with ES6 and beyond. Let's explore modern features like arrow functions, destructuring, async/await, modules, and more. These features make JavaScript code more readable, maintainable, and powerful. Arrow functions provide a concise syntax for writing functions, while destructuring allows elegant extraction of values from objects and arrays. The async/await pattern simplifies asynchronous programming, making code easier to read and debug. Template literals, spread operators, and optional chaining are just a few of the many features that have transformed JavaScript development. Understanding these modern features is essential for any JavaScript developer working on contemporary web applications.",
                    Author = "Omar Hassan",
                    CreatedAt = DateTime.Now.AddDays(-25)
                },
                new BlogPost
                {
                    Title = "Introduction to Docker Containers",
                    Content = "Docker has revolutionized application deployment by introducing containerization. Learn how to containerize your applications, create Docker images, and orchestrate containers using Docker Compose. Containers provide consistent environments across development, testing, and production, eliminating the 'it works on my machine' problem. We'll explore Docker architecture, understand the difference between images and containers, and learn best practices for writing Dockerfiles. Docker Compose allows you to define and run multi-container applications, making it easier to manage complex microservices architectures. By the end of this guide, you'll be able to containerize your own applications and deploy them with confidence.",
                    Author = "Fatima Ibrahim",
                    CreatedAt = DateTime.Now.AddDays(-23)
                },
                new BlogPost
                {
                    Title = "Building RESTful APIs with .NET",
                    Content = "REST APIs are the backbone of modern web applications. In this comprehensive guide, we'll learn how to build robust, scalable RESTful APIs using ASP.NET Core. We'll cover routing, HTTP methods, status codes, API versioning, authentication, and authorization. A well-designed API follows REST principles, uses appropriate HTTP verbs, and returns meaningful status codes. We'll implement CRUD operations, add input validation, handle errors gracefully, and secure our API using JWT tokens. Documentation is crucial for APIs, so we'll also integrate Swagger for automatic API documentation. Performance considerations like caching and rate limiting will also be discussed to ensure your API can handle production loads.",
                    Author = "Khaled Mahmoud",
                    CreatedAt = DateTime.Now.AddDays(-21)
                },

                // Programming Best Practices
                new BlogPost
                {
                    Title = "SOLID Principles Explained",
                    Content = "SOLID principles are fundamental to object-oriented design. Understanding Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion principles will dramatically improve your code quality. These principles help create maintainable, scalable, and testable software. The Single Responsibility Principle states that a class should have only one reason to change. The Open/Closed Principle encourages writing code that's open for extension but closed for modification. Liskov Substitution ensures that derived classes can substitute their base classes without breaking functionality. Interface Segregation prevents forcing clients to depend on interfaces they don't use. Finally, Dependency Inversion promotes depending on abstractions rather than concrete implementations.",
                    Author = "Ahmed Mohamed",
                    CreatedAt = DateTime.Now.AddDays(-20)
                },
                new BlogPost
                {
                    Title = "Clean Code: Writing Maintainable Software",
                    Content = "Writing clean, maintainable code is essential for any software project. This article covers important principles like naming conventions, code organization, DRY (Don't Repeat Yourself), KISS (Keep It Simple, Stupid), and YAGNI (You Aren't Gonna Need It). Clean code is easy to read, understand, and modify. Good naming makes code self-documenting, reducing the need for comments. Proper code organization and separation of concerns make applications easier to navigate and maintain. The DRY principle helps eliminate code duplication, while KISS reminds us to avoid unnecessary complexity. Following these principles results in code that other developers will thank you for, and your future self will appreciate when revisiting the codebase months later.",
                    Author = "Sara Ali",
                    CreatedAt = DateTime.Now.AddDays(-18)
                },
                new BlogPost
                {
                    Title = "Design Patterns Every Developer Should Know",
                    Content = "Design patterns are reusable solutions to common programming problems. Let's explore essential patterns like Singleton, Factory, Observer, Strategy, and Repository patterns. Understanding when and how to apply these patterns will make you a better developer. The Singleton pattern ensures a class has only one instance, useful for managing shared resources. Factory patterns provide a way to create objects without specifying their exact classes. The Observer pattern defines a one-to-many dependency between objects, perfect for implementing event systems. Strategy pattern enables selecting algorithms at runtime, while Repository pattern abstracts data access logic. Each pattern solves specific problems and should be applied thoughtfully, not just because they exist.",
                    Author = "Omar Hassan",
                    CreatedAt = DateTime.Now.AddDays(-16)
                },
                new BlogPost
                {
                    Title = "Test-Driven Development (TDD) Guide",
                    Content = "Test-Driven Development is a software development approach where tests are written before the actual code. This methodology ensures code quality, better design, and confidence when refactoring. The TDD cycle consists of three steps: Red (write a failing test), Green (write code to pass the test), and Refactor (improve the code while keeping tests passing). TDD leads to better test coverage, more modular code, and serves as living documentation. While it may seem slower initially, TDD actually speeds up development in the long run by catching bugs early and making refactoring safer. Unit tests become a safety net that gives developers confidence to make changes without fear of breaking existing functionality.",
                    Author = "Fatima Ibrahim",
                    CreatedAt = DateTime.Now.AddDays(-14)
                },

                // Web Development
                new BlogPost
                {
                    Title = "Responsive Web Design Principles",
                    Content = "Creating websites that work seamlessly across all devices is crucial in today's multi-device world. Learn about responsive design principles, CSS Grid, Flexbox, media queries, and mobile-first approach. Responsive design ensures your website looks great on phones, tablets, and desktops. The mobile-first approach starts with designing for smallest screens first, then progressively enhancing for larger displays. CSS Grid and Flexbox are powerful layout tools that make responsive design easier than ever. Media queries allow applying different styles based on screen size, orientation, and other device characteristics. Remember to test on real devices, optimize images for different screen sizes, and ensure touch-friendly interactive elements for mobile users.",
                    Author = "Khaled Mahmoud",
                    CreatedAt = DateTime.Now.AddDays(-12)
                },
                new BlogPost
                {
                    Title = "CSS Grid vs Flexbox: When to Use Which",
                    Content = "CSS Grid and Flexbox are both powerful layout systems, but they excel in different scenarios. Grid is ideal for two-dimensional layouts, while Flexbox shines in one-dimensional arrangements. Understanding the strengths of each will help you choose the right tool. Flexbox is perfect for navigation bars, centering content, and distributing space among items in a single row or column. CSS Grid excels at creating complex page layouts with multiple rows and columns. Often, the best approach combines both: use Grid for overall page structure and Flexbox for component-level layouts. We'll explore practical examples of when to use each, common patterns, and how they can work together to create sophisticated, responsive designs.",
                    Author = "Ahmed Mohamed",
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new BlogPost
                {
                    Title = "Web Performance Optimization Techniques",
                    Content = "Website performance directly impacts user experience and SEO rankings. Discover techniques for optimizing load times, including image optimization, code splitting, lazy loading, caching strategies, and CDN usage. Every millisecond counts in web performance. Start by measuring performance using tools like Lighthouse and WebPageTest. Optimize images by choosing the right format, compressing files, and using responsive images. Minify and bundle CSS and JavaScript files. Implement lazy loading for images and components below the fold. Use browser caching effectively and consider a CDN for static assets. Critical CSS and code splitting can significantly improve initial page load times. Remember: a one-second delay in page load time can result in a 7% reduction in conversions.",
                    Author = "Sara Ali",
                    CreatedAt = DateTime.Now.AddDays(-8)
                },

                // Database & Backend
                new BlogPost
                {
                    Title = "SQL vs NoSQL: Choosing the Right Database",
                    Content = "Selecting the right database is crucial for application success. SQL databases offer ACID compliance and structured data, while NoSQL provides flexibility and horizontal scaling. Let's explore when to use each type. SQL databases like PostgreSQL and SQL Server are ideal for complex queries, transactions, and structured data with relationships. NoSQL databases like MongoDB and Cassandra excel with unstructured data, high write loads, and need for horizontal scaling. Consider your data structure, query patterns, scalability requirements, and consistency needs when choosing. Sometimes a hybrid approach using both SQL and NoSQL databases for different parts of your application makes the most sense. Understanding the trade-offs is key to making informed decisions.",
                    Author = "Omar Hassan",
                    CreatedAt = DateTime.Now.AddDays(-6)
                },
                new BlogPost
                {
                    Title = "Database Indexing Best Practices",
                    Content = "Proper indexing can dramatically improve database query performance. Learn about different types of indexes, when to use them, and common pitfalls to avoid. Indexes speed up data retrieval but slow down write operations. Clustered indexes determine physical order of data, while non-clustered indexes create separate structures. Composite indexes can optimize queries with multiple WHERE conditions. However, too many indexes harm write performance and consume storage. Analyze query patterns using execution plans to identify which indexes will provide the most benefit. Remember to maintain indexes regularly and drop unused ones. Understanding index selectivity and covering indexes will help you make informed indexing decisions that balance read and write performance.",
                    Author = "Fatima Ibrahim",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },

                // DevOps & Deployment
                new BlogPost
                {
                    Title = "CI/CD Pipeline Implementation Guide",
                    Content = "Continuous Integration and Continuous Deployment automate the software delivery process. Learn how to set up CI/CD pipelines using GitHub Actions, Azure DevOps, or Jenkins for automated testing and deployment. CI/CD pipelines catch bugs early, enable faster releases, and reduce manual errors. Start by automating your build process, then add automated tests at various levels. Implement staging environments for testing before production deployment. Use feature flags for gradual rollouts. Infrastructure as Code ensures consistent environments. Monitor deployments and implement rollback strategies for when things go wrong. A well-designed CI/CD pipeline becomes your safety net, allowing teams to deploy multiple times per day with confidence.",
                    Author = "Khaled Mahmoud",
                    CreatedAt = DateTime.Now.AddDays(-4)
                },
                new BlogPost
                {
                    Title = "Microservices Architecture Patterns",
                    Content = "Microservices architecture breaks applications into small, independent services. Explore patterns like API Gateway, Service Discovery, Circuit Breaker, and Event-Driven Architecture for building scalable systems. Each microservice handles a specific business capability and can be deployed independently. Communication between services typically happens via REST APIs or message queues. The API Gateway pattern provides a single entry point for clients. Service Discovery helps services find each other dynamically. Circuit Breakers prevent cascading failures. Event-driven architecture enables loose coupling between services. While microservices offer benefits like independent scaling and technology diversity, they also introduce complexity in deployment, monitoring, and distributed transactions.",
                    Author = "Ahmed Mohamed",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },

                // Security
                new BlogPost
                {
                    Title = "Web Application Security Essentials",
                    Content = "Security should never be an afterthought. Learn about common vulnerabilities like SQL injection, XSS, CSRF, and how to protect your applications. Implement authentication, authorization, and follow OWASP security guidelines. Always validate and sanitize user input. Use parameterized queries to prevent SQL injection. Implement Content Security Policy to mitigate XSS attacks. Use anti-CSRF tokens for state-changing operations. Employ HTTPS everywhere and use secure authentication mechanisms like OAuth 2.0. Hash passwords with bcrypt or Argon2, never store them in plain text. Keep dependencies updated to patch known vulnerabilities. Regular security audits and penetration testing help identify weaknesses before attackers do.",
                    Author = "Sara Ali",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new BlogPost
                {
                    Title = "JWT Authentication Deep Dive",
                    Content = "JSON Web Tokens (JWT) provide a stateless authentication mechanism for modern applications. Understand JWT structure, how to implement authentication and authorization, token refresh strategies, and security considerations. JWTs consist of three parts: header, payload, and signature. They're self-contained, carrying all necessary information for verification. Implement short-lived access tokens combined with longer-lived refresh tokens for security. Store tokens securely - never in localStorage if avoiding XSS is critical. Use HTTP-only cookies when possible. Validate tokens on every request and check expiration. Consider token blacklisting for logout functionality. While JWTs are powerful, they're not suitable for every scenario - understand when to use them and when session-based authentication is better.",
                    Author = "Omar Hassan",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },

                // Career & Soft Skills
                new BlogPost
                {
                    Title = "Code Review Best Practices",
                    Content = "Code reviews are essential for maintaining code quality and knowledge sharing within teams. Learn how to give constructive feedback, what to look for during reviews, and how to handle feedback professionally. Good code reviews catch bugs, improve design, spread knowledge, and maintain coding standards. Focus on design, logic, and maintainability rather than style preferences. Be specific and kind in your feedback. Explain the 'why' behind suggestions. Ask questions instead of giving commands. As a reviewee, don't take feedback personally - it's about the code, not you. Respond to all comments and push updates promptly. Both parties should approach reviews as collaborative learning opportunities.",
                    Author = "Fatima Ibrahim",
                    CreatedAt = DateTime.Now.AddHours(-12)
                },
                new BlogPost
                {
                    Title = "Effective Technical Communication",
                    Content = "Strong communication skills are as important as technical skills for developers. Learn how to write clear documentation, explain complex concepts simply, give effective presentations, and collaborate with non-technical stakeholders. Good documentation saves countless hours and reduces onboarding time. Write code comments for the 'why', not the 'what'. Create README files that help others get started quickly. When explaining technical concepts, use analogies and avoid jargon. In meetings, listen actively and ask clarifying questions. Learn to say 'I don't know' and commit to finding answers. Tailor your communication style to your audience - executives need different information than fellow developers.",
                    Author = "Khaled Mahmoud",
                    CreatedAt = DateTime.Now.AddHours(-6)
                },
                new BlogPost
                {
                    Title = "The Art of Debugging",
                    Content = "Debugging is a critical skill that separates good developers from great ones. Master systematic debugging approaches, learn to use debugging tools effectively, and understand how to troubleshoot production issues. Start by reproducing the issue consistently. Read error messages carefully - they often contain the answer. Use the scientific method: form hypotheses, test them, and eliminate possibilities. Leverage debugging tools like breakpoints, watches, and stack traces. Add logging strategically. When stuck, explain the problem to someone else (rubber duck debugging). Take breaks when frustrated. Search for similar issues others have faced. Document solutions for future reference. Remember: every bug is an opportunity to learn something new about the system.",
                    Author = "Ahmed Mohamed",
                    CreatedAt = DateTime.Now.AddHours(-3)
                }
            };

            context.BlogPosts.AddRange(posts);
            context.SaveChanges();
        }
    }
}