namespace Sistema_de_Registro_de_Productos.Entidades
{
    /// <summary>
    /// ARD 09092026
    /// </summary>

    //Clase Producto que representa un producto con sus propiedades
    public class Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
    }
}
