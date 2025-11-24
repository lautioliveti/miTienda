using System.ComponentModel.DataAnnotations;

namespace MiTienda.Entities
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public int ProductoCategoria { get; set; }
        [Required]
        public required string ProductoNombre { get; set; }
        [Required]
        public required string ProductoDescripcion { get; set; }
        public decimal ProductoPrecio { get; set; }
        public int ProductoStock { get; set; }
        public string? ProductoImagen { get; set; } = null;
        public Categoria? Categoria { get; set; }
    }
}
