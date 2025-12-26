using System.Diagnostics;
using System.Threading.Tasks;
using Blog_App.Interfaces;
using Blog_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IActionResult> Index()
        {
            var recentPosts = await _blogRepository.GetRecentPostsAsync(3);

            var allPosts = await _blogRepository.GetAllAsync();
            var totalPosts = allPosts.Count();
            var totalAuthors = allPosts.Select(p => p.Author).Distinct().Count();

            ViewBag.TotalPosts = totalPosts;
            ViewBag.TotalAuthors = totalAuthors;

            return View(recentPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
