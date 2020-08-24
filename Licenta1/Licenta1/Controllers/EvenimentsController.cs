using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Licenta1.Models;
using PusherServer;

namespace Licenta1.Controllers
{
    [AllowAnonymous]
    public class EvenimentsController : Controller
    {
        private Licenta1Context db = new Licenta1Context();

        // GET: Eveniments
        public ActionResult Index(string linktext)
        {
            if (linktext == "Festival")
                return View(db.Evenimente.Where(m => m.GenEvent == "Festival" && m.DataEvent >= DateTime.Now).ToList());
            if (linktext == "Concert live")
                return View(db.Evenimente.Where(m => m.GenEvent == "Concert live" && m.DataEvent >= DateTime.Now).ToList());
            if (linktext == "Teatru")
                return View(db.Evenimente.Where(m => m.GenEvent == "Teatru" && m.DataEvent >= DateTime.Now).ToList());
            else return View(db.Evenimente.Where(m => m.DataEvent >= DateTime.Now));
        }

        public ActionResult IndexUser(string linktext, string searchString)
        {
            if (linktext == "Festival")
                return View(db.Evenimente.Where(m => m.GenEvent == "Festival" && m.DataEvent>=DateTime.Now).ToList());
            if (linktext == "Concert live")
                return View(db.Evenimente.Where(m => m.GenEvent == "Concert live" && m.DataEvent >= DateTime.Now).ToList());
            if (linktext == "Teatru")
                return View(db.Evenimente.Where(m => m.GenEvent == "Teatru" && m.DataEvent >= DateTime.Now).ToList());
            else return View(db.Evenimente.Where(m => m.DataEvent>=DateTime.Now));
        }

        [HttpPost]
        public ActionResult IndexUser(string searchedName)
        {
            var evenim = db.Evenimente.ToList().Where(p => p.NumeEvent.StartsWith(searchedName));
            return View(evenim);
        }

        public ActionResult IndexIstoric(string linktext)
        {
             return View(db.Evenimente.Where(m => m.DataEvent < DateTime.Now));
        }

        // GET: Eveniments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eveniment eveniment = db.Evenimente.Find(id);
            if (eveniment == null)
            {
                return HttpNotFound();
            }
            return View(eveniment);
        }

        public ActionResult Comments(int? id)
        {
            var comments = db.Comments.Where(x => x.EvenimentId == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            db.Comments.Add(data);
            db.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "eu";
            var pusher = new Pusher("1006665", "0c257db48809018c5fd3", "41ce8ec4dd6e7d560533", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
        }

        // GET: Eveniments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eveniments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvenimentId,NumeEvent,DataEvent,DescriereEvent,PozeEvent,GenEvent")] Eveniment eveniment, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                    file.SaveAs(path);
                    eveniment.PozeEvent = Url.Content("~/images/" + fileName);
                db.Evenimente.Add(eveniment);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eveniment);
        }

        // GET: Eveniments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eveniment eveniment = db.Evenimente.Find(id);
            if (eveniment == null)
            {
                return HttpNotFound();
            }
            return View(eveniment);
        }

        // POST: Eveniments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvenimentId,NumeEvent,DataEvent,DescriereEvent,PozeEvent,GenEvent")] Eveniment eveniment, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    db.Evenimente.Add(eveniment);
                    var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                    file.SaveAs(path);
                    eveniment.PozeEvent = Url.Content("~/images/" + fileName);
                }
                    db.Entry(eveniment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
            }
            return View(eveniment);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmail(int id)
        {
           Eveniment eveniment = db.Evenimente.Find(id);
            if (ModelState.IsValid)
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(Session["Email"].ToString()));  // replace with valid value 
                message.From = new MailAddress("popescu.sorin23@gmail.com");  // replace with valid value
                message.Subject = "Licenta Web App";
                message.Body = "Hello, ai ales sa mergi la evenimentul "+eveniment.NumeEvent + " care se desfasoara in data de "+ eveniment.DataEvent+". Descriere: " + eveniment.DescriereEvent;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "popescu.sorin23@gmail.com",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    
                    return RedirectToAction("IndexUser");
                }
            }
            return View();
        }
    //return View();

        // GET: Eveniments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eveniment eveniment = db.Evenimente.Find(id);
            if (eveniment == null)
            {
                return HttpNotFound();
            }
            return View(eveniment);
        }

        // POST: Eveniments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Eveniment eveniment = db.Evenimente.Find(id);
            db.Evenimente.Remove(eveniment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
