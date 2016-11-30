using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace SGSI.Data
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="commandWrapper"></param>
    public delegate void ParameterOutputHandler( Database db, DbCommand commandWrapper );
   
}
