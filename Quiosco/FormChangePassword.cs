using Quiosco.Negocio;
using System;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormChangePassword : Form
    {
        private TextBox txtPass;
        private TextBox txtPass2;
        private Button btnCambiar;
        private Label lblInfo;

        UsuarioNegocio negocio = new UsuarioNegocio();
        private readonly int usuarioId;

        public FormChangePassword(int id)
        {
            usuarioId = id;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Cambiar contraseña";
            this.Width = 380; this.Height = 200;

            txtPass = new TextBox { Left = 20, Top = 20, Width = 320, PasswordChar = '*' };
            txtPass2 = new TextBox { Left = 20, Top = 60, Width = 320, PasswordChar = '*' };
            btnCambiar = new Button { Left = 20, Top = 100, Width = 120, Text = "Cambiar" };
            lblInfo = new Label { Left = 20, Top = 140, Width = 320 };

            btnCambiar.Click += BtnCambiar_Click;

            this.Controls.Add(txtPass);
            this.Controls.Add(txtPass2);
            this.Controls.Add(btnCambiar);
            this.Controls.Add(lblInfo);
        }

        private void BtnCambiar_Click(object sender, EventArgs e)
        {
            string p1 = txtPass.Text;
            string p2 = txtPass2.Text;

            if (p1 == "" || p2 == "")
            {
                lblInfo.Text = "Completá ambos campos.";
                return;
            }
            if (p1 != p2)
            {
                lblInfo.Text = "Las contraseñas no coinciden.";
                return;
            }
            if (p1.Length < 6)
            {
                lblInfo.Text = "Debe tener mínimo 6 caracteres.";
                return;
            }

            string hash = BCrypt.Net.BCrypt.HashPassword(p1);

            negocio.CambiarPassword(usuarioId, hash);
            lblInfo.Text = "Contraseña cambiada correctamente.";
            this.Close();
        }
    }
}
