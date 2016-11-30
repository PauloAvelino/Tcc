using System;
using System.Diagnostics;
using System.Data;
using System.Collections;
using System.Reflection;
using log4net;
using System.Dynamic;
using System.Collections.Generic;
using System.Xml.Linq;
using SGSI.Interfaces;
using System.Dynamic;
using System.Collections.Generic;
using System.Xml.Linq;


namespace SGSI.Data

{


    public sealed class SqlHelper
    {
        #region Cabeçalho da Classe
        /// <summary>
        ///
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        /// <summary>
        ///
        /// </summary>
        public SqlHelper()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sdrReader"></param>
        /// <param name="objTipo"></param>
        /// <returns></returns>
        public static object SqlDataReaderToObject(IDataReader sdrReader, Type objTipo)
        {
            object[] returnValue = SqlDataReaderToArray(sdrReader, objTipo);
            if (returnValue.Length > 0)
            {
                return returnValue[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sdrReader"></param>
        /// <param name="objTipo"></param>
        /// <returns></returns>
        public static object[] SqlDataReaderToArray(IDataReader sdrReader, Type objTipo)
        {
            #region Cabeçalho do Método
            /*
					Objetivo         : Converter um objeto do tipo SqlDataReader em um array de entidades
					Premissas        :
					Efeitos          : Depende da construção da procedure a ser executada.
					Entradas         : DataReader, Tipo (classe de negócio), array de nomes das propriedades pra ordenar a busca na base.
					Retorno          : Array de Entidades de Negócio
					Data de Criação  : 07-03-2003
					Autor            : Gleisson de Souza Bezerra
				*/
            #endregion

            // GSB - 07032003 - Declara e inicializa objetos
            object[] arrRetorno = null;
            //const string DESC_METODO = "SqlDataReaderToArray";
            ArrayList arrLista = new ArrayList();

            // GSB - 07032003 - Chama o método mais especializado
            //arrLista = SqlDataReaderToArrayList( sdrReader, aColunas, objTipo );
            arrLista = SqlDataReaderToArrayList(sdrReader, objTipo);

            arrRetorno = (object[])arrLista.ToArray(objTipo);


            // GSB - 07032003 - Retorna o array de objetos para quem chamou.
            return arrRetorno;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="sdrReader"></param>
        /// <param name="objTipo"></param>
        /// <param name="aColunas"></param>
        /// <returns></returns>
        public static object[] SqlDataReaderToArray(IDataReader sdrReader, Type objTipo, String[] aColunas)
        {
            #region Cabeçalho do Método
            /*
					Objetivo         : Converter um objeto do tipo SqlDataReader em um array de entidades
					Premissas        :
					Efeitos          : Depende da construção da procedure a ser executada.
					Entradas         : DataReader, Tipo (classe de negócio), array de nomes das propriedades pra ordenar a busca na base.
					Retorno          : Array de Entidades de Negócio
					Data de Criação  : 07-03-2003
					Autor            : Gleisson de Souza Bezerra
				*/
            #endregion

            // GSB - 07032003 - Declara e inicializa objetos
            object[] arrRetorno = null;
            //const string DESC_METODO = "SqlDataReaderToArray";
            ArrayList arrLista = new ArrayList();

            // GSB - 07032003 - Chama o método mais especializado
            arrLista = SqlDataReaderToArrayList(sdrReader, aColunas, objTipo);

            arrRetorno = (object[])arrLista.ToArray(objTipo);

            // GSB - 07032003 - Retorna o array de objetos para quem chamou.
            return arrRetorno;
        }
        /// <summary>
        /// Método para converter um SqlDataReader em um Array de objetos de negócio
        /// </summary>
        /// <param name="sdrReader">SqlDataReader a ser varrido e convertido</param>
        /// <param name="objTipo">Tipo de negócio que irá gerar as instancias</param>
        /// <returns>Um array de objetos de negócio com as devida propriedade preenchidas pelo método Bindindo da interface IBindingObject</returns>
        /// <autor>Gleisson de Souza Bezerra</autor>
        /// <data>01/03/2003</data>
        public static ArrayList SqlDataReaderToArrayList(IDataReader sdrReader, Type objTipo)
        {
            // GSB - 07032003 - Declara e inicializa objetos
            ArrayList arrLista = new ArrayList();

            //const string DESC_METODO = "SqlDataReaderToArrayList";

            object objEntidade;
            /* GSB - 01072003 - Removido para eliminar grande utilização de reflection. Foi criada a inteface IBindingObject para isso.
				PropertyInfo objPropriedade; //Utilizado para capturar uma referencia a uma propriedade existente no tipo

				string strPropriedade = null;*/


            // GSB - 07032003 - Varre os registros e converte o Data Reader em um Array de Entidades
            while (sdrReader.Read())
            {

                // GSB - 010072003 - Cria instância do tipo de negócio específico
                objEntidade = Activator.CreateInstance(objTipo);

                ((IBindingObject)objEntidade).Binding(sdrReader);

                /* GSB - 01072003 - Removido para eliminar grande utilização de reflection. Foi criada a inteface IBindingObject para isso.
					for ( int i = 0 ; i < arrColunas.Length; ++i)
					{

						if ( arrColunas[i] != null ) // Se não foi informada a coluna
						{
							strPropriedade = arrColunas[i]; // Nome da propriedade a ser procurara no tipo

							objPropriedade = objTipo.GetProperty(strPropriedade); // Pega a referencia a propriedade dentro do tipo
							if ( sdrReader.GetValue(i).ToString() != "" )
							{
								objPropriedade.SetValue( objEntidade, sdrReader.GetValue(i), null); // Seta o valor da propriedade de acordo com o valor na base de dados
							}
						}
					}
					*/

                // GSB - 07032003 - Adiciona a nova entidade no Array
                arrLista.Add(objEntidade);

            }
            sdrReader.Close();

            // GSB - 07032003 - Retorna o array list para quem chamou.
            return arrLista;
        }

        /// <summary>
        /// Método para converter um SqlDataReader em um Array de objetos de negócio
        /// </summary>
        /// <param name="sdrReader">SqlDataReader a ser varrido e convertido</param>
        /// <param name="objTipo">Tipo de negócio que irá gerar as instancias</param>
        /// <returns>Um array de objetos de negócio com as devida propriedade preenchidas pelo método Bindindo da interface IBindingObject</returns>
        /// <autor>Gleisson de Souza Bezerra</autor>
        /// <data>01/03/2003</data>
        public static ArrayList SqlDataReaderToArrayList(IDataReader sdrReader, String[] arrColunas, Type objTipo)
        {
            // GSB - 07032003 - Declara e inicializa objetos
            ArrayList arrLista = new ArrayList();

            //const string DESC_METODO = "SqlDataReaderToArrayList";

            object objEntidade;

            //GSB - 01072003 - Removido para eliminar grande utilização de reflection. Foi criada a inteface IBindingObject para isso.
            PropertyInfo objPropriedade; //Utilizado para capturar uma referencia a uma propriedade existente no tipo

            string strPropriedade = null;

            // GSB - 07032003 - Varre os registros e converte o Data Reader em um Array de Entidades
            while (sdrReader.Read())
            {

                // GSB - 010072003 - Cria instância do tipo de negócio específico
                objEntidade = Activator.CreateInstance(objTipo);

                //GSB - 01072003 - Removido para eliminar grande utilização de reflection. Foi criada a inteface IBindingObject para isso.
                for (int i = 0; i < arrColunas.Length; ++i)
                {

                    if (arrColunas[i] != null) // Se não foi informada a coluna
                    {
                        strPropriedade = arrColunas[i]; // Nome da propriedade a ser procurara no tipo

                        objPropriedade = objTipo.GetProperty(strPropriedade); // Pega a referencia a propriedade dentro do tipo
                        if (sdrReader.GetValue(i).ToString() != "")
                        {
                            objPropriedade.SetValue(objEntidade, sdrReader.GetValue(i), null); // Seta o valor da propriedade de acordo com o valor na base de dados
                        }
                    }
                }

                // GSB - 07032003 - Adiciona a nova entidade no Array
                arrLista.Add(objEntidade);

            }

            sdrReader.Close();

            // GSB - 07032003 - Retorna o array list para quem chamou.
            return arrLista;
        }



        /// <summary>
        /// Retorna MinValue quando campo Null
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static bool GetIsNull(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            return (aux == DBNull.Value);

        }
        /// <summary>
        /// Retorna MinValue quando campo Null
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static int GetInt(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return int.MinValue;
            }
            else
            {
                return Convert.ToInt32(aux);
            }

        }
        /// <summary>
        /// Em caso de falha retorna MinValue
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static int GetIntTryCatch(IDataReader reader, string nameColumn)
        {
            try
            {
                object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

                if (aux == DBNull.Value)
                {
                    return int.MinValue;
                }
                else
                {
                    return Convert.ToInt32(aux);
                }
            }
            catch
            {
                return int.MinValue;
            }
        }
        public static long GetLong(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return long.MinValue;
            }
            else
            {
                return Convert.ToInt64(aux);
            }

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static double GetDouble(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return double.MinValue;
            }
            else
            {
                return Convert.ToDouble(aux);
            }

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static bool GetBool(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(aux);
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static bool GetBoolWithSN(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return false;
            }
            else
            {
                return aux.ToString().ToUpper() == "S" ? true : false;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                return (DateTime)aux;
            }

        }
        public static DateTime GetDateTimeTryCacth(IDataReader reader, string nameColumn)
        {
            DateTime aux = DateTime.MinValue;
            try
            {
                aux = GetDateTime(reader, nameColumn);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("WBS.Data.GetDateTimeTryCacth - Campo: {0} - Erro: {1}", nameColumn, ex.ToString()));
            }
            return aux;
        }
        public static string GetStringTryCacth(IDataReader reader, string nameColumn)
        {
            string aux = null;
            try
            {
                aux = GetString(reader, nameColumn);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("WBS.Data.GetStringTryCacth - Campo: {0} - Erro: {1}", nameColumn, ex.ToString()));
            }
            return aux;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static TimeSpan GetTimeSpan(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return TimeSpan.MinValue;
            }
            else
            {
                if (aux is TimeSpan)
                {
                    return (TimeSpan)aux;
                }
                else
                {
                    return ((DateTime)aux).TimeOfDay;
                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static byte GetByte(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return byte.MinValue;
            }
            else
            {
                return Convert.ToByte(aux);
            }

        }
        /// <summary>
        /// Retorna MinValue quando campo Null
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static short GetShort(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return short.MinValue;
            }
            else
            {
                return Convert.ToInt16(aux);
            }

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static ushort GetUshort(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return ushort.MinValue;
            }
            else
            {
                return Convert.ToUInt16(aux);
            }

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static string GetString(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (string)aux;
            }
        }
        /// <summary>
        /// Retorna empty quando campo null
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="nameColumn"></param>
        /// <returns></returns>
        public static string GetStringEmpty(IDataReader reader, string nameColumn)
        {
            string aux = GetString(reader, nameColumn);
            if (aux == null)
            {
                return string.Empty;
            }
            else
            {
                return aux;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetDBDatetime(DateTime value)
        {
            if ((DateTime.MinValue == value) || (DateTime.MaxValue == value))
                return DBNull.Value;
            else
                return value;
        }
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetDBString(string value, string valueDefault)
        {
            if (value == null)
            {
                return valueDefault;
            }
            else
            {
                return value;
            }
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetDBInt(int value)
        {
            if ((int.MinValue == value) || (int.MaxValue == value))
                return DBNull.Value;
            else
                return value;
        }
        public static object GetDBDouble(double value)
        {
            if ((double.MinValue == value) || (double.MaxValue == value))
                return DBNull.Value;
            else
                return value;
        }

        public static object GetDBDoubleIsNullDefault(double value, double valueDefault)
        {
            if ((double.MinValue == value) || (double.MaxValue == value))
                return valueDefault;
            else
                return value;
        }
        public static Guid GetUniqueIdentifier(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return Guid.Empty;
            }
            else
            {
                return (Guid)aux;
            }
        }
        public static byte[] GetBytes(IDataReader reader, string nameColumn)
        {
            object aux = reader.GetValue(reader.GetOrdinal(nameColumn));

            if (aux == DBNull.Value)
            {
                return null;
            }
            else
            {
                return (byte[])aux;
            }
        }

        public static object GetValueDefault(PropertyInfo property, IDataReader reader, string nameColumn)
        {
            Type aux = property.PropertyType;

            return GetValueDefault(reader, nameColumn, aux);
        }

        public static object GetValueDefault(IDataReader reader, string nameColumn, Type aux)
        {
            if (aux.Equals(typeof(byte)))
            {
                return GetByte(reader, nameColumn);
            }
            else if (aux.Equals(typeof(short)))
            {
                return GetShort(reader, nameColumn);
            }
            else if (aux.Equals(typeof(int)))
            {
                return GetInt(reader, nameColumn);
            }
            else if (aux.Equals(typeof(DateTime)))
            {
                return GetDateTime(reader, nameColumn);
            }
            else if (aux.Equals(typeof(string)))
            {
                return GetString(reader, nameColumn);
            }
            else if (aux.Equals(typeof(long)))
            {
                return GetLong(reader, nameColumn);
            }
            else if (aux.Equals(typeof(double)))
            {
                return GetDouble(reader, nameColumn);
            }
            else if (aux.Equals(typeof(bool)))
            {
                return GetBool(reader, nameColumn);
            }
            else if (aux.Equals(typeof(Guid)))
            {
                return GetUniqueIdentifier(reader, nameColumn);
            }
            else if (aux.Equals(typeof(CDataWrapper)))
            {
                CDataWrapper cdata = new CDataWrapper();
                string value = GetString(reader, nameColumn);
                cdata.Value = value;
                return cdata;
            }
            else if (aux.Equals(typeof(CommentWrapper)))
            {
                CommentWrapper cdata = new CommentWrapper();
                string value = GetString(reader, nameColumn);
                cdata.Value = value;
                return cdata;
            }
            else if (aux.Equals(typeof(byte[])))
            {
                return reader.GetValue(reader.GetOrdinal(nameColumn));
            }
            else
            {
                try
                {
                    return reader.GetValue(reader.GetOrdinal(nameColumn));
                }
                catch (Exception ex)
                {
                    if (log.IsErrorEnabled) { log.Error(string.Format("ReflectionBinding - tipo de campo não tratado! Campo:{0} - TYPE:{1} ", nameColumn, aux.GetType().Name)); }
                    throw;
                }
            }
        }

        public static void ReflectionBinding(IDataReader reader, object o)
        {
            ReflectionBinding(reader, o, false);
        }

        public static bool ReflectionBinding(IDataReader reader, object o, bool isThrow)
        {
            bool returnValue = true;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldReader = null;
                PropertyInfo property = null;
                try
                {
                    fieldReader = reader.GetName(i);
                    property = o.GetType().GetProperty(fieldReader);
                    if (property == null)
                    {
                        if (log.IsDebugEnabled)
                        {
                            log.DebugFormat("Propriedade não encontrada: {0}", fieldReader);
                        }
                    }
                    else
                    {
                        property.SetValue(o, GetValueDefault(property, reader, fieldReader), null);
                    }
                }
                catch (Exception ex)
                {
                    returnValue = false;
                    log.WarnFormat("Campo: {0} - Propriedade encontrada: {1} - Error: {2} - StackTrace: {3}", fieldReader, property != null, ex.Message, ex.StackTrace);

                    if (isThrow)
                        throw;
                }
            }
            return returnValue;
        }

        //public static void DynamicReflectionBinding(DynamicFieldHandler dynamicField, IDataReader reader, bool isThrow)
        //{
        //    for (int i = 0; i < reader.FieldCount; i++)
        //    {
        //        string fieldReader = null;
        //        PropertyInfo property = null;
        //        try
        //        {
        //            fieldReader = reader.GetName(i);
        //            object o = reader.GetValue(i);
        //            if (o == DBNull.Value)
        //                o = null;
        //            dynamicField(fieldReader, o);
        //        }
        //        catch (Exception ex)
        //        {
        //            log.WarnFormat("Campo: {0} - Propriedade encontrada: {1} - Error: {2} - StackTrace: {3}", fieldReader, property != null, ex.Message, ex.StackTrace);

        //            if (isThrow)
        //                throw;
        //        }
        //    }
        //}

        public static dynamic DynamicReflectionBinding(IEnumerable<XElement> reader, bool isThrow)
        {
            var item = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)item;

            foreach (XElement node in reader)
            {
                string fieldReader = null;
                try
                {
                    fieldReader = node.Name.ToString();
                    dictionary.Add(fieldReader, node.Value);
                }
                catch (Exception ex)
                {
                    //log.WarnFormat("Campo: {0} - Propriedade encontrada: {1} - Error: {2} - StackTrace: {3}", fieldReader, property != null, ex.Message, ex.StackTrace);

                    if (isThrow)
                        throw;
                }
            }
            return item;
        }

        public static dynamic DynamicReflectionBinding(IDataReader reader, bool isThrow)
        {
            var item = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)item;

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string fieldReader = null;
                PropertyInfo property = null;
                try
                {
                    fieldReader = reader.GetName(i);
                    object o = reader.GetValue(i);
                    if (o == DBNull.Value)
                        o = null;

                    dictionary.Add(fieldReader, o);
                }
                catch (Exception ex)
                {
                    log.WarnFormat("Campo: {0} - Propriedade encontrada: {1} - Error: {2} - StackTrace: {3}", fieldReader, property != null, ex.Message, ex.StackTrace);

                    if (isThrow)
                        throw;
                }
            }
            return item;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetDBTimeSpan(TimeSpan value)
        {
            if ((TimeSpan.MinValue == value) || (TimeSpan.MaxValue == value))
                return DBNull.Value;
            else
                return value;
        }
    }
}
