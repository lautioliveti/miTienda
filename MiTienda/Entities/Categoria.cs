using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.Entities
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Required]
        public string CategoriaNombre { get; set; } = string.Empty;
        
        

        public ICollection<Producto>? Productos { get; set; }
    }
}
