using Licenta1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Licenta1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private Licenta1Context db = new Licenta1Context();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User users)
        {
            if (ModelState.IsValid)
            {
                using (Licenta1Context db = new Licenta1Context())
                {
                    var obj = db.Useri.Where(u => u.Email.Equals(users.Email) && u.Password.Equals(users.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["Email"] = obj.Email.ToString();
                        Session["Password"] = obj.Password.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewBag.Message = "Email or password invalid!";
                }
            }
            return View(users);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserId,Nume,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Useri.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}