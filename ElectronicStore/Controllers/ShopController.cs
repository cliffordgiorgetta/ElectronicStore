using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class ShopController : BaseController
    {
        Models.CliffStoreEntities db = new Models.CliffStoreEntities();
        //
        // GET: /Shop/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult byCategory(int id)
        {
  
            var category = db.Categories.Find(id);
            category.AllProducts = db.GetProductsByCategoryID(id).ToList();
          
            return View(category);
        }

        [HttpPost]
        public ActionResult Product(int id)
        {

            var Product = db.Products.Find(id);
   

            return View(Product);
        }
        [HttpPost]
        public ActionResult Product(int id, FormCollection values)
        {
            int qty = int.Parse(values["qty"]);
            int orderID = GetOrderID();
            //get our order
           
            //make a new order line
            var orderLine = new Models.OrderLine();
            orderLine.productID = id;
            orderLine.quanity = qty;
            orderLine.unitPrice = decimal.Parse(values["price"]);
            orderLine.orderID = orderID;

            //add the orderLine to the database
            db.OrderLines.Add(orderLine);
            db.SaveChanges();


            //add the new item to the cart total

            //1. get the order
            var order = db.Orders.Find(orderID);
            //2. update the total 
            //(sum of all orderlines)
            order.subTotal = order.OrderLines.Sum(x => x.subTotal);
            //3.save the updated order total
            db.SaveChanges();


            //get the product to return to the view
            var product = db.Products.Find(id);
            ViewBag.SuccessMessage = "Added " + qty + " to cart";
            return View(product);

        }
    }
}
