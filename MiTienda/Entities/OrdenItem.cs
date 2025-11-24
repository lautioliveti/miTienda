 namespace MiTienda.Entities
{
    public class OrdenItem
    {
        public  int OrdenItemID { get; set; }
        public int OrdenID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public Orden? Orden { get; set; }
        public Producto? Producto { get; set; }
    }
}
