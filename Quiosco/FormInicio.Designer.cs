using System.Windows.Forms.DataVisualization.Charting;

namespace Quiosco
{
    partial class FormInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            tabControl1 = new TabControl();
            tabInicio = new TabPage();
            groupBox1 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            dtpHasta = new DateTimePicker();
            dtpDesde = new DateTimePicker();
            btnFiltrar = new Button();
            btnGestionUsuarios = new Button();
            pictureBox1 = new PictureBox();
            btnRegistrarVenta = new Button();
            btnRegistrarProducto = new Button();
            lblSaludo = new Label();
            tabMisProductos = new TabPage();
            label5 = new Label();
            txtBuscarStockProductos = new TextBox();
            btnBuscarProductos = new Button();
            btnEliminarProductos = new Button();
            label6 = new Label();
            dgvStockProductos = new DataGridView();
            tabMisVentas = new TabPage();
            label8 = new Label();
            txtBuscarDetalleVenta = new TextBox();
            btnBuscarDetalleVenta = new Button();
            label9 = new Label();
            dgvDetalleVenta = new DataGridView();
            tabDeudores = new TabPage();
            label4 = new Label();
            txtBuscarDeudor = new TextBox();
            btnBuscarDeudor = new Button();
            btnEliminarDeudor = new Button();
            label1 = new Label();
            dgvDeudor = new DataGridView();
            btnPagarDeudor = new Button();
            btnCancelarDeudor = new Button();
            tabControl1.SuspendLayout();
            tabInicio.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabMisProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockProductos).BeginInit();
            tabMisVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            tabDeudores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeudor).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabInicio);
            tabControl1.Controls.Add(tabMisProductos);
            tabControl1.Controls.Add(tabMisVentas);
            tabControl1.Controls.Add(tabDeudores);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1521, 699);
            tabControl1.TabIndex = 1;
            // 
            // tabInicio
            // 
            tabInicio.BackColor = Color.Transparent;
            tabInicio.BackgroundImage = (Image)resources.GetObject("tabInicio.BackgroundImage");
            tabInicio.BackgroundImageLayout = ImageLayout.Stretch;
            tabInicio.Controls.Add(groupBox1);
            tabInicio.Controls.Add(btnFiltrar);
            tabInicio.Controls.Add(btnGestionUsuarios);
            tabInicio.Controls.Add(pictureBox1);
            tabInicio.Controls.Add(btnRegistrarVenta);
            tabInicio.Controls.Add(btnRegistrarProducto);
            tabInicio.Controls.Add(lblSaludo);
            tabInicio.Location = new Point(4, 24);
            tabInicio.Name = "tabInicio";
            tabInicio.Padding = new Padding(3);
            tabInicio.Size = new Size(1513, 671);
            tabInicio.TabIndex = 3;
            tabInicio.Text = "Inicio";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpHasta);
            groupBox1.Controls.Add(dtpDesde);
            groupBox1.Location = new Point(47, 77);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(275, 118);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtro por Rango de Fechas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 20);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 19;
            label2.Text = "Desde:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 68);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 20;
            label3.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Location = new Point(17, 86);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(234, 23);
            dtpHasta.TabIndex = 16;
            // 
            // dtpDesde
            // 
            dtpDesde.Location = new Point(19, 38);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(232, 23);
            dtpDesde.TabIndex = 15;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.Gold;
            btnFiltrar.BackgroundImageLayout = ImageLayout.Center;
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.FlatStyle = FlatStyle.Popup;
            btnFiltrar.ForeColor = Color.Black;
            btnFiltrar.Location = new Point(361, 97);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(75, 23);
            btnFiltrar.TabIndex = 17;
            btnFiltrar.Text = "FILTRAR";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // btnGestionUsuarios
            // 
            btnGestionUsuarios.BackColor = Color.Gold;
            btnGestionUsuarios.BackgroundImageLayout = ImageLayout.Center;
            btnGestionUsuarios.Cursor = Cursors.Hand;
            btnGestionUsuarios.FlatStyle = FlatStyle.Popup;
            btnGestionUsuarios.Location = new Point(1345, 41);
            btnGestionUsuarios.Name = "btnGestionUsuarios";
            btnGestionUsuarios.Size = new Size(148, 23);
            btnGestionUsuarios.TabIndex = 14;
            btnGestionUsuarios.Text = "Gestion Usuarios";
            btnGestionUsuarios.UseVisualStyleBackColor = false;
            btnGestionUsuarios.Click += btnGestionUsuarios_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(131, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(851, 603);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.MouseEnter += pictureBox1_MouseEnter;
            pictureBox1.MouseLeave += PictureBox1_MouseLeave;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.Red;
            btnRegistrarVenta.BackgroundImageLayout = ImageLayout.Center;
            btnRegistrarVenta.Cursor = Cursors.Hand;
            btnRegistrarVenta.FlatStyle = FlatStyle.Popup;
            btnRegistrarVenta.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarVenta.ForeColor = SystemColors.ActiveCaptionText;
            btnRegistrarVenta.Location = new Point(1146, 422);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(220, 42);
            btnRegistrarVenta.TabIndex = 12;
            btnRegistrarVenta.Text = "REGISTRAR VENTA";
            btnRegistrarVenta.UseVisualStyleBackColor = false;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // btnRegistrarProducto
            // 
            btnRegistrarProducto.BackColor = Color.Red;
            btnRegistrarProducto.BackgroundImageLayout = ImageLayout.Center;
            btnRegistrarProducto.Cursor = Cursors.Hand;
            btnRegistrarProducto.FlatStyle = FlatStyle.Popup;
            btnRegistrarProducto.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarProducto.ForeColor = SystemColors.ActiveCaptionText;
            btnRegistrarProducto.Location = new Point(1146, 290);
            btnRegistrarProducto.Name = "btnRegistrarProducto";
            btnRegistrarProducto.Size = new Size(220, 42);
            btnRegistrarProducto.TabIndex = 11;
            btnRegistrarProducto.Text = "REGISTRAR PRODUCTO";
            btnRegistrarProducto.UseVisualStyleBackColor = false;
            btnRegistrarProducto.Click += btnRegistrarProducto_Click;
            // 
            // lblSaludo
            // 
            lblSaludo.AutoSize = true;
            lblSaludo.BackColor = Color.MintCream;
            lblSaludo.BorderStyle = BorderStyle.Fixed3D;
            lblSaludo.Font = new Font("High Tower Text", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblSaludo.Location = new Point(604, 16);
            lblSaludo.Name = "lblSaludo";
            lblSaludo.Size = new Size(218, 34);
            lblSaludo.TabIndex = 10;
            lblSaludo.Text = "BIENVENIDO!";
            // 
            // tabMisProductos
            // 
            tabMisProductos.BackgroundImage = (Image)resources.GetObject("tabMisProductos.BackgroundImage");
            tabMisProductos.BackgroundImageLayout = ImageLayout.Stretch;
            tabMisProductos.BorderStyle = BorderStyle.Fixed3D;
            tabMisProductos.Controls.Add(label5);
            tabMisProductos.Controls.Add(txtBuscarStockProductos);
            tabMisProductos.Controls.Add(btnBuscarProductos);
            tabMisProductos.Controls.Add(btnEliminarProductos);
            tabMisProductos.Controls.Add(label6);
            tabMisProductos.Controls.Add(dgvStockProductos);
            tabMisProductos.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabMisProductos.ForeColor = SystemColors.ActiveCaptionText;
            tabMisProductos.Location = new Point(4, 24);
            tabMisProductos.Margin = new Padding(4);
            tabMisProductos.Name = "tabMisProductos";
            tabMisProductos.Padding = new Padding(4);
            tabMisProductos.Size = new Size(1513, 671);
            tabMisProductos.TabIndex = 0;
            tabMisProductos.Text = "Mis Productos";
            tabMisProductos.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Wheat;
            label5.Location = new Point(356, 537);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 59;
            label5.Text = "Buscar";
            // 
            // txtBuscarStockProductos
            // 
            txtBuscarStockProductos.Location = new Point(420, 533);
            txtBuscarStockProductos.Name = "txtBuscarStockProductos";
            txtBuscarStockProductos.Size = new Size(155, 27);
            txtBuscarStockProductos.TabIndex = 58;
            // 
            // btnBuscarProductos
            // 
            btnBuscarProductos.BackColor = Color.Gold;
            btnBuscarProductos.Location = new Point(581, 524);
            btnBuscarProductos.Name = "btnBuscarProductos";
            btnBuscarProductos.Size = new Size(84, 36);
            btnBuscarProductos.TabIndex = 57;
            btnBuscarProductos.Text = "Buscar";
            btnBuscarProductos.UseVisualStyleBackColor = false;
            btnBuscarProductos.Click += btnBuscarProductos_Click;
            // 
            // btnEliminarProductos
            // 
            btnEliminarProductos.BackColor = Color.Gold;
            btnEliminarProductos.Location = new Point(917, 526);
            btnEliminarProductos.Name = "btnEliminarProductos";
            btnEliminarProductos.Size = new Size(84, 36);
            btnEliminarProductos.TabIndex = 56;
            btnEliminarProductos.Text = "Eliminar";
            btnEliminarProductos.UseVisualStyleBackColor = false;
            btnEliminarProductos.Click += btnEliminarProductos_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveCaption;
            label6.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(581, 52);
            label6.Name = "label6";
            label6.Size = new Size(158, 20);
            label6.TabIndex = 55;
            label6.Text = "MIS PRODUCTOS";
            label6.Click += label6_Click;
            // 
            // dgvStockProductos
            // 
            dgvStockProductos.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvStockProductos.BorderStyle = BorderStyle.Fixed3D;
            dgvStockProductos.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvStockProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStockProductos.Cursor = Cursors.Hand;
            dgvStockProductos.Location = new Point(362, 101);
            dgvStockProductos.Name = "dgvStockProductos";
            dgvStockProductos.Size = new Size(639, 408);
            dgvStockProductos.TabIndex = 54;
            // 
            // tabMisVentas
            // 
            tabMisVentas.BackgroundImage = (Image)resources.GetObject("tabMisVentas.BackgroundImage");
            tabMisVentas.BackgroundImageLayout = ImageLayout.Stretch;
            tabMisVentas.BorderStyle = BorderStyle.Fixed3D;
            tabMisVentas.Controls.Add(label8);
            tabMisVentas.Controls.Add(txtBuscarDetalleVenta);
            tabMisVentas.Controls.Add(btnBuscarDetalleVenta);
            tabMisVentas.Controls.Add(label9);
            tabMisVentas.Controls.Add(dgvDetalleVenta);
            tabMisVentas.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabMisVentas.Location = new Point(4, 24);
            tabMisVentas.Margin = new Padding(4);
            tabMisVentas.Name = "tabMisVentas";
            tabMisVentas.Padding = new Padding(4);
            tabMisVentas.Size = new Size(1513, 671);
            tabMisVentas.TabIndex = 1;
            tabMisVentas.Text = "Mis Ventas";
            tabMisVentas.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Wheat;
            label8.Location = new Point(1013, 581);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 90;
            label8.Text = "Buscar";
            // 
            // txtBuscarDetalleVenta
            // 
            txtBuscarDetalleVenta.Location = new Point(1079, 579);
            txtBuscarDetalleVenta.Name = "txtBuscarDetalleVenta";
            txtBuscarDetalleVenta.Size = new Size(155, 27);
            txtBuscarDetalleVenta.TabIndex = 89;
            // 
            // btnBuscarDetalleVenta
            // 
            btnBuscarDetalleVenta.BackColor = Color.Gold;
            btnBuscarDetalleVenta.Location = new Point(1240, 570);
            btnBuscarDetalleVenta.Name = "btnBuscarDetalleVenta";
            btnBuscarDetalleVenta.Size = new Size(84, 36);
            btnBuscarDetalleVenta.TabIndex = 88;
            btnBuscarDetalleVenta.Text = "Buscar";
            btnBuscarDetalleVenta.UseVisualStyleBackColor = false;
            btnBuscarDetalleVenta.Click += btnBuscarDetalleVenta_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ActiveCaption;
            label9.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(590, 38);
            label9.Name = "label9";
            label9.Size = new Size(121, 20);
            label9.TabIndex = 86;
            label9.Text = "MIS VENTAS";
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvDetalleVenta.BorderStyle = BorderStyle.Fixed3D;
            dgvDetalleVenta.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Cursor = Cursors.Hand;
            dgvDetalleVenta.Location = new Point(216, 71);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.Size = new Size(1039, 453);
            dgvDetalleVenta.TabIndex = 85;
            // 
            // tabDeudores
            // 
            tabDeudores.BackgroundImage = (Image)resources.GetObject("tabDeudores.BackgroundImage");
            tabDeudores.BackgroundImageLayout = ImageLayout.Stretch;
            tabDeudores.BorderStyle = BorderStyle.Fixed3D;
            tabDeudores.Controls.Add(label4);
            tabDeudores.Controls.Add(txtBuscarDeudor);
            tabDeudores.Controls.Add(btnBuscarDeudor);
            tabDeudores.Controls.Add(btnEliminarDeudor);
            tabDeudores.Controls.Add(label1);
            tabDeudores.Controls.Add(dgvDeudor);
            tabDeudores.Controls.Add(btnPagarDeudor);
            tabDeudores.Controls.Add(btnCancelarDeudor);
            tabDeudores.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabDeudores.Location = new Point(4, 24);
            tabDeudores.Name = "tabDeudores";
            tabDeudores.Padding = new Padding(3);
            tabDeudores.Size = new Size(1513, 671);
            tabDeudores.TabIndex = 2;
            tabDeudores.Text = "Deudores";
            tabDeudores.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(370, 546);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 90;
            label4.Text = "Buscar";
            // 
            // txtBuscarDeudor
            // 
            txtBuscarDeudor.Location = new Point(434, 542);
            txtBuscarDeudor.Name = "txtBuscarDeudor";
            txtBuscarDeudor.Size = new Size(155, 27);
            txtBuscarDeudor.TabIndex = 89;
            // 
            // btnBuscarDeudor
            // 
            btnBuscarDeudor.BackColor = Color.Gold;
            btnBuscarDeudor.Location = new Point(595, 536);
            btnBuscarDeudor.Name = "btnBuscarDeudor";
            btnBuscarDeudor.Size = new Size(84, 36);
            btnBuscarDeudor.TabIndex = 88;
            btnBuscarDeudor.Text = "Buscar";
            btnBuscarDeudor.UseVisualStyleBackColor = false;
            btnBuscarDeudor.Click += btnBuscarDeudor_Click;
            // 
            // btnEliminarDeudor
            // 
            btnEliminarDeudor.BackColor = Color.Gold;
            btnEliminarDeudor.Location = new Point(925, 536);
            btnEliminarDeudor.Name = "btnEliminarDeudor";
            btnEliminarDeudor.Size = new Size(84, 36);
            btnEliminarDeudor.TabIndex = 87;
            btnEliminarDeudor.Text = "Eliminar";
            btnEliminarDeudor.UseVisualStyleBackColor = false;
            btnEliminarDeudor.Click += btnEliminarDeudor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(617, 43);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 86;
            label1.Text = "DEUDORES";
            // 
            // dgvDeudor
            // 
            dgvDeudor.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvDeudor.BorderStyle = BorderStyle.Fixed3D;
            dgvDeudor.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvDeudor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeudor.Cursor = Cursors.Hand;
            dgvDeudor.Location = new Point(397, 86);
            dgvDeudor.Name = "dgvDeudor";
            dgvDeudor.Size = new Size(571, 408);
            dgvDeudor.TabIndex = 85;
            dgvDeudor.CellClick += dgvDeudor_CellClick;
            // 
            // btnPagarDeudor
            // 
            btnPagarDeudor.BackColor = Color.Gold;
            btnPagarDeudor.Location = new Point(153, 227);
            btnPagarDeudor.Name = "btnPagarDeudor";
            btnPagarDeudor.Size = new Size(93, 31);
            btnPagarDeudor.TabIndex = 1;
            btnPagarDeudor.Text = "PAGAR";
            btnPagarDeudor.UseVisualStyleBackColor = false;
            btnPagarDeudor.Click += btnPagarDeudor_Click;
            // 
            // btnCancelarDeudor
            // 
            btnCancelarDeudor.AccessibleRole = AccessibleRole.Sound;
            btnCancelarDeudor.BackColor = Color.Gold;
            btnCancelarDeudor.Location = new Point(142, 463);
            btnCancelarDeudor.Name = "btnCancelarDeudor";
            btnCancelarDeudor.Size = new Size(107, 31);
            btnCancelarDeudor.TabIndex = 0;
            btnCancelarDeudor.Text = "Actualizar";
            btnCancelarDeudor.UseVisualStyleBackColor = false;
            btnCancelarDeudor.Click += btnCancelarDeudor_Click;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1521, 699);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormInicio";
            Text = "Software Comercial";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormInicio_FormClosing;
            Load += FormInicio_Load;
            tabControl1.ResumeLayout(false);
            tabInicio.ResumeLayout(false);
            tabInicio.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabMisProductos.ResumeLayout(false);
            tabMisProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStockProductos).EndInit();
            tabMisVentas.ResumeLayout(false);
            tabMisVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            tabDeudores.ResumeLayout(false);
            tabDeudores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeudor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabMisProductos;
        private TabPage tabMisVentas;
        private TabPage tabDeudores;
        private Button btnPagarDeudor;
        private Button btnCancelarDeudor;
        private TabPage tabInicio;
        private Button btnEliminarProductos;
        private Button btnRegistrarProducto;
        private Label lblSaludo;
        private Button btnRegistrarVenta;
        private Label label4;
        private TextBox txtBuscarDeudor;
        private Button btnBuscarDeudor;
        private Button btnEliminarDeudor;
        private Label label1;
        private DataGridView dgvDeudor;
        private Label label5;
        private TextBox txtBuscarStockProductos;
        private Button btnBuscarProductos;
        private Label label6;
        private DataGridView dgvStockProductos;
        private Label label8;
        private TextBox txtBuscarDetalleVenta;
        private Button btnBuscarDetalleVenta;
        private Label label9;
        private DataGridView dgvDetalleVenta;
        private PictureBox pictureBox1;
        private Button btnGestionUsuarios;
        private Button btnFiltrar;
        private DateTimePicker dtpHasta;
        private DateTimePicker dtpDesde;
        private GroupBox groupBox1;
        private Label label2;
        private Label label3;
    }
}