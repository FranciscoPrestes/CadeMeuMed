using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models; // Criação da instância
using System.Data.Entity;
using System.Data;

namespace CadeMeuMedico.Controllers
{
    //public class MedicosController : Controller
    public class MedicosController : BaseController
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();
        //
        // GET: /Medicos/

        public ActionResult Index()
        {
            var medicosList = db.Medicos.Include(m => m.Cidades).Include(m => m.Especialidades).ToList();
            return View(medicosList);
        }

        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Medicos medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }

        public ActionResult Editar(long id)
        {
            Medicos m = db.Medicos.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidades, "IDCidade", "Nome", m.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", m.IDEspecialidade);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Medicos m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidades = new SelectList(db.Cidades, "IDCidade", "Nome", m.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidades, "IDEspecialidade", "Nome", m.IDEspecialidade);
            return View(m);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Medicos m = db.Medicos.Find(id);
                db.Medicos.Remove(m);
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
