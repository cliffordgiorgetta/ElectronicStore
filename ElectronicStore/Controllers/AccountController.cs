using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ElectronicStore.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {



            try
            {

                //create an admin
                var newUser = Membership.CreateUser("Admin", "1590908", "cssproplayer@yahoo.com");


                //log in a user
                FormsAuthentication.SetAuthCookie("Admin", false);

                //to validate a user
                if (Membership.ValidateUser("Admin", "1590908"))
                {
                    //log them in
                    FormsAuthentication.SetAuthCookie("Admin", false);

                }
                else
                {
                    //the username/password doesnt match
                    ViewBag.ErrorMessage = "user/pass is wrong";
                }

            }
            catch (Exception exception)
            {
                
                return Content(exception.Message);
            }


            return Content("OK");
        }

        [HttpGet]
        public ActionResult Logout(string returnURL)
        {
            FormsAuthentication.SignOut();
            return Redirect(returnURL);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.login login, string returnURL)
        {
            if(Membership.ValidateUser(login.Username, login.password))
            {
                //valid user
                FormsAuthentication.SetAuthCookie(login.Username, false);
                return Redirect(returnURL);
            }
            else
            {
                //invalid user
                ViewBag.ErrorMessage= "Invalid username/password, Please try again";
                return PartialView(login);
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.register register)
        {
            try
            {
                var user = Membership.CreateUser(register.Username, register.Password, register.Email);
                FormsAuthentication.SetAuthCookie(register.Username, false);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception exception)
            {
                ViewBag.ErrorMessage = exception.Message;
                return View(register);
               
            }
        }

  
    }
}
