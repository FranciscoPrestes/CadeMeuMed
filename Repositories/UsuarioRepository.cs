using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CadeMeuMedico.Models;
using CadeMeuMedico.Repositories;

namespace CadeMeuMedico.Repositories
{
    public class UsuarioRepository
    {
        // Autenticar usuário
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            //var hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            var hash = Senha;
            try
            {
                using (EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD())
                {
                    var usuarioLogin = db.Usuarios.Where(x => x.Login == Login && x.Senha == hash).SingleOrDefault();
                    if (usuarioLogin == null)
                    {
                        return false;
                    }
                    else
                    {
                        /**
                         * Gravar ID do usuário no Cookie
                         */
                        CookieRepository.RegistraCookieAutenticacao(usuarioLogin.IDUsuario);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Usuarios getUsuarioId(long IDUsuario)
        {
            try
            {
                using (EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD())
                {
                    var x = db.Usuarios.Where(u => u.IDUsuario == IDUsuario).SingleOrDefault();
                    return x;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static Usuarios checkUsuarioLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (Usuario == null)
            {
                return null;
            }
            else
            {
                long IDUsuario = Convert.ToInt64(CryptRepository.Descriptografar(Usuario.Values["IDUsuario"]));
                var usuario = getUsuarioId(IDUsuario);
                return usuario;
            }
        }
    }
}