using System.Collections.ObjectModel;

namespace MiTienda.Entities
{
    public class Orden
    {
        public int OrdenID { get; set; }
        public DateTime OrdenFecha { get; set; }
        public int UsuarioID { get; set; }
        public decimal OrdenTotal { get; set; }

        public Usuario? OrdenUsuario { get; set; }

        public ICollection<OrdenItem>? OrdenItems { get; set; }
    }
}
