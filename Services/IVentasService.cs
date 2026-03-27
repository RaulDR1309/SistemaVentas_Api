using SistemaVentasAPI.DTOs;
using SistemaVentasAPI.Models;

namespace SistemaVentasAPI.Services
{
    public interface IVentasService
    {
        Task<string> CrearVenta(VentaDTO ventaDTO);
        Task<List<Venta>> GetVentas();
        Task<Venta?> GetVentaPorId(int id);
        Task<bool> DeleteVenta(int id);
    }
}
