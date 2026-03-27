using Microsoft.AspNetCore.Mvc;
using SistemaVentasAPI.DTOs;
using SistemaVentasAPI.Models;
using SistemaVentasAPI.Services;

namespace SistemaVentasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductosService _productosService;

        public ProductosController(IProductosService productosService)
        {
            _productosService = productosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            return Ok(await _productosService.GetProductos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducto(int id)
        {
            var producto = await _productosService.GetProducto(id);

            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducto(ProductoDTO productoDTO)
        {
            var nuevoProducto = await _productosService.CreateProducto(productoDTO);
            return Ok(nuevoProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducto(int id, ProductoDTO productoDTO)
        {
            var productoActualizado = await _productosService.UpdateProducto(id, productoDTO);

            if (productoActualizado == null)
                return NotFound("Producto no encontrado");

            return Ok(productoActualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var eliminado = await _productosService.DeleteProducto(id);

            if (!eliminado)
                return NotFound();

            return Ok("Producto eliminado");
        }
    }
}