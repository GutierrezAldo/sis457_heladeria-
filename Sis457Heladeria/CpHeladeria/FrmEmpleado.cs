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
    public partial class FrmEmpleado : Form
    {
        private bool esNuevo = false;
        private int idUsuarioEmpleado = 0;
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void configurarPermisos()
        {
            string rolActual = Util.usuario.role;

            bool esAdministrador = (rolActual.ToUpper() == "ADMINISTRADOR");

            btnNuevo.Enabled = esAdministrador;
            btnEditar.Enabled = esAdministrador && dgvLista.Rows.Count > 0;
            btnEliminar.Enabled = esAdministrador && dgvLista.Rows.Count > 0;

        }

        private void listar()
        {
            var lista = EmpleadoCln.listarPa(txtBuscar.Text.Trim());
            dgvLista.DataSource = lista;
            dgvLista.Columns["idUsuario"].Visible = false;
            dgvLista.Columns["idEmpleado"].Visible = false;
            dgvLista.Columns["nombres"].HeaderText = "Nombres";
            dgvLista.Columns["primerApellido"].HeaderText = "Apellido Paterno";
            dgvLista.Columns["segundoApellido"].HeaderText = "Apellido Materno";
            dgvLista.Columns["usuario"].HeaderText = "Usuario";
            dgvLista.Columns["role"].HeaderText = "Rol ";
            dgvLista.Columns["direccion"].HeaderText = "Dirección";
            dgvLista.Columns["telefono"].HeaderText = "Celular";
            dgvLista.Columns["fechaContratacion"].HeaderText = "Fecha Contratacion";
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha de Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombres"];
            configurarPermisos();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            Size = new Size(713, 275);
            listar();
            configurarPermisos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (Util.usuario.role.ToUpper() != "ADMINISTRADOR")
            {
                MessageBox.Show("No tiene permisos para editar empleados.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            esNuevo = true;
            pnlAcciones.Enabled = false;
            Size = new Size(713, 434);
            txtNombre.Focus();
            configurarPermisos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (Util.usuario.role.ToUpper() != "ADMINISTRADOR")
            {
                MessageBox.Show("No tiene permisos para editar empleados.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            esNuevo = false;
            pnlAcciones.Enabled = false;
            Size = new Size(713, 434);

            int id = (int)dgvLista.CurrentRow.Cells["nombres"].Value;
            var empleado = EmpleadoCln.obtenerUno(id);

            if (empleado.Usuario.Count > 0)
            {
                idUsuarioEmpleado = empleado.Usuario.First().id;
            }
            else
            {
                idUsuarioEmpleado = 0;
            }

            var usuario = empleado.Usuario.Count > 0 ? empleado.Usuario.First().usuario1 : "";

            txtNombre.Text = empleado.nombres;
            txtPrimerApellido.Text = empleado.primerApellido;
            txtSegundoApellido.Text = empleado.segundoApellido;
            dtpFechaContratacion.Value = empleado.fechaContratacion;
            txtDireccion.Text = empleado.direccion; 
            txtTelefono.Text = empleado.telefono.ToString();
            cbxRol.Text = empleado.Usuario.Count > 0 ? empleado.Usuario.First().role : "";
            txtUsuario.Text = usuario;

            txtNombre.Focus();
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            dtpFechaContratacion.Value = DateTime.Now;
            txtTelefono.Clear();
            txtDireccion.Clear();
            cbxRol.SelectedIndex = -1;
            txtUsuario.Clear();
            idUsuarioEmpleado = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(713, 275);
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
            erpPrimerApellido.Clear();
            erpSegundoApellido.Clear();
            erpFechaContratacion.Clear();
            erpDireccion.Clear();
            erpTelefono.Clear();
            erpRol.Clear();
            erpUsuario.Clear();

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "El Nombre del Empleado es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtPrimerApellido.Text))
            {
                erpPrimerApellido.SetError(txtPrimerApellido, "El Apellido Paterno del Empleado es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtSegundoApellido.Text))
            {
                erpSegundoApellido.SetError(txtSegundoApellido, "El Apellido Materno del Empleado es obligatorio");
                esValido = false;
            }
            if (dtpFechaContratacion.Value > DateTime.Today)
            {
                erpFechaContratacion.SetError(dtpFechaContratacion, "La fecha de contratación no puede ser una fecha futura.");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                erpDireccion.SetError(txtDireccion, "La Dirección del Empleado es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                erpTelefono.SetError(txtTelefono, "El Celular del Empleado es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(cbxRol.Text) || cbxRol.SelectedIndex == -1)
            {
                erpRol.SetError(cbxRol, "El Rol del Empleado es obligatorio");
                esValido = false;
            }
            string usuarioIngresado = txtUsuario.Text.Trim();
            if (string.IsNullOrEmpty(usuarioIngresado))
            {
                erpUsuario.SetError(txtUsuario, "El campo Usuario es obligatorio");
                esValido = false;
            }
            else
            {
                if (ClnHeladeria.UsuarioCln.existeUsuario(usuarioIngresado))
                {
                    erpUsuario.SetError(txtUsuario, "¡Atención! Este nombre de Usuario ya existe. Por favor, elige otro.");
                    esValido = false;
                }

                if (usuarioIngresado.Length < 3)
                {
                    erpUsuario.SetError(txtUsuario, "El Usuario debe tener al menos 3 caracteres.");
                    esValido = false;
                }
            }

            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var empleado = new Empleado();
                empleado.nombres = txtNombre.Text.Trim();
                empleado.primerApellido = txtPrimerApellido.Text.Trim();
                empleado.segundoApellido = txtSegundoApellido.Text.Trim();
                empleado.fechaContratacion = dtpFechaContratacion.Value;
                empleado.direccion = txtDireccion.Text.Trim();
                empleado.telefono = long.Parse(txtTelefono.Text.Trim());
                empleado.usuarioRegistro = Util.usuario.usuario1;

                Usuario usuario = null;
                if (!string.IsNullOrEmpty(txtUsuario.Text))
                {
                    usuario = new Usuario();
                    usuario.role = cbxRol.Text.Trim();
                    usuario.usuario1 = txtUsuario.Text.Trim();
                    usuario.clave = Util.Encrypt("hola123");
                }
                if (usuario != null)
                {
                    usuario.usuarioRegistro = Util.usuario.usuario1;
                    usuario.estado = 1;
                    usuario.fechaRegistro = DateTime.Now;
                }


                if (esNuevo)
                {
                    empleado.fechaRegistro = DateTime.Now;
                    empleado.estado = 1;

                    var nuevoEmpleado = EmpleadoCln.insertar(empleado);

                    if (usuario != null)
                    {
                        usuario.idEmpleado = nuevoEmpleado.id;
                        usuario.estado = 1;

                        UsuarioCln.insertar(usuario);
                    }
                }
                else
                {
                    empleado.id = (int)dgvLista.CurrentRow.Cells["id"].Value;

                    EmpleadoCln.actualizar(empleado);

                    if (usuario != null)
                    {
                        if (idUsuarioEmpleado > 0)
                        {
                            usuario.id = idUsuarioEmpleado;
                            UsuarioCln.actualizar(usuario);
                        }
                        else
                        {
                            usuario.idEmpleado = empleado.id;
                            usuario.estado = 1;
                            UsuarioCln.insertar(usuario);
                        }
                    }
                }

                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Registro del empleado guardado correctamente", "::: Mensaje - Heladeria :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Util.usuario.role.ToUpper() != "ADMINISTRADOR")
            {
                MessageBox.Show("No tiene permisos para eliminar empleados.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = dgvLista.CurrentRow.Cells["nombres"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Está seguro de eliminar el producto {nombre}?",
                "::: Mensaje - Heladeria :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                EmpleadoCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Empleado dado de baja correctamente", "::: Mensaje - Heladeria :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
