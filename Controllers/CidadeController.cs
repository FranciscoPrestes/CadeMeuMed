using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;

namespace CadeMeuMedico.Controllers
{
    public class CidadeController : BaseController
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var cidadesList = db.Cidades.ToList();
            return View(cidadesList);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Cidades c)
        {
            if (ModelState.IsValid)
            {
                db.Cidades.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Editar(long id)
        {
            Cidades c = db.Cidades.Find(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Editar(Cidades c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Cidades c = db.Cidades.Find(id);
                db.Cidades.Remove(c);
                db.SaveChanges();
                return bool.TrueString;
            }
            catch { return bool.FalseString; }
        }
    }
}
