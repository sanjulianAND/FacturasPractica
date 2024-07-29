using FacturasPractica.Models;

namespace FacturasPractica.Repositories
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<TblFacturas>> GetFacturas();
        Task<TblFacturas> GetFactura(int id);
        Task AddFactura(TblFacturas factura);
        Task UpdateFactura(TblFacturas factura);
        Task DeleteFactura(int id);
    }
}
