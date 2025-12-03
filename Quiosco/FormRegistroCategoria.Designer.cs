namespace Quiosco
{
    partial class FormRegistroCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroCategoria));
            txtNombreCategoria = new TextBox();
            lblNombreProducto = new Label();
            txtEliminarCategoria = new TextBox();
            lblEliminarProducto = new Label();
            label4 = new Label();
            txtBuscarCategoria = new TextBox();
            btnBuscarCategoria = new Button();
            btnEliminarCategoria = new Button();
            btnCancelarCategoria = new Button();
            btnModificarCategoria = new Button();
            btnCargaCategoria = new Button();
            label2 = new Label();
            label1 = new Label();
            dgvCategoria = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCategoria).BeginInit();
            SuspendLayout();
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(256, 276);
            txtNombreCategoria.Margin = new Padding(4);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(185, 23);
            txtNombreCategoria.TabIndex = 100;
            txtNombreCategoria.KeyPress += txtNombreCategoria_KeyPress;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.BackColor = Color.Wheat;
            lblNombreProducto.ForeColor = SystemColors.ActiveCaptionText;
            lblNombreProducto.Location = new Point(111, 279);
            lblNombreProducto.Margin = new Padding(4, 0, 4, 0);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(133, 15);
            lblNombreProducto.TabIndex = 98;
            lblNombreProducto.Text = "Nombre de la Categoria";
            // 
            // txtEliminarCategoria
            // 
            txtEliminarCategoria.Location = new Point(1132, 573);
            txtEliminarCategoria.Name = "txtEliminarCategoria";
            txtEliminarCategoria.Size = new Size(134, 23);
            txtEliminarCategoria.TabIndex = 95;
            // 
            // lblEliminarProducto
            // 
            lblEliminarProducto.AutoSize = true;
            lblEliminarProducto.BackColor = Color.Wheat;
            lblEliminarProducto.Location = new Point(1070, 576);
            lblEliminarProducto.Margin = new Padding(4, 0, 4, 0);
            lblEliminarProducto.Name = "lblEliminarProducto";
            lblEliminarProducto.Size = new Size(50, 15);
            lblEliminarProducto.TabIndex = 94;
            lblEliminarProducto.Text = "Eliminar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Wheat;
            label4.Location = new Point(740, 578);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 93;
            label4.Text = "Buscar";
            // 
            // txtBuscarCategoria
            // 
            txtBuscarCategoria.Location = new Point(804, 574);
            txtBuscarCategoria.Name = "txtBuscarCategoria";
            txtBuscarCategoria.Size = new Size(155, 23);
            txtBuscarCategoria.TabIndex = 92;
            // 
            // btnBuscarCategoria
            // 
            btnBuscarCategoria.BackColor = Color.Gold;
            btnBuscarCategoria.Location = new Point(965, 565);
            btnBuscarCategoria.Name = "btnBuscarCategoria";
            btnBuscarCategoria.Size = new Size(84, 36);
            btnBuscarCategoria.TabIndex = 91;
            btnBuscarCategoria.Text = "Buscar";
            btnBuscarCategoria.UseVisualStyleBackColor = false;
            btnBuscarCategoria.Click += btnBuscarCategoria_Click_1;
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.BackColor = Color.Gold;
            btnEliminarCategoria.Location = new Point(1279, 567);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(84, 36);
            btnEliminarCategoria.TabIndex = 90;
            btnEliminarCategoria.Text = "Eliminar";
            btnEliminarCategoria.UseVisualStyleBackColor = false;
            btnEliminarCategoria.Click += btnEliminarCategoria_Click_1;
            // 
            // btnCancelarCategoria
            // 
            btnCancelarCategoria.BackColor = Color.Gold;
            btnCancelarCategoria.Location = new Point(207, 520);
            btnCancelarCategoria.Name = "btnCancelarCategoria";
            btnCancelarCategoria.Size = new Size(84, 36);
            btnCancelarCategoria.TabIndex = 88;
            btnCancelarCategoria.Text = "Cancelar";
            btnCancelarCategoria.UseVisualStyleBackColor = false;
            btnCancelarCategoria.Click += btnCancelarCategoria_Click_1;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.BackColor = Color.Gold;
            btnModificarCategoria.Location = new Point(295, 422);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(84, 39);
            btnModificarCategoria.TabIndex = 87;
            btnModificarCategoria.Text = "Modificar";
            btnModificarCategoria.UseVisualStyleBackColor = false;
            btnModificarCategoria.Click += btnModificarCategoria_Click_1;
            // 
            // btnCargaCategoria
            // 
            btnCargaCategoria.BackColor = Color.Gold;
            btnCargaCategoria.Location = new Point(129, 425);
            btnCargaCategoria.Name = "btnCargaCategoria";
            btnCargaCategoria.Size = new Size(84, 36);
            btnCargaCategoria.TabIndex = 89;
            btnCargaCategoria.Text = "Cargar";
            btnCargaCategoria.UseVisualStyleBackColor = false;
            btnCargaCategoria.Click += btnCargarCategoria_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.LightSeaGreen;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(519, 50);
            label2.Name = "label2";
            label2.Size = new Size(228, 22);
            label2.TabIndex = 86;
            label2.Text = "REGISTRAR CATEGORIA";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Font = new Font("Gill Sans Ultra Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(990, 89);
            label1.Name = "label1";
            label1.Size = new Size(116, 20);
            label1.TabIndex = 85;
            label1.Text = "CATEGORIA";
            // 
            // dgvCategoria
            // 
            dgvCategoria.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvCategoria.BorderStyle = BorderStyle.Fixed3D;
            dgvCategoria.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategoria.Cursor = Cursors.Hand;
            dgvCategoria.Location = new Point(552, 128);
            dgvCategoria.Name = "dgvCategoria";
            dgvCategoria.Size = new Size(837, 408);
            dgvCategoria.TabIndex = 84;
            dgvCategoria.CellClick += dgvCategoria_CellClick;
            dgvCategoria.CellContentClick += dgvCategoria_CellContentClick;
            // 
            // FormRegistroCategoria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1486, 662);
            Controls.Add(txtNombreCategoria);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtEliminarCategoria);
            Controls.Add(lblEliminarProducto);
            Controls.Add(label4);
            Controls.Add(txtBuscarCategoria);
            Controls.Add(btnBuscarCategoria);
            Controls.Add(btnEliminarCategoria);
            Controls.Add(btnCancelarCategoria);
            Controls.Add(btnModificarCategoria);
            Controls.Add(btnCargaCategoria);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvCategoria);
            Name = "FormRegistroCategoria";
            Text = "Registrar Categoria";
            ((System.ComponentModel.ISupportInitialize)dgvCategoria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    
        private TextBox txtNombreCategoria;
        private Label lblNombreProducto;
        private TextBox txtEliminarCategoria;
        private Label lblEliminarProducto;
        private Label label4;
        private TextBox txtBuscarCategoria;
        private Button btnBuscarCategoria;
        private Button btnEliminarCategoria;
        private Button btnCancelarCategoria;
        private Button btnModificarCategoria;
        private Button btnCargaCategoria;
        private Label label2;
        private Label label1;
        private DataGridView dgvCategoria;
    }
}