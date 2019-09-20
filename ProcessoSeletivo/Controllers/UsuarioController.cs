using ProcessoSeletivo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProcessoSeletivo.Controllers
{
    public class UsuarioController : Controller
    {
        DbModel db = new DbModel();

        // List
        public ActionResult List()
        {
            return View(db.Usuario.ToList());
        }

        //Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List", "Usuario");
        }

        //Detail
        public ActionResult Details(int ID)
        {
            Usuario usuario = db.Usuario.Find(ID);
            return View(usuario);
        }

        //Edit
        public ActionResult Edit(int ID)
        {
            Usuario usuario = db.Usuario.Find(ID);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("List");
        }

        //Delete
        public ActionResult Delete(int ID)
        {
            Usuario usuario = db.Usuario.Find(ID);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}