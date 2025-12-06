namespace Quiosco
{
    partial class FormRegistroMetodoDePago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroMetodoDePago));
            label2 = new Label();
            txtNombreMetodoDePago = new TextBox();
            lblNombreMetodoDePago = new Label();
            txtEliminarMetodoDePago = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarMetodoDePago = new TextBox();
            btnBuscarMetodoDePago = new Button();
            btnEliminarMetodoDePago = new Button();
            btnCancelarMetodoDePago = new Button();
            btnModificarMetodoDePago = new Button();
            btnCargaMetodoDePago = new Button();
            label1 = new Label();
            dgvMetodoDePago = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMetodoDePago).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(465, 20);
            label2.Name = "label2";
            label2.Size = new Size(284, 22);
            label2.TabIndex = 87;
            label2.Text = "REGISTRAR METODO DE PAGO";
            // 
            // txtNombreMetodoDePago
            // 
            txtNombreMetodoDePago.Location = new Point(298, 309);
            txtNombreMetodoDePago.Margin = new Padding(4);
            txtNombreMetodoDePago.Name = "txtNombreMetodoDePago";
            txtNombreMetodoDePago.Size = new Size(185, 23);
            txtNombreMetodoDePago.TabIndex = 113;
            txtNombreMetodoDePago.KeyPress += txtNombreMetodoDePago_KeyPress;
            // 
            // lblNombreMetodoDePago
            // 
            lblNombreMetodoDePago.AutoSize = true;
            lblNombreMetodoDePago.BackColor = Color.Wheat;
            lblNombreMetodoDePago.ForeColor = SystemColors.ActiveCaptionText;
            lblNombreMetodoDePago.Location = new Point(105, 312);
            lblNombreMetodoDePago.Margin = new Padding(4, 0, 4, 0);
            lblNombreMetodoDePago.Name = "lblNombreMetodoDePago";
            lblNombreMetodoDePago.Size = new Size(162, 15);
            lblNombreMetodoDePago.TabIndex = 112;
            lblNombreMetodoDePago.Text = "Nombre del Metodo De Pago";
            // 
            // txtEliminarMetodoDePago
            // 
            txtEliminarMetodoDePago.Location = new Point(1127, 571);
            txtEliminarMetodoDePago.Name = "txtEliminarMetodoDePago";
            txtEliminarMetodoDePago.Size = new Size(134, 23);
            txtEliminarMetodoDePago.TabIndex = 111;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1065, 574);
            lblEliminarProducto.Margin = new Padding(4, 0, 4, 0);
            lblEliminarProducto.Name = "lblEliminarProducto";
            lblEliminarProducto.Size = new Size(50, 15);
            lblEliminarProducto.TabIndex = 110;
            lblEliminarProducto.Text = "Eliminar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(738, 576);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 109;
            label4.Text = "Buscar";
            // 
            // txtBuscarMetodoDePago
            // 
            txtBuscarMetodoDePago.Location = new Point(799, 572);
            txtBuscarMetodoDePago.Name = "txtBuscarMetodoDePago";
            txtBuscarMetodoDePago.Size = new Size(155, 23);
            txtBuscarMetodoDePago.TabIndex = 108;
            // 
            // btnBuscarMetodoDePago
            // 
            btnBuscarMetodoDePago.BackColor = Color.Gold;
            btnBuscarMetodoDePago.Location = new Point(960, 563);
            btnBuscarMetodoDePago.Name = "btnBuscarMetodoDePago";
            btnBuscarMetodoDePago.Size = new Size(84, 36);
            btnBuscarMetodoDePago.TabIndex = 107;
            btnBuscarMetodoDePago.Text = "Buscar";
            btnBuscarMetodoDePago.UseVisualStyleBackColor = false;
            btnBuscarMetodoDePago.Click += btnBuscarMetodoDePago_Click_1;
            // 
            // btnEliminarMetodoDePago
            // 
            btnEliminarMetodoDePago.BackColor = Color.Gold;
            btnEliminarMetodoDePago.Location = new Point(1274, 565);
            btnEliminarMetodoDePago.Name = "btnEliminarMetodoDePago";
            btnEliminarMetodoDePago.Size = new Size(84, 36);
            btnEliminarMetodoDePago.TabIndex = 106;
            btnEliminarMetodoDePago.Text = "Eliminar";
            btnEliminarMetodoDePago.UseVisualStyleBackColor = false;
            btnEliminarMetodoDePago.Click += btnEliminarMetodoDePago_Click_1;
            // 
            // btnCancelarMetodoDePago
            // 
            btnCancelarMetodoDePago.BackColor = Color.Gold;
            btnCancelarMetodoDePago.Location = new Point(249, 553);
            btnCancelarMetodoDePago.Name = "btnCancelarMetodoDePago";
            btnCancelarMetodoDePago.Size = new Size(84, 36);
            btnCancelarMetodoDePago.TabIndex = 104;
            btnCancelarMetodoDePago.Text = "Cancelar";
            btnCancelarMetodoDePago.UseVisualStyleBackColor = false;
            btnCancelarMetodoDePago.Click += btnCancelarMetodoDePago_Click_1;
            // 
            // btnModificarMetodoDePago
            // 
            btnModificarMetodoDePago.BackColor = Color.Gold;
            btnModificarMetodoDePago.Location = new Point(337, 455);
            btnModificarMetodoDePago.Name = "btnModificarMetodoDePago";
            btnModificarMetodoDePago.Size = new Size(84, 39);
            btnModificarMetodoDePago.TabIndex = 103;
            btnModificarMetodoDePago.Text = "Modificar";
            btnModificarMetodoDePago.UseVisualStyleBackColor = false;
            btnModificarMetodoDePago.Click += btnModificarMetodoDePago_Click_1;
            // 
            // btnCargaMetodoDePago
            // 
            btnCargaMetodoDePago.BackColor = Color.Gold;
            btnCargaMetodoDePago.Location = new Point(171, 458);
            btnCargaMetodoDePago.Name = "btnCargaMetodoDePago";
            btnCargaMetodoDePago.Size = new Size(84, 36);
            btnCargaMetodoDePago.TabIndex = 105;
            btnCargaMetodoDePago.Text = "Cargar";
            btnCargaMetodoDePago.UseVisualStyleBackColor = false;
            btnCargaMetodoDePago.Click += btnCargarMetodoDePago_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(943, 83);
            label1.Name = "label1";
            label1.Size = new Size(172, 20);
            label1.TabIndex = 102;
            label1.Text = "METODO DE PAGO";
            // 
            // dgvMetodoDePago
            // 
            dgvMetodoDePago.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvMetodoDePago.BorderStyle = BorderStyle.Fixed3D;
            dgvMetodoDePago.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvMetodoDePago.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMetodoDePago.Cursor = Cursors.Hand;
            dgvMetodoDePago.Location = new Point(707, 126);
            dgvMetodoDePago.Name = "dgvMetodoDePago";
            dgvMetodoDePago.Size = new Size(677, 408);
            dgvMetodoDePago.TabIndex = 101;
            dgvMetodoDePago.CellClick += dgvMetodoDePago_CellClick;
            dgvMetodoDePago.CellContentClick += dgvMetodoDePago_CellContentClick;
            // 
            // FormRegistroMetodoDePago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1482, 663);
            Controls.Add(txtNombreMetodoDePago);
            Controls.Add(lblNombreMetodoDePago);
            Controls.Add(txtEliminarMetodoDePago);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarMetodoDePago);
            Controls.Add(btnBuscarMetodoDePago);
            Controls.Add(btnEliminarMetodoDePago);
            Controls.Add(btnCancelarMetodoDePago);
            Controls.Add(btnModificarMetodoDePago);
            Controls.Add(btnCargaMetodoDePago);
            Controls.Add(label1);
            Controls.Add(dgvMetodoDePago);
            Controls.Add(label2);
            Cursor = Cursors.Hand;
            Name = "FormRegistroMetodoDePago";
            Text = "Metodo De Pago";
            ((System.ComponentModel.ISupportInitialize)dgvMetodoDePago).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtNombreMetodoDePago;
        private Label lblNombreMetodoDePago;
        private TextBox txtEliminarMetodoDePago;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarMetodoDePago;
        private Button btnBuscarMetodoDePago;
        private Button btnEliminarMetodoDePago;
        private Button btnCancelarMetodoDePago;
        private Button btnModificarMetodoDePago;
        private Button btnCargaMetodoDePago;
        private Label label1;
        private DataGridView dgvMetodoDePago;
    }
}