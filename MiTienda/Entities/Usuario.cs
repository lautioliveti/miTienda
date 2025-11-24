using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MiTienda.Entities
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        [Required]
        public required string UsuarioNombre { get; set; }
        [Required]
        public required string UsuarioEmail { get; set; }
        [Required]
        public required string UsuarioContraseña { get; set; }
        [Required]
        public required string UsuarioTipo { get; set; }

        public ICollection<Orden>? UsuarioOrdenes { get; set; } 
    }
}
