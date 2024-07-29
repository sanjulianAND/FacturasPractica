using FacturasPractica.DTOs;
using FacturasPractica.Models;
using FacturasPractica.Repositories;
using AutoMapper;


namespace FacturasPractica.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        private readonly IMapper _mapper;

        public FacturaService(IFacturaRepository facturaRepository, IMapper mapper)
        {
            _facturaRepository = facturaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FacturaDto>> GetFacturas()
        {
            var facturas = await _facturaRepository.GetFacturas();
            return _mapper.Map<IEnumerable<FacturaDto>>(facturas);
        }

        public async Task<FacturaDto> GetFactura(int id)
        {
            var factura = await _facturaRepository.GetFactura(id);
            return _mapper.Map<FacturaDto>(factura);
        }

        public async Task AddFactura(FacturaDto facturaDto)
        {
            var factura = _mapper.Map<TblFacturas>(facturaDto);
            await _facturaRepository.AddFactura(factura);
        }

        public async Task UpdateFactura(FacturaDto facturaDto)
        {
            var factura = _mapper.Map<TblFacturas>(facturaDto);
            await _facturaRepository.UpdateFactura(factura);
        }

        public async Task DeleteFactura(int id)
        {
            await _facturaRepository.DeleteFactura(id);
        }
    }
}
