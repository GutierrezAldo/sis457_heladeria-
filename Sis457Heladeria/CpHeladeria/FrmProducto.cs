using CadHeladeria;
using ClnHeladeria;
using CpMinerva;
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
            //dgvLista.Columns["unidadMedida"].HeaderText = "Unidad Medida";
            dgvLista.Columns["sabor"].HeaderText = "Sabor";
            dgvLista.Columns["precio"].HeaderText = "Precio";
            dgvLista.Columns["stock"].HeaderText = "Stock";
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size = new Size(610, 301);
            listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(610, 429);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(610, 429);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var producto = ProductoCln.obtenerUno(id);
            txtNombre.Text = producto.nombre;
            cbxUnidadMedida.Text = producto.unidaMedida;
            cbxSabor.Text = producto.sabor;
            nudPrecio.Value = producto.precio;
            nudStock.Value = producto.stock;

            txtNombre.Focus();
        }
        private void limpiar()
        {
            txtNombre.Clear();
            cbxUnidadMedida.SelectedIndex = -1;
            cbxSabor.SelectedIndex = -1;
            nudPrecio.Value = 0;
            nudStock.Value = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(610, 301);
            pnlAcciones.Enabled = true;
            limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private bool validar()
        {
            bool esValido = true;
            erpNombre.Clear();
            erpUnidadMedida.Clear();
            erpSabor.Clear();
            erpPrecio.Clear();
            erpStock.Clear();

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El Nombre es obligatorio");
                esValido = false;
            }
            if (cbxUnidadMedida.SelectedIndex == -1)
            {
                erpUnidadMedida.SetError(cbxUnidadMedida, "La Unidad de Medida es obligatoria");
                esValido = false;
            }
            if (cbxSabor.SelectedIndex == -1)
            {
                erpSabor.SetError(cbxSabor, "El Campo Sabor es obligatoria");
                esValido = false;
            }
            if (nudPrecio.Value == 0)
            {
                erpPrecio.SetError(nudPrecio, "El Precio de Venta debe ser mayor a cero");
                esValido = false;
            }
            if (nudStock.Value == 0)
            {
                erpPrecio.SetError(nudStock, "El Stock del producto debe ser mayor a cero");
                esValido = false;
            }

            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var producto = new Producto();
                producto.nombre = txtNombre.Text.Trim();
                producto.unidaMedida = cbxUnidadMedida.Text;
                producto.sabor = cbxSabor.Text;
                producto.precio = nudPrecio.Value;
                producto.stock  = (int)nudStock.Value;
                producto.usuarioRegistro = Util.usuario.usuario1;
                producto.estado = 1;

                if (esNuevo)
                {
                    producto.fechaRegistro = DateTime.Now;
                    ProductoCln.insertar(producto);
                }
                else
                {
                    producto.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    ProductoCln.actualizar(producto);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Producto guardado correctamente", "::: Mensaje - Heladeria :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = dgvLista.CurrentRow.Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el producto {nombre}?",
                "::: Mensaje - Heladeria :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ProductoCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Producto dado de baja correctamente", "::: Mensaje - Heladeria :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
