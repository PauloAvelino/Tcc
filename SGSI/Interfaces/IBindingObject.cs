using System.Data;

namespace SGSI.Interfaces
{
    public interface IBindingObject
    {
        void Binding(IDataReader dr);
    }
}
