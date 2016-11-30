using System.Data;

namespace SGSI.Data
{
    /// <summary>
    /// 
    /// </summary>
    public delegate void BindingHandler<TValue>(TValue o, IDataReader dr);

    
}
