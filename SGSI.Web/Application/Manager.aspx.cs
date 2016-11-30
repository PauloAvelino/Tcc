using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SGSI.Web.Business;
using SGSI.Web.Entity;
using Newtonsoft;
using System.Security.Permissions;
using Telerik.Reporting;
using Telerik.ReportViewer.WebForms;
using Microsoft.Reporting.WebForms;
using SGSI.Web.Application.Relatórios;

namespace SGSI.Web.Application
{
    public partial class Manager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EMAIL"] != null)
            {
                TabPanel1.Title = "Bem vindo(a) " + Session["EMAIL"].ToString();
                Initializer();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        public void Initializer()
        {
            int dptoId = Convert.ToInt32(Session["DEPARTAMENTO_ID"]);
            int userId = Convert.ToInt32(Session["USER_ID"]);
            string nome = Convert.ToString(Session["NOME"]);

            SGSIBusiness ca = new SGSIBusiness();
            storeProcedimentos.DataSource = ca.CarregarProcedimentos(userId);
            storeProcedimentos.DataBind();
            storeCarregaNormas.DataSource = ca.CarregarNormas();
            storeCarregaNormas.DataBind();
            storeCmbNormas.DataSource = ca.CarregarCmbNormas();
            storeCmbNormas.DataBind();
            storeDepartamentos.DataSource = ca.CarregarCmbDepartamentos();
            storeDepartamentos.DataBind();
            storeFuncionarios.DataSource = ca.CarregarCmbFuncionarios(dptoId);
            storeFuncionarios.DataBind();
            HUserName.Value = Convert.ToString(Session["NOME"]);
            //NotificarProcedimento();

        }

        [DirectMethod]
        public void Sair()
        {

            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        [DirectMethod]
        public void CarregaHistoricoProc(string procId)
        {
            int procedimentoId = Convert.ToInt32(procId);
            SGSIBusiness ca = new SGSIBusiness();
            storeHistoricoProc.DataSource = ca.CarregaHistoricoProc(procedimentoId);
            storeHistoricoProc.DataBind();
        }

        [DirectMethod]
        public int ApagarProcedimento(string proc)
        {
            int procedimentoId = Convert.ToInt32(proc);
            int retorno;
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.ApagarProcedimento(procedimentoId);
            if (retorno == 1)
            {
                storeProcedimentos.Reload();
            }

            return retorno;
        }

        [DirectMethod]
        public void AbrirNorma(string caminho)
        {
            System.Diagnostics.Process.Start(caminho);

        }

        [DirectMethod]
        public int SalvarProcedimento(string nome, string norma, string dpId, DateTime dtInicial, DateTime dtFinal, string descricao)
        {
            string solicitante = Convert.ToString(Session["NOME"]);
            int situacaoId = 1;
            int situacaoHistoricoId = 1;
            double progresso = 0.0;
            int dptoId = Convert.ToInt32(dpId);
            SGSIBusiness ca = new SGSIBusiness();
            return ca.SalvarProcedimento(solicitante, nome, norma, dptoId, dtInicial, dtFinal, situacaoId, progresso, descricao, situacaoHistoricoId);
        }

        [DirectMethod]
        public int AtualizarProcedimento(string procedimento, int departamentoId, int situacaoId, double progresso, int situacaoHistoricoId)
        {
            int retorno;
            int procedimentoId = Convert.ToInt32(procedimento);
            //int departamentoId = Convert.ToInt32(departamento);
            string responsavelAtual = Convert.ToString(Session["NOME"]);
            string cargo = Convert.ToString(Session["CARGO"]);
            string executador = Convert.ToString(Session["NOME"]);
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.AtualizarProcedimento(procedimentoId, departamentoId, responsavelAtual, cargo, situacaoId, progresso, situacaoHistoricoId, executador);
            if (retorno == 1)
            {
                storeProcedimentos.Reload();

            }
            return retorno;
        }

        [DirectMethod]
        public void CarregarRelatorio(string procedimento)
        {


        }
        
        [DirectMethod]
        public int DelegarProcedimento(string procedimento, string responsavelAtual, int situacaoId, double progresso, int situacaoHistoricoId, string cargo)
        {
            int retorno;
            int procedimentoId = Convert.ToInt32(procedimento);
            //int departamentoId = Convert.ToInt32(departamento);
            int departamentoId = Convert.ToInt32(Session["DEPARTAMENTO_ID"]);
            string executador = Convert.ToString(Session["NOME"]);
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.AtualizarProcedimento(procedimentoId, departamentoId, responsavelAtual, cargo, situacaoId, progresso, situacaoHistoricoId, executador);
            if (retorno == 1)
            {
                storeProcedimentos.Reload();
            }
            return retorno;
        }

        [DirectMethod]
        public void CarregaComboFuncionario()
        {
            int dptoId = Convert.ToInt32(Session["DEPARTAMENTO_ID"]);
            SGSIBusiness ca = new SGSIBusiness();
            storeFuncionarios.DataSource = ca.CarregarCmbFuncionarios(dptoId);
            storeFuncionarios.DataBind();

        }


        [DirectMethod]
        public void CarregaEmailCargoFuncionario(string nome)
        {
            int departamentoId = Convert.ToInt32(Session["DEPARTAMENTO_ID"]);
            SGSIBusiness ca = new SGSIBusiness();
            List<EntityFuncionarios> dados = new List<EntityFuncionarios>();
            dados = ca.CarregarEmailCargo(nome, departamentoId);
            TextNewUserEmail.Value = dados[0].email;
            TextNewUserCargo.Value = dados[0].cargo;
        }
        public void NotificarProcedimento()
        {

            int retorno = 0;
            string usuario = Convert.ToString(Session["NOME"]);
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.NotificarProc(usuario);
            if (retorno > 0)
            {
                NotificProc.Text = Convert.ToString(retorno);
            }
        }


    }
}