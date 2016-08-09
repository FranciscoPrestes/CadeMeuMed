using CadeMeuMedico.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;

namespace CadeMeuMedico.Controllers
{
    public class UsuarioController : BaseController
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        public ActionResult Index()
        {
            var u = db.Usuarios.ToList();
            return View(u);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u);
        }

        public ActionResult Editar(long id)
        {
            Usuarios u = db.Usuarios.Find(id);
            return View(u);
        }

        [HttpPost]
        public ActionResult Editar(Usuarios u)
        {
            if (ModelState.IsValid)
            {
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(u);
        }

        [HttpPost]
        public string Excluir(long id)
        {
            try
            {
                Usuarios u = db.Usuarios.Find(id);
                db.Usuarios.Remove(u);
                db.SaveChanges();
                return bool.TrueString;
            }
            catch
            {
                return bool.FalseString;
            }
        }

        //
        // GET: /Usuario/
        [HttpGet]
        public JsonResult LoginUsuario(string login, string senha)
        {
            if (UsuarioRepository.AutenticarUsuario(login, senha))
            {
                return Json(new
                {
                    OK = true,
                    Mensagem = "Login aceito",
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    OK = false,
                    Mensagem = "Login recusado",
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
