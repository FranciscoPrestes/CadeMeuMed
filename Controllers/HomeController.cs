using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using CadeMeuMedico.Models.DAO;

namespace CadeMeuMedico.Controllers
{
    //public class HomeController : Controller
    public class HomeController : BaseController
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.title = "Autenticar";
            return View();
        }

        public ActionResult Publico()
        {

            //PreencheDropdowList();
            return View();
        }

        [HttpGet]
        public JsonResult PublicoPost(int cidade, int especialidade, string nome)
        {
            //db.Configuration.ProxyCreationEnabled = false; // Evitar o erro de referência circular
            
            //var busca = from m in db.Medicos
            //            where m.Nome.Contains(nome) && m.IDCidade.Equals(cidade) && m.IDEspecialidade.Equals(especialidade)
            //            select m;
          
            /*if (!string.IsNullOrEmpty(nome))
            {
                busca = busca.Where(s => s.Nome.Contains(nome)) && (s => s.IDCidade = cidade);
            }*/

            

           //PreencheDropdowList();

            List<Medicos> busca = new MedicoDAO().Pesquisa(nome, cidade, especialidade);

            return Json(new
            {
                busca
            }, JsonRequestBehavior.AllowGet);
        }

        //private void PreencheDropdowList()
        //{
        //    ViewBag.cidadeList = new SelectList(db.Cidades, "IDCidade", "Nome");
        //    ViewBag.especialidadeList = new SelectList(db.Especialidades, "IDEspecialidade", "Nome");
        //}


    }
}
