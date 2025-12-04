namespace Quiosco
{
    partial class FormRegistroCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroCliente));
            txtTelefonoCliente = new TextBox();
            txtNombreCliente = new TextBox();
            lblMarcaProducto = new Label();
            lblNombreProducto = new Label();
            txtAdeudaCliente = new TextBox();
            lblPrecio = new Label();
            txtEliminarCliente = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarCliente = new TextBox();
            btnBuscarCliente = new Button();
            btnEliminarCliente = new Button();
            btnCancelarCliente = new Button();
            btnModificarCliente = new Button();
            btnCargarCliente = new Button();
            label2 = new Label();
            label1 = new Label();
            dgvCliente = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCliente).BeginInit();
            SuspendLayout();
            // 
            // txtTelefonoCliente
            // 
            txtTelefonoCliente.Location = new Point(268, 273);
            txtTelefonoCliente.Margin = new Padding(4);
            txtTelefonoCliente.Name = "txtTelefonoCliente";
            txtTelefonoCliente.Size = new Size(173, 23);
            txtTelefonoCliente.TabIndex = 83;
            txtTelefonoCliente.KeyPress += txtTelefonoCliente_KeyPress;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(267, 194);
            txtNombreCliente.Margin = new Padding(4);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(173, 23);
            txtNombreCliente.TabIndex = 82;
            txtNombreCliente.KeyPress += txtNombreCliente_KeyPress;
            // 
            // lblMarcaProducto
            // 
            lblMarcaProducto.AutoSize = true;
            lblMarcaProducto.BackColor = Color.Wheat;
            lblMarcaProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblMarcaProducto.Location = new Point(158, 276);
            lblMarcaProducto.Margin = new Padding(4, 0, 4, 0);
            lblMarcaProducto.Name = "lblMarcaProducto";
            lblMarcaProducto.Size = new Size(52, 15);
            lblMarcaProducto.TabIndex = 81;
            lblMarcaProducto.Text = "Telefono";
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.BackColor = Color.Wheat;
            lblNombreProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblNombreProducto.Location = new Point(122, 197);
            lblNombreProducto.Margin = new Padding(4, 0, 4, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(110, 15);
            lblNombreProducto.TabIndex = 80;
            lblNombreProducto.Text = "Nombre del Cliente";
            // 
            // txtAdeudaCliente
            // 
            txtAdeudaCliente.Location = new Point(268, 354);
            txtAdeudaCliente.Margin = new Padding(4);
            txtAdeudaCliente.Name = "txtAdeudaCliente";
            txtAdeudaCliente.Size = new Size(173, 23);
            txtAdeudaCliente.TabIndex = 79;
            txtAdeudaCliente.KeyPress += txtAdeudaCliente_KeyPress;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.BackColor = Color.Wheat;
            lblPrecio.ForeColor = SystemColors.ActiveCaptionText;
            lblPrecio.Location = new Point(158, 360);
            lblPrecio.Margin = new Padding(4, 0, 4, 0);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(48, 15);
            lblPrecio.TabIndex = 78;
            lblPrecio.Text = "Adeuda";
            // 
            // txtEliminarCliente
            // 
            txtEliminarCliente.Location = new Point(1157, 572);
            txtEliminarCliente.Name = "txtEliminarCliente";
            txtEliminarCliente.Size = new Size(134, 23);
            txtEliminarCliente.TabIndex = 77;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1095, 575);
            lblEliminarProducto.Margin = new Padding(4, 0, 4, 0);
            lblEliminarProducto.Name = "lblEliminarProducto";
            lblEliminarProducto.Size = new Size(50, 15);
            lblEliminarProducto.TabIndex = 76;
            lblEliminarProducto.Text = "Eliminar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(765, 577);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 75;
            label4.Text = "Buscar";
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(829, 573);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(155, 23);
            txtBuscarCliente.TabIndex = 74;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.BackColor = Color.Gold;
            btnBuscarCliente.Location = new Point(990, 564);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(84, 36);
            btnBuscarCliente.TabIndex = 73;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = false;
            btnBuscarCliente.Click += btnBuscarCliente_Click;
            // 
            // btnEliminarCliente
            // 
            btnEliminarCliente.BackColor = Color.Gold;
            btnEliminarCliente.Location = new Point(1304, 566);
            btnEliminarCliente.Name = "btnEliminarCliente";
            btnEliminarCliente.Size = new Size(84, 36);
            btnEliminarCliente.TabIndex = 72;
            btnEliminarCliente.Text = "Eliminar";
            btnEliminarCliente.UseVisualStyleBackColor = false;
            btnEliminarCliente.Click += btnEliminarCliente_Click;
            // 
            // btnCancelarCliente
            // 
            btnCancelarCliente.BackColor = Color.Gold;
            btnCancelarCliente.Location = new Point(213, 576);
            btnCancelarCliente.Name = "btnCancelarCliente";
            btnCancelarCliente.Size = new Size(84, 36);
            btnCancelarCliente.TabIndex = 70;
            btnCancelarCliente.Text = "Cancelar";
            btnCancelarCliente.UseVisualStyleBackColor = false;
            btnCancelarCliente.Click += btnCancelarCliente_Click_1;
            // 
            // btnModificarCliente
            // 
            btnModificarCliente.BackColor = Color.Gold;
            btnModificarCliente.Location = new Point(272, 516);
            btnModificarCliente.Name = "btnModificarCliente";
            btnModificarCliente.Size = new Size(84, 39);
            btnModificarCliente.TabIndex = 69;
            btnModificarCliente.Text = "Modificar";
            btnModificarCliente.UseVisualStyleBackColor = false;
            btnModificarCliente.Click += btnModificarCliente_Click;
            // 
            // btnCargarCliente
            // 
            btnCargarCliente.BackColor = Color.Gold;
            btnCargarCliente.Location = new Point(162, 517);
            btnCargarCliente.Name = "btnCargarCliente";
            btnCargarCliente.Size = new Size(84, 36);
            btnCargarCliente.TabIndex = 71;
            btnCargarCliente.Text = "Cargar";
            btnCargarCliente.UseVisualStyleBackColor = false;
            btnCargarCliente.Click += btnCargarCliente_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(562, 27);
            label2.Name = "label2";
            label2.Size = new Size(194, 22);
            label2.TabIndex = 62;
            label2.Text = "REGISTRAR CLIENTE";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1010, 86);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 61;
            label1.Text = "CLIENTES";
            // 
            // dgvCliente
            // 
            dgvCliente.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvCliente.BorderStyle = BorderStyle.Fixed3D;
            dgvCliente.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCliente.Cursor = Cursors.Hand;
            dgvCliente.Location = new Point(740, 127);
            dgvCliente.Name = "dgvCliente";
            dgvCliente.Size = new Size(674, 408);
            dgvCliente.TabIndex = 60;
            dgvCliente.CellClick += dgvCliente_CellClick;
            dgvCliente.CellContentClick += dgvCliente_CellContentClick;
            // 
            // FormRegistroCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1482, 661);
            Controls.Add(txtTelefonoCliente);
            Controls.Add(txtNombreCliente);
            Controls.Add(lblMarcaProducto);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtAdeudaCliente);
            Controls.Add(lblPrecio);
            Controls.Add(txtEliminarCliente);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarCliente);
            Controls.Add(btnBuscarCliente);
            Controls.Add(btnEliminarCliente);
            Controls.Add(btnCancelarCliente);
            Controls.Add(btnModificarCliente);
            Controls.Add(btnCargarCliente);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvCliente);
            Name = "FormRegistroCliente";
            Text = "Registrar Cliente";
            ((System.ComponentModel.ISupportInitialize)dgvCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTelefonoCliente;
        private TextBox txtNombreCliente;
        private Label lblMarcaProducto;
        private Label lblNombreProducto;
        private TextBox txtAdeudaCliente;
        private Label lblPrecio;
        private TextBox txtEliminarCliente;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarCliente;
        private Button btnBuscarCliente;
        private Button btnEliminarCliente;
        private Button btnCancelarCliente;
        private Button btnModificarCliente;
        private Button btnCargarCliente;
        private Label label2;
        private Label label1;
        private DataGridView dgvCliente;
    }
}