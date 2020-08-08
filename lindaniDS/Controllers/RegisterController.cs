using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lindaniDS.Models;

namespace lindaniDS.Controllers
{
    public class RegisterController : Controller
    {
        private LindaniContext db = new LindaniContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User obj)

        {
            if (ModelState.IsValid)
            {                
                db.Users.Add(obj);
                db.SaveChanges();
            }
            return View(obj);
        }
    }
}