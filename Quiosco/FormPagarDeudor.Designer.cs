namespace Quiosco
{
    partial class FormPagarDeudor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPagarDeudor));
            labelInfo = new Label();
            btnAceptar = new Button();
            btnCancelar = new Button();
            txtMonto = new TextBox();
            SuspendLayout();
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(257, 93);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(45, 20);
            labelInfo.TabIndex = 0;
            labelInfo.Text = "INFO";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Gold;
            btnAceptar.ForeColor = SystemColors.ActiveCaptionText;
            btnAceptar.Location = new Point(277, 321);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(142, 34);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "ACEPTAR";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Gold;
            btnCancelar.ForeColor = SystemColors.ActiveCaptionText;
            btnCancelar.Location = new Point(448, 321);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(142, 34);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(346, 204);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(168, 27);
            txtMonto.TabIndex = 4;
            txtMonto.KeyPress += txtMonto_KeyPress;
            // 
            // FormPagarDeudor
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(865, 477);
            Controls.Add(txtMonto);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(labelInfo);
            Cursor = Cursors.Hand;
            Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "FormPagarDeudor";
            Text = "Pagar Deuda";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInfo;
        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox txtMonto;
    }
}