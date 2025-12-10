using Quiosco.Entidades;
using Quiosco.Negocio;
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
    public partial class FormRegistroCategoria : Form
    {
        public FormRegistroCategoria()
        {
            InitializeComponent();

            dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvCategoria.ColumnCount = 2;
            dgvCategoria.Columns[0].HeaderText = "Codigo Categoria";
            dgvCategoria.Columns[1].HeaderText = "Nombre Categoria";


            LlenarDGVCategoria();



        }



        public Categoria objEntCategoria = new Categoria();

        public CategoriaNegocio objNegCategoria = new CategoriaNegocio();



        private void TxtBox_a_ObjCategoria()
        {
            objEntCategoria.NombreCategoria = txtNombreCategoria.Text;

        }

        private void Ds_a_TxtBoxCategoria(DataSet ds)
        {

            txtNombreCategoria.Text = ds.Tables[0].Rows[0]["NombreCategoria"].ToString();


        }

        public bool ValidacionCamposCategoria()
        {

            //Nombre Categoria
            if (txtNombreCategoria.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre Categoria", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreCategoria.Text.Length > 100 || txtNombreCategoria.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }
        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir letras
            if (char.IsLetter(e.KeyChar))
                return;

            // Permitir Backspace
            if (e.KeyChar == (char)Keys.Back)
                return;

            // Permitir espacio
            if (e.KeyChar == ' ')
                return;

            // Si llegó acá, es un caracter no permitido
            MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            e.Handled = true;
        }

        private void LlenarDgCategoriaBuscar()
        {
            string cual = txtBuscarCategoria.Text;
            dgvCategoria.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegCategoria.listarCategoriaBuscar(cual);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCategoria.Rows.Add(dr[0].ToString(), dr[1]);
                }
            }

        }

        private void LlenarDGVCategoria()
        {

            dgvCategoria.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegCategoria.listadoCategoria("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvCategoria.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
            }
        }


        private void btnCargarCategoria_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposCategoria();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjCategoria();
                nGrabados = objNegCategoria.abmCategoria("Alta", objEntCategoria);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar la Categoria al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar la Categoria con éxito");
                    LlenarDGVCategoria();
                    LimpiarCategoria();

                }
            }
        }





        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            DataSet ds = new DataSet();
            objEntCategoria.IdCategoria = Convert.ToInt32(dgvCategoria.CurrentRow.Cells[0].Value);
            ds = objNegCategoria.listadoCategoria(objEntCategoria.IdCategoria.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBoxCategoria(ds);
                btnCargaCategoria.Visible = false;
                btnModificarCategoria.Visible = true;
                btnCancelarCategoria.Visible = true;

            }
        }




        private void btnModificarCategoria_Click_1(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposCategoria();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjCategoria();
                nResultado = objNegCategoria.abmCategoria("Modificar", objEntCategoria);
                if (nResultado != -1)
                {
                    MessageBox.Show(" La Categoria fue modificada con éxito");
                    LimpiarCategoria();
                    LlenarDGVCategoria();
                    btnModificarCategoria.Visible = false;
                    btnCargaCategoria.Visible = true;
                    btnCancelarCategoria.Visible = false;

                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar la Categoria");
                }
            }

        }

        private void btnCancelarCategoria_Click_1(object sender, EventArgs e)
        {
            LimpiarCategoria();
            btnCargaCategoria.Visible = true;
            btnModificarCategoria.Visible = true;
            btnCancelarCategoria.Visible = true;
            LlenarDGVCategoria();

        }

        private void btnBuscarCategoria_Click_1(object sender, EventArgs e)

        {
            LlenarDgCategoriaBuscar();
        }

        private void btnEliminarCategoria_Click_1(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dgvCategoria.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el IdCategoria de la fila seleccionada
            if (!int.TryParse(dgvCategoria.CurrentRow.Cells[0].Value.ToString(), out int idCategoria))
            {
                MessageBox.Show("El IdCategoria seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Confirmar eliminación
            var resultado = MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes) return;

            try
            {
                // Llamamos a tu método para eliminar y actualizar la grilla
                dgvCategoria.Rows.Clear();
                DataSet ds = objNegCategoria.ListarCategoriaEliminar(idCategoria.ToString());

                if (ds != null && ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dgvCategoria.Rows.Add(dr[0].ToString(), dr[1].ToString());
                    }

                    MessageBox.Show("Categoría eliminada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se encontró la categoría o no se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void LimpiarCategoria()
        {
            txtNombreCategoria.Text = string.Empty;
            txtBuscarCategoria.Clear();


        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormRegistroCategoria_Load(object sender, EventArgs e)
        {

            if (Sesion.UsuarioActual.Rol != "Admin")
            {
                btnEliminarCategoria.Visible = false;
            }
        }
    }
}
