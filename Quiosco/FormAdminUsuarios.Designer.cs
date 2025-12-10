namespace Quiosco
{
    partial class FormAdminUsuarios
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
            TxtBuscar = new TextBox();
            SuspendLayout();
            // 
            // TxtBuscar
            // 
            TxtBuscar.Location = new Point(414, 125);
            TxtBuscar.Name = "TxtBuscar";
            TxtBuscar.Size = new Size(100, 23);
            TxtBuscar.TabIndex = 0;
            // 
            // FormAdminUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TxtBuscar);
            Name = "FormAdminUsuarios";
            Text = "FormAdminUsuarios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtBuscar;
    }
}