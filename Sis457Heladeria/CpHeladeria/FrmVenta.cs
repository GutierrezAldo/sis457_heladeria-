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
    public partial class FrmVenta : Form
    {
        private List<VentaDetalle> listaDetalles = new List<VentaDetalle>();
        private decimal subTotal = 0;
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void cargarCliente()
        {
            var lista = ClienteCln.listar();
            cbxCliente.DataSource = lista;
            cbxCliente.ValueMember = "id";
            cbxCliente.DisplayMember = "nombre";
            cbxCliente.SelectedIndex = -1;
        }

        private void cargarProducto()
        {
            var lista = ProductoCln.listar();
            cbxProducto.DataSource = lista;
            cbxProducto.ValueMember = "id";
            cbxProducto.DisplayMember = "nombre";
            cbxProducto.SelectedIndex = -1;
        }


        private bool validarCliente()
        {
            bool esValido = true;
            erpRazonSocial.Clear();
            erpCI.Clear();
            erpNommbreCliente.Clear();
            erpTelefono.Clear();

            if (string.IsNullOrEmpty(txtNombreCliente.Text))
            {
                erpNommbreCliente.SetError(txtNombreCliente, "El Nombre del Cliente es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtCI.Text))
            {
                erpCI.SetError(txtCI, "El CI del Cliente es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                erpRazonSocial.SetError(txtRazonSocial, "La Razón social del Cliente es obligatorio");
                esValido = false;
            }

            return esValido;
        }

        private void btnAñadirCliente_Click(object sender, EventArgs e)
        {
            if (validarCliente())
            {
                var cliente = new Cliente()
                {
                    nombre = txtNombreCliente.Text.Trim(),
                    ci = long.Parse(txtCI.Text.Trim()),
                    razonSocial = txtRazonSocial.Text.Trim(),
                    telefono = txtTelefono.Text.Trim(),
                    usuarioRegistro = Util.usuario.usuario1,
                    estado = 1,
                    fechaRegistro = DateTime.Now
                };

                ClienteCln.insertar(cliente);

                cargarCliente(); // recargar combo
                MessageBox.Show("Cliente guardado correctamente", "::: Heladería :::");
            }
        }


        private bool validarVentaDetalle()
        {
            bool esValido = true;

            erpCliente.Clear();
            erpProducto.Clear();
            erpCantidad.Clear();
            erpTipoPago.Clear();

            if (cbxCliente.SelectedIndex == -1)
            {
                erpCliente.SetError(cbxCliente, "Debe seleccionar un cliente.");
                esValido = false;
            }
            if (cbxProducto.SelectedIndex == -1)
            {
                erpProducto.SetError(cbxProducto, "Debe seleccionar un producto.");
                esValido = false;
            }
            if (cbxTipoPago.SelectedIndex == -1)
            {
                erpTipoPago.SetError(cbxProducto, "Debe seleccionar el Tipo de Pago.");
                esValido = false;
            }
            if (nudCantidad.Value <= 0)
            {
                erpCantidad.SetError(nudCantidad, "La cantidad debe ser mayor a 0.");
                esValido = false;
            }

            return esValido;
        }


        private void btnAñadirVenta_Click(object sender, EventArgs e)
        {
            if (validarVentaDetalle())
            {
                var detalle = new VentaDetalle()
                {
                    idProducto = (int)cbxProducto.SelectedValue,
                    cantidad = nudCantidad.Value,
                    precioUnitario = nudPrecioUnitario.Value,
                    total = nudCantidad.Value * nudPrecioUnitario.Value,
                    tipoPago = cbxTipoPago.SelectedItem.ToString(),
                    usuarioRegistro = Util.usuario.usuario1,
                    fechaRegistro = DateTime.Now,
                    estado = 1
                };

                listaDetalles.Add(detalle);

                refrescarDetalle(); // ← NUEVO

                subTotal += detalle.total;
                txtSubTotal.Text = subTotal.ToString("0.00");
            }
        }

        private void refrescarDetalle()
        {
            dgvLista.DataSource = null;

            dgvLista.DataSource = listaDetalles.Select(d => new
            {
                Producto = ProductoCln.obtenerUno(d.idProducto).nombre,
                d.cantidad,
                d.precioUnitario,
                d.total,
                d.tipoPago
            }).ToList();
        }


        private void nudTotalPagar_ValueChanged(object sender, EventArgs e)
        {
            decimal totalPagar = nudTotalPagar.Value;
            decimal cambio = totalPagar - subTotal;
            txtCambio.Text = cambio.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un cliente.");
                return;
            }

            if (listaDetalles.Count == 0)
            {
                MessageBox.Show("Debe agregar mínimo un producto.");
                return;
            }

            // ===== 1. Registrar Venta =====
            var venta = new Venta()
            {
                idUsuario = Util.usuario.id,   // <-- DE TU SISTEMA
                idCliente = (int)cbxCliente.SelectedValue,
                usuarioRegistro = Util.usuario.usuario1,
                fechaRegistro = DateTime.Now,
                estado = 1
            };

            int idVenta = VentaCln.insertar(venta);  // devuelve el ID

            // ===== 2. Registrar Detalles =====
            foreach (var det in listaDetalles)
            {
                det.idVenta = idVenta;
                VentaDetalleCln.insertar(det);
            }

            MessageBox.Show("Venta registrada correctamente.");

            limpiar();
        }


        private void limpiar()
        {
            txtNombreCliente.Clear();
            txtCI.Clear();
            txtRazonSocial.Clear();
            txtTelefono.Clear();

            listaDetalles.Clear();
            dgvLista.DataSource = null;
            subTotal = 0;

            txtSubTotal.Text = "0";
            nudTotalPagar.Value = 0;
            txtCambio.Text = "0";

            cbxCliente.SelectedIndex = -1;
            cbxProducto.SelectedIndex = -1;
            nudCantidad.Value = 0;
            nudPrecioUnitario.Value = 0;
            cbxTipoPago.SelectedIndex = -1;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProducto.SelectedIndex != -1)
            {
                var producto = (Producto)cbxProducto.SelectedItem;
                nudPrecioUnitario.Value = producto.precio;  // Precio del producto desde DB
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            decimal precio = nudPrecioUnitario.Value;
            decimal cantidad = nudCantidad.Value;

            nudTotalPagar.Value = precio * cantidad;
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            cargarCliente();
            cargarProducto();
        }
    }
}
