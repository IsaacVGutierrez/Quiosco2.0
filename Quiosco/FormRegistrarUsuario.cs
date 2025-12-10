using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Quiosco.Negocio;
using Quiosco.Entidades;

namespace Quiosco
{
    public partial class FormRegistrarUsuario : Form
    {
        private TextBox txtEmail;
        private TextBox txtNombre;
        private TextBox txtTelefono;
        private TextBox txtPass1;
        private TextBox txtPass2;
        private Button btnRegistrar;
        private Label lblInfo;

        private ComboBox cmbRol;   // ← agregado aquí

        UsuarioNegocio negocio = new UsuarioNegocio();

        public FormRegistrarUsuario()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "Registrar nuevo usuario";
            this.Width = 420;
            this.Height = 350;

            int x = 20;

            txtEmail = new TextBox { Left = x, Top = 20, Width = 350, PlaceholderText = "Email" };
            txtNombre = new TextBox { Left = x, Top = 60, Width = 350, PlaceholderText = "Nombre de usuario" };
            txtTelefono = new TextBox { Left = x, Top = 100, Width = 350, PlaceholderText = "Teléfono (opcional)" };
            txtPass1 = new TextBox { Left = x, Top = 140, Width = 350, PasswordChar = '*', PlaceholderText = "Contraseña" };
            txtPass2 = new TextBox { Left = x, Top = 180, Width = 350, PasswordChar = '*', PlaceholderText = "Repetir contraseña" };

            // ----------- COMBOBOX DE ROL ------------
            cmbRol = new ComboBox
            {
                Left = 20,
                Top = 220,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("Empleado");
            cmbRol.SelectedIndex = 1; // Empleado por defecto
            // -----------------------------------------

            btnRegistrar = new Button { Left = x, Top = 260, Width = 140, Text = "Registrar" };
            lblInfo = new Label { Left = x, Top = 300, Width = 350, Height = 40 };

            btnRegistrar.Click += BtnRegistrar_Click;

            this.Controls.Add(cmbRol);
            this.Controls.Add(txtEmail);
            this.Controls.Add(txtNombre);
            this.Controls.Add(txtTelefono);
            this.Controls.Add(txtPass1);
            this.Controls.Add(txtPass2);
            this.Controls.Add(btnRegistrar);
            this.Controls.Add(lblInfo);
        }

        private bool EmailValido(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private bool TelefonoValido(string tel)
        {
            return Regex.IsMatch(tel, @"^[0-9]*$");
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string p1 = txtPass1.Text.Trim();
            string p2 = txtPass2.Text.Trim();

            // Validaciones
            if (email == "") { lblInfo.Text = "Debe ingresar email."; return; }
            if (!EmailValido(email)) { lblInfo.Text = "Email inválido."; return; }
            if (nombre == "") { lblInfo.Text = "Debe ingresar usuario."; return; }
            if (!TelefonoValido(telefono)) { lblInfo.Text = "Teléfono inválido."; return; }
            if (p1.Length < 6) { lblInfo.Text = "Contraseña mínima de 6 caracteres."; return; }
            if (p1 != p2) { lblInfo.Text = "Las contraseñas no coinciden."; return; }

            Usuario nuevo = new Usuario
            {
                Email = email,
                NombreUsuario = nombre,
                Telefono = telefono,
                ContrasenaHash = BCrypt.Net.BCrypt.HashPassword(p1),
                Rol = cmbRol.SelectedItem.ToString()   // ← CORRECTO
            };

            try
            {
                negocio.RegistrarUsuario(nuevo);
                MessageBox.Show("Usuario registrado correctamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                lblInfo.Text = "Error: " + ex.Message;
            }
        }
    }
}
