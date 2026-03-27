using Microsoft.AspNetCore.Mvc;
using SistemaVentasAPI.DTOs;
using SistemaVentasAPI.Services;

namespace SistemaVentasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentasService _ventasService;

        public VentasController(IVentasService ventasService)
        {
            _ventasService = ventasService;
        }

        // Crear venta
        [HttpPost]
        public async Task<IActionResult> CrearVenta([FromBody] VentaDTO ventaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _ventasService.CrearVenta(ventaDTO);

            if (resultado.Contains("no existe") || resultado.Contains("Stock"))
                return BadRequest(resultado);

            return Ok(resultado);
        }

        // Obtener todas las ventas
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var ventas = await _ventasService.GetVentas();
            return Ok(ventas);
        }

        // Obtener venta por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenta(int id)
        {
            var venta = await _ventasService.GetVentaPorId(id);

            if (venta == null)
                return NotFound("Venta no encontrada");

            return Ok(venta);
        }

        // Eliminar venta
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenta(int id)
        {
            var resultado = await _ventasService.DeleteVenta(id);

            if (!resultado)
                return NotFound("Venta no encontrada");

            return Ok("Venta eliminada correctamente");
        }
    }
}
