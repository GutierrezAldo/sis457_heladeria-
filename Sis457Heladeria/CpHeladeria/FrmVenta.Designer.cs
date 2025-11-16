namespace CpHeladeria
{
    partial class FrmVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenta));
            this.erpNommbreCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCI = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpRazonSocial = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblProductos = new System.Windows.Forms.Label();
            this.gbxCliente = new System.Windows.Forms.GroupBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnAñadirCliente = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.erpTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxRegistrar = new System.Windows.Forms.GroupBox();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTotalPagar = new System.Windows.Forms.NumericUpDown();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.gbxDetalle = new System.Windows.Forms.GroupBox();
            this.nudPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.cbxCliente = new System.Windows.Forms.ComboBox();
            this.cbxProducto = new System.Windows.Forms.ComboBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAñadirVenta = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.erpCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpProducto = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpTotalPagar = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbxTipoPago = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.erpTipoPago = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpNommbreCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpRazonSocial)).BeginInit();
            this.gbxCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpTelefono)).BeginInit();
            this.gbxRegistrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalPagar)).BeginInit();
            this.gbxDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTotalPagar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTipoPago)).BeginInit();
            this.SuspendLayout();
            // 
            // erpNommbreCliente
            // 
            this.erpNommbreCliente.ContainerControl = this;
            // 
            // erpCI
            // 
            this.erpCI.ContainerControl = this;
            // 
            // erpRazonSocial
            // 
            this.erpRazonSocial.ContainerControl = this;
            // 
            // lblProductos
            // 
            this.lblProductos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductos.Location = new System.Drawing.Point(12, 5);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(729, 24);
            this.lblProductos.TabIndex = 18;
            this.lblProductos.Text = "Registro de ventas";
            this.lblProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxCliente
            // 
            this.gbxCliente.Controls.Add(this.txtTelefono);
            this.gbxCliente.Controls.Add(this.label5);
            this.gbxCliente.Controls.Add(this.txtRazonSocial);
            this.gbxCliente.Controls.Add(this.label8);
            this.gbxCliente.Controls.Add(this.txtCI);
            this.gbxCliente.Controls.Add(this.label4);
            this.gbxCliente.Controls.Add(this.txtNombreCliente);
            this.gbxCliente.Controls.Add(this.btnAñadirCliente);
            this.gbxCliente.Controls.Add(this.label6);
            this.gbxCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCliente.Location = new System.Drawing.Point(15, 32);
            this.gbxCliente.Name = "gbxCliente";
            this.gbxCliente.Size = new System.Drawing.Size(726, 89);
            this.gbxCliente.TabIndex = 23;
            this.gbxCliente.TabStop = false;
            this.gbxCliente.Text = "1. Datos de la venta";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(400, 54);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(139, 22);
            this.txtTelefono.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(286, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 43;
            this.label5.Text = "Telefono:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(383, 23);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(156, 22);
            this.txtRazonSocial.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(286, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 41;
            this.label8.Text = "Razon Social:";
            // 
            // txtCI
            // 
            this.txtCI.Location = new System.Drawing.Point(129, 54);
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(139, 22);
            this.txtCI.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "CI:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(129, 23);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(139, 22);
            this.txtNombreCliente.TabIndex = 38;
            // 
            // btnAñadirCliente
            // 
            this.btnAñadirCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirCliente.Image = global::CpHeladeria.Properties.Resources._new;
            this.btnAñadirCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirCliente.Location = new System.Drawing.Point(560, 23);
            this.btnAñadirCliente.Name = "btnAñadirCliente";
            this.btnAñadirCliente.Size = new System.Drawing.Size(160, 41);
            this.btnAñadirCliente.TabIndex = 37;
            this.btnAñadirCliente.Text = "Añadir a la Cliente";
            this.btnAñadirCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirCliente.UseVisualStyleBackColor = true;
            this.btnAñadirCliente.Click += new System.EventHandler(this.btnAñadirCliente_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Nombre Cliente:";
            // 
            // erpTelefono
            // 
            this.erpTelefono.ContainerControl = this;
            // 
            // gbxRegistrar
            // 
            this.gbxRegistrar.Controls.Add(this.txtCambio);
            this.gbxRegistrar.Controls.Add(this.label3);
            this.gbxRegistrar.Controls.Add(this.nudTotalPagar);
            this.gbxRegistrar.Controls.Add(this.txtSubTotal);
            this.gbxRegistrar.Controls.Add(this.btnGuardar);
            this.gbxRegistrar.Controls.Add(this.btnCancelar);
            this.gbxRegistrar.Controls.Add(this.lblNombre);
            this.gbxRegistrar.Controls.Add(this.lblPrecio);
            this.gbxRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxRegistrar.Location = new System.Drawing.Point(12, 386);
            this.gbxRegistrar.Name = "gbxRegistrar";
            this.gbxRegistrar.Size = new System.Drawing.Size(729, 112);
            this.gbxRegistrar.TabIndex = 22;
            this.gbxRegistrar.TabStop = false;
            this.gbxRegistrar.Text = "3. Resumen y Pago";
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(570, 28);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(125, 22);
            this.txtCambio.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(499, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cambio:";
            // 
            // nudTotalPagar
            // 
            this.nudTotalPagar.DecimalPlaces = 2;
            this.nudTotalPagar.Location = new System.Drawing.Point(359, 28);
            this.nudTotalPagar.Name = "nudTotalPagar";
            this.nudTotalPagar.Size = new System.Drawing.Size(111, 22);
            this.nudTotalPagar.TabIndex = 15;
            this.nudTotalPagar.ValueChanged += new System.EventHandler(this.nudTotalPagar_ValueChanged);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(122, 27);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(109, 22);
            this.txtSubTotal.TabIndex = 14;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::CpHeladeria.Properties.Resources.save;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(132, 64);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 41);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Finalizar y Registrar la Venta";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = global::CpHeladeria.Properties.Resources.cancel;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(403, 64);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(207, 41);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cerrar o Cancelar la Venta";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(51, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 16);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "SubTotal:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(261, 30);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(92, 16);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Total a Pagar:";
            // 
            // gbxDetalle
            // 
            this.gbxDetalle.Controls.Add(this.cbxTipoPago);
            this.gbxDetalle.Controls.Add(this.label10);
            this.gbxDetalle.Controls.Add(this.nudPrecioUnitario);
            this.gbxDetalle.Controls.Add(this.cbxCliente);
            this.gbxDetalle.Controls.Add(this.cbxProducto);
            this.gbxDetalle.Controls.Add(this.nudCantidad);
            this.gbxDetalle.Controls.Add(this.label9);
            this.gbxDetalle.Controls.Add(this.btnAñadirVenta);
            this.gbxDetalle.Controls.Add(this.label7);
            this.gbxDetalle.Controls.Add(this.label1);
            this.gbxDetalle.Controls.Add(this.label2);
            this.gbxDetalle.Controls.Add(this.dgvLista);
            this.gbxDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDetalle.Location = new System.Drawing.Point(15, 127);
            this.gbxDetalle.Name = "gbxDetalle";
            this.gbxDetalle.Size = new System.Drawing.Size(726, 253);
            this.gbxDetalle.TabIndex = 25;
            this.gbxDetalle.TabStop = false;
            this.gbxDetalle.Text = "2. Detalle de Productos";
            // 
            // nudPrecioUnitario
            // 
            this.nudPrecioUnitario.DecimalPlaces = 2;
            this.nudPrecioUnitario.Location = new System.Drawing.Point(384, 30);
            this.nudPrecioUnitario.Name = "nudPrecioUnitario";
            this.nudPrecioUnitario.Size = new System.Drawing.Size(84, 22);
            this.nudPrecioUnitario.TabIndex = 40;
            // 
            // cbxCliente
            // 
            this.cbxCliente.FormattingEnabled = true;
            this.cbxCliente.Items.AddRange(new object[] {
            "Vaso Pequeño",
            "Vaso Mediano",
            "Vaso Grande"});
            this.cbxCliente.Location = new System.Drawing.Point(129, 29);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(139, 24);
            this.cbxCliente.TabIndex = 39;
            // 
            // cbxProducto
            // 
            this.cbxProducto.FormattingEnabled = true;
            this.cbxProducto.Items.AddRange(new object[] {
            "Vaso Pequeño",
            "Vaso Mediano",
            "Vaso Grande"});
            this.cbxProducto.Location = new System.Drawing.Point(384, 63);
            this.cbxProducto.Name = "cbxProducto";
            this.cbxProducto.Size = new System.Drawing.Size(139, 24);
            this.cbxProducto.TabIndex = 27;
            this.cbxProducto.SelectedIndexChanged += new System.EventHandler(this.cbxProducto_SelectedIndexChanged);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(129, 64);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(139, 22);
            this.nudCantidad.TabIndex = 37;
            this.nudCantidad.ValueChanged += new System.EventHandler(this.nudCantidad_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(286, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Producto: ";
            // 
            // btnAñadirVenta
            // 
            this.btnAñadirVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirVenta.Image = global::CpHeladeria.Properties.Resources._new;
            this.btnAñadirVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirVenta.Location = new System.Drawing.Point(560, 66);
            this.btnAñadirVenta.Name = "btnAñadirVenta";
            this.btnAñadirVenta.Size = new System.Drawing.Size(160, 41);
            this.btnAñadirVenta.TabIndex = 36;
            this.btnAñadirVenta.Text = "Añadir a la Venta";
            this.btnAñadirVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAñadirVenta.UseVisualStyleBackColor = true;
            this.btnAñadirVenta.Click += new System.EventHandler(this.btnAñadirVenta_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(286, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "Precio unitario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 32;
            this.label1.Text = "Cantidad: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Cliente: ";
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.AllowUserToDeleteRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(3, 114);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.ReadOnly = true;
            this.dgvLista.Size = new System.Drawing.Size(717, 133);
            this.dgvLista.TabIndex = 8;
            // 
            // erpCliente
            // 
            this.erpCliente.ContainerControl = this;
            // 
            // erpCantidad
            // 
            this.erpCantidad.ContainerControl = this;
            // 
            // erpProducto
            // 
            this.erpProducto.ContainerControl = this;
            // 
            // erpTotalPagar
            // 
            this.erpTotalPagar.ContainerControl = this;
            // 
            // cbxTipoPago
            // 
            this.cbxTipoPago.FormattingEnabled = true;
            this.cbxTipoPago.Items.AddRange(new object[] {
            "Efectivo",
            "QR"});
            this.cbxTipoPago.Location = new System.Drawing.Point(581, 27);
            this.cbxTipoPago.Name = "cbxTipoPago";
            this.cbxTipoPago.Size = new System.Drawing.Size(129, 24);
            this.cbxTipoPago.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(479, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Tipo de Pago: ";
            // 
            // erpTipoPago
            // 
            this.erpTipoPago.ContainerControl = this;
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 517);
            this.Controls.Add(this.gbxDetalle);
            this.Controls.Add(this.lblProductos);
            this.Controls.Add(this.gbxCliente);
            this.Controls.Add(this.gbxRegistrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVenta";
            this.Text = "::: Heladeria - FrmVenta :::";
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpNommbreCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpRazonSocial)).EndInit();
            this.gbxCliente.ResumeLayout(false);
            this.gbxCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpTelefono)).EndInit();
            this.gbxRegistrar.ResumeLayout(false);
            this.gbxRegistrar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTotalPagar)).EndInit();
            this.gbxDetalle.ResumeLayout(false);
            this.gbxDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTotalPagar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpTipoPago)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider erpNommbreCliente;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.GroupBox gbxCliente;
        private System.Windows.Forms.GroupBox gbxRegistrar;
        private System.Windows.Forms.NumericUpDown nudTotalPagar;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.ErrorProvider erpCI;
        private System.Windows.Forms.ErrorProvider erpRazonSocial;
        private System.Windows.Forms.ErrorProvider erpTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbxDetalle;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAñadirVenta;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Button btnAñadirCliente;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxProducto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider erpCliente;
        private System.Windows.Forms.ErrorProvider erpCantidad;
        private System.Windows.Forms.ErrorProvider erpProducto;
        private System.Windows.Forms.ErrorProvider erpTotalPagar;
        private System.Windows.Forms.ComboBox cbxCliente;
        private System.Windows.Forms.NumericUpDown nudPrecioUnitario;
        private System.Windows.Forms.ComboBox cbxTipoPago;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider erpTipoPago;
    }
}