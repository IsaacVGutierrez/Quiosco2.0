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
            txtEliminarVenta = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarVenta = new TextBox();
            btnBuscarVenta = new Button();
            btnEliminarVenta = new Button();
            btnCancelarVenta = new Button();
            btnModificarProducto = new Button();
            btnConfirmarVenta = new Button();
            label2 = new Label();
            label1 = new Label();
            dgvVenta = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // txtEliminarVenta
            // 
            txtEliminarVenta.Location = new Point(1153, 569);
            txtEliminarVenta.Name = "txtEliminarVenta";
            txtEliminarVenta.Size = new Size(134, 23);
            txtEliminarVenta.TabIndex = 84;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1091, 572);
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
            label4.Location = new Point(111, 118);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 82;
            label4.Text = "Buscar";
            // 
            // txtBuscarVenta
            // 
            txtBuscarVenta.Location = new Point(176, 115);
            txtBuscarVenta.Name = "txtBuscarVenta";
            txtBuscarVenta.Size = new Size(265, 23);
            txtBuscarVenta.TabIndex = 81;
            txtBuscarVenta.TextChanged += txtBuscarVenta_TextChanged;
            // 
            // btnBuscarVenta
            // 
            btnBuscarVenta.BackColor = Color.Gold;
            btnBuscarVenta.Location = new Point(464, 107);
            btnBuscarVenta.Name = "btnBuscarVenta";
            btnBuscarVenta.Size = new Size(84, 36);
            btnBuscarVenta.TabIndex = 80;
            btnBuscarVenta.Text = "Buscar";
            btnBuscarVenta.UseVisualStyleBackColor = false;
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
            // btnCancelarVenta
            // 
            btnCancelarVenta.BackColor = Color.Gold;
            btnCancelarVenta.Location = new Point(209, 579);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(84, 36);
            btnCancelarVenta.TabIndex = 77;
            btnCancelarVenta.Text = "Cancelar";
            btnCancelarVenta.UseVisualStyleBackColor = false;
            // 
            // btnModificarProducto
            // 
            btnModificarProducto.BackColor = Color.Gold;
            btnModificarProducto.Location = new Point(382, 569);
            btnModificarProducto.Name = "btnModificarProducto";
            btnModificarProducto.Size = new Size(84, 39);
            btnModificarProducto.TabIndex = 76;
            btnModificarProducto.Text = "Modificar";
            btnModificarProducto.UseVisualStyleBackColor = false;
            btnModificarProducto.Click += btnModificarProducto_Click;
            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.BackColor = Color.Gold;
            btnConfirmarVenta.Location = new Point(57, 579);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new Size(121, 36);
            btnConfirmarVenta.TabIndex = 78;
            btnConfirmarVenta.Text = "CONFIRMAR VENTA";
            btnConfirmarVenta.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(625, 26);
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
            // dgvVenta
            // 
            dgvVenta.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvVenta.BorderStyle = BorderStyle.Fixed3D;
            dgvVenta.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenta.Cursor = Cursors.Hand;
            dgvVenta.Location = new Point(111, 149);
            dgvVenta.Name = "dgvVenta";
            dgvVenta.Size = new Size(1299, 408);
            dgvVenta.TabIndex = 69;
            // 
            // FormCarritoCompra1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1474, 660);
            Controls.Add(txtEliminarVenta);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarVenta);
            Controls.Add(btnBuscarVenta);
            Controls.Add(btnEliminarVenta);
            Controls.Add(btnCancelarVenta);
            Controls.Add(btnModificarProducto);
            Controls.Add(btnConfirmarVenta);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvVenta);
            Name = "FormCarritoCompra1";
            Text = "Carrito";
            Load += FormCarritoCompra1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtEliminarVenta;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarVenta;
        private Button btnBuscarVenta;
        private Button btnEliminarVenta;
        private Button btnCancelarVenta;
        private Button btnModificarProducto;
        private Button btnConfirmarVenta;
        private Label label2;
        private Label label1;
        private DataGridView dgvVenta;
    }
}