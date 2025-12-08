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
            dgvResumen = new DataGridView();
            lblTotal = new Label();
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
            // dgvResumen
            // 
            dgvResumen.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvResumen.BorderStyle = BorderStyle.Fixed3D;
            dgvResumen.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvResumen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResumen.Cursor = Cursors.Hand;
            dgvResumen.Location = new Point(111, 149);
            dgvResumen.Name = "dgvResumen";
            dgvResumen.Size = new Size(1299, 408);
            dgvResumen.TabIndex = 69;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Wheat;
            lblTotal.Location = new Point(1208, 496);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(39, 15);
            lblTotal.TabIndex = 85;
            lblTotal.Text = "TOTAL";
            // 
            // FormCarritoCompra1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1474, 660);
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
        private DataGridView dgvResumen;
        private Label lblTotal;
    }
}