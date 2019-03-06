using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OverTheTop2.Models;

namespace OverTheTop2.Controllers
{
    public class SubCategoryImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Add(int id)
        {
            var subCat = db.SubCategories.Single(i => i.Id == id);

            return View(subCat);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> Images, int id)
        {
            SubCategory Subcategory = db.SubCategories.Include(i => i.SubCategoryImages).Single(i => i.Id == id);


            foreach (var file in Images)
            {
                var guid = Guid.NewGuid();
                if (file != null && file.ContentLength > 0)
                {

                    var path = Server.MapPath("~/Images/SubCategoryImages") + "/" +guid+ file.FileName;

                    file.SaveAs(path);


                    SubCategoryImage newImg = new SubCategoryImage()
                    {
                        directory = "~/Images/SubCategoryImages/"  +guid+ file.FileName
                    };

                    Subcategory.SubCategoryImages.Add(newImg);



                    //handle files;
                }
            }

            db.SaveChanges();
            return RedirectToAction("Details", "SubCategories", new { id = id });
        }





        // GET: SubCategoryImages/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, int subCAt)
        {
            SubCategoryImage subCategoryImage = db.SubCategoryImages.Find(id);
            if (subCategoryImage == null)
            {
                return HttpNotFound();
            }

            db.SubCategoryImages.Remove(subCategoryImage);
            db.SaveChanges();
            return RedirectToAction("Details", "SubCategories", new{id = subCAt });
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
