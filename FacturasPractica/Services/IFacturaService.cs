using FacturasPractica.DTOs;

namespace FacturasPractica.Services
{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturaDto>> GetFacturas();
        Task<FacturaDto> GetFactura(int id);
        Task AddFactura(FacturaDto facturaDto);
        Task UpdateFactura(FacturaDto facturaDto);
        Task DeleteFactura(int id);
    }
}
