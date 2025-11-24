using Microsoft.AspNetCore.Mvc.Rendering;
using MiTienda.Entities;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.Models
{
    public class ProductoVM
    {
        public int ProductoID { get; set; }
        public CategoriaVM ProductoCategoria { get; set; }

        public List<SelectListItem> Categorias{ get; set; }
        [Required]
        public string ProductoNombre { get; set; } = string.Empty;
        [Required]
        public string ProductoDescripcion { get; set; } = string.Empty;
        [Required]
        public decimal ProductoPrecio { get; set; }
        [Required]
        public int ProductoStock { get; set; }
        public string? ProductoImagen { get; set; } = null;
        public IFormFile? ImageFile { get; set; }
    }
}
