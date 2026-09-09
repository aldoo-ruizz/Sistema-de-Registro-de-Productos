using System.Collections.Generic;
using Sistema_de_Registro_de_Productos.Entidades;

namespace Sistema_de_Registro_de_Productos.Datos
{
    public class ProductoDatos
    {
        private static List<Producto> productos = new List<Producto>();

        public void Guardar(Producto producto)
        {
            productos.Add(producto);
        }

        public List<Producto> ObtenerTodos()
        {
            return new List<Producto>(productos);
        }
    }
}
