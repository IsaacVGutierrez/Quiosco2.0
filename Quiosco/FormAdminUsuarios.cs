using System;
using System.Windows.Forms;
using Quiosco.Negocio;
using Quiosco.Entidades;

namespace Quiosco
{
    public partial class FormAdminUsuarios : Form
    {
        UsuarioNegocio negocio = new UsuarioNegocio();

        DataGridView dgv;
        Button btnAgregar, btnEditar, btnEliminar;
        TextBox txtBuscar;

        public FormAdminUsuarios()
        {
            InitializeComponents();
            CargarUsuarios();
        }

        private void InitializeComponents()
        {
            this.Text = "Gestión de Usuarios - ADMIN";
            this.Width = 720;
            this.Height = 420;

            dgv = new DataGridView
            {
                Left = 20,
                Top = 20,
                Width = 660,
                Height = 280,
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnAgregar = new Button { Left = 20, Top = 320, Width = 120, Text = "Agregar Usuario" };
            btnEditar = new Button { Left = 160, Top = 320, Width = 120, Text = "Editar Usuario" };
            btnEliminar = new Button { Left = 300, Top = 320, Width = 120, Text = "Eliminar Usuario" };

            btnAgregar.Click += BtnAgregar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnEliminar.Click += BtnEliminar_Click;

            // ============================
            // BUSCADOR
            // ============================
            txtBuscar = new TextBox
            {
                Left = 440,
                Top = 320,
                Width = 240,
                PlaceholderText = "Buscar por nombre o email..."
            };
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            this.Controls.Add(txtBuscar);
            this.Controls.Add(dgv);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnEliminar);
        }

        private void CargarUsuarios()
        {
            dgv.DataSource = negocio.ListaUsuarios();

            if (dgv.Columns.Contains("PasswordHash"))
                dgv.Columns["PasswordHash"].Visible = false;
        }

        private Usuario ObtenerSeleccionado()
        {
            if (dgv.SelectedRows.Count == 0) return null;
            return dgv.SelectedRows[0].DataBoundItem as Usuario;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            new FormRegistrarUsuario().ShowDialog();
            CargarUsuarios();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Usuario u = ObtenerSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            new FormEditarUsuario(u).ShowDialog();
            CargarUsuarios();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Usuario u = ObtenerSeleccionado();
            if (u == null)
            {
                MessageBox.Show("Seleccione un usuario.");
                return;
            }

            if (MessageBox.Show("¿Eliminar usuario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                negocio.EliminarUsuario(u.IdUsuario);
                CargarUsuarios();
            }
        }

        // =====================================
        //  BUSCADOR (AHORA SÍ DENTRO DE LA CLASE)
        // =====================================
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            var lista = negocio.ListaUsuarios();

            var filtrada = lista.FindAll(u =>
                u.NombreUsuario.ToLower().Contains(filtro) ||
                u.Email.ToLower().Contains(filtro)
            );

            dgv.DataSource = filtrada;

            if (dgv.Columns.Contains("PasswordHash"))
                dgv.Columns["PasswordHash"].Visible = false;
        }
    }

    // ==========================================
    //  FORM EDITAR USUARIO
    // ==========================================
    public class FormEditarUsuario : Form
    {
        Usuario usuario;
        UsuarioNegocio negocio = new UsuarioNegocio();

        TextBox txtNombre;
        TextBox txtTelefono;
        ComboBox cmbRol;
        Button btnGuardar;

        public FormEditarUsuario(Usuario u)
        {
            usuario = u;
            InitializeComponents();
            CargarDatos();
        }

        private void InitializeComponents()
        {
            this.Text = "Editar Usuario";
            this.Width = 350;
            this.Height = 260;

            txtNombre = new TextBox { Left = 20, Top = 20, Width = 250 };
            txtTelefono = new TextBox { Left = 20, Top = 60, Width = 250 };

            cmbRol = new ComboBox
            {
                Left = 20,
                Top = 100,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cmbRol.Items.Add("Admin");
            cmbRol.Items.Add("Empleado");

            btnGuardar = new Button { Left = 20, Top = 150, Width = 120, Text = "Guardar" };
            btnGuardar.Click += BtnGuardar_Click;

            Controls.Add(txtNombre);
            Controls.Add(txtTelefono);
            Controls.Add(cmbRol);
            Controls.Add(btnGuardar);
        }

        private void CargarDatos()
        {
            txtNombre.Text = usuario.NombreUsuario;
            txtTelefono.Text = usuario.Telefono;
            cmbRol.SelectedItem = usuario.Rol;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            usuario.NombreUsuario = txtNombre.Text.Trim();
            usuario.Telefono = txtTelefono.Text.Trim();
            usuario.Rol = cmbRol.SelectedItem.ToString();

            negocio.ActualizarUsuario(usuario);

            MessageBox.Show("Usuario actualizado correctamente.");
            this.Close();
        }
    }
}
