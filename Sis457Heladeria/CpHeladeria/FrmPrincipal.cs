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
    public partial class FrmPrincipal : Form
    {
        private FrmAutenticacion frmAutenticacion;
        public FrmPrincipal(FrmAutenticacion frmAutenticacion)
        {
            InitializeComponent();
            this.frmAutenticacion = frmAutenticacion;
        }

        private void btnCaProductos_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();
        }

        private void btnCaVentas_Click(object sender, EventArgs e)
        {
            new FrmVenta().ShowDialog();
        }

        private void btnCaReporteVentas(object sender, EventArgs e)
        {
            new FrmListaVentas().ShowDialog();
        }

        private void ribbonButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
