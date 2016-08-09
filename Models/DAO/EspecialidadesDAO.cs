using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CadeMeuMedico.Models.POCO;

namespace CadeMeuMedico.Models.DAO
{
    public class EspecialidadesDAO
    {
        private EntidadesCadeMeuMedicoBD db;

        public EspecialidadesDAO()
        {
            db = new EntidadesCadeMeuMedicoBD();
        }

        public List<Especialidades> GetList()
        {
            return db.Especialidades.ToList();
        }

        public List<DropDownListBuilder> GetDropDowList()
        {
            List<DropDownListBuilder> especialidades = new List<DropDownListBuilder>();

            var listaCidades = this.GetList();

            //zerado
            especialidades.Add(new DropDownListBuilder { Nome = "Selecione", Valor = 0 });

            foreach (var item in listaCidades)
            {
                especialidades.Add(new DropDownListBuilder { Nome = item.Nome, Valor = item.IDEspecialidade });
            }

            return especialidades;
        }
    }
}

