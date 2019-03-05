using OverTheTop2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace OverTheTop2.Controllers
{
    
    public class SubCategoryController : Controller
    {
        private ApplicationDbContext _context;

        public SubCategoryController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: SubCategory
        public ActionResult Index(int id)
        {
            var subCategory = _context.SubCategories.Include(c => c.SubCategoryImages).Single(i => i.Id == id);

            if (User.IsInRole("Admin"))
            {
                return View("index_Admin",subCategory);
            }

            return View(subCategory);
        }
    }
}