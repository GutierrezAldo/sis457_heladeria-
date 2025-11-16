namespace CpHeladeria
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.crbPrincipal = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonBottomToolBar1 = new C1.Win.C1Ribbon.RibbonBottomToolBar();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.btnCaProductos = new C1.Win.C1Ribbon.RibbonButton();
            this.btnCaVentas = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab3 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup3 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton2 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab4 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup4 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton1 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab5 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup5 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton4 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab2 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton3 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTopToolBar1 = new C1.Win.C1Ribbon.RibbonTopToolBar();
            this.ribbonTab6 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup6 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton5 = new C1.Win.C1Ribbon.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.crbPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // crbPrincipal
            // 
            this.crbPrincipal.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.crbPrincipal.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.crbPrincipal.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.crbPrincipal.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.crbPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crbPrincipal.Location = new System.Drawing.Point(0, 0);
            this.crbPrincipal.Name = "crbPrincipal";
            this.crbPrincipal.QatHolder = this.ribbonQat1;
            this.crbPrincipal.Size = new System.Drawing.Size(708, 154);
            this.crbPrincipal.Tabs.Add(this.ribbonTab1);
            this.crbPrincipal.Tabs.Add(this.ribbonTab5);
            this.crbPrincipal.Tabs.Add(this.ribbonTab3);
            this.crbPrincipal.Tabs.Add(this.ribbonTab6);
            this.crbPrincipal.Tabs.Add(this.ribbonTab4);
            this.crbPrincipal.Tabs.Add(this.ribbonTab2);
            this.crbPrincipal.TopToolBarHolder = this.ribbonTopToolBar1;
            this.crbPrincipal.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Blue;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonBottomToolBar1
            // 
            this.ribbonBottomToolBar1.Name = "ribbonBottomToolBar1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Operaciones";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.HasLauncherButton = true;
            this.ribbonGroup1.Items.Add(this.btnCaProductos);
            this.ribbonGroup1.Items.Add(this.btnCaVentas);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Gestion de Operaciones";
            // 
            // btnCaProductos
            // 
            this.btnCaProductos.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaProductos.LargeImage")));
            this.btnCaProductos.Name = "btnCaProductos";
            this.btnCaProductos.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaProductos.SmallImage")));
            this.btnCaProductos.Text = "Productos";
            this.btnCaProductos.Click += new System.EventHandler(this.btnCaProductos_Click);
            // 
            // btnCaVentas
            // 
            this.btnCaVentas.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCaVentas.LargeImage")));
            this.btnCaVentas.Name = "btnCaVentas";
            this.btnCaVentas.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCaVentas.SmallImage")));
            this.btnCaVentas.Text = "Ventas";
            this.btnCaVentas.Click += new System.EventHandler(this.btnCaVentas_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Groups.Add(this.ribbonGroup3);
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Productos";
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Items.Add(this.ribbonButton2);
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Text = "Gestion de Productos";
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Productos";
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Groups.Add(this.ribbonGroup4);
            this.ribbonTab4.Name = "ribbonTab4";
            this.ribbonTab4.Text = "Reportes";
            // 
            // ribbonGroup4
            // 
            this.ribbonGroup4.Items.Add(this.ribbonButton1);
            this.ribbonGroup4.Name = "ribbonGroup4";
            this.ribbonGroup4.Text = "Gestion de Ventas";
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.LargeImage")));
            this.ribbonButton1.Name = "ribbonButton1";
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Lista de VentasRealidaz";
            this.ribbonButton1.Click += new System.EventHandler(this.btnCaReporteVentas);
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Groups.Add(this.ribbonGroup5);
            this.ribbonTab5.Name = "ribbonTab5";
            this.ribbonTab5.Text = "Empleados";
            // 
            // ribbonGroup5
            // 
            this.ribbonGroup5.Items.Add(this.ribbonButton4);
            this.ribbonGroup5.Name = "ribbonGroup5";
            this.ribbonGroup5.Text = "Gestion de empleados";
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "Empleados";
            this.ribbonButton4.Click += new System.EventHandler(this.ribbonButton4_Click);
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Groups.Add(this.ribbonGroup2);
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Ayuda";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.ribbonButton3);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Ayuda";
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.LargeImage")));
            this.ribbonButton3.Name = "ribbonButton3";
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "Ayuda";
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // ribbonTab6
            // 
            this.ribbonTab6.Groups.Add(this.ribbonGroup6);
            this.ribbonTab6.Name = "ribbonTab6";
            this.ribbonTab6.Text = "Clientes";
            // 
            // ribbonGroup6
            // 
            this.ribbonGroup6.Items.Add(this.ribbonButton5);
            this.ribbonGroup6.Name = "ribbonGroup6";
            this.ribbonGroup6.Text = "Group";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "Clientes";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 450);
            this.Controls.Add(this.crbPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.Text = "::: Principal - Heladeria :::";
            ((System.ComponentModel.ISupportInitialize)(this.crbPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon crbPrincipal;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.RibbonTopToolBar ribbonTopToolBar1;
        private C1.Win.C1Ribbon.RibbonButton btnCaProductos;
        private C1.Win.C1Ribbon.RibbonButton btnCaVentas;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab2;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab3;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup3;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab4;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup4;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab5;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup5;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton2;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton4;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton3;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab6;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup6;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton5;
    }
}