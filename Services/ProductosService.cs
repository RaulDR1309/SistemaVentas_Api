using Microsoft.EntityFrameworkCore;
using SistemaVentasAPI.Data;
using SistemaVentasAPI.Models;
using SistemaVentasAPI.DTOs;

namespace SistemaVentasAPI.Services
{
    public class ProductosService : IProductosService
    {
        private readonly AppDbContext _context;

        public ProductosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetProducto(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> CreateProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio,
                Stock = productoDTO.Stock
            };

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<Producto?> UpdateProducto(int id, ProductoDTO productoDTO)
        {
            var productoDB = await _context.Productos.FindAsync(id);

            if (productoDB == null)
                return null;

            productoDB.Nombre = productoDTO.Nombre;
            productoDB.Precio = productoDTO.Precio;
            productoDB.Stock = productoDTO.Stock;

            await _context.SaveChangesAsync();

            return productoDB;
        }

        public async Task<bool> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
                return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
