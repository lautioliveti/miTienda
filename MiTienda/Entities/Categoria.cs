using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.Entities
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Required]
        public required string CategoriaNombre { get; set; }
        [Required]

        public ICollection<Producto>? Productos { get; set; }
    }
}
