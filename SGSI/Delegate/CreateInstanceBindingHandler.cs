using System.Data;

namespace SGSI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public delegate TValue CreateInstanceBindingHandler<TValue>(IDataReader dr);

    
}
