 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Licenta1.Models;

namespace Licenta1.Controllers
{
    [AllowAnonymous]
    public class PozesController : Controller
    {
        private Licenta1Context db = new Licenta1Context();

        // GET: Pozes
        public ActionResult Index()
        {
            var foto = db.Foto.Include(p => p.Eveniment);
            return View(foto.ToList());
        }

        // GET: Pozes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poze poze = db.Foto.Find(id);
            if (poze == null)
            {
                return HttpNotFound();
            }
            return View(poze);
        }

        // GET: Pozes/Create
        public ActionResult Create()
        {
            ViewBag.PozeId = new SelectList(db.Evenimente, "EvenimentId", "NumeEvent");
            return View();
        }

        // POST: Pozes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PozeId,Poza1,Poza2,Poza3,Poza4")] Poze poze, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                file1.SaveAs(path);
                poze.Poza1 = Url.Content("~/images/" + fileName);

                var fileName2 = Path.GetFileName(file2.FileName);
                var path2 = Path.Combine(Server.MapPath("~/images/"), fileName2);
                file2.SaveAs(path2);
                poze.Poza2 = Url.Content("~/images/" + fileName2);

                var fileName3 = Path.GetFileName(file3.FileName);
                var path3 = Path.Combine(Server.MapPath("~/images/"), fileName3);
                file3.SaveAs(path3);
                poze.Poza3 = Url.Content("~/images/" + fileName3);

                var fileName4 = Path.GetFileName(file4.FileName);
                var path4 = Path.Combine(Server.MapPath("~/images/"), fileName4);
                file4.SaveAs(path4);
                poze.Poza4 = Url.Content("~/images/" + fileName4);

                db.Foto.Add(poze);
                 db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.PozeId = new SelectList(db.Evenimente, "EvenimentId", "NumeEvent", poze.PozeId);
            return View(poze);
        }

        // GET: Pozes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poze poze = db.Foto.Find(id);
            if (poze == null)
            {
                return HttpNotFound();
            }
            ViewBag.PozeId = new SelectList(db.Evenimente, "EvenimentId", "NumeEvent", poze.PozeId);
            return View(poze);
        }

        // POST: Pozes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PozeId,Poza1,Poza2,Poza3,Poza4")] Poze poze, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                file1.SaveAs(path);
                poze.Poza1 = Url.Content("~/images/" + fileName);

                var fileName2 = Path.GetFileName(file2.FileName);
                var path2 = Path.Combine(Server.MapPath("~/images/"), fileName2);
                file2.SaveAs(path2);
                poze.Poza2 = Url.Content("~/images/" + fileName2);

                var fileName3 = Path.GetFileName(file3.FileName);
                var path3 = Path.Combine(Server.MapPath("~/images/"), fileName3);
                file3.SaveAs(path3);
                poze.Poza3 = Url.Content("~/images/" + fileName3);

                var fileName4 = Path.GetFileName(file4.FileName);
                var path4 = Path.Combine(Server.MapPath("~/images/"), fileName4);
                file4.SaveAs(path4);
                poze.Poza4 = Url.Content("~/images/" + fileName4);

                db.Entry(poze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PozeId = new SelectList(db.Evenimente, "EvenimentId", "NumeEvent", poze.PozeId);
            return View(poze);
        }

        // GET: Pozes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poze poze = db.Foto.Find(id);
            if (poze == null)
            {
                return HttpNotFound();
            }
            return View(poze);
        }

        // POST: Pozes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poze poze = db.Foto.Find(id);
            db.Foto.Remove(poze);
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
