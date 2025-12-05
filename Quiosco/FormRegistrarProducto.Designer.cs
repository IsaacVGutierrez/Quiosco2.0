namespace Quiosco
{
    partial class FormRegistrarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarProducto));
            label1 = new Label();
            dgvProducto = new DataGridView();
            label2 = new Label();
            txtEliminarProducto = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarProducto = new TextBox();
            btnBuscarProducto = new Button();
            btnEliminarProducto = new Button();
            btnCancelarProducto = new Button();
            btnModificarProducto = new Button();
            btnCargarProducto = new Button();
            txtCantidadProducto = new TextBox();
            txtPrecioCompraProducto = new TextBox();
            lblCantidadProducto = new Label();
            lblPrecioVentaProducto = new Label();
            lblDistribuidorProducto = new Label();
            txtNombreProducto = new TextBox();
            lblNombreProducto = new Label();
            lblMarcaProducto = new Label();
            txtMarcaProducto = new TextBox();
            txtPrecioTotalProducto = new TextBox();
            lblPrecioCompraProducto = new Label();
            cmbDistribuidorProducto = new ComboBox();
            label3 = new Label();
            btnAgregarCategoria = new Button();
            cmbCategoriaProducto = new ComboBox();
            btnAgregarProveedor = new Button();
            lblFechaCaja = new Label();
            dtFechaCompraProducto = new DateTimePicker();
            txtPrecioVentaProducto = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1057, 67);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 8;
            label1.Text = "PRODUCTOS";
            label1.Click += label1_Click;
            // 
            // dgvProducto
            // 
            dgvProducto.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvProducto.BorderStyle = BorderStyle.Fixed3D;
            dgvProducto.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Cursor = Cursors.Hand;
            dgvProducto.Location = new Point(619, 100);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.Size = new Size(909, 408);
            dgvProducto.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(586, 28);
            label2.Name = "label2";
            label2.Size = new Size(231, 22);
            label2.TabIndex = 9;
            label2.Text = "REGISTRAR PRODUCTOS";
            label2.Click += label2_Click;
            // 
            // txtEliminarProducto
            // 
            txtEliminarProducto.Location = new Point(1199, 551);
            txtEliminarProducto.Name = "txtEliminarProducto";
            txtEliminarProducto.Size = new Size(134, 23);
            txtEliminarProducto.TabIndex = 53;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1137, 554);
            lblEliminarProducto.Margin = new Padding(4, 0, 4, 0);
            lblEliminarProducto.Name = "lblEliminarProducto";
            lblEliminarProducto.Size = new Size(50, 15);
            lblEliminarProducto.TabIndex = 52;
            lblEliminarProducto.Text = "Eliminar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(807, 556);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 51;
            label4.Text = "Buscar";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(871, 552);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(155, 23);
            txtBuscarProducto.TabIndex = 50;
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.BackColor = Color.Gold;
            btnBuscarProducto.Location = new Point(1032, 543);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(84, 36);
            btnBuscarProducto.TabIndex = 49;
            btnBuscarProducto.Text = "Buscar";
            btnBuscarProducto.UseVisualStyleBackColor = false;
            btnBuscarProducto.Click += btnBuscarProducto_Click;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.BackColor = Color.Gold;
            btnEliminarProducto.Location = new Point(1346, 545);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(84, 36);
            btnEliminarProducto.TabIndex = 48;
            btnEliminarProducto.Text = "Eliminar";
            btnEliminarProducto.UseVisualStyleBackColor = false;
            btnEliminarProducto.Click += btnEliminarProducto_Click_1;
            // 
            // btnCancelarProducto
            // 
            btnCancelarProducto.BackColor = Color.Gold;
            btnCancelarProducto.Location = new Point(255, 555);
            btnCancelarProducto.Name = "btnCancelarProducto";
            btnCancelarProducto.Size = new Size(84, 36);
            btnCancelarProducto.TabIndex = 46;
            btnCancelarProducto.Text = "Cancelar";
            btnCancelarProducto.UseVisualStyleBackColor = false;
            btnCancelarProducto.Click += btnCancelarProducto_Click_1;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.Gold;
            btnModificarProducto.Location = new Point(314, 495);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(84, 39);
            btnModificarProducto.TabIndex = 45;
            btnModificarProducto.Text = "Modificar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += BtnModificarProducto_Click;
            // 
            // btnCargarProducto
            // 
            btnCargarProducto.BackColor = Color.Gold;
            btnCargarProducto.Location = new Point(204, 496);
            btnCargarProducto.Name = "btnCargarProducto";
            btnCargarProducto.Size = new Size(84, 36);
            btnCargarProducto.TabIndex = 47;
            btnCargarProducto.Text = "Cargar";
            btnCargarProducto.UseVisualStyleBackColor = false;
            btnCargarProducto.Click += btnCargarProducto_Click;
            // 
            // txtCantidadProducto
            // 
            txtCantidadProducto.Location = new Point(250, 276);
            txtCantidadProducto.Margin = new Padding(4);
            txtCantidadProducto.Name = "txtCantidadProducto";
            txtCantidadProducto.Size = new Size(173, 23);
            txtCantidadProducto.TabIndex = 44;
            txtCantidadProducto.TextChanged += txtCantidadProducto_TextChanged;
            txtCantidadProducto.KeyPress += txtCantidadProducto_KeyPress;
            // 
            // txtPrecioCompraProducto
            // 
            txtPrecioCompraProducto.Location = new Point(255, 368);
            txtPrecioCompraProducto.Margin = new Padding(4);
            txtPrecioCompraProducto.Name = "txtPrecioCompraProducto";
            txtPrecioCompraProducto.Size = new Size(176, 23);
            txtPrecioCompraProducto.TabIndex = 43;
            txtPrecioCompraProducto.TextChanged += txtPrecioCompraProducto_TextChanged;
            txtPrecioCompraProducto.KeyPress += txtPrecioCompraProducto_KeyPress;
            txtPrecioCompraProducto.Leave += txtPrecioCompraProducto_Leave;
            // 
            // lblCantidadProducto
            // 
            lblCantidadProducto.AutoSize = true;
            lblCantidadProducto.BackColor = Color.Wheat;
            lblCantidadProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblCantidadProducto.Location = new Point(135, 282);
            lblCantidadProducto.Margin = new Padding(4, 0, 4, 0);
            lblCantidadProducto.Name = "lblCantidadProducto";
            lblCantidadProducto.Size = new Size(55, 15);
            lblCantidadProducto.TabIndex = 41;
            lblCantidadProducto.Text = "Cantidad";
            // 
            // lblPrecioVentaProducto
            // 
            lblPrecioVentaProducto.AutoSize = true;
            lblPrecioVentaProducto.BackColor = Color.Wheat;
            lblPrecioVentaProducto.Location = new Point(132, 371);
            lblPrecioVentaProducto.Margin = new Padding(4, 0, 4, 0);
            lblPrecioVentaProducto.Name = "lblPrecioVentaProducto";
            lblPrecioVentaProducto.Size = new Size(102, 15);
            lblPrecioVentaProducto.TabIndex = 40;
            lblPrecioVentaProducto.Text = "Precio de Compra";
            // 
            // lblDistribuidorProducto
            // 
            lblDistribuidorProducto.AutoSize = true;
            lblDistribuidorProducto.BackColor = Color.Wheat;
            lblDistribuidorProducto.Location = new Point(131, 331);
            lblDistribuidorProducto.Margin = new Padding(4, 0, 4, 0);
            lblDistribuidorProducto.Name = "lblDistribuidorProducto";
            lblDistribuidorProducto.Size = new Size(69, 15);
            lblDistribuidorProducto.TabIndex = 39;
            lblDistribuidorProducto.Text = "Distribuidor";
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(252, 97);
            txtNombreProducto.Margin = new Padding(4);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(173, 23);
            txtNombreProducto.TabIndex = 57;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.BackColor = Color.Wheat;
            lblNombreProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblNombreProducto.Location = new Point(107, 100);
            lblNombreProducto.Margin = new Padding(4, 0, 4, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 56;
            lblNombreProducto.Text = "Nombre del Producto";
            // 
            // lblMarcaProducto
            // 
            lblMarcaProducto.AutoSize = true;
            lblMarcaProducto.BackColor = Color.Wheat;
            lblMarcaProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblMarcaProducto.Location = new Point(142, 146);
            lblMarcaProducto.Margin = new Padding(4, 0, 4, 0);
            lblMarcaProducto.Name = "lblMarcaProducto";
            lblMarcaProducto.Size = new Size(40, 15);
            lblMarcaProducto.TabIndex = 56;
            lblMarcaProducto.Text = "Marca";
            // 
            // txtMarcaProducto
            // 
            txtMarcaProducto.Location = new Point(252, 143);
            txtMarcaProducto.Margin = new Padding(4);
            txtMarcaProducto.Name = "txtMarcaProducto";
            txtMarcaProducto.Size = new Size(173, 23);
            txtMarcaProducto.TabIndex = 57;
            // 
            // txtPrecioTotalProducto
            // 
            txtPrecioTotalProducto.Location = new Point(249, 185);
            txtPrecioTotalProducto.Margin = new Padding(4);
            txtPrecioTotalProducto.Name = "txtPrecioTotalProducto";
            txtPrecioTotalProducto.Size = new Size(173, 23);
            txtPrecioTotalProducto.TabIndex = 59;
            txtPrecioTotalProducto.KeyPress += txtPrecioTotalProducto_KeyPress;
            // 
            // lblPrecioCompraProducto
            // 
            lblPrecioCompraProducto.AutoSize = true;
            lblPrecioCompraProducto.BackColor = Color.Wheat;
            lblPrecioCompraProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblPrecioCompraProducto.Location = new Point(113, 189);
            lblPrecioCompraProducto.Margin = new Padding(4, 0, 4, 0);
            lblPrecioCompraProducto.Name = "lblPrecioCompraProducto";
            lblPrecioCompraProducto.Size = new Size(68, 15);
            lblPrecioCompraProducto.TabIndex = 58;
            lblPrecioCompraProducto.Text = "Precio Total";
            lblPrecioCompraProducto.Click += label7_Click;
            // 
            // cmbDistribuidorProducto
            // 
            cmbDistribuidorProducto.FormattingEnabled = true;
            cmbDistribuidorProducto.Location = new Point(249, 327);
            cmbDistribuidorProducto.Name = "cmbDistribuidorProducto";
            cmbDistribuidorProducto.Size = new Size(176, 23);
            cmbDistribuidorProducto.TabIndex = 97;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Wheat;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(134, 238);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 98;
            label3.Text = "Categoria";
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.BackColor = Color.Gold;
            btnAgregarCategoria.Location = new Point(444, 230);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(149, 28);
            btnAgregarCategoria.TabIndex = 100;
            btnAgregarCategoria.Text = "Agregar Nueva Categoria";
            btnAgregarCategoria.UseVisualStyleBackColor = false;
            btnAgregarCategoria.Click += btnAgregarCategoria_Click;
            // 
            // cmbCategoriaProducto
            // 
            cmbCategoriaProducto.FormattingEnabled = true;
            cmbCategoriaProducto.Location = new Point(249, 234);
            cmbCategoriaProducto.Name = "cmbCategoriaProducto";
            cmbCategoriaProducto.Size = new Size(176, 23);
            cmbCategoriaProducto.TabIndex = 102;
            // 
            // btnAgregarProveedor
            // 
            btnAgregarProveedor.BackColor = Color.Gold;
            btnAgregarProveedor.Location = new Point(444, 325);
            btnAgregarProveedor.Name = "btnAgregarProveedor";
            btnAgregarProveedor.Size = new Size(161, 28);
            btnAgregarProveedor.TabIndex = 103;
            btnAgregarProveedor.Text = "Agregar Nuevo Proveedor";
            btnAgregarProveedor.UseVisualStyleBackColor = false;
            btnAgregarProveedor.Click += btnAgregarProveedor_Click;
            // 
            // lblFechaCaja
            // 
            lblFechaCaja.AutoSize = true;
            lblFechaCaja.BackColor = Color.Wheat;
            lblFechaCaja.ForeColor = SystemColors.ActiveCaptionText;
            lblFechaCaja.Location = new Point(74, 451);
            lblFechaCaja.Name = "lblFechaCaja";
            lblFechaCaja.Size = new Size(152, 15);
            lblFechaCaja.TabIndex = 105;
            lblFechaCaja.Text = "Fecha Compra de Producto";
            // 
            // dtFechaCompraProducto
            // 
            dtFechaCompraProducto.Location = new Point(249, 445);
            dtFechaCompraProducto.Name = "dtFechaCompraProducto";
            dtFechaCompraProducto.Size = new Size(300, 23);
            dtFechaCompraProducto.TabIndex = 104;
            dtFechaCompraProducto.ValueChanged += dtFechaCompraProducto_ValueChanged;
            // 
            // txtPrecioVentaProducto
            // 
            txtPrecioVentaProducto.Location = new Point(251, 404);
            txtPrecioVentaProducto.Margin = new Padding(4);
            txtPrecioVentaProducto.Name = "txtPrecioVentaProducto";
            txtPrecioVentaProducto.Size = new Size(176, 23);
            txtPrecioVentaProducto.TabIndex = 107;
            txtPrecioVentaProducto.TextChanged += txtPrecioVentaProducto_TextChanged;
            txtPrecioVentaProducto.KeyPress += txtPrecioVentaProducto_KeyPress;
            txtPrecioVentaProducto.Leave += txtPrecioVentaProducto_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Wheat;
            label5.Location = new Point(128, 407);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(88, 15);
            label5.TabIndex = 106;
            label5.Text = "Precio de Venta";
            // 
            // FormRegistrarProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1536, 653);
            Controls.Add(txtPrecioVentaProducto);
            Controls.Add(label5);
            Controls.Add(lblFechaCaja);
            Controls.Add(dtFechaCompraProducto);
            Controls.Add(btnAgregarProveedor);
            Controls.Add(cmbCategoriaProducto);
            Controls.Add(btnAgregarCategoria);
            Controls.Add(label3);
            Controls.Add(cmbDistribuidorProducto);
            Controls.Add(txtPrecioTotalProducto);
            Controls.Add(lblPrecioCompraProducto);
            Controls.Add(txtMarcaProducto);
            Controls.Add(txtNombreProducto);
            Controls.Add(lblMarcaProducto);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtEliminarProducto);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarProducto);
            Controls.Add(btnBuscarProducto);
            Controls.Add(btnEliminarProducto);
            Controls.Add(btnCancelarProducto);
            Controls.Add(btnModificarProducto);
            Controls.Add(btnCargarProducto);
            Controls.Add(txtCantidadProducto);
            Controls.Add(txtPrecioCompraProducto);
            Controls.Add(lblCantidadProducto);
            Controls.Add(lblPrecioVentaProducto);
            Controls.Add(lblDistribuidorProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvProducto);
            Name = "FormRegistrarProducto";
            Text = "Registro de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvProducto;
        private Label label2;
        private TextBox txtEliminarProducto;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarProducto;
        private Button btnBuscarProducto;
        private Button btnEliminarProducto;
        private Button btnCancelarProducto;
        private Button btnModificarProducto;
        private Button btnCargarProducto;
        private TextBox txtCantidadProducto;
        private TextBox txtPrecioCompraProducto;
        private Label lblCantidadProducto;
        private Label lblPrecioVentaProducto;
        private Label lblDistribuidorProducto;
        private TextBox txtNombreProducto;
        private Label lblNombreProducto;
        private Label lblMarcaProducto;
        private TextBox txtMarcaProducto;
        private TextBox txtPrecioTotalProducto;
        private Label lblPrecioCompraProducto;
        private ComboBox cmbDistribuidorProducto;
        private Label label3;
        private Button btnAgregarCategoria;
        private ComboBox cmbCategoriaProducto;
        private Button btnAgregarProveedor;
        private Label lblFechaCaja;
        private DateTimePicker dtFechaCompraProducto;
        private TextBox txtPrecioVentaProducto;
        private Label label5;
    }
}