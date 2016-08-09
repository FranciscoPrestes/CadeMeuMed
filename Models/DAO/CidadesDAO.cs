using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CadeMeuMedico.Models.POCO;

namespace CadeMeuMedico.Models.DAO
{
    public class CidadesDAO
    {
        private EntidadesCadeMeuMedicoBD db;

        public CidadesDAO()
        {
            db = new EntidadesCadeMeuMedicoBD();
        }

        public List<Cidades> GetList()
        {
            return db.Cidades.ToList();
        }

        /// <summary>
        /// Preenche do=ropdow list
        /// </summary>
        /// <returns>ddl com cidades</returns>
        public List<DropDownListBuilder> GetDropDowList()
        {
            List<DropDownListBuilder> cidades = new List<DropDownListBuilder>();

            var listaCidades = this.GetList();

            //zerado
            cidades.Add(new DropDownListBuilder { Nome = "Selecione", Valor = 0 });

            foreach (var item in listaCidades)
            {
                cidades.Add(new DropDownListBuilder { Nome = item.Nome, Valor = item.IDCidade });
            }

            return cidades;
        }

        public static string GetPrimeiraCidade()
        {
            var db = new EntidadesCadeMeuMedicoBD();

            return db.Cidades.FirstOrDefault().Nome;
        }
    }
}