using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OverTheTop2.Migrations;
using OverTheTop2.Models;
using OverTheTop2.ViewModels;

namespace OverTheTop2.Controllers
{
    public class SubCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SubCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Include(i=>i.SubCategoryImages).Single(i=>i.Id == id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }


            if (User.IsInRole("Admin"))
            {
                return View("Details_Admin",subCategory);
            }
            else
            {
                return View("Details", subCategory);
            }
            
        }

        // GET: SubCategories/Create
        [Authorize(Roles = "Admin")]
        public ActionResult New(int id)
        {
            ViewData["CategoryId"] = id;
            return View("SubCategoryForm");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var SubCategory = db.SubCategories.Single(i => i.Id == id);
            ViewData["SubId"] = id;
            ViewData["BeforeImg"] = SubCategory.Beforeimg;
            ViewData["AfterImg"] = SubCategory.Afterimg;

            var viewmodel = new subCategoryFormViewModel
            {
                Name = SubCategory.Name
            };

            return View("Edit", viewmodel);
        }



        [Authorize(Roles = "Admin")]
        public ActionResult Update(subCategoryFormViewModel form, int id)
        {

            var subInDb = db.SubCategories.Single(i => i.Id == id);

            var exBefore = subInDb.Beforeimg;
            var exAfter = subInDb.Afterimg;

            var path = Server.MapPath("~/Images/BeforeAfterImages")+"/";

            if (form.Before != null )
            {
                var guid = Guid.NewGuid();
                System.IO.File.Delete(Server.MapPath(exBefore));
                subInDb.Beforeimg = "~/Images/BeforeAfterImages/"+ guid + form.Before.FileName;
                form.Before.SaveAs(path+guid + form.Before.FileName);


            }
            if (form.After != null)
            {
                var guid = Guid.NewGuid();
                System.IO.File.Delete(Server.MapPath(exAfter));
                subInDb.Afterimg = "~/Images/BeforeAfterImages/"+guid + form.After.FileName;
                form.After.SaveAs(path+guid + form.After.FileName);
            }

            if (subInDb.Name != form.Name)
            {
                subInDb.Name = form.Name;
            }

            db.SaveChanges();
            return RedirectToAction("Details", "SubCategories", new {id = id});
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Save(subCategoryFormViewModel form, int id)
        {
            if (ModelState.IsValid)
            {             

                Category category = db.Categories.Include(i => i.SubCategory).Single(i => i.id == id);


                SubCategory subCategory = new SubCategory();
                subCategory.Name = form.Name;

                var before = form.Before;
                var after = form.After;
                var images = form.Images;

                var path = Server.MapPath("~/Images/BeforeAfterImages") + "/";
                if (before != null && before.ContentLength > 0)
                {
                    var guid = Guid.NewGuid();
                    before.SaveAs(path+ guid + form.Before.FileName);
                    subCategory.Beforeimg = "~/Images/BeforeAfterImages/"+ guid + form.Before.FileName;
                }
                if (after != null && after.ContentLength > 0)
                {
                    var guid = Guid.NewGuid();
                    after.SaveAs(path +guid+ form.After.FileName);
                    subCategory.Afterimg = "~/Images/BeforeAfterImages/"+guid + form.After.FileName;
                }
                category.SubCategory.Add(subCategory);
                db.SaveChanges();

                var subId = subCategory.Id;

                SubCategory subCategoryIns = db.SubCategories.Include(i=>i.SubCategoryImages).Single(i => i.Id == subId);

                path = Server.MapPath("~/Images/SubCAtegoryImages") + "/";
                foreach (var file in form.Images)
                {
                    var guid = Guid.NewGuid();
                    if (file != null && file.ContentLength > 0)
                    {

                        path = Server.MapPath("~/Images/SubCategoryImages") + "/" + guid+ file.FileName;

                        file.SaveAs(path);


                        SubCategoryImage newImg = new SubCategoryImage()
                        {
                            directory = "~/Images/SubCategoryImages/"+guid  + file.FileName
                        };
                        subCategoryIns.SubCategoryImages.Add(newImg);




                        //handle files;
                    }
                }
                db.SaveChanges();


                return RedirectToAction("Index","Category");
            }

            return View();
        }

    

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
