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
    public partial class FrmListaVentas : Form
    {
        public FrmListaVentas()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = VentaCln.listarPa(dtpDesde.Value.Date, dtpHasta.Value.Date);
            dgvLista.DataSource = lista;
            dgvLista.Columns["idVenta"].Visible = false;
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";
            dgvLista.Columns["Cliente"].HeaderText = "Cliente";
            dgvLista.Columns["tipoPago"].HeaderText = "Tipo de Pago";
            dgvLista.Columns["MontoVenta"].HeaderText = "Monto Total";
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FrmListaVentas_Load(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;

            DateTime inicioGestion = new DateTime(hoy.Year, 1, 1);

            dtpDesde.Value = inicioGestion;
            dtpHasta.Value = hoy;

            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
