using Blog_App.Models;

namespace Blog_App.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetByIdAsync(int id);

        Task<BlogPost> AddAsync(BlogPost post);

        Task<BlogPost> EditAsync(BlogPost post);

        Task<bool> DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);

        // Get posts by author
        Task<IEnumerable<BlogPost>> GetByAuthorAsync(string author);

        // Get recent posts
        Task<IEnumerable<BlogPost>> GetRecentPostsAsync(int count);

        Task<IEnumerable<BlogPost>> SearchAsync(string searchTerm);
        Task<IEnumerable<BlogPost>> GetAllAsync(string? searchTerm, string? author, string? sortOrder);
        Task<IEnumerable<string>> GetAllAuthorsAsync();

    }
}
