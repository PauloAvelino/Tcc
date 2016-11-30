using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGSI.Data;

using System.Data;

namespace SGSI.Web.Entity
{
    public class EntityUsuarios
    {
        public int UserId
        {
            get;
            set;
        }
        public string Nome
        {
            get;
            set;
        }
        public string Cargo
        {
            get;
            set;
        }
        public string Email {
            get;
            set;
        }
       
        public int TipoAcesso
        {
            get;
            set;
        }
        public int DepartamentoId
        {
            get;
            set;
        }

        public int Retorno
        {
            get;
            set;
        }

        public string Gerente
        {
            get;
            set;
        }
        public static void Binding(EntityUsuarios o, System.Data.IDataReader dr)
        {
            SqlHelper.ReflectionBinding(dr, o);
        }
    }
}