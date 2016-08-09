using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadeMeuMedico.Areas.Mobile.Controllers
{
    public class PainelController : Controller
    {
        //
        // GET: /Mobile/Painel/

        public ActionResult Index()
        {
            return Content("Área Para Dispositivos Móveis");
        }

    }
}
