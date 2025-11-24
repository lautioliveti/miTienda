using System.ComponentModel.DataAnnotations;

namespace MiTienda.Models
{
    public class CategoriaVM
    {
        public int CategoriaID { get; set; }
        [Required]
        public string CategoriaNombre { get; set; } = string.Empty; 
        
    }
}
