using Sistema_de_Registro_de_Productos.Entidades;

namespace Sistema_de_Registro_de_Productos.Negocio
{
    /// <summary>
    /// ARD 09092026
    /// </summary>

    //Clase ProductoNegocio que maneja la lógica de negocio para validar productos
    public class ProductoNegocio
    {
        public bool Validar(Producto producto, out string mensaje)
        {
            if (producto == null)
            {
                mensaje = "Producto inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(producto.Codigo))
            {
                mensaje = "El código no puede estar vacío.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                mensaje = "El nombre no puede estar vacío.";
                return false;
            }

            if (producto.Precio <= 0M)
            {
                mensaje = "El precio debe ser mayor que cero.";
                return false;
            }

            if (producto.Existencia < 0)
            {
                mensaje = "La existencia debe ser mayor o igual a cero.";
                return false;
            }

            mensaje = string.Empty;
            return true;
        }
    }
}
