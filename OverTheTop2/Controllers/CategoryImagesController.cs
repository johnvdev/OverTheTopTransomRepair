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
    public class CategoryImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CategoryImages
        public ActionResult Index(int id)
        {
            var cat = db.Categories.Include(c => c.CategoryImages).Single(i =>i.id == id);
            var imgs = cat.CategoryImages;
            return View(imgs);
        }

        // GET: CategoryImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = db.CategoryImages.Find(id);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // GET: CategoryImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Image")] CategoryImage categoryImage)
        {
            if (ModelState.IsValid)
            {
                db.CategoryImages.Add(categoryImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryImage);
        }

        // GET: CategoryImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = db.CategoryImages.Find(id);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // POST: CategoryImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Image")] CategoryImage categoryImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryImage);
        }

        // GET: CategoryImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = db.CategoryImages.Find(id);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // POST: CategoryImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryImage categoryImage = db.CategoryImages.Find(id);
            db.CategoryImages.Remove(categoryImage);
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
