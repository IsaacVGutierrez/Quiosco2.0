using Quiosco.Negocio;
using Quiosco.Entidades;
using System;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormEmailRecuperarContraseña : Form
    {
        private TextBox txtEmail;
        private Button btnEnviar;
        private Label lblInfo;

        UsuarioNegocio negocio = new UsuarioNegocio();
        EmailService emailService;

        public FormEmailRecuperarContraseña()
        {   //AQUI INGRESAMOS NUESTRO CORREO COMERCIAL
            emailService = new EmailService("smtp.gmail.com",587,"softwarecomercialivg@gmail.com","siai vmml dsqv zgau");

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Recuperar contraseña";
            this.Width = 400; this.Height = 180;

            txtEmail = new TextBox { Left = 20, Top = 20, Width = 340 };
            btnEnviar = new Button { Left = 20, Top = 60, Width = 120, Text = "Enviar código" };
            lblInfo = new Label { Left = 20, Top = 100, Width = 340 };

            btnEnviar.Click += BtnEnviar_Click;

            this.Controls.Add(txtEmail);
            this.Controls.Add(btnEnviar);
            this.Controls.Add(lblInfo);
        }

        private async void BtnEnviar_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            if (email == "")
            {
                lblInfo.Text = "Ingresá un email.";
                return;
            }

            var user = negocio.BuscarPorEmail(email);
            if (user == null)
            {
                lblInfo.Text = "No existe un usuario con ese email.";
                return;
            }

            string codigo = new Random().Next(100000, 999999).ToString();

            negocio.CrearCodigoRecuperacion(user.IdUsuario, codigo);

            try
            {
                await emailService.SendRecoveryCodeAsync(email, codigo);
                lblInfo.Text = "Código enviado al correo.";

                var form = new FormEnterCode(user.IdUsuario);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Error enviando email: " + ex.Message;
            }
        }
    }
}
