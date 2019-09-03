using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Monitoria.Models;

namespace Monitoria.Controllers
{

    public class SemestreController : Controller
    {
        private MonitoriaEntities5 db = new MonitoriaEntities5();

        // GET: Semestre
        public ActionResult Index()
        {
            return View(db.Semestres.ToList());
        }

        // GET: Semestre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestres.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // GET: Semestre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Semestre/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SemestreID,NomeSemestre")] Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                db.Semestres.Add(semestre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(semestre);
        }

        // GET: Semestre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestres.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // POST: Semestre/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SemestreID,NomeSemestre")] Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semestre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(semestre);
        }

        // GET: Semestre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Semestre semestre = db.Semestres.Find(id);
            if (semestre == null)
            {
                return HttpNotFound();
            }
            return View(semestre);
        }

        // POST: Semestre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Semestre semestre = db.Semestres.Find(id);
            db.Semestres.Remove(semestre);
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
