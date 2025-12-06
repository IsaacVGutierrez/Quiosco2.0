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
    public partial class FormRegistroMetodoDePago : Form
    {
        public FormRegistroMetodoDePago()
        {
            InitializeComponent();

            dgvMetodoDePago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            dgvMetodoDePago.ColumnCount = 2;
            dgvMetodoDePago.Columns[0].HeaderText = "Codigo Metodo De Pago";
            dgvMetodoDePago.Columns[1].HeaderText = "Nombre Metodo De Pago";


            LlenarDGVMetodoDePago();




        }

        public MetodoDePago objEntMetodoDePago = new MetodoDePago();

        public MetodoDePagoNegocio objNegMetodoDePago = new MetodoDePagoNegocio();


        public bool ValidacionCamposMetodoDePago()
        {

            //Nombre MetodoDePago
            if (txtNombreMetodoDePago.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre de Metodo De Pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreMetodoDePago.Text.Length > 100 || txtNombreMetodoDePago.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }


        public void DgEliminarMetodoDePagoId()
        {
            string id = txtEliminarMetodoDePago.Text;
            dgvMetodoDePago.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegMetodoDePago.ListarMetodoDePagoEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvMetodoDePago.Rows.Add(dr[0].ToString(), dr[1]);
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

        private void LlenarDgMetodoDePagoBuscar()
        {
            string cual = txtBuscarMetodoDePago.Text;
            dgvMetodoDePago.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegMetodoDePago.listarMetodoDePagoBuscar(cual);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvMetodoDePago.Rows.Add(dr[0].ToString(), dr[1]);
                }
            }

        }


        private void LlenarDGVMetodoDePago()
        {

            dgvMetodoDePago.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegMetodoDePago.listadoMetodoDePago("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvMetodoDePago.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
            }
        }

        private void dgvMetodoDePago_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            DataSet ds = new DataSet();
            objEntMetodoDePago.IdMetodoDePago = Convert.ToInt32(dgvMetodoDePago.CurrentRow.Cells[0].Value);
            ds = objNegMetodoDePago.listadoMetodoDePago(objEntMetodoDePago.IdMetodoDePago.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBoxMetodoDePago(ds);
                btnCargaMetodoDePago.Visible = false;
                btnModificarMetodoDePago.Visible = true;
                btnCancelarMetodoDePago.Visible = true;
            }
        }


        private void TxtBox_a_ObjMetodoDePago()
        {
            objEntMetodoDePago.NombreMetodoDePago = txtNombreMetodoDePago.Text;

        }






        private void LimpiarMetodoDePago()
        {
            txtNombreMetodoDePago.Text = string.Empty;
            txtBuscarMetodoDePago.Clear();
            txtEliminarMetodoDePago.Clear();

        }
        private void Ds_a_TxtBoxMetodoDePago(DataSet ds)
        {

            txtNombreMetodoDePago.Text = ds.Tables[0].Rows[0]["NombreMetodoDePago"].ToString();


        }



        private void btnCargarMetodoDePago_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposMetodoDePago();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjMetodoDePago();
                nGrabados = objNegMetodoDePago.abmMetodoDePago("Alta", objEntMetodoDePago);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el Metodo De Pago al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar el Metodo De Pago con éxito");
                    LlenarDGVMetodoDePago();
                    LimpiarMetodoDePago();

                }
            }
        }



        private void btnModificarMetodoDePago_Click_1(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposMetodoDePago();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjMetodoDePago();
                nResultado = objNegMetodoDePago.abmMetodoDePago("Modificar", objEntMetodoDePago);
                if (nResultado != -1)
                {
                    MessageBox.Show("el Metodo De Pago fue modificada con éxito");
                    LimpiarMetodoDePago();
                    LlenarDGVMetodoDePago();
                    btnModificarMetodoDePago.Visible = false;
                    btnCargaMetodoDePago.Visible = true;
                    btnCancelarMetodoDePago.Visible = false;
                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar el Metodo De Pago");
                }
            }

        }

        private void btnCancelarMetodoDePago_Click_1(object sender, EventArgs e)
        {
            LimpiarMetodoDePago();
            btnCargaMetodoDePago.Visible = true;
            btnModificarMetodoDePago.Visible = true;
            btnCancelarMetodoDePago.Visible = true;
            LlenarDGVMetodoDePago();
        }

        private void btnBuscarMetodoDePago_Click_1(object sender, EventArgs e)

        {
            LlenarDgMetodoDePagoBuscar();
        }


        private void btnEliminarMetodoDePago_Click_1(object sender, EventArgs e)
        {
            {


                if (true)
                {

                    DgEliminarMetodoDePagoId();

                    LlenarDGVMetodoDePago();

                    MessageBox.Show("Se eliminaron los detalles de Metodo De Pago");
                }
            }
        }

        private void txtNombreMetodoDePago_KeyPress(object sender, KeyPressEventArgs e)
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


        private void dgvMetodoDePago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
