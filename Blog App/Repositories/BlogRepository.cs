using Blog_App.Data;
using Blog_App.Interfaces;
using Blog_App.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog_App.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
          return  await _context.BlogPosts.OrderByDescending(b => b.CreatedAt).ToListAsync();
        }

        public async Task<BlogPost?> GetByIdAsync(int id)
        {
            return await _context.BlogPosts.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task<BlogPost> AddAsync(BlogPost post)
        {
            _context.BlogPosts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }
        public async Task<BlogPost> EditAsync(BlogPost post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
            return post;
        }
        public async Task<bool> DeleteAsync(int id )
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);

            if (blogPost == null)
            {
                return false;
            }

            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.BlogPosts.AnyAsync(b => b.Id == id);
        }
        public async Task<IEnumerable<BlogPost>> GetByAuthorAsync(string author)
        {
            return await _context.BlogPosts
                .Where(b => b.Author.ToLower() == author.ToLower())
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }
        public async Task<IEnumerable<BlogPost>> GetRecentPostsAsync(int count)
        {
            return await _context.BlogPosts.OrderByDescending(b => b.CreatedAt).Take(count).ToListAsync();
        }
    }
}
