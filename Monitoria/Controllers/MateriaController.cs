using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Monitoria.Models;

namespace Monitoria.Controllers
{

    public class MateriaController : Controller
    {

        private MonitoriaEntities5 db = new MonitoriaEntities5();


        public ActionResult Trabalho()
        {
            return View(db.Materias.ToList());
        }



        public ActionResult Tarefa()
        {
            return View(db.Cursos.ToList());
        }

        // GET: Materia
        public ActionResult Index()
        {
            return View(db.Materias.ToList());
        }

        public ActionResult Home()
        {
            return View();

        }
        // POST:

        [HttpPost]
        public ActionResult Home(Remessa arq)
        {

            try
            {
                string nomeArquivo = "";
                string arquivoEnviados = "";
                foreach (var arquivo in arq.Arquivos)
                {
                    if (arquivo.ContentLength > 0)
                    {
                        nomeArquivo = Path.GetFileName(arquivo.FileName);
                        var caminho = Path.Combine(Server.MapPath("~/Imagens"), nomeArquivo);
                        arquivo.SaveAs(caminho);
                    }
                    arquivoEnviados = arquivoEnviados + " , " + nomeArquivo;

                }
                ViewBag.Mensagem = "Arquivo enviados : " + arquivoEnviados + " , com sucesso.";

            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro : " + ex.Message;
            }
            return View();
        }


        // GET: Materia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // GET: Materia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materia/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MateriaID,Nome")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Materias.Add(materia);
                db.SaveChanges();
                return RedirectToAction("Index");
               
            }

            return View(materia);
        }

        // GET: Materia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: Materia/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MateriaID,Nome")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materia);
        }

        // GET: Materia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materia materia = db.Materias.Find(id);
            if (materia == null)
            {
                return HttpNotFound();
            }
            return View(materia);
        }

        // POST: Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materia materia = db.Materias.Find(id);
            db.Materias.Remove(materia);
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
