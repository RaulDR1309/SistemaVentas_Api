using Microsoft.EntityFrameworkCore;
using SistemaVentasAPI.Data;
using SistemaVentasAPI.Models;
using SistemaVentasAPI.DTOs;

namespace SistemaVentasAPI.Services
{
    public class ClientesService : IClientesService
    {
        private readonly AppDbContext _context;

        public ClientesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetCliente(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> CreateCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDTO.Nombre,
                Telefono = clienteDTO.Telefono
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente?> UpdateCliente(int id, ClienteDTO clienteDTO)
        {
            var clienteDB = await _context.Clientes.FindAsync(id);

            if (clienteDB == null)
                return null;

            clienteDB.Nombre = clienteDTO.Nombre;
            clienteDB.Telefono = clienteDTO.Telefono;

            await _context.SaveChangesAsync();

            return clienteDB;
        }

        public async Task<bool> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
