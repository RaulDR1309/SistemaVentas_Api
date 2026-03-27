using SistemaVentasAPI.Models;
using SistemaVentasAPI.DTOs;

namespace SistemaVentasAPI.Services
{
    public interface IProductosService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto?> GetProducto(int id);
        Task<Producto> CreateProducto(ProductoDTO productoDTO);
        Task<Producto?> UpdateProducto(int id, ProductoDTO productoDTO);
        Task<bool> DeleteProducto(int id);
    }
}