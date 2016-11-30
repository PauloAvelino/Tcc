using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGSI.Data;

using System.Data;

namespace SGSI.Web.Entity
{
    public class EntityFuncionarios
    {
        public string email {
            get;
            set;
        }

        public string cargo {
            get;
            set;
        }

        public int departamentoId {
            get;
            set;
        }
        public static void Binding(EntityFuncionarios o, System.Data.IDataReader dr)
        {
            SqlHelper.ReflectionBinding(dr, o);
        }
    }
}