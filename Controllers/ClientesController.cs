using Microsoft.AspNetCore.Mvc;
using SistemaVentasAPI.Models;
using SistemaVentasAPI.Services;
using SistemaVentasAPI.DTOs;

namespace SistemaVentasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        // Obtener todos los clientes
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _clientesService.GetClientes();
            return Ok(clientes);
        }

        // Obtener cliente por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _clientesService.GetCliente(id);

            if (cliente == null)
                return NotFound("Cliente no encontrado");

            return Ok(cliente);
        }

        // Crear cliente
        [HttpPost]
        public async Task<IActionResult> CreateCliente(ClienteDTO clienteDTO)
        {
            var nuevoCliente = await _clientesService.CreateCliente(clienteDTO);
            return Ok(nuevoCliente);
        }

        // Actualizar cliente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, ClienteDTO clienteDTO)
        {
            var clienteActualizado = await _clientesService.UpdateCliente(id, clienteDTO);

            if (clienteActualizado == null)
                return NotFound("Cliente no encontrado");

            return Ok(clienteActualizado);
        }

        // Eliminar cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var eliminado = await _clientesService.DeleteCliente(id);

            if (!eliminado)
                return NotFound("Cliente no encontrado");

            return Ok("Cliente eliminado correctamente");
        }
    }
}
