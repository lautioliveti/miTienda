using System.ComponentModel.DataAnnotations;

namespace MiTienda.Models
{
    public class CategoriaVM
    {
        public int CategoriaID { get; set; }
        
        public required string CategoriaNombre { get; set; }
        
    }
}
