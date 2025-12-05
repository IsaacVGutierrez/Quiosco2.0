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
    public partial class FormRegistrarProducto : Form
    {
        public FormRegistrarProducto()
        {
            InitializeComponent();

            dgvProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvProducto.ColumnCount = 9;
            dgvProducto.Columns[0].HeaderText = "Nombre Producto";
            dgvProducto.Columns[1].HeaderText = "Marca Producto";
            dgvProducto.Columns[2].HeaderText = "Precio Producto";
            dgvProducto.Columns[3].HeaderText = "Categoria";
            dgvProducto.Columns[4].HeaderText = "Cantidad Producto";
            dgvProducto.Columns[5].HeaderText = "Distribuidor";
            dgvProducto.Columns[6].HeaderText = "Precio Compra";
            dgvProducto.Columns[7].HeaderText = "Precio Venta";
            dgvProducto.Columns[8].HeaderText = "Fecha de compra";

            txtPrecioCompraProducto.Text = "";
            txtPrecioVentaProducto.Text = "";
            txtPrecioTotalProducto.Text = "";


            LlenarDGVProducto();

            LlenarCombos();
            LlenarCombos2();


        }

        public Producto objEntProducto = new Producto();

        public ProductoNegocio objNegProducto = new ProductoNegocio();

        public bool ValidacionCamposProducto()
        {

            //Nombre Producto
            if (txtNombreProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreProducto.Text.Length > 100 || txtNombreProducto.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten Nombres de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            //Marca Producto
            if (txtMarcaProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Marca de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtMarcaProducto.Text.Length > 50 || txtMarcaProducto.Text.Length < 3)
            {
                MessageBox.Show("Solo se permiten Marcas de Producto entre 3 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Precio Total Producto
            if (txtPrecioTotalProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Precio Total de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPrecioTotalProducto.Text.Length > 100 || txtPrecioTotalProducto.Text.Length < 1)
            {
                MessageBox.Show("Solo se permite un Precio Total de Producto entre 5 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPrecioTotalProducto.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Categoria Producto
            if (cmbCategoriaProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Categoria de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbCategoriaProducto.Text.Length > 100 || cmbCategoriaProducto.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten Categoria de Producto entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbCategoriaProducto.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Cantidad Producto
            if (txtCantidadProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Cantidad Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCantidadProducto.Text.Length > 100 || txtCantidadProducto.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten  Cantidad Producto entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtCantidadProducto.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Distribuidor 
            if (cmbDistribuidorProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Distribuidor de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbDistribuidorProducto.Text.Length > 100 || cmbDistribuidorProducto.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten Distribuidor de Producto entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (cmbDistribuidorProducto.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }



            //Precio Compra de Producto
            if (txtPrecioCompraProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Precio Compra de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPrecioCompraProducto.Text.Length > 100 || txtPrecioCompraProducto.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten  Precio Compra de Producto entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPrecioCompraProducto.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }




            //Precio Venta de Producto
            if (txtPrecioVentaProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Precio Venta de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPrecioVentaProducto.Text.Length > 100 || txtPrecioVentaProducto.Text.Length < 1)
            {
                MessageBox.Show("Solo se permiten Precio Venta de Producto entre 1 y 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtPrecioVentaProducto.Text.Length > 200)
            {
                MessageBox.Show("La observación no puede superar los 200 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;







        }




        public void DgEliminarProductoId()
        {
            string id = txtEliminarProducto.Text;
            dgvProducto.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegProducto.ListarProductoEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvProducto.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
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

        private void LlenarDgProductoBuscar()
        {
            string cual = txtBuscarProducto.Text;
            dgvProducto.Rows.Clear();
            DataSet ds = new DataSet();

            ds = objNegProducto.listarProductoBuscar(cual);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvProducto.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8]);
                }
            }

        }


        private void LlenarDGVProducto()
        {

            dgvProducto.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegProducto.listadoProducto("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvProducto.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8].ToString());
                }
            }
        }


        #region DeclaracionVariables

        public Categoria objEntCategoria = new Categoria();
        public Proveedor objEntProveedor = new Proveedor();



        public CategoriaNegocio objNegCategoria = new CategoriaNegocio();
        public ProveedorNegocio objNegProveedor = new ProveedorNegocio();


        #endregion

        #region MetodoLlenarCombo
        private void LlenarCombos()
        {
            cmbCategoriaProducto.DataSource = objNegCategoria.ObtenerCategoria();
            cmbCategoriaProducto.DisplayMember = "NombreCategoria";
            cmbCategoriaProducto.ValueMember = "IdCategoria";
        }

        private void LlenarCombos2()
        {
            cmbDistribuidorProducto.DataSource = objNegProveedor.ObtenerProveedor();
            cmbDistribuidorProducto.DisplayMember = "NombreProveedor";
            cmbDistribuidorProducto.ValueMember = "IdProveedor";
        }


        #endregion




        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            DataSet ds = new DataSet();
            objEntProducto.IdProducto = Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value);
            ds = objNegProducto.listadoProducto(objEntProducto.IdProducto.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBoxProducto(ds);
                btnCargarProducto.Visible = false;
                btnModificarProducto.Visible = true;
                btnCancelarProducto.Visible = true;
            }
        }

        private void TxtBox_a_ObjProducto()
        {
            objEntProducto.NombreProducto = txtNombreProducto.Text;
            objEntProducto.MarcaProducto = txtMarcaProducto.Text;
            objEntProducto.PrecioProducto = decimal.Parse(txtPrecioTotalProducto.Text.Replace(".", ","));
            objEntCategoria.IdCategoria = int.Parse(cmbCategoriaProducto.SelectedValue.ToString());
            objEntProducto.CantidadProducto = int.Parse(txtCantidadProducto.Text);
            //objEntProducto.DistribuidorProducto = cmbDistribuidorProducto.Text;
            objEntProducto.PrecioCompra = decimal.Parse(txtPrecioCompraProducto.Text.Replace(".", ","));
            objEntProducto.PrecioVenta = decimal.Parse(txtPrecioVentaProducto.Text.Replace(".", ","));








        }

        private void LimpiarProducto()
        {
            txtNombreProducto.Text = string.Empty;
            txtMarcaProducto.Text = string.Empty;
            txtPrecioTotalProducto.Text = string.Empty;
            cmbCategoriaProducto.SelectedIndex = -1;
            txtCantidadProducto.Text = string.Empty;
            cmbDistribuidorProducto.SelectedIndex = -1;
            txtPrecioCompraProducto.Text = string.Empty;
            txtPrecioVentaProducto.Text = string.Empty;
            txtBuscarProducto.Clear();
            txtEliminarProducto.Clear();
        }
        private void Ds_a_TxtBoxProducto(DataSet ds)
        {

            txtNombreProducto.Text = ds.Tables[0].Rows[0]["NombreProducto"].ToString();
            txtMarcaProducto.Text = ds.Tables[0].Rows[0]["MarcaProducto"].ToString();
            txtPrecioTotalProducto.Text = ds.Tables[0].Rows[0]["PrecioTotalProducto"].ToString();
            cmbCategoriaProducto.SelectedValue = System.Convert.ToInt32(ds.Tables[0].Rows[0]["CategoriaId"].ToString());
            txtCantidadProducto.Text = ds.Tables[0].Rows[0]["CantidadProducto"].ToString();
            cmbDistribuidorProducto.SelectedValue = System.Convert.ToInt32(ds.Tables[0].Rows[0]["DistribuidorId"].ToString());
            txtPrecioCompraProducto.Text = ds.Tables[0].Rows[0]["PrecioCompraProducto"].ToString();
            txtPrecioVentaProducto.Text = ds.Tables[0].Rows[0]["PrecioVentaProducto"].ToString();
            dtFechaCompraProducto.Value = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["FechaCompraProducto"]);



        }




        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposProducto();
            int nGrabados = -1;
            if (validar == true)
            {
                TxtBox_a_ObjProducto();
                nGrabados = objNegProducto.abmProducto("Alta", objEntProducto);
                if (nGrabados == -1)
                {
                    MessageBox.Show("No se logró agregar el Producto al sistema");
                }
                else
                {
                    MessageBox.Show("Se logró agregar al Producto con éxito");
                    LlenarDGVProducto();
                    LimpiarProducto();

                }
            }
        }

        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposProducto();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjProducto();
                nResultado = objNegProducto.abmProducto("Modificar", objEntProducto);
                if (nResultado != -1)
                {
                    MessageBox.Show("el Producto fue modificada con éxito");
                    LimpiarProducto();
                    LlenarDGVProducto();
                    btnModificarProducto.Visible = false;
                    btnCargarProducto.Visible = true;
                    btnCancelarProducto.Visible = false;
                }
                else
                {
                    MessageBox.Show("Se produjo un error al intentar modificar el Producto");
                }
            }

        }



        private void btnCancelarProducto_Click_1(object sender, EventArgs e)
        {
            LimpiarProducto();
            btnCargarProducto.Visible = true;
            btnModificarProducto.Visible = true;
            btnCancelarProducto.Visible = true;
            LlenarDGVProducto();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            LlenarDgProductoBuscar();
        }

        private void btnEliminarProducto_Click_1(object sender, EventArgs e)
        {


            if (true)
            {

                DgEliminarProductoId();

                LlenarDGVProducto();

                MessageBox.Show("Se eliminaron los detalles de Producto");
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Form form2 = new FormRegistroCategoria();
            form2.Show();
        }


        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Form form2 = new FormRegistroProveedores();
            form2.Show();
        }

        private void dtFechaCompraProducto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CalcularTotal()
        {
            string precio = NormalizarNumero(txtPrecioCompraProducto.Text);
            string cantidad = txtCantidadProducto.Text.Replace(".", "");

            if (decimal.TryParse(precio, out decimal p) &&
                int.TryParse(cantidad, out int c))
            {
                decimal total = p * c;
                txtPrecioTotalProducto.Text = total.ToString("#,##0.00");
            }
            else
            {
                txtPrecioTotalProducto.Text = "0,00";
            }
        }


        private string NormalizarNumero(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "0";

            // Primero reemplazar punto por coma
            texto = texto.Replace(".", ",");

            // Ahora quitar separadores de miles
            // Pero solamente si hay más de una coma
            // Ej: "1.234,56" → "1,23456" → OK
            // Ej: "1.234" → "1,234" → OK
            // NO queremos borrar la coma decimal
            while (texto.IndexOf(',') != texto.LastIndexOf(','))
            {
                texto = texto.Remove(texto.IndexOf(','), 1);
            }

            return texto;
        }


        private string FormatoMilesDecimal(string texto)
        {
            texto = NormalizarNumero(texto);

            if (!decimal.TryParse(texto, out decimal valor))
                return "0,00";

            return valor.ToString("#,##0.00");
        }
        private string FormatoMilesEntero(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "0";

            texto = texto.Replace(".", "");

            if (!int.TryParse(texto, out int valor))
                return "0";

            return valor.ToString("#,##0");
        }


        private string FormatoMiles(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "0,00";

            // Reemplazar punto por coma
            texto = texto.Replace(".", ",");

            if (!decimal.TryParse(texto, out decimal valor))
                return "0,00";

            // Formato con miles y 2 decimales
            return valor.ToString("#,##0.00");
        }


        private void txtPrecioCompraProducto_Leave(object sender, EventArgs e)
        {
            txtPrecioCompraProducto.Text = FormatoMilesDecimal(txtPrecioCompraProducto.Text);
        }

        private void txtPrecioVentaProducto_Leave(object sender, EventArgs e)
        {
            txtPrecioVentaProducto.Text = FormatoMilesDecimal(txtPrecioVentaProducto.Text);
        }



        private void txtPrecioCompraProducto_TextChanged(object sender, EventArgs e)
        {
           CalcularTotal();
        }

        private void txtPrecioVentaProducto_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtCantidadProducto_TextChanged(object sender, EventArgs e)
        {
            if (!txtCantidadProducto.Focused)
                return;

            int pos = txtCantidadProducto.SelectionStart;

            txtCantidadProducto.Text = FormatoMilesEntero(txtCantidadProducto.Text);
            txtCantidadProducto.SelectionStart = Math.Min(pos + 1, txtCantidadProducto.Text.Length);

            CalcularTotal();
        }





        private void SoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (char.IsDigit(e.KeyChar))
                return;

            if (e.KeyChar == (char)Keys.Back)
                return;

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';

                if (txt.Text.Contains(','))
                {
                    e.Handled = true;
                    return;
                }

                if (txt.SelectionStart == 0)
                {
                    e.Handled = true;
                    return;
                }

                return;
            }

            e.Handled = true;
        }





        private void txtPrecioTotalProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void txtCantidadProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void txtPrecioCompraProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

            SoloDecimal_KeyPress(sender, e);

        }


        private void txtPrecioVentaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {

            SoloDecimal_KeyPress(sender, e);

        }

    }
}
