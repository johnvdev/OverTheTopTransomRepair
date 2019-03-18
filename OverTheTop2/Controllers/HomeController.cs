using OverTheTop2.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OverTheTop2.ViewModels;

namespace OverTheTop2.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context =new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            var categories = _context.Categories.Include(c => c.SubCategory).Include(c => c.CategoryImages).ToList();
            var reviews = _context.Reviews;

            IndexFormViewModel viewModel = new IndexFormViewModel
            {
                Categories = categories,
                Reviews = reviews
            };

            if (User.IsInRole("Admin"))
            {
                return View("Index_Admin", viewModel);
            }
            else
            {
                return View("Index", viewModel);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}