using FacturasPractica.Models;

namespace FacturasPractica.Repositories
{
    public interface IDetalleFacturaRepository
    {
        Task<IEnumerable<TblDetallesFactura>> GetDetallesFactura(int facturaId);
        Task AddDetalleFactura(TblDetallesFactura detalleFactura);
        Task UpdateDetalleFactura(TblDetallesFactura detalleFactura);
        Task DeleteDetalleFactura(int id);
    }
}
