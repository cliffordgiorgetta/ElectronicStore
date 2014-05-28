using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class HomeController : Controller
    {

        Models.CliffStoreEntities db = new Models.CliffStoreEntities();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult navigation()
        {
            var categories = db.Categories.Where(x => x.parentID == null);
            return PartialView(categories);
        }

      
        public ActionResult advertisement()
        {
            return View();
        }
        public ActionResult videogames()
        {
            return View();
        }
        public ActionResult email()
        {
            return View();
        }

        public ActionResult BreadCrumbs(int id)
        {
            // get our category
            var category = db.Categories.Find(id);
            // create a new list to return for our breadcrumbs
            var breadcrumbsList = new List<Models.Category>();
            // TODO: figure out how to fill the list.
            while (category.parentID != null)
            {
                breadcrumbsList.Add(category);
                category = category.parentCategory;
            }
            // add the root parent category to the list
            breadcrumbsList.Add(category);
            //reverse and return the list
            breadcrumbsList.Reverse();
            //return the list.
            return PartialView("breadcrumbs", breadcrumbsList);
        }
       


    }
}
