using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class BaseController : Controller

        
    {

       public Models.CliffStoreEntities db = new Models.CliffStoreEntities();

        //making a readonly property for our current order

        //declar a property variable
       private Models.Order _myOrder;
        //write the property
       public Models.Order MyOrder
       {
           get
           {
               //is _myOrder a thing?
               if (_myOrder == null)
               {
                   //it doesnt exist, get the order id
                   var orderID = GetOrderID();
                   //set the _myOrder variable to the order
                   //from the database
                   _myOrder = db.Orders.Find(orderID);
               }
               return _myOrder;
           }

       }


        public int GetOrderID()
        {
            if (Session["OrderID"] == null)
            {
                //create a new order
                var newOrder = new Models.Order();
                newOrder.dateCreated = DateTime.Now;
                newOrder.status = "Cart";
                newOrder.subTotal = 0;
                newOrder.shippingPrice = 0;
                newOrder.totalPrice = 0;
                newOrder.salesTax = 0;
                //add order to the DB
                db.Orders.Add(newOrder);
                db.SaveChanges();
                //set the session orderID to the
                //new orderID
                Session["OrderID"] = newOrder.OrdersID;
                return newOrder.OrdersID;
            }
            return int.Parse(Session["OrderID"].ToString());
        }


    }
}
