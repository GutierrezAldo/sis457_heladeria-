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
    public partial class FrmCliente : Form
    {
        private bool esNuevo = false;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ClienteCln.listarPa(txtBuscar.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["ci"].HeaderText = "CI";
            dgvLista.Columns["razonSocial"].Visible = false;
            dgvLista.Columns["telefono"].HeaderText = "Teléfono";
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(720, 397);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(720, 397);

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var cliente = ClienteCln.obtenerUno(id);
            txtNombreCliente.Text = cliente.nombre;
            txtCI.Text = cliente.ci.ToString();
            txtRazonSocial.Text = cliente.razonSocial;
            txtTelefono.Text = cliente.telefono;

            txtNombreCliente.Focus();
        }

        private void limpiar()
        {
            txtNombreCliente.Clear();
            txtCI.Clear();
            txtRazonSocial.Clear();
            txtTelefono.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(720, 277);
            pnlAcciones.Enabled = true;
            limpiar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private bool validar()
        {
            bool esValido = true;
            erpNombre.Clear();
            erpCI.Clear();
            erpRazonSocial.Clear();

            if (string.IsNullOrEmpty(txtNombreCliente.Text))
            {
                erpNombre.SetError(txtNombreCliente, "El Nombre es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtCI.Text))
            {
                erpCI.SetError(txtCI, "La CI es obligatoria");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                erpRazonSocial.SetError(txtRazonSocial, "La Razón Social es obligatoria");
                esValido = false;
            }

            return esValido;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = dgvLista.CurrentRow.Cells["nombre"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el producto {nombre}?",
                "::: Mensaje - Heladeria :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                ClienteCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Producto dado de baja correctamente", "::: Mensaje - Heladeria :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Size = new Size(720, 277);
            listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var cliente = new Cliente();
                cliente.nombre = txtNombreCliente.Text.Trim();
                cliente.ci = long.Parse(txtCI.Text.Trim());
                cliente.razonSocial = txtRazonSocial.Text.Trim();
                cliente.telefono = txtTelefono.Text.Trim();
                cliente.usuarioRegistro = Util.usuario.usuario1;
                cliente.estado = 1;

                if (esNuevo)
                {
                    cliente.fechaRegistro = DateTime.Now;

                    ClienteCln.insertar(cliente);
                }
                else
                {
                    cliente.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    ClienteCln.actualizar(cliente);
                }
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Cliente guardado correctamente", "::: Mensaje - Heladeria :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
