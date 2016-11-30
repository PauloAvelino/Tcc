using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SGSI.Interfaces;
using log4net;

namespace SGSI.Data
{
    public class SqlHelperFactory
    {
        #region Variaveis
        /// <summary>
        /// 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        public static void ExecuteNonQuery(string instanceDb, string storedProcedureName, object[] parameterValues, ParameterOutputHandler parameterOutput)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("ExecuteNonQuery(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                db.ExecuteNonQuery(commandWrapper);

                if (parameterOutput != null)
                {
                    parameterOutput(db, commandWrapper);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        public static void ExecuteNonQuery(string instanceDb, string storedProcedureName, params object[] parameterValues)
        {
            if (log.IsDebugEnabled)
            {
                string parameters = null;
                if (parameterValues != null)
                {
                    // parameters = string.Join(",", parameterValues);
                }
                log.DebugFormat("ExecuteNonQuery(instanceDb:{0}, storedProcedureName:{1} Parameters: {2}", instanceDb, storedProcedureName, parameters);
            }

            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                db.ExecuteNonQuery(commandWrapper);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="binding"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static List<TValue> GetListDB<TValue>(string instanceDb, string storedProcedureName, params object[] parameterValues)
        {
            return GetListDB<TValue>(instanceDb, storedProcedureName, null, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeReturn"></param>
        /// <returns></returns>
        public static List<TValue> GetListDB<TValue>(string instanceDb, string storedProcedureName)
        {
            return GetListDB<TValue>(instanceDb, storedProcedureName, delegate (TValue o, IDataReader dataReader)
            {
                ((IBindingObject)o).Binding(dataReader);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeReturn"></param>
        /// <returns></returns>
        public static List<TValue> GetListDB<TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetListDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            List<TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToList<TValue>(db.ExecuteReader(commandWrapper), binding);
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeReturn"></param>
        /// <returns></returns>
        public static List<TValue> GetListDB<TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding, params object[] parameterValues)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetListDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            List<TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                if (binding == null)
                {
                    returnValue = SqlHelperFactory.SqlDataReaderToList<TValue>(db.ExecuteReader(commandWrapper));
                }
                else
                {
                    returnValue = SqlHelperFactory.SqlDataReaderToList<TValue>(db.ExecuteReader(commandWrapper), binding);
                }
            }
            return returnValue;

        }
        public static List<TValue> GetListDB<TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding, object[] parameterValues, ParameterOutputHandler parameterOutput)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetListDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            List<TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                if (binding == null)
                {
                    returnValue = SqlHelperFactory.SqlDataReaderToList<TValue>(db.ExecuteReader(commandWrapper));
                }
                else
                {
                    returnValue = SqlHelperFactory.SqlDataReaderToList<TValue>(db.ExecuteReader(commandWrapper), binding);
                }
                if (parameterOutput != null)
                {
                    parameterOutput(db, commandWrapper);
                }
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> GetDictionaryDB<TKey, TValue>(string instanceDb, string storedProcedureName)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetDictionaryDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            Dictionary<TKey, TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToDictionary<TKey, TValue>(db.ExecuteReader(commandWrapper));
            }
            return returnValue;
        }

        public static Dictionary<TKey, TValue> GetDictionaryDB<TKey, TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetDictionaryDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            Dictionary<TKey, TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToDictionary<TKey, TValue>(db.ExecuteReader(commandWrapper), binding);
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> GetDictionaryDB<TKey, TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding, params object[] parameterValues)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetDictionaryDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            Dictionary<TKey, TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToDictionary<TKey, TValue>(db.ExecuteReader(commandWrapper), binding);
            }
            return returnValue;

        }

        public static Dictionary<TKey, TValue> GetDictionaryDB<TKey, TValue>(string instanceDb, string storedProcedureName, params object[] parameterValues)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetDictionaryDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            Dictionary<TKey, TValue> returnValue = null;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToDictionary<TKey, TValue>(db.ExecuteReader(commandWrapper));
            }
            return returnValue;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="binding"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static TValue GetObjectDB<TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding, params object[] parameterValues)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetObjectDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            return SqlHelperFactory.SqlDataReaderToObject<TValue>(instanceDb, storedProcedureName, binding, parameterValues);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="binding"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public static TValue GetObjectDB<TValue>(string instanceDb, string storedProcedureName, CreateInstanceBindingHandler<TValue> binding, params object[] parameterValues)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetObjectDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            return SqlHelperFactory.SqlDataReaderToObject<TValue>(instanceDb, storedProcedureName, binding, parameterValues);
        }

        public static List<TValue> SqlDataReaderToList<TValue>(IDataReader dr)
        {
            return SqlDataReaderToList<TValue>(dr, delegate (TValue o, IDataReader dataReader)
            {
                ((IBindingObject)o).Binding(dataReader);
            });
        }
        /// 
        /// </summary>
        /// <param name="sdrReader"></param>
        /// <param name="objTipo"></param>
        /// <returns></returns>
        public static List<TValue> SqlDataReaderToList<TValue>(IDataReader sdrReader, BindingHandler<TValue> binding)
        {
            // GSB - 07032003 - Declara e inicializa objetos
            List<TValue> arrLista = new List<TValue>();

            TValue objEntidade;

            // GSB - 07032003 - Varre os registros e converte o Data Reader em um Array de Entidades
            while (sdrReader.Read())
            {
                // GSB - 010072003 - Cria instância do tipo de negócio específico
                objEntidade = Activator.CreateInstance<TValue>();

                binding(objEntidade, sdrReader);

                // GSB - 07032003 - Adiciona a nova entidade no Array
                arrLista.Add(objEntidade);
            }
            sdrReader.Close();
            // GSB - 07032003 - Retorna o array list para quem chamou.
            return arrLista;
        }

        public static Dictionary<TKey, TValue> SqlDataReaderToDictionary<TKey, TValue>(IDataReader dr)
        {
            return SqlDataReaderToDictionary<TKey, TValue>(dr, delegate (TValue o, IDataReader dataReader)
            {
                ((IBindingObject)o).Binding(dataReader);
            });
        }
        /// </summary>
        /// <param name="sdrReader"></param>
        /// <param name="objTipo"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> SqlDataReaderToDictionary<TKey, TValue>(IDataReader sdrReader, BindingHandler<TValue> binding)
        {
            Dictionary<TKey, TValue> arrDict = new Dictionary<TKey, TValue>();

            TValue objEntidade;

            while (sdrReader.Read())
            {
                objEntidade = Activator.CreateInstance<TValue>();

                //((IBindingObject)objEntidade).Binding(sdrReader);
                binding(objEntidade, sdrReader);

                arrDict[(TKey)((IKeyItemCacheFactory)objEntidade).Key] = objEntidade;
            }
            sdrReader.Close();
            return arrDict;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sdrReader"></param>
        /// <returns></returns> 
        internal static TValue SqlDataReaderToObject<TValue>(IDataReader sdrReader, BindingHandler<TValue> binding)
        {
            // GSB - 07032003 - Declara e inicializa objetos             
            TValue objEntidade = default(TValue);

            // GSB - 07032003 - Varre os registros e converte o Data Reader em um Array de Entidades
            while (sdrReader.Read())
            {
                // GSB - 010072003 - Cria instância do tipo de negócio específico
                objEntidade = Activator.CreateInstance<TValue>();

                //((IBindingObject)objEntidade).Binding(sdrReader);
                binding(objEntidade, sdrReader);

                // GSB - 07032003 - Adiciona a nova entidade no Array
                break;
            }
            sdrReader.Close();
            return objEntidade;
        }

        public static TValue SqlDataReaderToObject<TValue>(string instanceDb, string storedProcedureName, CreateInstanceBindingHandler<TValue> binding, params object[] parameterValues)
        {
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            TValue returnValue;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToObject<TValue>(db.ExecuteReader(commandWrapper), binding);
            }
            return returnValue;

        }

        internal static TValue SqlDataReaderToObject<TValue>(IDataReader sdrReader, CreateInstanceBindingHandler<TValue> binding)
        {
            // GSB - 07032003 - Declara e inicializa objetos             
            TValue objEntidade = default(TValue);

            // GSB - 07032003 - Varre os registros e converte o Data Reader em um Array de Entidades
            if (sdrReader.Read())
            {
                objEntidade = binding(sdrReader);
            }
            sdrReader.Close();
            return objEntidade;
        }

        public static TValue SqlDataReaderToObject<TValue>(string instanceDb, string storedProcedureName, params object[] parameterValues)
        {
            return SqlHelperFactory.SqlDataReaderToObject<TValue>(instanceDb,
                                            storedProcedureName,
                                            delegate (TValue o, IDataReader dataReader)
                                            {
                                                ((IBindingObject)o).Binding(dataReader);
                                            },
                                            parameterValues);

        }

        public static TValue SqlDataReaderToObject<TValue>(string instanceDb, string storedProcedureName, BindingHandler<TValue> binding, params object[] parameterValues)
        {
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);
            TValue returnValue;

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                returnValue = SqlHelperFactory.SqlDataReaderToObject<TValue>(db.ExecuteReader(commandWrapper), binding);
            }
            return returnValue;

        }

        public static XmlReader ExecuteXmlReader(string instanceDb, string storedProcedureName, params object[] parameterValues)
        {
            SqlDatabase db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb) as SqlDatabase;
            XmlReader returnValue = null;
            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                returnValue = db.ExecuteXmlReader(commandWrapper);
            }
            return returnValue;
        }

        public static IDataReader ExecuteReader(string instanceDb, string storedProcedureName)
        {
            SqlDatabase db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb) as SqlDatabase;
            IDataReader returnValue = null;
            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName))
            {
                returnValue = db.ExecuteReader(commandWrapper);
            }
            return returnValue;
        }

        public static IDataReader ExecuteReader(string instanceDb, string storedProcedureName, params object[] parameterValues)
        {
            SqlDatabase db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb) as SqlDatabase;
            IDataReader returnValue = null;
            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                returnValue = db.ExecuteReader(commandWrapper);
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceDb"></param>
        /// <param name="commandSql"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReaderCommandText(string instanceDb, string commandSql)
        {
            SqlDatabase db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb) as SqlDatabase;
            IDataReader returnValue = null;
            using (commandWrapper = db.GetSqlStringCommand(commandSql))
            {
                returnValue = db.ExecuteReader(commandWrapper);
            }
            return returnValue;
        }
        public static List<TValue> GetListCreateInstanceDB<TValue>(string instanceDb, string storedProcedureName, CreateInstanceBindingHandler<TValue> binding, object[] parameterValues)
        {
            return GetListCreateInstanceDB(instanceDb, storedProcedureName, binding, parameterValues, null);
        }

        public static List<TValue> GetListCreateInstanceDB<TValue>(string instanceDb, string storedProcedureName, CreateInstanceBindingHandler<TValue> binding, object[] parameterValues, ParameterOutputHandler parameterOutput)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("GetListCreateInstanceDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            SqlDatabase db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb) as SqlDatabase;
            List<TValue> returnValue = new List<TValue>();

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName, parameterValues))
            {
                IDataReader sdrReader = db.ExecuteReader(commandWrapper);
                while (sdrReader.Read())
                {
                    returnValue.Add(binding(sdrReader));
                }
                sdrReader.Close();

                if (parameterOutput != null)
                {
                    parameterOutput(db, commandWrapper);
                }
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="binding"></param>
        /// <returns></returns>
        public static List<TValue> GetListCreateInstanceDB<TValue>(string instanceDb, string storedProcedureName, CreateInstanceBindingHandler<TValue> binding)
        {

            if (log.IsInfoEnabled) { log.InfoFormat("GetListCreateInstanceDB(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            SqlDatabase db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb) as SqlDatabase;
            List<TValue> returnValue = new List<TValue>();

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName))
            {
                IDataReader sdrReader = db.ExecuteReader(commandWrapper);
                while (sdrReader.Read())
                {
                    returnValue.Add(binding(sdrReader));
                }
                sdrReader.Close();
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceDb"></param>
        /// <param name="storedProcedureName"></param>
        /// <param name="typeName"></param>
        /// <param name="table"></param>
        public static void ExecuteNonQuery(string instanceDb, string storedProcedureName, string typeName, string parameterName, DataTable table)
        {
            if (log.IsInfoEnabled) { log.InfoFormat("ExecuteNonQuery(instanceDb:{0}, storedProcedureName:{1})", instanceDb, storedProcedureName); }
            Database db = null;
            DbCommand commandWrapper = null;
            db = DatabaseFactory.CreateDatabase(instanceDb);

            using (commandWrapper = db.GetStoredProcCommand(storedProcedureName))
            {
                SqlParameter parameter = ((SqlCommand)commandWrapper).Parameters.AddWithValue(parameterName, table);
                parameter.SqlDbType = SqlDbType.Structured;
                parameter.TypeName = typeName;
                db.ExecuteNonQuery(commandWrapper);
            }
        }
    }
}