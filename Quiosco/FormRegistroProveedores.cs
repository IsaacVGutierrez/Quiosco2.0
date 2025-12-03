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
    public partial class FormRegistroProveedores : Form
    {
        public FormRegistroProveedores()
        {
            InitializeComponent();
       
    
                dgvProveedor.ColumnCount = 6;
                dgvProveedor.Columns[0].HeaderText = "Codigo Proveedor";
                dgvProveedor.Columns[1].HeaderText = "Nombre Proveedor";
                dgvProveedor.Columns[2].HeaderText = "Telefono Proveedor";
                dgvProveedor.Columns[3].HeaderText = "Direccion Proveedor";
                dgvProveedor.Columns[4].HeaderText = "Horario Proveedor";
                dgvProveedor.Columns[5].HeaderText = "Dias de atencion";

                LlenarDGVProveedor();

                // LlenarCombos();
                // LlenarCombos2();
                            

        }

        public Proveedor objEntProveedor = new Proveedor();

        public ProveedorNegocio objNegProveedor = new ProveedorNegocio();

        public bool ValidacionCamposProveedor()
        {

            //Nombre Proveedor
            if (txtNombreProveedor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreProveedor.Text.Length > 100 || txtNombreProveedor.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            //Telefono Proveedor
            if (txtTelefonoProveedor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Telefono Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtTelefonoProveedor.Text.Length > 50 || txtTelefonoProveedor.Text.Length < 3)
            {
                MessageBox.Show("Solo se permiten telefonos entre 3 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Direccion Proveedor
            if (txtDireccionProveedor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Direccion Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDireccionProveedor.Text.Length > 100 || txtDireccionProveedor.Text.Length < 5)
            {
                MessageBox.Show("Solo se permiten Direccion Proveedor entre 5 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDireccionProveedor.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Horario Proveedor
            if (txtHorarioProveedor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Horario Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtHorarioProveedor.Text.Length > 100 || txtHorarioProveedor.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten  Horario Proveedor entre 2 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtHorarioProveedor.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Dias atencion Proveedor
            if (txtDiasAtencionProveedor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Dias de Atencion de Proveedor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDiasAtencionProveedor.Text.Length > 100 || txtDiasAtencionProveedor.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten  Dias de Atencion de Proveedor entre 2 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtDiasAtencionProveedor.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;

        }


        public void DgEliminarProveedorId()
        {
            string id = txtEliminarProveedor.Text;
            dgvProveedor.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegProveedor.ListarProveedorEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvProveedor.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5]);
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

        private void LlenarDgProveedorBuscar()
        {
            string cual = txtBuscarProveedor.Text;
            dgvProveedor.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegProveedor.listarProveedorBuscar(cual);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvProveedor.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5]);
                }
            }

        }


        private void LlenarDGVProveedor()
        {

            dgvProveedor.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegProveedor.listadoProveedor("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvProveedor.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5].ToString());
                }
            }
        }



        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
         {

          
             DataSet ds = new DataSet();
             objEntProveedor.IdProveedor = Convert.ToInt32(dgvProveedor.CurrentRow.Cells[0].Value);
             ds = objNegProveedor.listadoProveedor(objEntProveedor.IdProveedor.ToString());
             if (ds.Tables[0].Rows.Count > 0)
             {
                 Ds_a_TxtBoxProveedor(ds);
                 btnCargaProveedor.Visible = false;
                 btnModificarProveedor.Visible = true;
                 btnCancelarProveedor.Visible = true;
             }
         }

        private void TxtBox_a_ObjProveedor()
        {
            objEntProveedor.NombreProveedor = txtNombreProveedor.Text;
            objEntProveedor.TelefonoProveedor = txtTelefonoProveedor.Text;
            objEntProveedor.DireccionProveedor = txtDireccionProveedor.Text;
            objEntProveedor.HorarioProveedor = txtHorarioProveedor.Text;
            objEntProveedor.DiasProveedor = txtDiasAtencionProveedor.Text;
        }

        private void LimpiarProveedor()
        {
            txtNombreProveedor.Text = string.Empty;
            txtTelefonoProveedor.Text = string.Empty;
            txtDireccionProveedor.Text = string.Empty;
            txtHorarioProveedor.Text = string.Empty;
            txtDiasAtencionProveedor.Text = string.Empty;
            txtBuscarProveedor.Clear();
            txtEliminarProveedor.Clear();
        }
        private void Ds_a_TxtBoxProveedor(DataSet ds)
        {

            txtNombreProveedor.Text = ds.Tables[0].Rows[0]["NombreProveedor"].ToString();
            txtTelefonoProveedor.Text = ds.Tables[0].Rows[0]["TelefonoProveedor"].ToString();
            txtDireccionProveedor.Text = ds.Tables[0].Rows[0]["DireccionProveedor"].ToString();
            txtHorarioProveedor.Text = ds.Tables[0].Rows[0]["HorarioProveedor"].ToString();
            txtDiasAtencionProveedor.Text = ds.Tables[0].Rows[0]["DiasProveedor"].ToString();

        }

        private void btnCargarProveedor_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposProveedor();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjProveedor();
                nGrabados = objNegProveedor.abmProveedor("Alta", objEntProveedor);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el Proveedor al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar al Proveedor con éxito");
                    LlenarDGVProveedor();
                    LimpiarProveedor();
                   // tabControl1.SelectTab(tabProveedor);
                }
            }
        }

        private void BtnModificarProveedor_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposProveedor();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjProveedor();
                nResultado = objNegProveedor.abmProveedor("Modificar", objEntProveedor);
                if (nResultado != -1)
                {
                    MessageBox.Show("el Proveedor fue modificada con éxito");
                    LimpiarProveedor();
                    LlenarDGVProveedor();
                    btnModificarProveedor.Visible = false;
                    btnCargaProveedor.Visible = true;
                    btnCancelarProveedor.Visible = false;
                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar la Proveedor");
                }
            }

        }



        private void btnCancelarProveedor_Click(object sender, EventArgs e)
        {
            LimpiarProveedor();
            btnCargaProveedor.Visible = true;
            btnModificarProveedor.Visible = true;
            btnCancelarProveedor.Visible = true;
            LlenarDGVProveedor();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            LlenarDgProveedorBuscar();
        }

        private void btnEliminarProveedor_Click(object sender, EventArgs e)
        {


            if (true)
            {

                DgEliminarProveedorId();

                LlenarDGVProveedor();

                MessageBox.Show("Se eliminaron los detalles de Proveedor");
            }
        }


        private void txtTelefonoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }



         private void txtDiasAtencionProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
         }

      


        private void FormRegistroProveedores_Load(object sender, EventArgs e)
        {

        }
           
   
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}