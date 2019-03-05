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

        // GET: SubCategoryImages
        public ActionResult Index()
        {
            return View(db.SubCategoryImages.ToList());
        }

        // GET: SubCategoryImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryImage subCategoryImage = db.SubCategoryImages.Find(id);
            if (subCategoryImage == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryImage);
        }

        // GET: SubCategoryImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubCategoryImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,directory")] SubCategoryImage subCategoryImage)
        {
            if (ModelState.IsValid)
            {
                db.SubCategoryImages.Add(subCategoryImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subCategoryImage);
        }

        // GET: SubCategoryImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryImage subCategoryImage = db.SubCategoryImages.Find(id);
            if (subCategoryImage == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryImage);
        }

        // POST: SubCategoryImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,directory")] SubCategoryImage subCategoryImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subCategoryImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subCategoryImage);
        }

        // GET: SubCategoryImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryImage subCategoryImage = db.SubCategoryImages.Find(id);
            if (subCategoryImage == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryImage);
        }

        // POST: SubCategoryImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoryImage subCategoryImage = db.SubCategoryImages.Find(id);
            db.SubCategoryImages.Remove(subCategoryImage);
            db.SaveChanges();
            return RedirectToAction("Index");
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
