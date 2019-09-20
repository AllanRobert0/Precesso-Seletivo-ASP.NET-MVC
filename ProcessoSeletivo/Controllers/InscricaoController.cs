using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class InscricaoController : Controller
    {
        DbModel db = new DbModel();

        // List
        public ActionResult List()
        {
            
            return View(db.Inscricao.ToList());
        }

        //Create
        public ActionResult Create()
        {
            var cursos = db.Curso.ToList();
            SelectList listCursos = new SelectList(cursos, "Id", "nome");

            ViewBag.selectCurso = listCursos;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Inscricao inscricao)
        { 
            try
            {
                //int _id = Int32.Parse(inscricao.curso);
                //Curso _curso = db.Curso.Find(_id);
                //inscricao.nomeCurso = _curso.nome;
                    
                db.Entry(inscricao).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("List", "Inscricao");
            }
            catch (Exception)
            {
                return View(inscricao);
            }
        }
    

        //Detail
        public ActionResult Details(int ID)
        {
            Inscricao inscricao = db.Inscricao.Find(ID);
            return View(inscricao);
        }

        //Edit
        public ActionResult Edit(int ID)
        {
            var cursos = db.Curso.ToList();
            SelectList listCursos = new SelectList(cursos, "Id", "nome");
            ViewBag.selectCurso = listCursos;

            Inscricao inscricao = db.Inscricao.Find(ID);
            return View(inscricao);
        }

        [HttpPost]
        public ActionResult Edit(Inscricao inscricao)
        {
            db.Entry(inscricao).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int ID)
        {
            Inscricao inscricao = db.Inscricao.Find(ID);
            return View(inscricao);
        }

        [HttpPost]
        public ActionResult Delete(Inscricao inscricao)
        {
            db.Entry(inscricao).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}