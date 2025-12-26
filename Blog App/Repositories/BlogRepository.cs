using AspNetCoreGeneratedDocument;
using Blog_App.Data;
using Blog_App.Helpers;
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

       public async Task<IEnumerable<BlogPost>> SearchAsync(string searchTerm)
        {
            return await _context.BlogPosts
                .Where(b => b.Title.Contains(searchTerm) || b.Content.Contains(searchTerm))
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();
        }
        public async Task<IEnumerable<BlogPost>> GetAllAsync(string? searchTerm, string? author, string? sortOrder)
        {
            var query = _context.BlogPosts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(
                    p => p.Title.Contains(searchTerm) ||
                    p.Content.Contains(searchTerm) ||
                    p.Author.Contains(searchTerm));
            };

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(p => p.Author == author);
            }

            query = sortOrder switch
            {
                "date_asc" => query.OrderBy(p => p.CreatedAt),
                "date_desc" => query.OrderByDescending(p => p.CreatedAt),
                "title_asc" => query.OrderBy(p => p.Title),
                "title_desc" => query.OrderByDescending(p => p.Title),
                _ => query.OrderByDescending(p => p.CreatedAt) // Default
            };

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<string>> GetAllAuthorsAsync()
        {
            return await _context.BlogPosts
                .Select(b => b.Author)
                .Distinct()
                .OrderBy(a => a)
                .ToListAsync();
        }

        public async Task<PaginatedList<BlogPost>> GetAllPaginatedAsync(
            string? searchTerm,
            string? author,
            string? sortOrder,
            int pageIndex,
            int pageSize)
        {
            // نبدأ بكل البوستات
            var query = _context.BlogPosts.AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(p =>
                    p.Title.Contains(searchTerm) ||
                    p.Content.Contains(searchTerm) ||
                    p.Author.Contains(searchTerm));
            }

            // Filter by Author
            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(p => p.Author == author);
            }

            // Sort
            query = sortOrder switch
            {
                "date_asc" => query.OrderBy(p => p.CreatedAt),
                "date_desc" => query.OrderByDescending(p => p.CreatedAt),
                "title_asc" => query.OrderBy(p => p.Title),
                "title_desc" => query.OrderByDescending(p => p.Title),
                _ => query.OrderByDescending(p => p.CreatedAt)
            };

            // Pagination
            return await PaginatedList<BlogPost>.CreateAsync(query, pageIndex, pageSize);
        }
    }
}
