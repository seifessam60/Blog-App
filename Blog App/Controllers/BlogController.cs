using Blog_App.Data;
using Blog_App.Interfaces;
using Blog_App.Models;
using Blog_App.Repositories;
using Blog_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Blog_App.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IActionResult> Index()
        {
            var posts = await _blogRepository.GetAllAsync();
            return View(posts);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var blogPost = await _blogRepository.GetByIdAsync(id.Value);
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
                await _blogRepository.AddAsync(blogPost);
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

            var blogPost = await _blogRepository.GetByIdAsync(id.Value);
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
                    var blogPost = await _blogRepository.GetByIdAsync(id);
                    if (blogPost == null)
                    {
                        return NotFound();
                    }


                    blogPost.Title = model.Title;
                    blogPost.Content = model.Content;
                    blogPost.Author = model.Author;

                    await _blogRepository.EditAsync(blogPost);
                }
                catch (DbUpdateConcurrencyException)
                {

                    
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

            var blogPost = await _blogRepository.GetByIdAsync(id.Value);

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
            var result = await _blogRepository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            
             return RedirectToAction(nameof(Index));
        }
 

        
    }
}
