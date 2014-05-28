using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Models;
using System.IO;

namespace ElectronicStore.Controllers
{
    public class ImagesController : Controller
    {
        private CliffStoreEntities db = new CliffStoreEntities();

        //
        // GET: /Images/

        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Product);
            return View(images.ToList());
        }

        //
        // GET: /Images/Details/5

        public ActionResult Details(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // GET: /Images/Create

        public ActionResult Create()
        {
            ViewBag.productID = new SelectList(db.Products, "productID", "name");
            return View();
        }

        //
        // POST: /Images/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image image, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    var fileName = Path.GetFileName(file.FileName);
                    //add a random GUID before the filename
                    fileName = Guid.NewGuid().ToString() + "-" + fileName;
                    // store the file inside ~/App_Data/uploads folder
                    var path = Path.Combine(Server.MapPath("~/content/images/"), fileName);
                    file.SaveAs(path);
                    image.imageURL = "/content/images/" + fileName;
                }
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productID = new SelectList(db.Products, "productID", "name", image.productID);
            return View(image);
        }

        //
        // GET: /Images/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.productID = new SelectList(db.Products, "productID", "name", image.productID);
            return View(image);
        }

        //
        // POST: /Images/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productID = new SelectList(db.Products, "productID", "name", image.productID);
            return View(image);
        }

        //
        // GET: /Images/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // POST: /Images/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}