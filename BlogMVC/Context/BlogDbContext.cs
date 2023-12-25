using BlogMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC.Context
{
    public class BlogDbContext : IdentityDbContext
    {
        public DbSet<Blog> Blogs {  get; set; }

        public BlogDbContext(DbContextOptions options) : base(options) { }
    }
}
