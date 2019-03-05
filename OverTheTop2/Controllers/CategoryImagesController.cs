using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OverTheTop2.Models;
using OverTheTop2.ViewModels;

namespace OverTheTop2.Controllers
{
    public class CategoryImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryImages
        public ActionResult Index(int id)
        {
          
            var cat = db.Categories.Include(c => c.CategoryImages).Single(i =>i.id == id);
            return View(cat);
        }


        // GET: CategoryImages/Create
        public ActionResult Create(int id)
        {
            return View(db.Categories.Single(i=>i.id == id));
        }


        [HttpPost]
        public ActionResult MyUpload(IEnumerable<HttpPostedFileBase> myFiles, int id)
        {

            Category category = db.Categories.Include(i => i.CategoryImages).Single(i => i.id == id);


            foreach (var file in myFiles)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = file.FileName;
                    var path = Server.MapPath("~/Images/CategoryImages")+ "/"+fileName;

                    file.SaveAs(path);


                    CategoryImage newImg = new CategoryImage()
                    {
                        Image = "~/Images/CategoryImages/"+file.FileName
                    };
                    
                    category.CategoryImages.Add(newImg);

                    

                    //handle files;
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index","CategoryImages", new{id = id});
        }



        // GET: CategoryImages/Delete/5
        public ActionResult Delete(int? imgId, int catId)
        {
            if (imgId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = db.CategoryImages.Find(imgId);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }

            db.CategoryImages.Remove(categoryImage);
            db.SaveChanges();
            System.IO.File.Delete(Server.MapPath(categoryImage.Image));

            return RedirectToAction("Index","CategoryImages",new{id=catId});
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
