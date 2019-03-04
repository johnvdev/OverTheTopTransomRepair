using OverTheTop2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OverTheTop2.ViewModels;

namespace OverTheTop2.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var categories = _context.Categories.Include(c => c.SubCategory).Include(c => c.CategoryImages).ToList();

            if (User.IsInRole("Admin"))
            {
                return View("Index_Admin",categories);
            }
            else
            {
                return View("Index", categories);
            }
            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {
            

            return View("CategoryForm");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Save(Category category)
        {
            if (category.id == 0)
            {
                _context.Categories.Add(category);

            }
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.id == category.id);
                categoryInDb.Name = category.Name;
                categoryInDb.Description = category.Description;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.id == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View("CategoryForm", category);
        }
    }
}