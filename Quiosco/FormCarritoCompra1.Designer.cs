namespace Quiosco
{
    partial class FormCarritoCompra1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCarritoCompra1));
            btnEliminarVenta = new Button();
            btnCancelar = new Button();
            btnAceptar = new Button();
            label2 = new Label();
            label1 = new Label();
            lblTotal = new Label();
            label3 = new Label();
            cmbMedioPago = new ComboBox();
            txtMontoPago = new TextBox();
            dgvPagos = new DataGridView();
            dgvResumen = new DataGridView();
            lblDeuda = new Label();
            lblTotalPagado = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            btnQuitarPago = new Button();
            btnAgregarPago = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPagos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).BeginInit();
            SuspendLayout();
            // 
            // btnEliminarVenta
            // 
            btnEliminarVenta.BackColor = Color.Gold;
            btnEliminarVenta.Location = new Point(1300, 563);
            btnEliminarVenta.Name = "btnEliminarVenta";
            btnEliminarVenta.Size = new Size(84, 36);
            btnEliminarVenta.TabIndex = 79;
            btnEliminarVenta.Text = "Eliminar";
            btnEliminarVenta.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Gold;
            btnCancelar.Location = new Point(111, 582);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 36);
            btnCancelar.TabIndex = 77;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Gold;
            btnAceptar.Location = new Point(632, 579);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(121, 36);
            btnAceptar.TabIndex = 78;
            btnAceptar.Text = "CONFIRMAR VENTA";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(632, 24);
            label2.Name = "label2";
            label2.Size = new Size(189, 22);
            label2.TabIndex = 71;
            label2.Text = "CARRITO DE VENTA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(664, 113);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 70;
            label1.Text = "PRODUCTOS";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Wheat;
            lblTotal.Location = new Point(953, 538);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(39, 15);
            lblTotal.TabIndex = 85;
            lblTotal.Text = "TOTAL";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Wheat;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(906, 538);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 103;
            label3.Text = "TOTAL";
            // 
            // cmbMedioPago
            // 
            cmbMedioPago.FormattingEnabled = true;
            cmbMedioPago.Location = new Point(288, 132);
            cmbMedioPago.Name = "cmbMedioPago";
            cmbMedioPago.Size = new Size(121, 23);
            cmbMedioPago.TabIndex = 104;
            // 
            // txtMontoPago
            // 
            txtMontoPago.Location = new Point(316, 215);
            txtMontoPago.Name = "txtMontoPago";
            txtMontoPago.Size = new Size(100, 23);
            txtMontoPago.TabIndex = 105;
            // 
            // dgvPagos
            // 
            dgvPagos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagos.Location = new Point(1096, 88);
            dgvPagos.Name = "dgvPagos";
            dgvPagos.RowTemplate.Height = 25;
            dgvPagos.Size = new Size(240, 150);
            dgvPagos.TabIndex = 106;
            // 
            // dgvResumen
            // 
            dgvResumen.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvResumen.BorderStyle = BorderStyle.Fixed3D;
            dgvResumen.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumen.Cursor = Cursors.Hand;
            dgvResumen.Location = new Point(498, 145);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.Size = new Size(387, 408);
            dgvResumen.TabIndex = 69;
            // 
            // lblDeuda
            // 
            lblDeuda.AutoSize = true;
            lblDeuda.Location = new Point(325, 375);
            lblDeuda.Name = "lblDeuda";
            lblDeuda.Size = new Size(41, 15);
            lblDeuda.TabIndex = 107;
            lblDeuda.Text = "Deuda";
            // 
            // lblTotalPagado
            // 
            lblTotalPagado.AutoSize = true;
            lblTotalPagado.Location = new Point(316, 326);
            lblTotalPagado.Name = "lblTotalPagado";
            lblTotalPagado.Size = new Size(75, 15);
            lblTotalPagado.TabIndex = 108;
            lblTotalPagado.Text = "Total Pagado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(191, 132);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 109;
            label4.Text = "Medio Pago";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(208, 218);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 110;
            label5.Text = "Monto Pago";
            // 
            // button1
            // 
            button1.Location = new Point(313, 91);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 111;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnQuitarPago
            // 
            btnQuitarPago.Location = new Point(337, 49);
            btnQuitarPago.Name = "btnQuitarPago";
            btnQuitarPago.Size = new Size(75, 23);
            btnQuitarPago.TabIndex = 112;
            btnQuitarPago.Text = "QuitarPago";
            btnQuitarPago.UseVisualStyleBackColor = true;
            btnQuitarPago.Click += btnQuitarPago_Click;
            // 
            // btnAgregarPago
            // 
            btnAgregarPago.Location = new Point(358, 19);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(113, 23);
            btnAgregarPago.TabIndex = 113;
            btnAgregarPago.Text = "AgregarPago";
            btnAgregarPago.UseVisualStyleBackColor = true;
            btnAgregarPago.Click += btnAgregarPago_Click;
            // 
            // FormCarritoCompra1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1474, 660);
            Controls.Add(btnAgregarPago);
            Controls.Add(btnQuitarPago);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblTotalPagado);
            Controls.Add(lblDeuda);
            Controls.Add(dgvPagos);
            Controls.Add(txtMontoPago);
            Controls.Add(cmbMedioPago);
            Controls.Add(label3);
            Controls.Add(lblTotal);
            Controls.Add(btnEliminarVenta);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvResumen);
            Name = "FormCarritoCompra1";
            Text = "Carrito";
            Load += FormCarritoCompra1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPagos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvResumen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnEliminarVenta;
        private Button btnCancelar;
        private Button btnAceptar;
        private Label label2;
        private Label label1;
        private Label lblTotal;
        private Label label3;
        private ComboBox cmbMedioPago;
        private TextBox txtMontoPago;
        private DataGridView dgvPagos;
        private DataGridView dgvResumen;
        private Label lblDeuda;
        private Label lblTotalPagado;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button btnQuitarPago;
        private Button btnAgregarPago;
    }
}