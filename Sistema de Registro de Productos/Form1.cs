using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Registro_de_Productos.Entidades;
using Sistema_de_Registro_de_Productos.Negocio;
using Sistema_de_Registro_de_Productos.Datos;

namespace Sistema_de_Registro_de_Productos
{
    /// <summary>
    /// ARD 09092026
    /// </summary>
    public partial class Form1 : Form
    {
        private ProductoNegocio negocio;
        private ProductoDatos datos;
        // Constructor de la clase Form1 que inicializa los componentes y eventos del formulario
        public Form1()
        {
            InitializeComponent();
            negocio = new ProductoNegocio();
            datos = new ProductoDatos();
            btnRegistrar.Click += BtnRegistrar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnSalir.Click += BtnSalir_Click;
            MostrarProductos();
        }
        //El evento realiza la validación de los campos del formulario y, si son válidos, crea un objeto Producto y lo guarda en la base de datos. Luego, actualiza la lista de productos mostrada en el DataGridView y limpia los controles del formulario.
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            decimal precio;
            int existencia;
            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                errorProvider1.SetError(txtCodigo, "El código no puede estar vacío.");
                ok = false;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "El nombre no puede estar vacío.");
                ok = false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                errorProvider1.SetError(txtPrecio, "Precio inválido.");
                ok = false;
            }
            else if (precio <= 0M)
            {
                errorProvider1.SetError(txtPrecio, "El precio debe ser mayor que cero.");
                ok = false;
            }

            if (!int.TryParse(txtExistencia.Text, out existencia))
            {
                errorProvider1.SetError(txtExistencia, "Existencia inválida.");
                ok = false;
            }
            else if (existencia < 0)
            {
                errorProvider1.SetError(txtExistencia, "La existencia debe ser mayor o igual a cero.");
                ok = false;
            }

            if (!ok) return;

            var producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Precio = precio,
                Existencia = existencia
            };

            string mensaje;
            if (!negocio.Validar(producto, out mensaje))
            {
                MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            datos.Guardar(producto);
            MostrarProductos();
            LimpiarControles();
        }
        //Evento que limpia los controles del formulario y borra los errores del ErrorProvider.
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        //Evento que cierra el formulario.
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Clase que limpia los controles del formulario y borra los errores del ErrorProvider.
        private void LimpiarControles()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtExistencia.Text = string.Empty;
            errorProvider1.Clear();
            txtCodigo.Focus();
        }
        //Clase que muestra los productos en el DataGridView.
        private void MostrarProductos()
        {
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = datos.ObtenerTodos();
        }

    
    }
}
