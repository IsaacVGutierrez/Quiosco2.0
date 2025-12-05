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
            txtEliminarVenta = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarVenta = new TextBox();
            btnBuscarVenta = new Button();
            btnEliminarVenta = new Button();
            btnCancelarVenta = new Button();
            btnModificarVenta = new Button();
            btnCargarVenta = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.BackColor = Color.Wheat;
            lblNombreProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblNombreProducto.Location = new Point(104, 170);
            lblNombreProducto.Margin = new Padding(4, 0, 4, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(122, 15);
            lblNombreProducto.TabIndex = 87;
            lblNombreProducto.Text = "Nombre del Producto";
            // 
            // txtEliminarVenta
            // 
            txtEliminarVenta.Location = new Point(1142, 565);
            txtEliminarVenta.Name = "txtEliminarVenta";
            txtEliminarVenta.Size = new Size(134, 23);
            txtEliminarVenta.TabIndex = 84;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1080, 568);
            lblEliminarProducto.Margin = new Padding(4, 0, 4, 0);
            lblEliminarProducto.Name = "lblEliminarProducto";
            lblEliminarProducto.Size = new Size(50, 15);
            lblEliminarProducto.TabIndex = 83;
            lblEliminarProducto.Text = "Eliminar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(750, 570);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 82;
            label4.Text = "Buscar";
            // 
            // txtBuscarVenta
            // 
            txtBuscarVenta.Location = new Point(814, 566);
            txtBuscarVenta.Name = "txtBuscarVenta";
            txtBuscarVenta.Size = new Size(155, 23);
            txtBuscarVenta.TabIndex = 81;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackColor = Color.Gold;
            btnBuscarVenta.Location = new Point(975, 557);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(84, 36);
            btnBuscarVenta.TabIndex = 80;
            btnBuscarVenta.Text = "Buscar";
            btnBuscarVenta.UseVisualStyleBackColor = false;
            btnBuscarVenta.Click += btnBuscarVenta_Click;
            // 
            // btnEliminarVenta
            // 
            btnEliminarVenta.BackColor = Color.Gold;
            btnEliminarVenta.Location = new Point(1289, 559);
            btnEliminarVenta.Name = "btnEliminarVenta";
            btnEliminarVenta.Size = new Size(84, 36);
            btnEliminarVenta.TabIndex = 79;
            btnEliminarVenta.Text = "Eliminar";
            btnEliminarVenta.UseVisualStyleBackColor = false;
            btnEliminarVenta.Click += btnEliminarVenta_Click;
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.BackColor = Color.Gold;
            btnCancelarVenta.Location = new Point(213, 535);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(84, 36);
            btnCancelarVenta.TabIndex = 77;
            btnCancelarVenta.Text = "Cancelar";
            btnCancelarVenta.UseVisualStyleBackColor = false;
            btnCancelarVenta.Click += btnCancelarVenta_Click_1;
            // 
            // btnModificarVenta
            // 
            btnModificarVenta.BackColor = Color.Gold;
            btnModificarVenta.Location = new Point(272, 475);
            btnModificarVenta.Name = "btnModificarVenta";
            btnModificarVenta.Size = new Size(84, 39);
            btnModificarVenta.TabIndex = 76;
            btnModificarVenta.Text = "Modificar";
            btnModificarVenta.UseVisualStyleBackColor = false;
            btnModificarVenta.Click += BtnModificarVenta_Click;
            // 
            // btnCargarVenta
            // 
            btnCargarVenta.BackColor = Color.Gold;
            btnCargarVenta.Location = new Point(162, 476);
            btnCargarVenta.Name = "btnCargarVenta";
            btnCargarVenta.Size = new Size(84, 36);
            btnCargarVenta.TabIndex = 78;
            btnCargarVenta.Text = "Cargar";
            btnCargarVenta.UseVisualStyleBackColor = false;
            btnCargarVenta.Click += btnCargarVenta_Click;
            // 
            // txtCantidadVenta
            // 
            txtCantidadVenta.Location = new Point(249, 232);
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
            lblCantidadProducto.Location = new Point(134, 238);
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
            label2.Location = new Point(529, 42);
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
            label1.Location = new Point(1000, 81);
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
            dgvVenta.Location = new Point(707, 120);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.Size = new Size(718, 408);
            dgvVenta.TabIndex = 69;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Wheat;
            label5.Location = new Point(115, 352);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(87, 15);
            label5.TabIndex = 99;
            label5.Text = "Medio de Pago";
            // 
            // cmbProductoVenta
            // 
            cmbProductoVenta.FormattingEnabled = true;
            cmbProductoVenta.Location = new Point(249, 167);
            cmbProductoVenta.Name = "cmbProductoVenta";
            cmbProductoVenta.Size = new Size(176, 23);
            cmbProductoVenta.TabIndex = 101;
            cmbProductoVenta.SelectedIndexChanged += cmbProductoVenta_SelectedIndexChanged;
            // 
            // txtSubtotalVenta
            // 
            txtSubtotalVenta.Location = new Point(246, 290);
            txtSubtotalVenta.Margin = new Padding(4);
            txtSubtotalVenta.Name = "txtSubtotalVenta";
            txtSubtotalVenta.Size = new Size(173, 23);
            txtSubtotalVenta.TabIndex = 103;
            txtSubtotalVenta.KeyPress += txtSubtotalVenta_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Wheat;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(131, 296);
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
            label6.Location = new Point(115, 398);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 104;
            label6.Text = "Cliente";
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.BackColor = Color.Gold;
            btnAgregarCliente.Location = new Point(438, 390);
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
            cmbClienteVenta.Location = new Point(246, 395);
            cmbClienteVenta.Name = "cmbClienteVenta";
            cmbClienteVenta.Size = new Size(173, 23);
            cmbClienteVenta.TabIndex = 107;
            cmbClienteVenta.SelectedIndexChanged += cmbClienteVenta_SelectedIndexChanged;
            // 
            // cmbMedioPagoVenta
            // 
            cmbMedioPagoVenta.FormattingEnabled = true;
            cmbMedioPagoVenta.Location = new Point(246, 344);
            cmbMedioPagoVenta.Name = "cmbMedioPagoVenta";
            cmbMedioPagoVenta.Size = new Size(176, 23);
            cmbMedioPagoVenta.TabIndex = 108;
            // 
            // FormRegistroVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1453, 652);
            Controls.Add(cmbMedioPagoVenta);
            Controls.Add(cmbClienteVenta);
            Controls.Add(btnAgregarCliente);
            Controls.Add(label6);
            Controls.Add(txtSubtotalVenta);
            Controls.Add(label3);
            Controls.Add(cmbProductoVenta);
            Controls.Add(label5);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtEliminarVenta);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarVenta);
            Controls.Add(btnBuscarVenta);
            Controls.Add(btnEliminarVenta);
            Controls.Add(btnCancelarVenta);
            Controls.Add(btnModificarVenta);
            Controls.Add(btnCargarVenta);
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
        private TextBox txtEliminarVenta;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarVenta;
        private Button btnBuscarVenta;
        private Button btnEliminarVenta;
        private Button btnCancelarVenta;
        private Button btnModificarVenta;
        private Button btnCargarVenta;
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
    }
}