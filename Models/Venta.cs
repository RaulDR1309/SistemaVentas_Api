namespace SistemaVentasAPI.Models
{
    public class Venta
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public Cliente? Cliente { get; set; }

        public ICollection<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
    }
}
