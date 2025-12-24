using Blog_App.Data;
using Blog_App.Models;
using Blog_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog_App.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _context.BlogPosts.OrderByDescending(b=>b.CreatedAt).ToListAsync();
            return View(posts);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(b => b.Id == id);
            if(blogPost == null)
            {
                 return NotFound();
            }
            return View(blogPost);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blogPost = new BlogPost
                {
                    Title = model.Title,
                    Content = model.Content,
                    Author = model.Author,
                    CreatedAt = DateTime.Now
                };
                _context.BlogPosts.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if(blogPost == null)
            {
                return NotFound();
            }

            var viewModel = new CreateBlogPostViewModel
            {
                Id = blogPost.Id,
                Content = blogPost.Content,
                Title = blogPost.Title,
                Author = blogPost.Author
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateBlogPostViewModel model)
        {
            if (model.Id != id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var blogPost = await _context.BlogPosts.FindAsync(id);
                    if (blogPost == null)
                    {
                        return NotFound();
                    }


                    blogPost.Title = model.Title;
                    blogPost.Content = model.Content;
                    blogPost.Author = model.Author;

                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!BlogPostExists(id)){
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(b => b.Id == id);

            if(blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if( blogPost != null)
            {
                _context.BlogPosts.Remove(blogPost);
                await _context.SaveChangesAsync();
            }
            
             return RedirectToAction(nameof(Index));
        }
 

        // Helper method
        public bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(b => b.Id == id);
        }
    }
}
