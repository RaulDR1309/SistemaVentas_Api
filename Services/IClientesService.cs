using SistemaVentasAPI.Models;
using SistemaVentasAPI.DTOs;

namespace SistemaVentasAPI.Services
{
    public interface IClientesService
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente?> GetCliente(int id);
        Task<Cliente> CreateCliente(ClienteDTO clienteDTO);
        Task<Cliente?> UpdateCliente(int id, ClienteDTO clienteDTO);
        Task<bool> DeleteCliente(int id);
    }
}