using FacturasPractica.DTOs;

namespace FacturasPractica.Services
{
    public interface IDetalleFacturaService
    {
        Task<IEnumerable<DetalleFacturaDto>> GetDetallesFactura(int facturaId);
        Task AddDetalleFactura(DetalleFacturaDto detalleFacturaDto);
        Task UpdateDetalleFactura(DetalleFacturaDto detalleFacturaDto);
        Task DeleteDetalleFactura(int id);
    }
}
