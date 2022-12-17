using BasicLINQweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicLINQweb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {   //var
            IQueryable categories = from category in _context.Categories select category;
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int CategroyId)
        {
            Category category = (from cate in _context.Categories where cate.CategroyId == CategroyId select cate).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int CategroyId)
        {
            Category category = (from cate in _context.Categories where cate.CategroyId == CategroyId select cate).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
