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
using System.IO;

namespace SGSI.Web.Application
{
    public partial class SecurityOffice : System.Web.UI.Page
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

        [DirectMethod]
        public void Sair()
        {
            Session.Clear();
            Response.Redirect("Default.aspx");


        }
        protected void Initializer()
        {
            int userId = Convert.ToInt32(Session["USER_ID"]);
            string nome = Convert.ToString(Session["NOME"]);
            SGSIBusiness ca = new SGSIBusiness();
            storeUsuarios.DataSource = ca.CarregarUsuarios();
            storeUsuarios.DataBind();
            storeDepartamentos.DataSource = ca.CarregarCmbDepartamentos();
            storeDepartamentos.DataBind();
            storeGrupoUsuarios.DataSource = ca.CarregarCmbGrupos();
            storeGrupoUsuarios.DataBind();
            storeCarregaNormas.DataSource = ca.CarregarNormas();
            storeCarregaNormas.DataBind();
            storeCmbNormas.DataSource = ca.CarregarCmbNormas();
            storeCmbNormas.DataBind();
            storeProcedimentos.DataSource = ca.CarregarProcedimentos(userId);
            storeProcedimentos.DataBind();
            HUserName.Value = Convert.ToString(Session["NOME"]);
        }

        [DirectMethod]
        public int SalvarNorma(string nome, int dpId)
        {

            int retorno;
            string autor = TabPanel1.Title;
            string destino = "/Normas/";
            HttpPostedFile file = this.UploadNorma.PostedFile; // or this.Request.Files[0]
            string fileName = file.FileName;
            string path = Server.MapPath(null) + destino + nome + ".pdf";
            file.SaveAs(path);
            SGSIBusiness ca = new SGSIBusiness();
            DateTime criacao = DateTime.Now;
            retorno = ca.SalvarNorma(nome, dpId, path, criacao, autor);
            //storeCarregaNormas.Reload();
            return retorno;


        }
        [DirectMethod]
        public void AbrirNorma(string caminho)
        {
            System.Diagnostics.Process.Start(caminho);

        }

        [DirectMethod]
        public int AdicionarUsuario(string nome, string cargo, string departamento, string email, int tipo, string senha)
        {

            int departamentoId = Convert.ToInt32(departamento);
            SGSIBusiness ca = new SGSIBusiness();

            return ca.AdicionarUsuario(nome, cargo, departamentoId, email, tipo, senha);



        }

        protected void CarregaUsuarios(object sender, StoreReadDataEventArgs e)
        {
            SGSIBusiness ca = new SGSIBusiness();
            storeUsuarios.DataSource = ca.CarregarUsuarios();
            storeUsuarios.DataBind();
        }

        [DirectMethod]
        public void CarregaComboFuncionario(string dpId)
        {
            int dptoId = Convert.ToInt32(dpId);
            SGSIBusiness ca = new SGSIBusiness();
            storeFuncionarios.DataSource = ca.CarregarCmbFuncionarios(dptoId);
            storeFuncionarios.DataBind();

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
        public void CarregaEmailCargoFuncionario(string nome, string dpId)
        {
            int departamentoId = Convert.ToInt32(dpId);
            SGSIBusiness ca = new SGSIBusiness();
            List<EntityFuncionarios> dados = new List<EntityFuncionarios>();
            dados = ca.CarregarEmailCargo(nome, departamentoId);
            TextNewUserEmail.Value = dados[0].email;
            TextNewUserCargo.Value = dados[0].cargo;
        }


        [DirectMethod]
        public int AtualizarUsuario(string email, int ativo)
        {
            SGSIBusiness ca = new SGSIBusiness();

            return ca.AtualizarUsuario(email, ativo);
        }

        [DirectMethod]
        public int AlterarSenhaUsuario(string email, string senha)
        {

            SGSIBusiness ca = new SGSIBusiness();

            return ca.AlterarSenhaUsuario(email, senha);
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
        public int ApagarNorma(string norma, string caminho)
        {
            int normaId = Convert.ToInt32(norma);
            int retorno;
            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.ApagarNorma(normaId);
            if (retorno == 1)
            {
                File.Delete(caminho);
                storeCarregaNormas.Reload();
            }

            return retorno;
        }

        [DirectMethod]
        public int AtualizarNorma(string norma, string nome)
        {
            int normaId = Convert.ToInt32(norma);
            DateTime data = DateTime.Now;
            int retorno;
            string autor = Session["EMAIL"].ToString();
            string destino = "/Normas/";
            HttpPostedFile file = this.UpdateUploadNorma.PostedFile; // or this.Request.Files[0]
            string fileName = file.FileName;
            string path = Server.MapPath(null) + destino + nome + ".pdf";
            file.SaveAs(path);

            SGSIBusiness ca = new SGSIBusiness();
            retorno = ca.AtualizarNorma(normaId, data, autor);
            if (retorno == 1)
            {
                storeCarregaNormas.Reload();
            }

            return retorno;
        }

        [DirectMethod]
        public void CarregaHistoricoNorma(string norma)
        {
            int normaId = Convert.ToInt32(norma);
            SGSIBusiness ca = new SGSIBusiness();
            storeCarregaHistoricoNorma.DataSource = ca.CarregaHistoricoNorma(normaId);
            storeCarregaHistoricoNorma.DataBind();
        }

        protected void strItemSelector1_ReadData(object sender, StoreReadDataEventArgs e)
        {
            SGSIBusiness ca = new SGSIBusiness();
            strItemSelector1.DataSource = ca.CarregarCmbNormas();
            strItemSelector1.DataBind();
            
        }

        [DirectMethod]
        public void GenerateRandomUsername()
        {
            string rv = "";
            string senha = "";

            char[] lowers = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            int l = lowers.Length;
            int n = numbers.Length;

            Random random = new Random();

            rv += lowers[random.Next(0, l)].ToString();
            rv += numbers[random.Next(0, n)].ToString();
            rv += lowers[random.Next(0, l)].ToString();
            rv += numbers[random.Next(0, n)].ToString();
            rv += lowers[random.Next(0, l)].ToString();
            rv += numbers[random.Next(0, n)].ToString();
            senha += lowers[random.Next(0, l)].ToString();
            senha += lowers[random.Next(0, l)].ToString();
            senha += lowers[random.Next(0, l)].ToString();
            senha += lowers[random.Next(0, l)].ToString();
            senha += lowers[random.Next(0, l)].ToString();
            senha += numbers[random.Next(0, n)].ToString();
           
            DateTime data = DateTime.Now.Date;
            DataPublicacao.Value = data;
            SenhaAuditor.Value = senha;
            string email = rv + "@sgsi.com.br";
            UsuarioAuditor.Value = email;
            

        }

    }
}