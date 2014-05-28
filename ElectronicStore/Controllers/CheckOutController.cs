using AuthorizeNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicStore.Controllers
{
    public class CheckOutController : BaseController
    {
        //
        // GET: /CheckOut/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreditCardTest()
        {
            //what sends our transaction request
            Gateway target = new Gateway("3JDg85h5FT", "4N7H6g6E8fS3Y6xC", true);
            //creating an authorization request
            IGatewayRequest request = new AuthorizationRequest("5424000000000015", "0224", (decimal)20.10, "AuthCap transaction approved testing", true);
            request.Address = "123 main st. apt 2 denver co 80203";
            string description = "AuthCap transaction approved testing";
            IGatewayResponse response = target.Send(request, description);





            return Content("Ok");
        }

    }
}
