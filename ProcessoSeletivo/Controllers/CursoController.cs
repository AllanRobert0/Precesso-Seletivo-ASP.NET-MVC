using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class CursoController : Controller
    {
        DbModel db = new DbModel();

        // List
        public ActionResult List()
        {
            return View(db.Curso.ToList());
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            db.Entry(curso).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List", "Curso");
        }

        //Detail
        public ActionResult Details(int ID)
        {
            Curso curso = db.Curso.Find(ID);
            return View(curso);
        }

        //Edit
        public ActionResult Edit(int ID)
        {
            Curso curso = db.Curso.Find(ID);
            return View(curso);
        }

        [HttpPost]
        public ActionResult Edit(Curso curso)
        {
            db.Entry(curso).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int ID)
        {
            Curso curso = db.Curso.Find(ID);
            return View(curso);
        }

        [HttpPost]
        public ActionResult Delete(Curso curso)
        {
            db.Entry(curso).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}