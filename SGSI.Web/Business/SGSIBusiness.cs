using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SGSI.Web.Data;
using System.Data;
using SGSI.Data;
using SGSI.Web.Entity;

namespace SGSI.Web.Business
{
    public class SGSIBusiness
    {

        //public int ConsultarLogin(string email, string senha)
        //{
        //    DBSGSI db = new DBSGSI();

        //    return db.ConsultarLogin(email, senha);

        //}
        public int AdicionarUsuario(string nome, string cargo, int departamentoId, string email, int tipo, string senha)
        {

            DBSGSI db = new DBSGSI();

            return db.InsereNovoUsuario(nome, cargo, departamentoId, email, tipo, senha);
        }

        public int SalvarNorma(string nome, int dpId, string local, DateTime criacao, string autor)
        {

            DBSGSI db = new DBSGSI();

            return db.SalvaNorma(nome, dpId, local, criacao, autor);
        }

        public int SalvarEvidencia(int procedimentoId, string local, string descricao, string executador, DateTime data)
        {

            DBSGSI db = new DBSGSI();

            return db.SalvarEvidencia(procedimentoId, local, descricao, executador, data);
        }
        public List<object> CarregarUsuarios()
        {
            DBSGSI db = new DBSGSI();

            return db.CarregarUsuarios<object>(delegate (IDataReader dr)
            {
                return new
                {
                    Nome = SqlHelper.GetString(dr, "Nome"),
                    Departamento = SqlHelper.GetString(dr, "Departamento"),
                    Cargo = SqlHelper.GetString(dr, "Cargo"),
                    Email = SqlHelper.GetString(dr, "Email"),
                    Ativo = SqlHelper.GetInt(dr, "Ativo")
                };
            });



        }

        public List<object> CarregaHistoricoProc(int procedimentoId)
        {
            DBSGSI db = new DBSGSI();
            return db.CarregaHistoricoProc<object>(delegate (IDataReader dr)
            {

                return new
                {
                    HistoricoId = SqlHelper.GetInt(dr, "HistoricoId"),
                    ProcedimentoId = SqlHelper.GetInt(dr, "ProcedimentoId"),
                    Usuario = SqlHelper.GetString(dr, "Usuario"),
                    DataHistorico = SqlHelper.GetDateTime(dr, "DataHistorico"),
                    Atualizacao = SqlHelper.GetString(dr, "Atualizacao")

                };
            }, procedimentoId);
        }
        public List<object> CarregarCmbDepartamentos()
        {
            DBSGSI db = new DBSGSI();
            return db.CarregarCmbDepartamentos<object>(delegate (IDataReader dr)
            {
                return new
                {
                    Id = SqlHelper.GetInt(dr, "Id"),
                    Nome = SqlHelper.GetString(dr, "Nome")
                };
            });

        }

        public List<object> CarregarProcedimentos(int userId)
        {
            DBSGSI db = new DBSGSI();
            return db.CarregarProcedimentos<object>(delegate (IDataReader dr)
            {
                return new
                {
                    Descricao = SqlHelper.GetString(dr, "Descricao"),
                    Solicitante = SqlHelper.GetString(dr, "Solicitante"),
                    ProcedimentoId = SqlHelper.GetInt(dr, "ProcedimentoId"),
                    DepartamentoId = SqlHelper.GetInt(dr, "DepartamentoId"),
                    Nome = SqlHelper.GetString(dr, "Nome"),
                    Norma = SqlHelper.GetString(dr, "Norma"),
                    DataInicial = SqlHelper.GetDateTime(dr, "DataInicial"),
                    DataFinal = SqlHelper.GetDateTime(dr, "DataFinal"),
                    Departamento = SqlHelper.GetString(dr, "Departamento"),
                    ResponsavelAtual = SqlHelper.GetString(dr, "ResponsavelAtual"),
                    Cargo = SqlHelper.GetString(dr, "Cargo"),
                    Situacao = SqlHelper.GetString(dr, "Situacao"),
                    Progresso = SqlHelper.GetDouble(dr, "Progresso"),
                    Caminho = SqlHelper.GetString(dr, "Caminho")
                };
            }, userId);

        }



        public List<object> CarregarCmbGrupos()
        {
            DBSGSI db = new DBSGSI();
            return db.CarregaCmbGrupos<object>(delegate (IDataReader dr)
            {
                return new
                {
                    AcessoId = SqlHelper.GetInt(dr, "AcessoId"),
                    Descricao = SqlHelper.GetString(dr, "Descricao")
                };
            });

        }

