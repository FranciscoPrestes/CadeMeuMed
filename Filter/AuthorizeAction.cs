using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CadeMeuMedico.Repositories;
using System.Web.Mvc;

namespace CadeMeuMedico.Filter
{
    [HandleError] // Torna a classe como um gerenciador de erros
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filter)
        {
            var c = filter.ActionDescriptor.ControllerDescriptor.ControllerName;
            var a = filter.ActionDescriptor.ActionName;
            string[] IgnoreRoutes = {
                "Home", "Usuario", "Login", "Publico", "PublicoPost", "LoginUsuario"
            };
            //if (c != "Home" || a != "Login" && a != "EsqueceuSuaSenha" || c != "UsuarioController" && a != "LoginUsuario")
            if (!Array.Exists(IgnoreRoutes, element => element == c) || !Array.Exists(IgnoreRoutes, element => element == a))
            {
                if (UsuarioRepository.checkUsuarioLogado() == null)
                {
                    filter.RequestContext.HttpContext.Response.Redirect("/Home/Login?Url=" + filter.HttpContext.Request.Url.LocalPath);
                }
            }
        }
    }
}
