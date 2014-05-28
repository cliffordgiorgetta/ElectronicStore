using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Models;

namespace ElectronicStore.Controllers
{
    public class ProductController : Controller
    {
        private CliffStoreEntities db = new CliffStoreEntities();

        //
        // GET: /Product/

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Supplier).Include(p => p.Category);
            return View(products.ToList());
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            ViewBag.suppliersID = new SelectList(db.Suppliers, "suppliersID", "name");
            ViewBag.categoriesID = new SelectList(db.Categories, "categoriesID", "name");
            return View();
        }

        //
        // POST: /Product/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.suppliersID = new SelectList(db.Suppliers, "suppliersID", "name", product.suppliersID);
            ViewBag.categoriesID = new SelectList(db.Categories, "categoriesID", "name", product.categoriesID);
            return View(product);
        }

        //
        // GET: /Product/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.suppliersID = new SelectList(db.Suppliers, "suppliersID", "name", product.suppliersID);
            ViewBag.categoriesID = new SelectList(db.Categories, "categoriesID", "name", product.categoriesID);
            return View(product);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.suppliersID = new SelectList(db.Suppliers, "suppliersID", "name", product.suppliersID);
            ViewBag.categoriesID = new SelectList(db.Categories, "categoriesID", "name", product.categoriesID);
            return View(product);
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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