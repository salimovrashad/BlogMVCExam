using BlogMVC.Context;
using BlogMVC.Models;
using BlogMVC.ViewModels.BlogVM;
using Microsoft.AspNetCore.Mvc;

namespace BlogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BlogController : Controller
    {
        BlogDbContext _db { get; }

        public BlogController(BlogDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var items = _db.Blogs.ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(BlogCreateItemVM vm)
        {
            Blog blog = new Blog
            {
                Description = vm.Description,
                ImageUrl = vm.ImageUrl,
            };
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Update(int id) 
        {
            var item = await _db.Blogs.FindAsync(id);
            return View(new BlogUpdateItemVM
            {
                Description = item.Description,
                ImageUrl = item.ImageUrl,
            });
        }

        [HttpPost]
        
        public async Task<IActionResult> Update(int id, BlogUpdateItemVM vm)
        {
            var item = await _db.Blogs.FindAsync(id);
            item.Description = vm.Description;
            item.ImageUrl = vm.ImageUrl;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var item = await _db.Blogs.FindAsync(id);
            _db.Blogs.Remove(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
