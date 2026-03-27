

namespace SistemaVentasAPI.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        public int VentaId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public Venta? Venta { get; set; }

        public Producto? Producto { get; set; }
    }
}
