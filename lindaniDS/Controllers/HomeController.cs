using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lindaniDS.Models;

namespace lindaniDS.Controllers
{
    public class HomeController : Controller
    {
        private LindaniContext db = new LindaniContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AllBookings()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User User)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(User);
                db.SaveChanges();
            }
            return RedirectToAction("Login","Home");
        }

        public ActionResult Login()
        {
            if(Session["Email"] != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
            var UserLogedIn = db.Users.SingleOrDefault(x => x.Email == User.Email && x.Password == User.Password);
            if (UserLogedIn != null)
            {
                string email = User.Email;
                ViewBag.err = "The E-mail or Password are incorrect, Please try again";
                ViewBag.success = "You are successfully Loged In.";
                Session["Email"] = email;
                Session["UserID"] = User.UserID;
               
                if(email.Contains("lindani") || email.Contains("lindaniDS") || email.Contains("lindanids"))
                {
                    Session["ad"] = email;
                    return RedirectToAction("Index", "VehicleHires");
                }
                else
                {
                    return RedirectToAction("Index");
                }


               
            }
            else
            {
                ViewBag.tryOnce = "yes";
                return View();
            }   
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}