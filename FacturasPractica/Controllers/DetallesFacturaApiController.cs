using FacturasPractica.DTOs;
using FacturasPractica.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturasPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesFacturaApiController : ControllerBase
    {
        private readonly IDetalleFacturaService _detalleFacturaService;

        public DetallesFacturaApiController(IDetalleFacturaService detalleFacturaService)
        {
            _detalleFacturaService = detalleFacturaService;
        }

        [HttpGet("{facturaId}")]
        public async Task<ActionResult<IEnumerable<DetalleFacturaDto>>> GetDetallesFactura(int facturaId)
        {
            var detalles = await _detalleFacturaService.GetDetallesFactura(facturaId);
            return Ok(detalles);
        }

        [HttpPost]
        public async Task<ActionResult<DetalleFacturaDto>> PostDetalleFactura(DetalleFacturaDto detalleFacturaDto)
        {
            await _detalleFacturaService.AddDetalleFactura(detalleFacturaDto);
            return CreatedAtAction(nameof(GetDetallesFactura), new { facturaId = detalleFacturaDto.IdFactura }, detalleFacturaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleFactura(int id, DetalleFacturaDto detalleFacturaDto)
        {
            if (id != detalleFacturaDto.Id)
            {
                return BadRequest();
            }

            await _detalleFacturaService.UpdateDetalleFactura(detalleFacturaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleFactura(int id)
        {
            await _detalleFacturaService.DeleteDetalleFactura(id);
            return NoContent();
        }
    }
}
