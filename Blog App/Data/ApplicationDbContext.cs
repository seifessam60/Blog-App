using Blog_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog_App.Data
{
    public class IBlogRepositoryApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<BlogPost> BlogPosts{ get; set; }
    }
}
