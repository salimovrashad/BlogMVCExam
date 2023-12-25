using BlogMVC.Context;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Controllers
{
    public class HomeController : Controller
    {
        BlogDbContext _db { get; }
        public HomeController(BlogDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var items = _db.Blogs.ToList();
            return View(items);
        }
    }
}
