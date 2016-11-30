using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGSI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void DynamicBindingHandler<ExpandoObject>(ExpandoObject o, IDataReader dr);

    
}
