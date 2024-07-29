using FacturasPractica.DTOs;
using FacturasPractica.Models;
using FacturasPractica.Repositories;
using AutoMapper;

namespace FacturasPractica.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly IDetalleFacturaRepository _detalleFacturaRepository;
        private readonly IMapper _mapper;

        public DetalleFacturaService(IDetalleFacturaRepository detalleFacturaRepository, IMapper mapper)
        {
            _detalleFacturaRepository = detalleFacturaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DetalleFacturaDto>> GetDetallesFactura(int facturaId)
        {
            var detalles = await _detalleFacturaRepository.GetDetallesFactura(facturaId);
            return _mapper.Map<IEnumerable<DetalleFacturaDto>>(detalles);
        }

        public async Task AddDetalleFactura(DetalleFacturaDto detalleFacturaDto)
        {
            var detalle = _mapper.Map<TblDetallesFactura>(detalleFacturaDto);
            await _detalleFacturaRepository.AddDetalleFactura(detalle);
        }

        public async Task UpdateDetalleFactura(DetalleFacturaDto detalleFacturaDto)
        {
            var detalle = _mapper.Map<TblDetallesFactura>(detalleFacturaDto);
            await _detalleFacturaRepository.UpdateDetalleFactura(detalle);
        }

        public async Task DeleteDetalleFactura(int id)
        {
            await _detalleFacturaRepository.DeleteDetalleFactura(id);
        }
    }
}
