using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INSTAL_MIX_SQL.Models;

namespace INSTAL_MIX_SQL.Controllers
{
    public class MainPageContentsController : Controller
    {
        private INSTALMIXEntities2 db = new INSTALMIXEntities2();

        // GET: MainPageContents
        public ActionResult Index()
        {
            return View(db.MainPageContent.ToList());
        }

        // GET: MainPageContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainPageContent mainPageContent = db.MainPageContent.Find(id);
            if (mainPageContent == null)
            {
                return HttpNotFound();
            }
            return View(mainPageContent);
        }

        // GET: MainPageContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainPageContents/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPK,opis,urlAdres,pozycja")] MainPageContent mainPageContent)
        {
            if (ModelState.IsValid)
            {
                db.MainPageContent.Add(mainPageContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainPageContent);
        }

        // GET: MainPageContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainPageContent mainPageContent = db.MainPageContent.Find(id);
            if (mainPageContent == null)
            {
                return HttpNotFound();
            }
            return View(mainPageContent);
        }

        // POST: MainPageContents/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPK,opis,urlAdres,pozycja")] MainPageContent mainPageContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainPageContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainPageContent);
        }

        // GET: MainPageContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainPageContent mainPageContent = db.MainPageContent.Find(id);
            if (mainPageContent == null)
            {
                return HttpNotFound();
            }
            return View(mainPageContent);
        }

        // POST: MainPageContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainPageContent mainPageContent = db.MainPageContent.Find(id);
            db.MainPageContent.Remove(mainPageContent);
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
