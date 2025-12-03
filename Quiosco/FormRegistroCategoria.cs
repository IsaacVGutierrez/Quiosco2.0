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


            dgvCategoria.ColumnCount = 2;
            dgvCategoria.Columns[0].HeaderText = "Codigo Categoria";
            dgvCategoria.Columns[1].HeaderText = "Nombre Categoria";


            LlenarDGVCategoria();

            // LlenarCombos();
            // LlenarCombos2();


        }

        public Categoria objEntCategoria = new Categoria();

        public CategoriaNegocio objNegCategoria = new CategoriaNegocio();


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


        public void DgEliminarCategoriaId()
        {
            string id = txtEliminarCategoria.Text;
            dgvCategoria.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegCategoria.ListarCategoriaEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvCategoria.Rows.Add(dr[0].ToString(), dr[1]);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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


        private void TxtBox_a_ObjCategoria()
        {
            objEntCategoria.NombreCategoria = txtNombreCategoria.Text;

        }






        private void LimpiarCategoria()
        {
            txtNombreCategoria.Text = string.Empty;
            txtBuscarCategoria.Clear();
            txtEliminarCategoria.Clear();

        }
        private void Ds_a_TxtBoxCategoria(DataSet ds)
        {

            txtNombreCategoria.Text = ds.Tables[0].Rows[0]["NombreCategoria"].ToString();


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
                   // tabControl1.SelectTab(tabCategoria);
                }
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
                    MessageBox.Show("el Categoria fue modificada con éxito");
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
            {


                if (true)
                {

                    DgEliminarCategoriaId();

                    LlenarDGVCategoria();

                    MessageBox.Show("Se eliminaron los detalles de Categoria");
                }
            }
        }

        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
