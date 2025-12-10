using Quiosco.Negocio;
using System;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormEnterCode : Form
    {
        private TextBox txtCodigo;
        private Button btnVerificar;
        private Label lblInfo;

        UsuarioNegocio negocio = new UsuarioNegocio();
        private readonly int usuarioId;

        public FormEnterCode(int userId)
        {
            usuarioId = userId;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Ingresar código";
            this.Width = 360; this.Height = 160;

            txtCodigo = new TextBox { Left = 20, Top = 20, Width = 300 };
            btnVerificar = new Button { Left = 20, Top = 60, Width = 120, Text = "Verificar" };
            lblInfo = new Label { Left = 20, Top = 100, Width = 300 };

            btnVerificar.Click += BtnVerificar_Click;

            this.Controls.Add(txtCodigo);
            this.Controls.Add(btnVerificar);
            this.Controls.Add(lblInfo);
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            var codigo = txtCodigo.Text.Trim();

            if (!negocio.ValidarCodigo(usuarioId, codigo))
            {
                lblInfo.Text = "Código inválido o expirado.";
                return;
            }

            negocio.MarcarCodigoUsado(usuarioId, codigo);

            var f = new FormChangePassword(usuarioId);
            f.ShowDialog();
            this.Close();
        }
    }
}
