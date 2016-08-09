using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CadeMeuMedico.Repositories;

namespace CadeMeuMedico.Repositories
{
    public class CookieRepository
    {
        public static void RegistraCookieAutenticacao(long IDUsuario)
        {
            HttpCookie UserCookie = new HttpCookie("UserCookieAuthentication");
            UserCookie.Values["IDUsuario"] = CryptRepository.Criptografar(IDUsuario.ToString());
            UserCookie.Expires = DateTime.Now.AddDays(1); // Configurar o cookie para expirar em 1 dia
            HttpContext.Current.Response.Cookies.Add(UserCookie); // Setar cookie
        }
    }
}