namespace Quiosco
{
    partial class FormRegistroProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroProveedores));
            txtTelefonoProveedor = new TextBox();
            txtNombreProveedor = new TextBox();
            lblMarcaProducto = new Label();
            lblNombreProducto = new Label();
            txtDireccionProveedor = new TextBox();
            lblPrecio = new Label();
            txtEliminarProveedor = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarProveedor = new TextBox();
            btnBuscarProveedor = new Button();
            btnEliminarProveedor = new Button();
            btnCancelarProveedor = new Button();
            btnModificarProveedor = new Button();
            btnCargaProveedor = new Button();
            txtHorarioProveedor = new TextBox();
            txtDiasAtencionProveedor = new TextBox();
            lblCantidadProducto = new Label();
            lblDistribuidorProducto = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvProveedor = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProveedor).BeginInit();
            SuspendLayout();
            // 
            // txtTelefonoProveedor
            // 
            txtTelefonoProveedor.Location = new Point(276, 216);
            txtTelefonoProveedor.Margin = new Padding(4);
            txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            txtTelefonoProveedor.Size = new Size(195, 23);
            txtTelefonoProveedor.TabIndex = 83;
            txtTelefonoProveedor.KeyPress += txtTelefonoProveedor_KeyPress;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(276, 170);
            txtNombreProveedor.Margin = new Padding(4);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(195, 23);
            txtNombreProveedor.TabIndex = 82;
            // 
            // lblMarcaProducto
            // 
            lblMarcaProducto.AutoSize = true;
            lblMarcaProducto.BackColor = Color.Wheat;
            lblMarcaProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblMarcaProducto.Location = new Point(166, 219);
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
            lblNombreProducto.Location = new Point(131, 173);
            lblNombreProducto.Margin = new Padding(4, 0, 4, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(127, 15);
            lblNombreProducto.TabIndex = 80;
            lblNombreProducto.Text = "Nombre del Proveedor";
            // 
            // txtDireccionProveedor
            // 
            txtDireccionProveedor.Location = new Point(276, 266);
            txtDireccionProveedor.Margin = new Padding(4);
            txtDireccionProveedor.Name = "txtDireccionProveedor";
            txtDireccionProveedor.Size = new Size(195, 23);
            txtDireccionProveedor.TabIndex = 79;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.BackColor = Color.Wheat;
            lblPrecio.ForeColor = SystemColors.ActiveCaptionText;
            lblPrecio.Location = new Point(166, 272);
            lblPrecio.Margin = new Padding(4, 0, 4, 0);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(57, 15);
            lblPrecio.TabIndex = 78;
            lblPrecio.Text = "Direccion";
            // 
            // txtEliminarProveedor
            // 
            txtEliminarProveedor.Location = new Point(1152, 570);
            txtEliminarProveedor.Name = "txtEliminarProveedor";
            txtEliminarProveedor.Size = new Size(134, 23);
            txtEliminarProveedor.TabIndex = 77;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1090, 573);
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
            label4.Location = new Point(760, 575);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 75;
            label4.Text = "Buscar";
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.Location = new Point(824, 571);
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.Size = new Size(155, 23);
            txtBuscarProveedor.TabIndex = 74;
            // 
            // btnBuscarProveedor
            // 
            btnBuscarProveedor.BackColor = Color.Gold;
            btnBuscarProveedor.Location = new Point(985, 562);
            btnBuscarProveedor.Name = "btnBuscarProveedor";
            btnBuscarProveedor.Size = new Size(84, 36);
            btnBuscarProveedor.TabIndex = 73;
            btnBuscarProveedor.Text = "Buscar";
            btnBuscarProveedor.UseVisualStyleBackColor = false;
            btnBuscarProveedor.Click += btnBuscarProveedor_Click;
            // 
            // btnEliminarProveedor
            // 
            btnEliminarProveedor.BackColor = Color.Gold;
            btnEliminarProveedor.Location = new Point(1299, 564);
            btnEliminarProveedor.Name = "btnEliminarProveedor";
            btnEliminarProveedor.Size = new Size(84, 36);
            btnEliminarProveedor.TabIndex = 72;
            btnEliminarProveedor.Text = "Eliminar";
            btnEliminarProveedor.UseVisualStyleBackColor = false;
            btnEliminarProveedor.Click += btnEliminarProveedor_Click;
            // 
            // btnCancelarProveedor
            // 
            btnCancelarProveedor.BackColor = Color.Gold;
            btnCancelarProveedor.Location = new Point(273, 545);
            btnCancelarProveedor.Name = "btnCancelarProveedor";
            btnCancelarProveedor.Size = new Size(84, 36);
            btnCancelarProveedor.TabIndex = 70;
            btnCancelarProveedor.Text = "Cancelar";
            btnCancelarProveedor.UseVisualStyleBackColor = false;
            btnCancelarProveedor.Click += btnCancelarProveedor_Click;
            // 
            // btnModificarProveedor
            // 
            btnModificarProveedor.BackColor = Color.Gold;
            btnModificarProveedor.Location = new Point(332, 485);
            btnModificarProveedor.Name = "btnModificarProveedor";
            btnModificarProveedor.Size = new Size(84, 39);
            btnModificarProveedor.TabIndex = 69;
            btnModificarProveedor.Text = "Modificar";
            btnModificarProveedor.UseVisualStyleBackColor = false;
            btnModificarProveedor.Click += BtnModificarProveedor_Click;
            // 
            // btnCargaProveedor
            // 
            btnCargaProveedor.BackColor = Color.Gold;
            btnCargaProveedor.Location = new Point(222, 486);
            btnCargaProveedor.Name = "btnCargaProveedor";
            btnCargaProveedor.Size = new Size(84, 36);
            btnCargaProveedor.TabIndex = 71;
            btnCargaProveedor.Text = "Cargar";
            btnCargaProveedor.UseVisualStyleBackColor = false;
            btnCargaProveedor.Click += btnCargarProveedor_Click;
            // 
            // txtHorarioProveedor
            // 
            txtHorarioProveedor.Location = new Point(276, 318);
            txtHorarioProveedor.Margin = new Padding(4);
            txtHorarioProveedor.Name = "txtHorarioProveedor";
            txtHorarioProveedor.Size = new Size(195, 23);
            txtHorarioProveedor.TabIndex = 68;
            // 
            // txtDiasAtencionProveedor
            // 
            txtDiasAtencionProveedor.Location = new Point(276, 373);
            txtDiasAtencionProveedor.Margin = new Padding(4);
            txtDiasAtencionProveedor.Name = "txtDiasAtencionProveedor";
            txtDiasAtencionProveedor.Size = new Size(195, 23);
            txtDiasAtencionProveedor.TabIndex = 66;
            txtDiasAtencionProveedor.KeyPress += txtDiasAtencionProveedor_KeyPress;
            // 
            // lblCantidadProducto
            // 
            lblCantidadProducto.AutoSize = true;
            lblCantidadProducto.BackColor = Color.Wheat;
            lblCantidadProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblCantidadProducto.Location = new Point(169, 324);
            lblCantidadProducto.Margin = new Padding(4, 0, 4, 0);
            lblCantidadProducto.Name = "lblCantidadProducto";
            lblCantidadProducto.Size = new Size(47, 15);
            lblCantidadProducto.TabIndex = 65;
            lblCantidadProducto.Text = "Horario";
            // 
            // lblDistribuidorProducto
            // 
            lblDistribuidorProducto.AutoSize = true;
            lblDistribuidorProducto.BackColor = Color.Wheat;
            lblDistribuidorProducto.Location = new Point(157, 377);
            lblDistribuidorProducto.Margin = new Padding(4, 0, 4, 0);
            lblDistribuidorProducto.Name = "lblDistribuidorProducto";
            lblDistribuidorProducto.Size = new Size(96, 15);
            lblDistribuidorProducto.TabIndex = 63;
            lblDistribuidorProducto.Text = "Dias de Atencion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(539, 47);
            label2.Name = "label2";
            label2.Size = new Size(256, 22);
            label2.TabIndex = 62;
            label2.Text = "REGISTRAR PROVEEDORES";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1010, 86);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 61;
            label1.Text = "PROVEEDORES";
            // 
            // dgvProveedor
            // 
            dgvProveedor.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvProveedor.BorderStyle = BorderStyle.Fixed3D;
            dgvProveedor.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedor.Cursor = Cursors.Hand;
            dgvProveedor.Location = new Point(735, 125);
            dgvProveedor.Name = "dgvProveedor";
            dgvProveedor.Size = new Size(674, 408);
            dgvProveedor.TabIndex = 60;
            dgvProveedor.CellClick += dgvProveedor_CellClick;
            dgvProveedor.CellContentClick += dgvProveedor_CellContentClick;
            // 
            // FormRegistroProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1472, 657);
            Controls.Add(txtTelefonoProveedor);
            Controls.Add(txtNombreProveedor);
            Controls.Add(lblMarcaProducto);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtDireccionProveedor);
            Controls.Add(lblPrecio);
            Controls.Add(txtEliminarProveedor);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarProveedor);
            Controls.Add(btnBuscarProveedor);
            Controls.Add(btnEliminarProveedor);
            Controls.Add(btnCancelarProveedor);
            Controls.Add(btnModificarProveedor);
            Controls.Add(btnCargaProveedor);
            Controls.Add(txtHorarioProveedor);
            Controls.Add(txtDiasAtencionProveedor);
            Controls.Add(lblCantidadProducto);
            Controls.Add(lblDistribuidorProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvProveedor);
            Name = "FormRegistroProveedores";
            Text = "Registrar Proveedores";
            Load += FormRegistroProveedores_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
    
        private TextBox txtTelefonoProveedor;
        private TextBox txtNombreProveedor;
        private Label lblMarcaProducto;
        private Label lblNombreProducto;
        private TextBox txtDireccionProveedor;
        private Label lblPrecio;
        private TextBox txtEliminarProveedor;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarProveedor;
        private Button btnBuscarProveedor;
        private Button btnEliminarProveedor;
        private Button btnCancelarProveedor;
        private Button btnModificarProveedor;
        private Button btnCargaProveedor;
        private TextBox txtHorarioProveedor;
        private TextBox txtDiasAtencionProveedor;
        private Label lblCantidadProducto;
        private Label lblDistribuidorProducto;
        private Label label2;
        private Label label1;
        private DataGridView dgvProveedor;
    }
}