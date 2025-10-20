using CadHeladeria;
using ClnHeladeria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpHeladeria
{
    public partial class FrmProducto : Form
    {
        private bool esNuevo = false;
        public FrmProducto()
        {
            InitializeComponent();
        }
        private void listar()
        {
            var lista = ProductoCln.listarPa(txtBuscar.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["precio"].HeaderText = "Precio";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            /*if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["id"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;*/
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size = new Size(610, 301);
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(610, 399);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            //pnlAcciones.Enabled = false;
            Size = new Size(610, 399);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var producto = ProductoCln.obtenerUno(id);
            txtNombre.Text = producto.nombre;
            nudPrecio.Value = producto.precio;

            //txtCodigo.Focus();
        }
        private void limpiar()
        {
            //txtCodigo.Clear();
            txtNombre.Clear();
            nudPrecio.Value = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(610, 301);
            //pnlAcciones.Enabled = true;
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }
    }
}
