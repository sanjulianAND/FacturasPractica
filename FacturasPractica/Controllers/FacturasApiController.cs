using FacturasPractica.DTOs;
using FacturasPractica.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturasPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasApiController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasApiController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> GetFacturas()
        {
            var facturas = await _facturaService.GetFacturas();
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDto>> GetFactura(int id)
        {
            var factura = await _facturaService.GetFactura(id);

            if (factura == null)
            {
                return NotFound();
            }

            return Ok(factura);
        }

        [HttpPost]
        public async Task<ActionResult<FacturaDto>> PostFactura(FacturaDto facturaDto)
        {
            await _facturaService.AddFactura(facturaDto);
            return CreatedAtAction(nameof(GetFactura), new { id = facturaDto.Id }, facturaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, FacturaDto facturaDto)
        {
            if (id != facturaDto.Id)
            {
                return BadRequest();
            }

            await _facturaService.UpdateFactura(facturaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            await _facturaService.DeleteFactura(id);
            return NoContent();
        }
    }
}
