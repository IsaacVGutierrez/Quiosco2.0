using Quiosco.Entidades;
using Quiosco.Negocio;
using Quiosco.BD;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormRegistroCliente : Form
    {
        public FormRegistroCliente()
        {
            InitializeComponent();

            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvCliente.ColumnCount = 4;
            dgvCliente.Columns[0].HeaderText = "Codigo Cliente";
            dgvCliente.Columns[1].HeaderText = "Nombre Cliente";
            dgvCliente.Columns[2].HeaderText = "Telefono Cliente";
            dgvCliente.Columns[3].HeaderText = "Adeuda Cliente";


            LlenarDGVCliente();



        }






        public Cliente objEntCliente = new Cliente();

        public ClienteNegocio objNegCliente = new ClienteNegocio();


        private void TxtBox_a_ObjCliente()
        {
            objEntCliente.NombreCliente = txtNombreCliente.Text;
            objEntCliente.TelefonoCliente = txtTelefonoCliente.Text;
            // objEntCliente.AdeudaCliente = int.Parse(txtAdeudaCliente.Text);
            if (decimal.TryParse(txtAdeudaCliente.Text.Replace(",", "."),
                      System.Globalization.NumberStyles.Any,
                      System.Globalization.CultureInfo.InvariantCulture,
                      out decimal monto))
            {
                objEntCliente.AdeudaCliente = monto;
            }
            else
            {
                MessageBox.Show("Ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // detiene la ejecución si el monto no es válido
            }




        }

        private void Ds_a_TxtBoxCliente(DataSet ds)
        {
            txtNombreCliente.Text = ds.Tables[0].Rows[0]["NombreCliente"].ToString();
            txtTelefonoCliente.Text = ds.Tables[0].Rows[0]["TelefonoCliente"].ToString();
            txtAdeudaCliente.Text = ds.Tables[0].Rows[0]["AdeudaCliente"].ToString();

        }

        private void LlenarDGVCliente()
        {
            dgvCliente.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegCliente.listadoCliente("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCliente.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2], dr[3].ToString());
                }
            }
        }

        private void LlenarDgClienteBuscar()
        {
            string cual = txtBuscarCliente.Text;
            dgvCliente.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegCliente.listarClienteBuscar(cual);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCliente.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2], dr[3]);
                }
            }
        }









        public bool ValidacionCamposCliente()
        {

            //Nombre
            if (txtNombreCliente.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre de Cliente ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreCliente.Text.Length > 90 || txtNombreCliente.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombre de 90 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Telefono
            if (txtTelefonoCliente.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Telefono de Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtTelefonoCliente.Text.Length > 50 || txtTelefonoCliente.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres entre 2 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Adeuda
            if (txtAdeudaCliente.Text == string.Empty)
            {
                MessageBox.Show("Ingrese si Adeuda un monto el cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtAdeudaCliente.Text.Length > 50 || txtAdeudaCliente.Text.Length < 0)
            {
                MessageBox.Show("Solo se permiten precio entre 0 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;


        }


        private void btnCargarCliente_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposCliente();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjCliente();
                nGrabados = objNegCliente.abmCliente("Alta", objEntCliente);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el Cliente al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar al Cliente con éxito");
                    LlenarDGVCliente();
                    LimpiarCliente();


                }
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposCliente();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjCliente();
                nResultado = objNegCliente.abmCliente("Modificar", objEntCliente);
                if (nResultado != -1)
                {
                    MessageBox.Show("El Cliente fue modificado con éxito");
                    LimpiarCliente();
                    LlenarDGVCliente();
                    btnModificarCliente.Visible = false;
                    btnCargarCliente.Visible = true;
                    btnCancelarCliente.Visible = false;

                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar el Cliente");
                }

            }
        }




        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataSet ds = new DataSet();
            objEntCliente.IdCliente = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value);
            ds = objNegCliente.listadoCliente(objEntCliente.IdCliente.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBoxCliente(ds);
                btnCargarCliente.Visible = false;
                btnModificarCliente.Visible = true;
                btnCancelarCliente.Visible = true;

            }
        }



        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void txtAdeudaCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Permitir punto o coma, pero solo UNO
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                // Si ya existe punto o coma, no permitir repetir
                if (txt.Text.Contains('.') || txt.Text.Contains(','))
                {
                    MessageBox.Show("Solo se permite un separador decimal (coma o punto).",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    e.Handled = true;
                    return;
                }

                return; // se permite
            }

            // Si llegó acá → caracter inválido
            MessageBox.Show("Solo se permiten números y separador decimal.",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            e.Handled = true;
        }




        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dgvCliente.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el IdCliente de la fila seleccionada
            if (!int.TryParse(dgvCliente.CurrentRow.Cells[0].Value.ToString(), out int idCliente))
            {
                MessageBox.Show("El IdCliente seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            var resultado = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            try
            {
                // Limpiar grilla y eliminar cliente usando tu método existente
                dgvCliente.Rows.Clear();
                DataSet ds = objNegCliente.ListarClienteEliminar(idCliente.ToString());

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dgvCliente.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3]);
                    }

                    MessageBox.Show("Cliente eliminado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente o no se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }









        private void btnCancelarCliente_Click_1(object sender, EventArgs e)
        {
            LimpiarCliente();
            btnCargarCliente.Visible = true;
            btnModificarCliente.Visible = true;
            btnCancelarCliente.Visible = true;
            LlenarDGVCliente();

        }



        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            {
                LlenarDgClienteBuscar();
            }
        }

        private void LimpiarCliente()
        {
            txtNombreCliente.Text = string.Empty;
            txtTelefonoCliente.Text = string.Empty;
            txtAdeudaCliente.Text = string.Empty;
            txtBuscarCliente.Clear();

        }


        private void dgvCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormRegistroCliente_Load(object sender, EventArgs e)
        {

            if (Sesion.UsuarioActual.Rol != "Admin")
            {
                btnEliminarCliente.Visible = false;
            }
        }
    }
}

