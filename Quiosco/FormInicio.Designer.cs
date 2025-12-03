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
            label12 = new Label();
            label11 = new Label();
            VENTA = new Label();
            pictureBox1 = new PictureBox();
            btnRegistrarVenta = new Button();
            btnRegistrarProducto = new Button();
            label2 = new Label();
            tabMisProductos = new TabPage();
            txtEliminarStockProductos = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtBuscarStockProductos = new TextBox();
            btnBuscarProductos = new Button();
            btnEliminarProductos = new Button();
            label6 = new Label();
            dgvStockProductos = new DataGridView();
            tabMisVentas = new TabPage();
            txtEliminarDetalleVenta = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtBuscarDetalleVenta = new TextBox();
            btnBuscarDetalleVenta = new Button();
            btnEliminarDetalleVenta = new Button();
            label9 = new Label();
            dgvDetalleVenta = new DataGridView();
            tabDeudores = new TabPage();
            txtEliminarDeudor = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarDeudor = new TextBox();
            btnBuscarDeudor = new Button();
            btnEliminarDeudor = new Button();
            label1 = new Label();
            dgvDeudor = new DataGridView();
            btnModificarDeudor = new Button();
            btnPagarDeudor = new Button();
            btnCancelarDeudor = new Button();
            tabControl1.SuspendLayout();
            tabInicio.SuspendLayout();
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
            tabControl1.Location = new Point(22, 8);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1371, 650);
            tabControl1.TabIndex = 1;
            // 
            // tabInicio
            // 
            tabInicio.BackgroundImage = (Image)resources.GetObject("tabInicio.BackgroundImage");
            tabInicio.BackgroundImageLayout = ImageLayout.Stretch;
            tabInicio.Controls.Add(label12);
            tabInicio.Controls.Add(label11);
            tabInicio.Controls.Add(VENTA);
            tabInicio.Controls.Add(pictureBox1);
            tabInicio.Controls.Add(btnRegistrarVenta);
            tabInicio.Controls.Add(btnRegistrarProducto);
            tabInicio.Controls.Add(label2);
            tabInicio.Location = new Point(4, 24);
            tabInicio.Name = "tabInicio";
            tabInicio.Padding = new Padding(3);
            tabInicio.Size = new Size(1363, 622);
            tabInicio.TabIndex = 3;
            tabInicio.Text = "Inicio";
            tabInicio.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Black;
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(303, 258);
            label12.Name = "label12";
            label12.Size = new Size(68, 15);
            label12.TabIndex = 17;
            label12.Text = "GANANCIA";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Black;
            label11.ForeColor = SystemColors.ButtonHighlight;
            label11.Location = new Point(389, 313);
            label11.Name = "label11";
            label11.Size = new Size(57, 15);
            label11.TabIndex = 16;
            label11.Text = "COMPRA\r\n";
            // 
            // VENTA
            // 
            VENTA.AutoSize = true;
            VENTA.BackColor = Color.Black;
            VENTA.ForeColor = SystemColors.ButtonHighlight;
            VENTA.Location = new Point(404, 222);
            VENTA.Name = "VENTA";
            VENTA.Size = new Size(42, 15);
            VENTA.TabIndex = 14;
            VENTA.Text = "VENTA\r\n";
            VENTA.Click += VENTA_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleRole = AccessibleRole.Chart;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(236, 162);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(308, 246);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.BackColor = Color.Red;
            btnRegistrarVenta.BackgroundImageLayout = ImageLayout.Center;
            btnRegistrarVenta.Cursor = Cursors.Hand;
            btnRegistrarVenta.FlatStyle = FlatStyle.Popup;
            btnRegistrarVenta.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarVenta.ForeColor = SystemColors.ActiveCaptionText;
            btnRegistrarVenta.Location = new Point(981, 336);
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
            btnRegistrarProducto.Location = new Point(981, 204);
            btnRegistrarProducto.Name = "btnRegistrarProducto";
            btnRegistrarProducto.Size = new Size(220, 42);
            btnRegistrarProducto.TabIndex = 11;
            btnRegistrarProducto.Text = "REGISTRAR PRODUCTO";
            btnRegistrarProducto.UseVisualStyleBackColor = false;
            btnRegistrarProducto.Click += btnRegistrarProducto_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.MintCream;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("High Tower Text", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(544, 53);
            label2.Name = "label2";
            label2.Size = new Size(218, 34);
            label2.TabIndex = 10;
            label2.Text = "BIENVENIDO!";
            // 
            // tabMisProductos
            // 
            tabMisProductos.BackgroundImage = (Image)resources.GetObject("tabMisProductos.BackgroundImage");
            tabMisProductos.BackgroundImageLayout = ImageLayout.Stretch;
            tabMisProductos.BorderStyle = BorderStyle.Fixed3D;
            tabMisProductos.Controls.Add(txtEliminarStockProductos);
            tabMisProductos.Controls.Add(label3);
            tabMisProductos.Controls.Add(label5);
            tabMisProductos.Controls.Add(txtBuscarStockProductos);
            tabMisProductos.Controls.Add(btnBuscarProductos);
            tabMisProductos.Controls.Add(btnEliminarProductos);
            tabMisProductos.Controls.Add(label6);
            tabMisProductos.Controls.Add(dgvStockProductos);
            tabMisProductos.Cursor = Cursors.Hand;
            tabMisProductos.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabMisProductos.ForeColor = SystemColors.ActiveCaptionText;
            tabMisProductos.Location = new Point(4, 24);
            tabMisProductos.Margin = new Padding(4);
            tabMisProductos.Name = "tabMisProductos";
            tabMisProductos.Padding = new Padding(4);
            tabMisProductos.Size = new Size(1363, 622);
            tabMisProductos.TabIndex = 0;
            tabMisProductos.Text = "Mis Productos";
            tabMisProductos.UseVisualStyleBackColor = true;
            // 
            // txtEliminarStockProductos
            // 
            txtEliminarStockProductos.Location = new Point(770, 532);
            txtEliminarStockProductos.Name = "txtEliminarStockProductos";
            txtEliminarStockProductos.Size = new Size(134, 27);
            txtEliminarStockProductos.TabIndex = 61;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Wheat;
            label3.Location = new Point(697, 535);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 60;
            label3.Text = "Eliminar";
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
            dgvStockProductos.Location = new Point(206, 93);
            dgvStockProductos.Name = "dgvStockProductos";
            dgvStockProductos.Size = new Size(989, 408);
            dgvStockProductos.TabIndex = 54;
            // 
            // tabMisVentas
            // 
            tabMisVentas.BackgroundImage = (Image)resources.GetObject("tabMisVentas.BackgroundImage");
            tabMisVentas.BackgroundImageLayout = ImageLayout.Stretch;
            tabMisVentas.BorderStyle = BorderStyle.Fixed3D;
            tabMisVentas.Controls.Add(txtEliminarDetalleVenta);
            tabMisVentas.Controls.Add(label7);
            tabMisVentas.Controls.Add(label8);
            tabMisVentas.Controls.Add(txtBuscarDetalleVenta);
            tabMisVentas.Controls.Add(btnBuscarDetalleVenta);
            tabMisVentas.Controls.Add(btnEliminarDetalleVenta);
            tabMisVentas.Controls.Add(label9);
            tabMisVentas.Controls.Add(dgvDetalleVenta);
            tabMisVentas.Cursor = Cursors.Hand;
            tabMisVentas.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabMisVentas.Location = new Point(4, 24);
            tabMisVentas.Margin = new Padding(4);
            tabMisVentas.Name = "tabMisVentas";
            tabMisVentas.Padding = new Padding(4);
            tabMisVentas.Size = new Size(1363, 622);
            tabMisVentas.TabIndex = 1;
            tabMisVentas.Text = "Mis Ventas";
            tabMisVentas.UseVisualStyleBackColor = true;
            // 
            // txtEliminarDetalleVenta
            // 
            txtEliminarDetalleVenta.Location = new Point(755, 520);
            txtEliminarDetalleVenta.Name = "txtEliminarDetalleVenta";
            txtEliminarDetalleVenta.Size = new Size(134, 27);
            txtEliminarDetalleVenta.TabIndex = 92;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Wheat;
            label7.Location = new Point(670, 525);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 91;
            label7.Text = "Eliminar";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Wheat;
            label8.Location = new Point(338, 525);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(56, 20);
            label8.TabIndex = 90;
            label8.Text = "Buscar";
            // 
            // txtBuscarDetalleVenta
            // 
            txtBuscarDetalleVenta.Location = new Point(404, 523);
            txtBuscarDetalleVenta.Name = "txtBuscarDetalleVenta";
            txtBuscarDetalleVenta.Size = new Size(155, 27);
            txtBuscarDetalleVenta.TabIndex = 89;
            // 
            // btnBuscarDetalleVenta
            // 
            btnBuscarDetalleVenta.BackColor = Color.Gold;
            btnBuscarDetalleVenta.Location = new Point(565, 514);
            btnBuscarDetalleVenta.Name = "btnBuscarDetalleVenta";
            btnBuscarDetalleVenta.Size = new Size(84, 36);
            btnBuscarDetalleVenta.TabIndex = 88;
            btnBuscarDetalleVenta.Text = "Buscar";
            btnBuscarDetalleVenta.UseVisualStyleBackColor = false;
            // 
            // btnEliminarDetalleVenta
            // 
            btnEliminarDetalleVenta.BackColor = Color.Gold;
            btnEliminarDetalleVenta.Location = new Point(902, 514);
            btnEliminarDetalleVenta.Name = "btnEliminarDetalleVenta";
            btnEliminarDetalleVenta.Size = new Size(84, 36);
            btnEliminarDetalleVenta.TabIndex = 87;
            btnEliminarDetalleVenta.Text = "Eliminar";
            btnEliminarDetalleVenta.UseVisualStyleBackColor = false;
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
            dgvDetalleVenta.Location = new Point(170, 75);
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.Size = new Size(994, 408);
            dgvDetalleVenta.TabIndex = 85;
            // 
            // tabDeudores
            // 
            tabDeudores.BackgroundImage = (Image)resources.GetObject("tabDeudores.BackgroundImage");
            tabDeudores.BackgroundImageLayout = ImageLayout.Stretch;
            tabDeudores.BorderStyle = BorderStyle.Fixed3D;
            tabDeudores.Controls.Add(txtEliminarDeudor);
            tabDeudores.Controls.Add(lblEliminarProducto);
            tabDeudores.Controls.Add(label4);
            tabDeudores.Controls.Add(txtBuscarDeudor);
            tabDeudores.Controls.Add(btnBuscarDeudor);
            tabDeudores.Controls.Add(btnEliminarDeudor);
            tabDeudores.Controls.Add(label1);
            tabDeudores.Controls.Add(dgvDeudor);
            tabDeudores.Controls.Add(btnModificarDeudor);
            tabDeudores.Controls.Add(btnPagarDeudor);
            tabDeudores.Controls.Add(btnCancelarDeudor);
            tabDeudores.Cursor = Cursors.Hand;
            tabDeudores.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            tabDeudores.Location = new Point(4, 24);
            tabDeudores.Name = "tabDeudores";
            tabDeudores.Padding = new Padding(3);
            tabDeudores.Size = new Size(1363, 622);
            tabDeudores.TabIndex = 2;
            tabDeudores.Text = "Deudores";
            tabDeudores.UseVisualStyleBackColor = true;
            // 
            // txtEliminarDeudor
            // 
            txtEliminarDeudor.Location = new Point(816, 521);
            txtEliminarDeudor.Name = "txtEliminarDeudor";
            txtEliminarDeudor.Size = new Size(134, 27);
            txtEliminarDeudor.TabIndex = 92;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(738, 524);
            lblEliminarProducto.Margin = new Padding(4, 0, 4, 0);
            lblEliminarProducto.Name = "lblEliminarProducto";
            lblEliminarProducto.Size = new Size(66, 20);
            lblEliminarProducto.TabIndex = 91;
            lblEliminarProducto.Text = "Eliminar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(408, 526);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 20);
            label4.TabIndex = 90;
            label4.Text = "Buscar";
            // 
            // txtBuscarDeudor
            // 
            txtBuscarDeudor.Location = new Point(472, 522);
            txtBuscarDeudor.Name = "txtBuscarDeudor";
            txtBuscarDeudor.Size = new Size(155, 27);
            txtBuscarDeudor.TabIndex = 89;
            // 
            // btnBuscarDeudor
            // 
            btnBuscarDeudor.BackColor = Color.Gold;
            btnBuscarDeudor.Location = new Point(633, 513);
            btnBuscarDeudor.Name = "btnBuscarDeudor";
            btnBuscarDeudor.Size = new Size(84, 36);
            btnBuscarDeudor.TabIndex = 88;
            btnBuscarDeudor.Text = "Buscar";
            btnBuscarDeudor.UseVisualStyleBackColor = false;
            // 
            // btnEliminarDeudor
            // 
            btnEliminarDeudor.BackColor = Color.Gold;
            btnEliminarDeudor.Location = new Point(963, 515);
            btnEliminarDeudor.Name = "btnEliminarDeudor";
            btnEliminarDeudor.Size = new Size(84, 36);
            btnEliminarDeudor.TabIndex = 87;
            btnEliminarDeudor.Text = "Eliminar";
            btnEliminarDeudor.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(651, 30);
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
            dgvDeudor.Location = new Point(329, 72);
            dgvDeudor.Name = "dgvDeudor";
            dgvDeudor.Size = new Size(799, 408);
            dgvDeudor.TabIndex = 85;
            // 
            // btnModificarDeudor
            // 
            btnModificarDeudor.BackColor = Color.Gold;
            btnModificarDeudor.Location = new Point(131, 269);
            btnModificarDeudor.Name = "btnModificarDeudor";
            btnModificarDeudor.Size = new Size(91, 32);
            btnModificarDeudor.TabIndex = 20;
            btnModificarDeudor.Text = "Modificar";
            btnModificarDeudor.UseVisualStyleBackColor = false;
            // 
            // btnPagarDeudor
            // 
            btnPagarDeudor.BackColor = Color.Gold;
            btnPagarDeudor.Location = new Point(37, 269);
            btnPagarDeudor.Name = "btnPagarDeudor";
            btnPagarDeudor.Size = new Size(75, 31);
            btnPagarDeudor.TabIndex = 1;
            btnPagarDeudor.Text = "PAGAR";
            btnPagarDeudor.UseVisualStyleBackColor = false;
            // 
            // btnCancelarDeudor
            // 
            btnCancelarDeudor.AccessibleRole = AccessibleRole.Sound;
            btnCancelarDeudor.BackColor = Color.Gold;
            btnCancelarDeudor.Location = new Point(86, 318);
            btnCancelarDeudor.Name = "btnCancelarDeudor";
            btnCancelarDeudor.Size = new Size(84, 31);
            btnCancelarDeudor.TabIndex = 0;
            btnCancelarDeudor.Text = "Cancelar";
            btnCancelarDeudor.UseVisualStyleBackColor = false;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1463, 671);
            Controls.Add(tabControl1);
            Name = "FormInicio";
            Text = "Form3";
            Load += FormInicio_Load;
            tabControl1.ResumeLayout(false);
            tabInicio.ResumeLayout(false);
            tabInicio.PerformLayout();
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
        private Button btnModificarDeudor;
        private Button btnPagarDeudor;
        private Button btnCancelarDeudor;
        private TabPage tabInicio;
        private Button btnEliminarProductos;
        private Button btnRegistrarProducto;
        private Label label2;
        private Button btnRegistrarVenta;
        private PictureBox pictureBox1;
        private TextBox txtEliminarDeudor;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarDeudor;
        private Button btnBuscarDeudor;
        private Button btnEliminarDeudor;
        private Label label1;
        private DataGridView dgvDeudor;
        private TextBox txtEliminarStockProductos;
        private Label label3;
        private Label label5;
        private TextBox txtBuscarStockProductos;
        private Button btnBuscarProductos;
        private Label label6;
        private DataGridView dgvStockProductos;
        private TextBox txtEliminarDetalleVenta;
        private Label label7;
        private Label label8;
        private TextBox txtBuscarDetalleVenta;
        private Button btnBuscarDetalleVenta;
        private Button btnEliminarDetalleVenta;
        private Label label9;
        private DataGridView dgvDetalleVenta;
        private Label label12;
        private Label VENTA;
        private Label label11;
    }
}