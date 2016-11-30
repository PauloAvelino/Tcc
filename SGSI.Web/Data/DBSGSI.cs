using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using SGSI.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SGSI.Web.Data
{
    public class DBSGSI
    {
        public int InsereNovoUsuario(string nome, string cargo, int departamentoId, string email, int tipo, string senha)
        {


            int p_retorno = 0;

            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "InsereUsuario",
                new object[] {
                nome,
                cargo,
                departamentoId,
                email,
                tipo,
                senha,
                p_retorno},
                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );


            return p_retorno;

        }


        public List<TValue> CarregaHistoricoProc<TValue>(CreateInstanceBindingHandler<TValue> binding, int procedimentoId)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaHistoricoProcedimento",
                binding,
                new object[] {
                procedimentoId
                });
        }
        public List<TValue> CarregarUsuarios<TValue>(CreateInstanceBindingHandler<TValue> binding)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                 SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaUsuarios",
                binding);
        }

        public List<TValue> CarregaNormas<TValue>(CreateInstanceBindingHandler<TValue> binding)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                 SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaNormas",
                binding);
        }

        public List<TValue> CarregaCmbGrupos<TValue>(CreateInstanceBindingHandler<TValue> binding)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                 SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaCmbGrupo",
                binding);
        }

        public List<TValue> CarregarCmbDepartamentos<TValue>(CreateInstanceBindingHandler<TValue> binding)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaCmbDepartamento",
                binding
               );
        }

        public int SalvaNorma(string nome, int dpId, string local, DateTime criacao, string autor)
        {
            int p_retorno = 0;
            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "SalvarNorma",
                new object[] {
                nome,
                dpId,
                criacao,
                autor,
                local,
                p_retorno},
                        delegate (Database db, DbCommand commandWrapper)
                        {
                            p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                        }
                        );
            return p_retorno;
        }

        public int SalvarEvidencia(int procedimentoId, string local, string descricao, string executador, DateTime data)
        {
            int p_retorno = 0;
            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "SalvarEvidencia",
                new object[] {
                procedimentoId,
                local,
                descricao,
                executador,
                data,
                p_retorno},
                        delegate (Database db, DbCommand commandWrapper)
                        {
                            p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                        }
                        );
            return p_retorno;
        }
        public List<TValue> CarregarCmbFuncionarios<TValue>(CreateInstanceBindingHandler<TValue> binding, int dptoId)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaCmbFuncionario",
                binding,
                new object[] {
                dptoId
                });
        }

        public List<TValue> CarregarEmailCargo<TValue>(BindingHandler<TValue> binding, string nome, int dpId)
        {
            return SqlHelperFactory.GetListDB<TValue>(
                SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaEmailCargo",
                binding,
                nome,
                dpId);
        }

        public List<TValue> CarregarProcedimentos<TValue>(CreateInstanceBindingHandler<TValue> binding, int userId)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
               SGSI.Settings.Settings.Default.InstanceDB,
               "CarregaProcedimentos",
                binding,
                   new object[] {
                   userId
                });
        }


        public List<TValue> CarregaCmbNormas<TValue>(CreateInstanceBindingHandler<TValue> binding)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
                SGSI.Settings.Settings.Default.InstanceDB,
                "CarregaCmbNorma",
                binding
               );
        }

        public List<TValue> ConsultarLogin<TValue>(BindingHandler<TValue> binding, string email, string senha)
        {
            int retorno = 0;
            return SqlHelperFactory.GetListDB<TValue>(
                SGSI.Settings.Settings.Default.InstanceDB,
                "ValidarLogin",
                binding,
                email,
                senha,
                retorno
                );
        }

        public int AtualizarUsuario(string email, int ativo)
        {
            int p_retorno = 0;

            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "AtivaDesativaUsuarios",
                new object[] {
                email,
                ativo,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }


        public int SalvarProcedimento(string solicitante, string nome, string norma, int dpId, DateTime dtInicial, DateTime dtFinal, int situacaoId, double progresso, string descricao, int situacaoHistoricoId)
        {
            int p_retorno = 0;
            DateTime horaAtual = DateTime.Now;
            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "SalvarProcedimento",
                new object[] {
                horaAtual,
                solicitante,
                nome,
                norma,
                dpId,
                dtInicial,
                dtFinal,
                situacaoId,
                progresso,
                descricao,
                situacaoHistoricoId,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }

        public int AtualizarProcedimento(int procedimentoId, int departamentoId, string responsavel, string cargo, int situacaoId, double progresso, int situacaoHistoricoId, string executador, DateTime dataAtual)
        {
            int p_retorno = 0;
            DateTime horaAtual = DateTime.Now;
            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "AtualizarProcedimento",
                new object[] {
                procedimentoId,
                departamentoId,
                responsavel,
                cargo,
                situacaoId,
                progresso,
                situacaoHistoricoId,
                executador,
                dataAtual,
                p_retorno},

              delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }


        public int AlterarSenhaUsuario(string email, string senha)
        {
            int p_retorno = 0;

            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "AlterarSenhaUsuarios",
                new object[] {
                email,
                senha,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }


        public int ApagarProcedimento(int procedimentoId)
        {
            int p_retorno = 0;

            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "ApagarProcedimento",
                new object[] {
                procedimentoId,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }

        public int ApagarNorma(int normaId)
        {
            int p_retorno = 0;

            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "ApagarNorma",
                new object[] {
                normaId,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }

        public int AtualizarNorma(int normaId, DateTime data, string autor)
        {
            int p_retorno = 0;

            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "AtualizarNorma",
                new object[] {
                normaId,
                data,
                autor,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }

        public List<TValue> CarregaHistoricoNorma<TValue>(CreateInstanceBindingHandler<TValue> binding, int normaId)
        {
            return SqlHelperFactory.GetListCreateInstanceDB<TValue>(
               SGSI.Settings.Settings.Default.InstanceDB,
               "CarregaHistoricoNormas",
                binding,
                   new object[] {
                   normaId
                });
        }
        public int NotificarProc(string usuario)
        {
            int p_retorno = 0;
            DateTime horaAtual = DateTime.Now;
            SqlHelperFactory.ExecuteNonQuery(
                SGSI.Settings.Settings.Default.InstanceDB,
                "NotificProc",
                new object[] {
                usuario,
                p_retorno},

                delegate (Database db, DbCommand commandWrapper)
                {
                    p_retorno = Convert.ToInt32(db.GetParameterValue(commandWrapper, "p_retorno"));
                }
                );

            return p_retorno;

        }
    }
}