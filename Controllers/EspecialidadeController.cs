using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;

namespace CadeMeuMedico.Controllers
{
    public class EspecialidadeController : BaseController
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();
        //
        // GET: /Especialidade/

        public ActionResult Index()
        {
            var especialidadeList = db.Especialidades.ToList();
            return View(especialidadeList);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Especialidades e)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(e);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        public ActionResult Editar(long id)
        {
            Especialidades m = db.Especialidades.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Especialidades e)
        {
            if (ModelState.IsValid)
            {
                db.Entry(e).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Especialidades e = db.Especialidades.Find(id);
                db.Especialidades.Remove(e);
                db.SaveChanges();
                return bool.TrueString;
            }
            catch
            {
                return bool.FalseString;
            }
        }
    }
}
