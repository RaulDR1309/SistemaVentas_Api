using System.ComponentModel.DataAnnotations;

namespace SistemaVentasAPI.DTOs
{
    public class VentaDTO
    {
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Debe agregar al menos un producto")]
        [MinLength(1, ErrorMessage = "Debe agregar al menos un producto")]
        public required List<DetalleVentaDTO> Productos { get; set; }
    }
}