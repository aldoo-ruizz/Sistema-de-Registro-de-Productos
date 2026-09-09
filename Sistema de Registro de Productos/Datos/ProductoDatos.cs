using System.Collections.Generic;
using Sistema_de_Registro_de_Productos.Entidades;

namespace Sistema_de_Registro_de_Productos.Datos
{
    /// <summary>
    /// ARD 09092026
    /// Se creo la clase ProductoDatos para manejar el almacenamiento de productos en memoria.
    /// </summary>

    //Clase ProductoDatos que maneja el almacenamiento de productos en memoria
    public class ProductoDatos
    {
        private static List<Producto> productos = new List<Producto>();

        //Metodo para guardar un producto en la lista de productos
        public void Guardar(Producto producto)
        {
            productos.Add(producto);
        }

        //Metodo para obtener todos los productos de la lista de productos
        public List<Producto> ObtenerTodos()
        {
            return new List<Producto>(productos);
        }
    }
}
