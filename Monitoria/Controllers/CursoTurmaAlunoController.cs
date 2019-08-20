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
    public class CursoTurmaAlunoController : Controller
    {
        private MonitoriaEntities4 db = new MonitoriaEntities4();

        // GET: CursoTurmaAluno
        public ActionResult Index()
        {
            var cursoTurmaAlunoes = db.CursoTurmaAlunoes.Include(c => c.Usuario);
            return View(cursoTurmaAlunoes.ToList());
        }

        // GET: CursoTurmaAluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoTurmaAluno cursoTurmaAluno = db.CursoTurmaAlunoes.Find(id);
            if (cursoTurmaAluno == null)
            {
                return HttpNotFound();
            }
            return View(cursoTurmaAluno);
        }

        // GET: CursoTurmaAluno/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Usuarios, "ID", "Nome");
            return View();
        }

        // POST: CursoTurmaAluno/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CursoTurmaAlunoID,ID")] CursoTurmaAluno cursoTurmaAluno)
        {
            if (ModelState.IsValid)
            {
                db.CursoTurmaAlunoes.Add(cursoTurmaAluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Usuarios, "ID", "Nome", cursoTurmaAluno.ID);
            return View(cursoTurmaAluno);
        }

        // GET: CursoTurmaAluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoTurmaAluno cursoTurmaAluno = db.CursoTurmaAlunoes.Find(id);
            if (cursoTurmaAluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Usuarios, "ID", "Nome", cursoTurmaAluno.ID);
            return View(cursoTurmaAluno);
        }

        // POST: CursoTurmaAluno/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CursoTurmaAlunoID,ID")] CursoTurmaAluno cursoTurmaAluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cursoTurmaAluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Usuarios, "ID", "Nome", cursoTurmaAluno.ID);
            return View(cursoTurmaAluno);
        }

        // GET: CursoTurmaAluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoTurmaAluno cursoTurmaAluno = db.CursoTurmaAlunoes.Find(id);
            if (cursoTurmaAluno == null)
            {
                return HttpNotFound();
            }
            return View(cursoTurmaAluno);
        }

        // POST: CursoTurmaAluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CursoTurmaAluno cursoTurmaAluno = db.CursoTurmaAlunoes.Find(id);
            db.CursoTurmaAlunoes.Remove(cursoTurmaAluno);
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
