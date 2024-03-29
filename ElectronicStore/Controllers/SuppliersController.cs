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
    public class SuppliersController : Controller
    {
        private CliffStoreEntities db = new CliffStoreEntities();

        //
        // GET: /Suppliers/

        public ActionResult Index()
        {
           
            return View(db.Suppliers.ToList());
        }

        //
        // GET: /Suppliers/Details/5

        public ActionResult Details(int id = 0)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // GET: /Suppliers/Create

        public ActionResult Create()
        {
            db.SaveChanges();
            return View();
        }

        //
        // POST: /Suppliers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        //
        // GET: /Suppliers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
               
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /Suppliers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier).State = EntityState.Modified;
           
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        //
        // GET: /Suppliers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
               
                return HttpNotFound();
            }
            return View(supplier);
        }

        //
        // POST: /Suppliers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}