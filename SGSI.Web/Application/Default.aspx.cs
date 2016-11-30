using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SGSI.Web.Business;
using SGSI.Web.Entity;

namespace SGSI.Web.Application
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public int ConsultarLogin(string email, string senha)
        {
            SGSIBusiness ca = new SGSIBusiness();
            int retorno = 0;
           
            List<EntityUsuarios> dados = new List<EntityUsuarios>();
            dados = ca.ConsultarLogin(email, senha);

            retorno = dados[0].Retorno;



            if (retorno == 1) {
                Session["Gerente"] = dados[0].Gerente;
                Session["TipoAcesso"] = dados[0].TipoAcesso;
                int tipoAcesso = Convert.ToInt32(Session["TipoAcesso"]);
                Session["USER_ID"] = dados[0].UserId;
                Session["EMAIL"] = dados[0].Email;
                Session["NOME"] = dados[0].Nome;
                Session["CARGO"] = dados[0].Cargo;
                Session["DEPARTAMENTO_ID"] = dados[0].DepartamentoId;
                if (tipoAcesso == 1)
                {
                    Response.Redirect("SecurityOffice.aspx");
                }
                else if (tipoAcesso == 2)
                {
                    Response.Redirect("Manager.aspx");
                }
                else if (tipoAcesso == 3)
                {
                    Response.Redirect("Executors.aspx");
                }

            }
            return retorno;
        }
    }
}