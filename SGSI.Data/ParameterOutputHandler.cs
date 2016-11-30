using System;
using System.Data;
using System.Data.Sql;
using System.Data.Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SGSI.Data
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="commandWrapper"></param>
    public delegate void ParameterOutputHandler(Database db, DbCommand commandWrapper);
}

