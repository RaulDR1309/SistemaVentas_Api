using Microsoft.EntityFrameworkCore;
using SistemaVentasAPI.Data;
using SistemaVentasAPI.DTOs;
using SistemaVentasAPI.Models;

namespace SistemaVentasAPI.Services
{
    public class VentasService : IVentasService
    {
        private readonly AppDbContext _context;

        public VentasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CrearVenta(VentaDTO ventaDTO)
        {
            var cliente = await _context.Clientes.FindAsync(ventaDTO.ClienteId);

            if (cliente == null)
                return "Cliente no existe";

            decimal total = 0;

            var venta = new Venta
            {
                ClienteId = ventaDTO.ClienteId,
                Fecha = DateTime.Now,
                Total = 0
            };

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            foreach (var item in ventaDTO.Productos)
            {
                var producto = await _context.Productos.FindAsync(item.ProductoId);

                if (producto == null)
                    return "Producto no existe";

                if (producto.Stock < item.Cantidad)
                    return "Stock insuficiente";

                var detalle = new DetalleVenta
                {
                    VentaId = venta.Id,
                    ProductoId = producto.Id,
                    Cantidad = item.Cantidad,
                    Precio = producto.Precio
                };

                total += producto.Precio * item.Cantidad;

                producto.Stock -= item.Cantidad;

                _context.DetalleVentas.Add(detalle);
            }

            venta.Total = total;

            await _context.SaveChangesAsync();

            return "Venta creada correctamente";
        }

        public async Task<List<Venta>> GetVentas()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVentas)
                .ThenInclude(d => d.Producto)
                .ToListAsync();
        }

        public async Task<Venta?> GetVentaPorId(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.DetalleVentas)
                .ThenInclude(d => d.Producto)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> DeleteVenta(int id)
        {
            var venta = await _context.Ventas
                .Include(v => v.DetalleVentas)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (venta == null)
                return false;

            _context.DetalleVentas.RemoveRange(venta.DetalleVentas);
            _context.Ventas.Remove(venta);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
