using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadeMeuMedico.Models.DAO
{
    public class MedicoDAO
    {
        private EntidadesCadeMeuMedicoBD db;
        public MedicoDAO()
        {
            
            db = new EntidadesCadeMeuMedicoBD();
            db.Configuration.ProxyCreationEnabled = false;
        }

        public List<Medicos> Pesquisa(string nome, int idCidade, int idEspecilidade)
        {
            var busca = (from m in db.Medicos
                         select m).AsQueryable();


            //nome
            if (!string.IsNullOrEmpty(nome))
            {
                busca = busca.Where(m => m.Nome.ToUpper().Contains(nome.ToUpper()));
            }

            //cidade
            if (0 != idCidade)
            {
                busca = busca.Where(m => m.IDCidade == idCidade);
            }
            //especialidade 

            if (0 != idEspecilidade)
            {
                busca = busca.Where(m => m.IDEspecialidade == idEspecilidade);
            }



            return busca.ToList();

        }
    }
}