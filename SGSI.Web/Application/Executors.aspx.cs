using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SGSI.Web.Business;
using SGSI.Web.Entity;
using System.Security.Permissions;
using System.IO;
using System.Drawing;

namespace SGSI.Web.Application
{

    public partial class Executors : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {




            //var instanceReporteSource = new Telerik.Reporting.InstanceReportSource();
            //RelatorioProcedimentoExecutado report = new RelatorioProcedimentoExecutado();
            //report.ReportParameters["ProcedimentoId"].Value = 17;
            //instanceReporteSource.ReportDocument = new RelatorioProcedimentoExecutado();

            //ReportViewer1.ReportSource = instanceReporteSource;



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

        //public void PassarPram()
        //{
        //    RelatorioProcedimentoExecutado r1 = new RelatorioProcedimentoExecutado();
        //    r1.Report.ReportParameters[0].Value = 17;
        //    ReportViewer1.RefreshReport();
        //}

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
            string executador = Convert.ToString(Session["Nome"]);
            string cargo = Convert.ToString(Session["CARGO"]);
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.AtualizarProcedimento(procedimentoId, departamentoId, responsavelAtual, cargo, situacaoId, progresso, situacaoHistoricoId, executador);
            if (retorno == 1)
            {
                storeProcedimentos.Reload();
            }
            return retorno;
        }

        [DirectMethod]
        public int AtualizarConcluirProcedimento(int procedimento, int departamento, int situacaoId, double progresso, int situacaoHistoricoId)
        {
            int retorno;
            int procedimentoId = Convert.ToInt32(procedimento);
            int departamentoId = Convert.ToInt32(departamento);
            string responsavelAtual = Convert.ToString(Session["Gerente"]);
            string executador = Convert.ToString(Session["Nome"]);
            string cargo = "Gerente";
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.AtualizarProcedimento(procedimentoId, departamentoId, responsavelAtual, cargo, situacaoId, progresso, situacaoHistoricoId, executador);
            if (retorno == 1)
            {
                storeProcedimentos.Reload();
                WinConcProce.Hide();
            }
            return retorno;
        }

        [DirectMethod]
        public int DelegarProcedimento(string procedimento, string responsavelAtual, int situacaoId, double progresso, int situacaoHistoricoId, string cargo)
        {
            int retorno;
            int procedimentoId = Convert.ToInt32(procedimento);
            //int departamentoId = Convert.ToInt32(departamento);
            int departamentoId = Convert.ToInt32(Session["DEPARTAMENTO_ID"]);
            SGSIBusiness ca = new SGSIBusiness();
            string executador = Convert.ToString(Session["NOME"]);
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


        [DirectMethod]
        public int SalvarEvidencia(string procedimento, string descricao)
        {
            int procedimentoId = Convert.ToInt32(procedimento);
            int retorno;
            string destino = "/Evidencias/";
            HttpPostedFile file = this.FileUploadEviden.PostedFile; // or this.Request.Files[0]
            string fileName = file.FileName;
            string path = Server.MapPath(null) + destino + procedimento + ".jpeg";
            string caminho = destino + procedimento + ".jpeg";
            string executador = Convert.ToString(Session["NOME"]);
            file.SaveAs(path);
            SGSIBusiness ca = new SGSIBusiness();
            DateTime data = DateTime.Now;
            retorno = ca.SalvarEvidencia(procedimentoId, caminho, descricao, executador, data);

            return retorno;
        }


        //[DirectMethod]
        //public void CarregaImagem()
        //{
        //    string destino = "/Temp/";
        //    HttpPostedFile file = this.FileUploadEviden.PostedFile; // or this.Request.Files[0]
        //    string fileName = file.FileName;
        //    string path = Server.MapPath(null) + destino + fileName;
        //    file.SaveAs(path);
        //    string img = "Temp/" + fileName;
        //    imgEvid.ImageUrl = img;
        //    imgEvid.Hidden = false;

        //    //imgEvid.SetSize(500, 500);


        //}




        public void NotificarProcedimento()
        {

            int retorno = 10;
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