        public List<object> CarregarCmbFuncionarios(int dptoId)
        {
            DBSGSI db = new DBSGSI();
            return db.CarregarCmbFuncionarios<object>(delegate (IDataReader dr)
            {
                return new
                {
                    Nome = SqlHelper.GetString(dr, "Nome"),
                    Email = SqlHelper.GetString(dr, "Email"),
                    Cargo = SqlHelper.GetString(dr, "Cargo"),
                };
            }, dptoId);

        }


        public int SalvarProcedimento(string solicitante, string nome, string norma, int dpId, DateTime dtInicial, DateTime dtFinal, int situacaoId, double progresso, string descricao, int situacaoHistoricoId)
        {
            DBSGSI db = new DBSGSI();
            return db.SalvarProcedimento(solicitante, nome, norma, dpId, dtInicial, dtFinal, situacaoId, progresso, descricao, situacaoHistoricoId);

        }

        public int AtualizarProcedimento(int procedimentoId, int departamentoId, string responsavelAtual, string cargo, int situacaoId, double progresso, int situacaoHistoricoId, string executador)
        {
            DateTime dataAtual = DateTime.Now;
            DBSGSI db = new DBSGSI();
            return db.AtualizarProcedimento(procedimentoId, departamentoId, responsavelAtual, cargo, situacaoId, progresso, situacaoHistoricoId, executador, dataAtual);

        }

        public List<object> CarregarCmbNormas()
        {
            DBSGSI db = new DBSGSI();
            return db.CarregaCmbNormas<object>(delegate (IDataReader dr)
            {
                return new
                {
                    Nome = SqlHelper.GetString(dr, "Nome"),
                    Caminho = SqlHelper.GetString(dr, "Caminho")
                };
            });

        }


        public List<object> CarregarNormas()
        {
            DBSGSI db = new DBSGSI();
            return db.CarregaNormas<object>(delegate (IDataReader dr)
            {
                return new
                {
                    NormaId = SqlHelper.GetInt(dr, "NormaId"),
                    Nome = SqlHelper.GetString(dr, "Nome"),
                    Criacao = SqlHelper.GetDateTime(dr, "DataCriacao"),
                    Autor = SqlHelper.GetString(dr, "Autor"),
                    Caminho = SqlHelper.GetString(dr, "Caminho"),
                    Atualizacao = SqlHelper.GetDateTime(dr, "DataAtualizacao"),
                    Departamento = SqlHelper.GetString(dr, "Departamento")
                };
            });

        }

        public List<EntityFuncionarios> CarregarEmailCargo(string nome, int dpId)
        {
            DBSGSI db = new DBSGSI();
            return db.CarregarEmailCargo<EntityFuncionarios>(EntityFuncionarios.Binding, nome, dpId);
        }

        public List<EntityUsuarios> ConsultarLogin(string email, string senha)
        {
            DBSGSI db = new DBSGSI();
            return db.ConsultarLogin<EntityUsuarios>(EntityUsuarios.Binding, email, senha);
        }

        public int AtualizarUsuario(string email, int ativo)
        {

            DBSGSI db = new DBSGSI();

            return db.AtualizarUsuario(email, ativo);
        }

        public int AlterarSenhaUsuario(string email, string senha)
        {
            DBSGSI db = new DBSGSI();
            return db.AlterarSenhaUsuario(email, senha);
        }

        public int ApagarProcedimento(int procedimentoId)
        {
            DBSGSI db = new DBSGSI();
            return db.ApagarProcedimento(procedimentoId);
        }

        public int ApagarNorma(int normaId)
        {
            DBSGSI db = new DBSGSI();
            return db.ApagarNorma(normaId);
        }
        public int AtualizarNorma(int normaId, DateTime data, string autor)
        {
            DBSGSI db = new DBSGSI();
            return db.AtualizarNorma(normaId, data, autor);
        }

        public List<object> CarregaHistoricoNorma(int normaId)
        {
            DBSGSI db = new DBSGSI();
            return db.CarregaHistoricoNorma<object>(delegate (IDataReader dr)
            {
                return new
                {

                    HistoricoNormaId = SqlHelper.GetInt(dr, "HistoricoNormaId"),                  
                    Usuario = SqlHelper.GetString(dr, "Usuario"),
                    Situacao = SqlHelper.GetString(dr, "Situacao"),
                    DataAtualizacao = SqlHelper.GetDateTime(dr, "DataAtualizacao")
                };
            }, normaId);

        }

        public int NotificarProc(string usuario)
        {

            DBSGSI db = new DBSGSI();

            return db.NotificarProc(usuario);
        }
    }
}