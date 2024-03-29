﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicStore.Models;

namespace ElectronicStore.Controllers
{
    public class CategoriesController : Controller
    {
        private CliffStoreEntities db = new CliffStoreEntities();

        //
        // GET: /Categories/

        public ActionResult Index()
        {
            var categories = db.Categories.Include(c => c.parentCategory);
            db.SaveChanges();
            return View(categories.ToList());
        }

        //
        // GET: /Categories/Details/5

        public ActionResult Details(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                db.SaveChanges();
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            ViewBag.parentID = new SelectList(db.Categories, "categoriesID", "name");
            db.SaveChanges();
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.parentID = new SelectList(db.Categories, "categoriesID", "name", category.parentID);
            return View(category);
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                db.SaveChanges();
                return HttpNotFound();
            }
            ViewBag.parentID = new SelectList(db.Categories, "categoriesID", "name", category.parentID);
            return View(category);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.parentID = new SelectList(db.Categories, "categoriesID", "name", category.parentID);
            return View(category);
        }

        //
        // GET: /Categories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                db.SaveChanges();
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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