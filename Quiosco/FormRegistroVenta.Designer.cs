namespace Quiosco
{
    partial class FormRegistroVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroVenta));
            lblNombreProducto = new Label();
            txtCantidadVenta = new TextBox();
            lblCantidadProducto = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvVenta = new DataGridView();
            label5 = new Label();
            cmbProductoVenta = new ComboBox();
            txtSubtotalVenta = new TextBox();
            label3 = new Label();
            label6 = new Label();
            btnAgregarCliente = new Button();
            cmbClienteVenta = new ComboBox();
            cmbMedioPagoVenta = new ComboBox();
            btnAgregarMetodoDePago = new Button();
            btnAgregarAlCarrito = new Button();
            btnQuitarDelCarrito = new Button();
            btnVaciarCarrito = new Button();
            btnConfirmarVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.BackColor = Color.Wheat;
            lblNombreProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblNombreProducto.Location = new Point(103, 210);
            lblNombreProducto.Margin = new Padding(4, 0, 4, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 87;
            lblNombreProducto.Text = "Nombre del Producto";
            // 
            // txtCantidadVenta
            // 
            txtCantidadVenta.Location = new Point(248, 272);
            txtCantidadVenta.Margin = new Padding(4);
            txtCantidadVenta.Name = "txtCantidadVenta";
            txtCantidadVenta.Size = new Size(173, 23);
            txtCantidadVenta.TabIndex = 75;
            txtCantidadVenta.KeyPress += txtCantidadVenta_KeyPress;
            // 
            // lblCantidadProducto
            // 
            lblCantidadProducto.AutoSize = true;
            lblCantidadProducto.BackColor = Color.Wheat;
            lblCantidadProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblCantidadProducto.Location = new Point(133, 278);
            lblCantidadProducto.Margin = new Padding(4, 0, 4, 0);
            lblCantidadProducto.Name = "lblCantidadProducto";
            lblCantidadProducto.Size = new Size(55, 15);
            lblCantidadProducto.TabIndex = 73;
            lblCantidadProducto.Text = "Cantidad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(538, 27);
            label2.Name = "label2";
            label2.Size = new Size(183, 22);
            label2.TabIndex = 71;
            label2.Text = "REGISTRAR VENTA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1001, 44);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 70;
            label1.Text = "VENTAS";
            // 
            // dgvVenta
            // 
            dgvVenta.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvVenta.BorderStyle = BorderStyle.Fixed3D;
            dgvVenta.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Cursor = Cursors.Hand;
            dgvVenta.Location = new Point(674, 120);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.Size = new Size(767, 408);
            dgvVenta.TabIndex = 69;
            dgvVenta.CellClick += dgvVenta_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Wheat;
            label5.Location = new Point(114, 392);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 99;
            label5.Text = "Medio de Pago";
            // 
            // cmbProductoVenta
            // 
            cmbProductoVenta.FormattingEnabled = true;
            cmbProductoVenta.Location = new Point(248, 207);
            cmbProductoVenta.Name = "cmbProductoVenta";
            cmbProductoVenta.Size = new Size(176, 23);
            cmbProductoVenta.TabIndex = 101;
            cmbProductoVenta.SelectedIndexChanged += cmbProductoVenta_SelectedIndexChanged;
            // 
            // txtSubtotalVenta
            // 
            txtSubtotalVenta.Location = new Point(248, 336);
            txtSubtotalVenta.Name = "txtSubtotalVenta";
            txtSubtotalVenta.ReadOnly = true;
            txtSubtotalVenta.Size = new Size(173, 23);
            txtSubtotalVenta.TabIndex = 114;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Wheat;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(130, 336);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 102;
            label3.Text = "Subtotal";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Wheat;
            label6.Location = new Point(117, 163);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 104;
            label6.Text = "Cliente";
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = Color.Gold;
            btnAgregarCliente.Location = new Point(440, 155);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(93, 28);
            btnAgregarCliente.TabIndex = 106;
            btnAgregarCliente.Text = "Nuevo Cliente";
            btnAgregarCliente.UseVisualStyleBackColor = false;
            btnAgregarCliente.Click += btnAgregarCliente_Click;
            // 
            // cmbClienteVenta
            // 
            cmbClienteVenta.FormattingEnabled = true;
            cmbClienteVenta.Location = new Point(248, 160);
            cmbClienteVenta.Name = "cmbClienteVenta";
            cmbClienteVenta.Size = new Size(173, 23);
            cmbClienteVenta.TabIndex = 107;
            cmbClienteVenta.SelectedIndexChanged += cmbClienteVenta_SelectedIndexChanged;
            // 
            // cmbMedioPagoVenta
            // 
            cmbMedioPagoVenta.FormattingEnabled = true;
            cmbMedioPagoVenta.Location = new Point(245, 384);
            cmbMedioPagoVenta.Name = "cmbMedioPagoVenta";
            cmbMedioPagoVenta.Size = new Size(176, 23);
            cmbMedioPagoVenta.TabIndex = 108;
            // 
            // btnAgregarMetodoDePago
            // 
            btnAgregarMetodoDePago.BackColor = Color.Gold;
            btnAgregarMetodoDePago.Location = new Point(437, 384);
            btnAgregarMetodoDePago.Name = "btnAgregarMetodoDePago";
            btnAgregarMetodoDePago.Size = new Size(31, 24);
            btnAgregarMetodoDePago.TabIndex = 109;
            btnAgregarMetodoDePago.Text = "+";
            btnAgregarMetodoDePago.UseVisualStyleBackColor = false;
            btnAgregarMetodoDePago.Click += btnAgregarMetodoDePago_Click;
            // 
            // btnAgregarAlCarrito
            // 
            btnAgregarAlCarrito.BackColor = Color.Gold;
            btnAgregarAlCarrito.Location = new Point(258, 442);
            btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            btnAgregarAlCarrito.Size = new Size(121, 36);
            btnAgregarAlCarrito.TabIndex = 110;
            btnAgregarAlCarrito.Text = "Agregar Al Carrito";
            btnAgregarAlCarrito.UseVisualStyleBackColor = false;
            btnAgregarAlCarrito.Click += btnAgregarAlCarrito_Click;
            // 
            // btnQuitarDelCarrito
            // 
            btnQuitarDelCarrito.BackColor = Color.Gold;
            btnQuitarDelCarrito.Location = new Point(934, 566);
            btnQuitarDelCarrito.Name = "btnQuitarDelCarrito";
            btnQuitarDelCarrito.Size = new Size(112, 39);
            btnQuitarDelCarrito.TabIndex = 111;
            btnQuitarDelCarrito.Text = "Quitar Del Carrito";
            btnQuitarDelCarrito.UseVisualStyleBackColor = false;
            btnQuitarDelCarrito.Click += btnQuitarDelCarrito_Click;
            // 
            // btnVaciarCarrito
            // 
            btnVaciarCarrito.BackColor = Color.Gold;
            btnVaciarCarrito.Location = new Point(1109, 566);
            btnVaciarCarrito.Name = "btnVaciarCarrito";
            btnVaciarCarrito.Size = new Size(121, 39);
            btnVaciarCarrito.TabIndex = 112;
            btnVaciarCarrito.Text = "Vaciar Carrito";
            btnVaciarCarrito.UseVisualStyleBackColor = false;
            btnVaciarCarrito.Click += btnVaciarCarrito_Click;
            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.BackColor = Color.Gold;
            btnConfirmarVenta.Location = new Point(41, 566);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new Size(109, 39);
            btnConfirmarVenta.TabIndex = 113;
            btnConfirmarVenta.Text = "Confirmar Venta";
            btnConfirmarVenta.UseVisualStyleBackColor = false;
            btnConfirmarVenta.Click += btnConfirmarVenta_Click;
            // 
            // FormRegistroVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1453, 652);
            Controls.Add(btnConfirmarVenta);
            Controls.Add(btnVaciarCarrito);
            Controls.Add(btnQuitarDelCarrito);
            Controls.Add(btnAgregarAlCarrito);
            Controls.Add(btnAgregarMetodoDePago);
            Controls.Add(cmbMedioPagoVenta);
            Controls.Add(cmbClienteVenta);
            Controls.Add(btnAgregarCliente);
            Controls.Add(label6);
            Controls.Add(txtSubtotalVenta);
            Controls.Add(label3);
            Controls.Add(cmbProductoVenta);
            Controls.Add(label5);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtCantidadVenta);
            Controls.Add(lblCantidadProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvVenta);
            Name = "FormRegistroVenta";
            Text = "Registro de Ventas";
            Load += FormRegistroVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNombreProducto;
        private TextBox txtCantidadVenta;
        private Label lblCantidadProducto;
        private Label label2;
        private Label label1;
        private DataGridView dgvVenta;
        private Label label5;
        private ComboBox cmbProductoVenta;
        private TextBox txtSubtotalVenta;
        private Label label3;
        private Label label6;
        private Button btnAgregarCliente;
        private ComboBox cmbClienteVenta;
        private ComboBox cmbMedioPagoVenta;
        private Button btnAgregarMetodoDePago;
        private Button btnAgregarAlCarrito;
        private Button btnQuitarDelCarrito;
        private Button btnVaciarCarrito;
        private Button btnConfirmarVenta;
    }
}