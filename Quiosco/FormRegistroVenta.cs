using Quiosco.Entidades;
using Quiosco.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormRegistroVenta : Form
    {
        public FormRegistroVenta()
        {
            InitializeComponent();

            dgvVenta.AutoGenerateColumns = false; // IMPORTANTE: evita que se creen columnas automáticamente
            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Definir columnas manualmente según tu gusto
            dgvVenta.Columns.Clear();

            // Ejemplo:

            dgvVenta.Columns.Add("IdVenta", "Código");
            dgvVenta.Columns["IdVenta"].DataPropertyName = "IdVenta";
            dgvVenta.Columns["IdVenta"].Visible = false; // ocultamos la columna


            dgvVenta.Columns.Add("NombreProducto", "Nombre Producto");
            dgvVenta.Columns["NombreProducto"].DataPropertyName = "NombreProducto";

            dgvVenta.Columns.Add("CantidadProducto", "Cantidad");
            dgvVenta.Columns["CantidadProducto"].DataPropertyName = "CantidadProducto";

            dgvVenta.Columns.Add("SubtotalVenta", "Subtotal");
            dgvVenta.Columns["SubtotalVenta"].DataPropertyName = "SubtotalVenta";

            dgvVenta.Columns.Add("NombreMetodoDePago", "Medio de Pago");
            dgvVenta.Columns["NombreMetodoDePago"].DataPropertyName = "NombreMetodoDePago";

            dgvVenta.Columns.Add("NombreCliente", "Cliente");
            dgvVenta.Columns["NombreCliente"].DataPropertyName = "NombreCliente";

            // Si querés mostrar la fecha, pero en otra posición:
            // dgvVenta.Columns.Add("FechaVenta", "Fecha");
            // dgvVenta.Columns["FechaVenta"].DataPropertyName = "FechaVenta";

            dgvVenta.Columns.Add("FechaVenta", "Fecha");
            dgvVenta.Columns["FechaVenta"].DataPropertyName = "FechaVenta";
            dgvVenta.Columns["FechaVenta"].Visible = false;

            // NO agregamos IdVenta si no queremos mostrarlo
            // dgvVenta.Columns.Add("IdVenta", "Código");
            // dgvVenta.Columns["IdVenta"].DataPropertyName = "IdVenta";

            LlenarDGVVenta();

            LlenarCombosVentaProducto();
            LlenarCombosVentaCliente();
            LlenarCombosVentaMetodoDePago();


        }

        public Venta objEntVenta = new Venta();

        public VentaNegocio objNegVenta = new VentaNegocio();

        // en la cabecera del form agrega:
        public DetalleVentaNegocio objNegDetalleVenta = new DetalleVentaNegocio();
        public ProductoNegocio objNegProducto = new ProductoNegocio();

        private void btnCargarVenta_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposVenta();
            if (!validar) return;

            // 1) Armar la entidad Venta
            Venta v = new Venta
            {
                SubtotalVenta = decimal.Parse(txtSubtotalVenta.Text.Replace(".", "").Replace(",", ".")),
                FechaVenta = DateTime.Now, // o toma desde un datetimepicker si lo tenés
                IdMetodoDePagoVenta = Convert.ToInt32(cmbMedioPagoVenta.SelectedValue),
                IdCliente = Convert.ToInt32(cmbClienteVenta.SelectedValue),
                SaldoVenta = 0 // o lo que corresponda
            };

            // 2) Insertar venta y obtener id
            int idVentaCreada = objNegVenta.abmVenta("Alta", v);
            if (idVentaCreada <= 0)
            {
                MessageBox.Show("No se pudo crear la venta.");
                return;
            }

            // 3) Insertar detalle (un solo producto: adaptá si querés varios)
            int idProducto = Convert.ToInt32(cmbProductoVenta.SelectedValue);
            int cantidad = int.Parse(txtCantidadVenta.Text);

            DetalleVenta dv = new DetalleVenta
            {
                IdVenta = idVentaCreada,
                IdProducto = idProducto,
                CantidadProducto = cantidad
            };

            int r = objNegDetalleVenta.abmDetalleVenta("Alta", dv);
            if (r <= 0)
            {
                MessageBox.Show("Venta creada pero no se pudo guardar el detalle.");
                // opcional: eliminar la venta creada para mantener integridad
                return;
            }

            // 4) Reducir stock del producto
            objNegProducto.ReducirStock(idProducto, cantidad);

            MessageBox.Show("Venta y detalle guardados correctamente.");
            LlenarDGVVenta();
            LimpiarVenta();
        }

        public bool ValidacionCamposVenta()
        {

            //Nombre Producto Venta
            if (cmbProductoVenta.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbProductoVenta.Text.Length > 100 || cmbProductoVenta.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten Nombres de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            // Cantidad Venta
            if (txtCantidadVenta.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Cantidad de Venta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCantidadVenta.Text.Length > 1000 || txtCantidadVenta.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten Cantidad de Producto entre 1 y 1000 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            // Subtotal Venta
            if (txtSubtotalVenta.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Subtotal de Venta de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtSubtotalVenta.Text.Length > 1000 || txtSubtotalVenta.Text.Length < 1)
            {
                MessageBox.Show("Solo se permite un Subtotal de Venta de Producto entre 1 y 1000 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtSubtotalVenta.Text.Length > 2000)
            {
                MessageBox.Show("La observación no puede superar los 2000 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            // Medio de Pago de Venta
            if (cmbMedioPagoVenta.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Medio de Pago de Venta ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbMedioPagoVenta.Text.Length > 100 || cmbMedioPagoVenta.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten Medio de Pago de Venta entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbMedioPagoVenta.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            // Cliente Venta
            if (cmbClienteVenta.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Cliente para Venta ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbClienteVenta.Text.Length > 100 || cmbClienteVenta.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten  Cliente de Venta entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbClienteVenta.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;

        }




        public void DgEliminarVentaId()
        {
            string id = txtEliminarVenta.Text;
            dgvVenta.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegVenta.ListarVentaEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvVenta.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
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

        private void LlenarDgVentaBuscar()
        {
            string cual = txtBuscarVenta.Text;
            dgvVenta.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegVenta.listarVentaBuscar(cual);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvVenta.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
                }
            }

        }


        private void LlenarDGVVenta()
        {
            DataSet ds = objNegVenta.listadoVenta("Todos");

            if (ds.Tables.Count > 0)
            {
                dgvVenta.DataSource = ds.Tables[0];

                // Ocultar columnas que no querés mostrar
                dgvVenta.Columns["IdVenta"].Visible = false;

                // Reordenar columnas según tu preferencia
                dgvVenta.Columns["NombreCliente"].DisplayIndex = 0;
                dgvVenta.Columns["NombreProducto"].DisplayIndex = 1;
                dgvVenta.Columns["CantidadProducto"].DisplayIndex = 2;
                dgvVenta.Columns["SubtotalVenta"].DisplayIndex = 3;
                dgvVenta.Columns["NombreMetodoDePago"].DisplayIndex = 4;
                dgvVenta.Columns["FechaVenta"].Visible = false;
                //  dgvVenta.Columns["FechaVenta"].DisplayIndex = 5;

                // Formatear fecha si querés
                dgvVenta.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }





        #region DeclaracionVariables

        public Producto objEntProducto = new Producto();
        public Cliente objEntCliente = new Cliente();
        public MetodoDePago objEntMetodoDePago = new MetodoDePago();



      
        public ClienteNegocio objNegCliente = new ClienteNegocio();
        public MetodoDePagoNegocio objNegMetodoDePago = new MetodoDePagoNegocio();

        #endregion

        #region MetodoLlenarCombo
        private void LlenarCombosVentaProducto()
        {
            cmbProductoVenta.DataSource = objNegProducto.ObtenerProducto();
            cmbProductoVenta.DisplayMember = "NombreProducto";
            cmbProductoVenta.ValueMember = "IdProducto";
        }

        private void LlenarCombosVentaCliente()
        {
            cmbClienteVenta.DataSource = objNegCliente.ObtenerCliente();
            cmbClienteVenta.DisplayMember = "NombreCliente";
            cmbClienteVenta.ValueMember = "IdCliente";
        }

        private void LlenarCombosVentaMetodoDePago()
        {
            cmbMedioPagoVenta.DataSource = objNegMetodoDePago.ObtenerMetodoDePago();
            cmbMedioPagoVenta.DisplayMember = "NombreMetodoDePago";
            cmbMedioPagoVenta.ValueMember = "IdMetododePago";
        }
        #endregion




        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            DataSet ds = new DataSet();
            objEntVenta.IdVenta = Convert.ToInt32(dgvVenta.CurrentRow.Cells[0].Value);
            ds = objNegVenta.listadoVenta(objEntVenta.IdVenta.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBoxVenta(ds);
                btnCargarVenta.Visible = false;
                btnModificarVenta.Visible = true;
                btnCancelarVenta.Visible = true;
            }
        }

        private void TxtBox_a_ObjVenta()
        {
            objEntProducto.IdProducto = int.Parse(cmbProductoVenta.SelectedValue.ToString());
            //objEntVenta.CantidadVenta = int.Parse(txtCantidadVenta.Text);
            objEntVenta.SubtotalVenta = int.Parse(txtSubtotalVenta.Text);
            objEntCliente.IdCliente = int.Parse(cmbClienteVenta.SelectedValue.ToString());
            objEntMetodoDePago.IdMetodoDePago = int.Parse(cmbMedioPagoVenta.SelectedValue.ToString());
            //objEntVenta.SaldoVenta = int.Parse(txtSaldoVenta.ToString());



        }

        private void LimpiarVenta()
        {
            cmbProductoVenta.SelectedIndex = -1;
            txtCantidadVenta.Text = string.Empty;
            txtSubtotalVenta.Text = string.Empty;
            cmbMedioPagoVenta.SelectedIndex = -1;
            cmbClienteVenta.SelectedIndex = -1;
            // txtSaldoVenta.Text = string.Empty;
            txtBuscarVenta.Clear();
            txtEliminarVenta.Clear();
        }
        private void Ds_a_TxtBoxVenta(DataSet ds)
        {

            cmbProductoVenta.SelectedValue = System.Convert.ToInt32(ds.Tables[0].Rows[0]["ProductoId"].ToString());
            txtCantidadVenta.Text = ds.Tables[0].Rows[0]["CantidadVenta"].ToString();
            txtSubtotalVenta.Text = ds.Tables[0].Rows[0]["SubtotalVenta"].ToString();
            cmbMedioPagoVenta.SelectedValue = System.Convert.ToInt32(ds.Tables[0].Rows[0]["MetodoDePagoId"].ToString());
            cmbClienteVenta.SelectedValue = System.Convert.ToInt32(ds.Tables[0].Rows[0]["ClienteId"].ToString());
            //txtSaldoVenta.Text = ds.Tables[0].Rows[0]["SaldoVenta"].ToString();



        }




        private void BtnModificarVenta_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposVenta();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjVenta();
                nResultado = objNegVenta.abmVenta("Modificar", objEntVenta);
                if (nResultado != -1)
                {
                    MessageBox.Show("la Venta fue modificada con éxito");
                    LimpiarVenta();
                    LlenarDGVVenta();
                    btnModificarVenta.Visible = false;
                    btnCargarVenta.Visible = true;
                    btnCancelarVenta.Visible = false;
                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar la Venta");
                }
            }

        }



        private void btnCancelarVenta_Click_1(object sender, EventArgs e)
        {
            LimpiarVenta();
            btnCargarVenta.Visible = true;
            btnModificarVenta.Visible = true;
            btnCancelarVenta.Visible = true;
            LlenarDGVVenta();
        }

        private void btnBuscarVenta_Click(object sender, EventArgs e)
        {
            LlenarDgVentaBuscar();
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {


            if (true)
            {

                DgEliminarVentaId();

                LlenarDGVVenta();

                MessageBox.Show("Se eliminaron los detalles de Venta");
            }
        }



        private void txtCantidadVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void txtSubtotalVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void cmbMedioPagoVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Form form2 = new FormRegistroCliente();
            form2.Show();
        }

        private void btnAgregarMetodoDePago_Click(object sender, EventArgs e)
        {
            Form form3 = new FormRegistroMetodoDePago();
            form3.Show();
        }

        private void cmbProductoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbClienteVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormRegistroVenta_Load(object sender, EventArgs e)
        {

        }


    }
}
