using Quiosco.Negocio;
using Quiosco.Entidades;
using System;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormLogin : Form
    {
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnOlvido;
        private Label lblInfo;
        private Button btnRegistrar;

        UsuarioNegocio negocio = new UsuarioNegocio();

        public FormLogin()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Ingreso al sistema";
            this.Width = 400;
            this.Height = 250;

            txtEmail = new TextBox { Left = 20, Top = 20, Width = 320, PlaceholderText = "Email" };
            txtPassword = new TextBox { Left = 20, Top = 60, Width = 320, PasswordChar = '*', PlaceholderText = "Contraseña" };

            btnLogin = new Button { Left = 20, Top = 110, Width = 120, Text = "Ingresar" };
            btnOlvido = new Button { Left = 160, Top = 110, Width = 180, Text = "Olvidé mi contraseña" };

            lblInfo = new Label { Left = 20, Top = 160, Width = 350 };

            btnRegistrar = new Button { Left = 20, Top = 140, Width = 120, Text = "Registrarse" };
            btnRegistrar.Click += (s, e) => new FormRegistrarUsuario().ShowDialog();
            this.Controls.Add(btnRegistrar);


            btnLogin.Click += BtnLogin_Click;
            btnOlvido.Click += BtnOlvido_Click;

            this.Controls.Add(txtEmail);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnOlvido);
            this.Controls.Add(lblInfo);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var pass = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
            {
                lblInfo.Text = "Complete usuario y contraseña.";
                return;
            }

            // Buscar usuario
            var user = negocio.BuscarPorEmail(email);
            if (user == null)
            {
                lblInfo.Text = "Usuario no encontrado.";
                return;
            }

            // Verificar hash
            if (!BCrypt.Net.BCrypt.Verify(pass, user.ContrasenaHash))
            {
                lblInfo.Text = "Contraseña incorrecta.";
                return;
            }


            Sesion.UsuarioActual = user;   //  GUARDA EL USUARIO QUE INICIÓ SESIÓN

            lblInfo.Text = $"Bienvenido {user.NombreUsuario}";

            // Abrir el FormInicio con la sesión ya cargada
            var inicio = new FormInicio();
            inicio.Show();

            // Ocultar login
            this.Hide();
        }

        private void BtnOlvido_Click(object sender, EventArgs e)
        {
            var f = new FormEmailRecuperarContraseña();
            f.ShowDialog();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            var f2 = new FormRegistrarUsuario();
            f2.ShowDialog();
        }
    }
}
