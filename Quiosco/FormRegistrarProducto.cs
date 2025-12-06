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

            // 10 columnas según tu diseño
            dgvProducto.ColumnCount = 11;
            dgvProducto.Columns[0].HeaderText = "Codigo Producto";
            dgvProducto.Columns[1].HeaderText = "Nombre Producto";
            dgvProducto.Columns[2].HeaderText = "Marca Producto";
            dgvProducto.Columns[3].HeaderText = "Precio Producto";
            dgvProducto.Columns[4].HeaderText = "Categoria";
            dgvProducto.Columns[5].HeaderText = "Cantidad Producto";
            dgvProducto.Columns[6].HeaderText = "Distribuidor";
            dgvProducto.Columns[7].HeaderText = "Precio Compra";
            dgvProducto.Columns[8].HeaderText = "Precio Venta";
            dgvProducto.Columns[9].HeaderText = "Medio de Pago";
            dgvProducto.Columns[10].HeaderText = "Fecha de compra";



            txtPrecioCompraProducto.Text = "";
            txtPrecioVentaProducto.Text = "";
            txtPrecioTotalProducto.Text = "";

            LlenarCombos();
            LlenarCombos2();
            LlenarCombos3();
            LlenarDGVProducto();
            FormatearColumnasDGV();
           
        }

        // Entidades / Negocios
        public Producto objEntProducto = new Producto();
        public ProductoNegocio objNegProducto = new ProductoNegocio();

        public CompraProducto objEntCompra = new CompraProducto();
        public CompraProductoNegocio objNegCompra = new CompraProductoNegocio();

        public DetalleCompra objEntDetalle = new DetalleCompra();
        public DetalleCompraNegocio objNegDetalle = new DetalleCompraNegocio();

        public MetodoDePago objEntMetodoDePago = new MetodoDePago();
        public MetodoDePagoNegocio objNegMetodoDePago = new MetodoDePagoNegocio();

        public Categoria objEntCategoria = new Categoria();
        public Proveedor objEntProveedor = new Proveedor();


        public CategoriaNegocio objNegCategoria = new CategoriaNegocio();
        public ProveedorNegocio objNegProveedor = new ProveedorNegocio();


        #region Validaciones

        public bool ValidacionCamposProducto()
        {
            // --- tus validaciones originales ---
            if (txtNombreProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtNombreProducto.Text.Length > 100 || txtNombreProducto.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten Nombres de 100 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtMarcaProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Marca de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtMarcaProducto.Text.Length > 50 || txtMarcaProducto.Text.Length < 3)
            {
                MessageBox.Show("Solo se permiten Marcas de Producto entre 3 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPrecioTotalProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Precio Total de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbCategoriaProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese una Categoria de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtCantidadProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Cantidad Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbDistribuidorProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Distribuidor de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPrecioCompraProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Precio Compra de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (txtPrecioVentaProducto.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Precio Venta de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cmbMetodoPago.Text == string.Empty)
            {
                MessageBox.Show("Ingrese Metodo de Pago de Producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region Combos / Grilla

        private void LlenarCombos()
        {
            cmbCategoriaProducto.DataSource = objNegCategoria.ObtenerCategoria();
            cmbCategoriaProducto.DisplayMember = "NombreCategoria";
            cmbCategoriaProducto.ValueMember = "IdCategoria";
            cmbCategoriaProducto.SelectedIndex = -1;
        }

        private void LlenarCombos2()
        {
            cmbDistribuidorProducto.DataSource = objNegProveedor.ObtenerProveedor();
            cmbDistribuidorProducto.DisplayMember = "NombreProveedor";
            cmbDistribuidorProducto.ValueMember = "IdProveedor";
            cmbDistribuidorProducto.SelectedIndex = -1;
        }

        private void LlenarCombos3()
        {
            cmbMetodoPago.DataSource = objNegMetodoDePago.ObtenerMetodoDePago();
            cmbMetodoPago.DisplayMember = "NombreMetodoDePago";
            cmbMetodoPago.ValueMember = "IdMetodoDePago";
            cmbMetodoPago.SelectedIndex = -1;
        }

        private void LlenarDGVProducto()
        {
            dgvProducto.Rows.Clear();
            // Usamos UNION (que devolverá los campos necesarios)
            DataSet ds = objNegProducto.Union();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    // Mapear exactamente 10 columnas: IdProducto, Nombre, Marca, PrecioProducto, Categoria, Cantidad, Distribuidor, PrecioCompra, PrecioVenta, FechaCompra
                    dgvProducto.Rows.Add(
                      dr["IdProducto"],
                      dr["NombreProducto"],
                      dr["MarcaProducto"],
                      dr["PrecioProducto"],
                      dr["NombreCategoria"],
                      dr["CantidadProducto"],
                      dr["NombreProveedor"] == DBNull.Value ? "" : dr["NombreProveedor"],
                      dr["PrecioCompra"],
                      dr["PrecioVenta"],
                      dr["NombreMetodoDePago"] == DBNull.Value ? "" : dr["NombreMetodoDePago"], // 💥 método de pago
                      dr["FechaCompraProductos"] == DBNull.Value ? "" : Convert.ToDateTime(dr["FechaCompraProductos"]).ToString("yyyy-MM-dd")
   );
                    FormatearColumnasDGV();
                }
            }
        }

        #endregion

        #region Conversores Entidades <-> Controles

        private void TxtBox_a_ObjProducto()
        {
            // ID DEL PRODUCTO DESDE EL DGV
            if (dgvProducto.CurrentRow != null && dgvProducto.CurrentRow.Cells[0].Value != null)
                objEntProducto.IdProducto = Convert.ToInt32(dgvProducto.CurrentRow.Cells[0].Value);

            objEntProducto.NombreProducto = txtNombreProducto.Text.Trim();
            objEntProducto.MarcaProducto = txtMarcaProducto.Text.Trim();
            objEntProducto.PrecioProducto = ConvertirDecimal(txtPrecioTotalProducto.Text);
            objEntProducto.IdCategoria = int.Parse(cmbCategoriaProducto.SelectedValue.ToString());
            objEntProducto.CantidadProducto = int.Parse(txtCantidadProducto.Text.Replace(".", "").Replace(",", "."));
            objEntProducto.PrecioCompra = ConvertirDecimal(txtPrecioCompraProducto.Text);
            objEntProducto.PrecioVenta = ConvertirDecimal(txtPrecioVentaProducto.Text);

                 


        }


        private void LimpiarProducto()
        {
            txtNombreProducto.Text = string.Empty;
            txtMarcaProducto.Text = string.Empty;
            txtPrecioTotalProducto.Text = string.Empty;
            cmbCategoriaProducto.SelectedIndex = -1;
            txtCantidadProducto.Text = string.Empty;
            cmbDistribuidorProducto.SelectedIndex = -1;
            cmbMetodoPago.SelectedIndex = -1;
            txtPrecioCompraProducto.Text = string.Empty;
            txtPrecioVentaProducto.Text = string.Empty;
            txtBuscarProducto.Clear();
            txtEliminarProducto.Clear();
        }

        #endregion

        #region Eventos de grilla / botones

        private decimal DGV_ObtenerDecimal(DataGridViewCell cell)
        {
            if (cell == null || cell.Value == null)
                return 0;

            string valor = cell.Value.ToString();

            valor = valor.Replace(".", "").Replace(",", ".");

            decimal.TryParse(valor, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal num);

            return num;
        }


        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducto.Rows[e.RowIndex];

            if (row.Cells[0].Value == null) return;

            int id = Convert.ToInt32(row.Cells[0].Value);
            DataSet ds = objNegProducto.listadoProducto(id.ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBoxProducto(ds); // ← PRIMERO cargamos todo

                // ← AL FINAL recién tomamos el valor real del DGV
                decimal precio = DGV_ObtenerDecimal(dgvProducto.Rows[e.RowIndex].Cells[3]);
                txtPrecioTotalProducto.Text = precio.ToString("#,##0.00");

                btnCargarProducto.Visible = false;
                btnModificarProducto.Visible = true;
                btnCancelarProducto.Visible = true;
            }
        }


        private void Ds_a_TxtBoxProducto(DataSet ds)
        {
            var r = ds.Tables[0].Rows[0];
            txtNombreProducto.Text = r["NombreProducto"].ToString();
            txtMarcaProducto.Text = r["MarcaProducto"].ToString();

            // Algunos nombres de columnas varían, intentamos fallbacks
            if (ds.Tables[0].Columns.Contains("PrecioProducto"))
                txtPrecioTotalProducto.Text = Convert.ToDecimal(r["PrecioProducto"]).ToString("#,##0.00");
            if (ds.Tables[0].Columns.Contains("PrecioCompra"))
                txtPrecioCompraProducto.Text = Convert.ToDecimal(r["PrecioCompra"]).ToString("#,##0.00");
            if (ds.Tables[0].Columns.Contains("PrecioVenta"))
                txtPrecioVentaProducto.Text = Convert.ToDecimal(r["PrecioVenta"]).ToString("#,##0.00");

            if (ds.Tables[0].Columns.Contains("CantidadProducto"))
                txtCantidadProducto.Text = r["CantidadProducto"].ToString();

            if (ds.Tables[0].Columns.Contains("IdCategoria"))
                cmbCategoriaProducto.SelectedValue = Convert.ToInt32(r["IdCategoria"]);

            if (ds.Tables[0].Columns.Contains("IdMetodoDePago"))
                cmbMetodoPago.SelectedValue = Convert.ToInt32(r["IdMetodoDePago"]);

            // Si venís guardando DistribuidorId en producto, setear; sino no hace nada
            if (ds.Tables[0].Columns.Contains("IdProveedor"))
                cmbDistribuidorProducto.SelectedValue = Convert.ToInt32(r["IdProveedor"]);

            if (ds.Tables[0].Columns.Contains("IdCompraProducto"))
                objEntCompra.IdCompraProducto = Convert.ToInt32(r["IdCompraProducto"]);

        }

        #endregion

        #region Cargar => CompraProducto + Producto + DetalleCompra (atomic-ish)

        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposProducto();
            if (!validar) return;

            TxtBox_a_ObjProducto();

            // --- Preparar compra ---
            objEntCompra = new CompraProducto();
            decimal subtotal = objEntProducto.PrecioCompra * objEntProducto.CantidadProducto; // subtotal para la compra
            objEntCompra.SubtotalCompraProducto = subtotal;
            // Fecha: toma del control dtFechaCompraProducto si existe, si no DateTime.Now
            DateTime fechaCompra = DateTime.Now;
            try
            {
                // si tenes control dtFechaCompraProducto en el form:
                if (this.Controls.ContainsKey("dtFechaCompraProducto"))
                {
                    var ctrl = this.Controls["dtFechaCompraProducto"] as DateTimePicker;
                    if (ctrl != null) fechaCompra = ctrl.Value;
                }
            }
            catch { }
            objEntCompra.FechaCompraProductos = fechaCompra;

            // Metodo de Pago
            if (cmbMetodoPago.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un método de pago válido");
                return;
            }

            objEntCompra.IdMetodoDePago = Convert.ToInt32(cmbMetodoPago.SelectedValue);


            // Proveedor (obligatorio)
            if (cmbDistribuidorProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un distribuidor válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            objEntCompra.IdProveedor = Convert.ToInt32(cmbDistribuidorProducto.SelectedValue);

            int idCompraCreada = -1;
            int idProductoCreado = -1;
            int idDetalleCreado = -1;

            try
            {
                // 1) Insertar CompraProducto -> obtener Id
                idCompraCreada = objNegCompra.abmCompraProducto("Alta", objEntCompra);
                if (idCompraCreada <= 0)
                    throw new Exception("No se pudo crear el registro de CompraProducto.");

                // 2) Insertar Producto -> obtener Id (objEntProducto debe contener todos los datos)
                idProductoCreado = objNegProducto.abmProducto("Alta", objEntProducto);
                if (idProductoCreado <= 0)
                    throw new Exception("No se pudo crear el registro de Producto. Se eliminará la compra creada.");

                // 3) Insertar DetalleCompra con IdCompraProducto e IdProducto
                objEntDetalle = new DetalleCompra();
                objEntDetalle.IdCompraProducto = idCompraCreada;
                objEntDetalle.IdProducto = idProductoCreado;
                objEntDetalle.CantidadProducto = objEntProducto.CantidadProducto;

                idDetalleCreado = objNegDetalle.abmDetalleCompra("Alta", objEntDetalle);
                if (idDetalleCreado <= 0)
                    throw new Exception("No se pudo crear el DetalleCompra. Se eliminarán registros previos.");

                // todo ok
                MessageBox.Show("Se cargó correctamente Compra + Producto + Detalle.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarProducto();
                LlenarDGVProducto();
            }
            catch (Exception ex)
            {
                // Intentar limpieza manual en caso de fallo parcial
                try
                {
                    if (idDetalleCreado > 0)
                    {
                        // eliminar detalle
                        objNegDetalle.ListarDetalleCompraEliminar(idDetalleCreado.ToString());
                    }
                }
                catch { }

                try
                {
                    if (idProductoCreado > 0)
                    {
                        // eliminar producto
                        objNegProducto.ListarProductoEliminar(idProductoCreado);

                    }
                }
                catch { }

                try
                {
                    if (idCompraCreada > 0)
                    {
                        // eliminar compra
                        objNegCompra.ListarCompraProductoEliminar(idCompraCreada.ToString());
                    }
                }
                catch { }

                MessageBox.Show("Error al cargar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Busqueda / Eliminación

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            LlenarDgProductoBuscar();
        }

        private void LlenarDgProductoBuscar()
        {
            string cual = txtBuscarProducto.Text;
            dgvProducto.Rows.Clear();
            DataSet ds = objNegProducto.listarProductoBuscar(cual);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvProducto.Rows.Add(
                        dr["IdProducto"],                              // 0
                        dr["NombreProducto"],                          // 1
                        dr["MarcaProducto"],                           // 2
                        dr["PrecioProducto"],                          // 3
                        dr["NombreCategoria"],                         // 4
                        dr["CantidadProducto"],                        // 5
                        dr["NombreProveedor"],                         // 6
                        dr["PrecioCompra"],                            // 7
                        dr["PrecioVenta"],                             // 8
                        dr["NombreMetodoDePago"],                      // 9
                        dr["FechaCompraProductos"] != DBNull.Value
                            ? Convert.ToDateTime(dr["FechaCompraProductos"]).ToString("yyyy-MM-dd")
                            : ""                                       // 10
                    );
                }
            }
        }


        private void btnEliminarProducto_Click_1(object sender, EventArgs e)
        {
            DgEliminarProductoId();
            LlenarDGVProducto();
            MessageBox.Show("Se eliminaron los detalles de Producto");
        }


        public void DgEliminarProductoId()
        {
            if (!int.TryParse(txtEliminarProducto.Text, out int id))
            {
                MessageBox.Show("Ingrese un ID válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool eliminado = objNegProducto.ListarProductoEliminar(id);

                if (eliminado)
                    MessageBox.Show("Producto y registros asociados eliminados correctamente.");
                else
                    MessageBox.Show("No se encontró el producto o no se pudo eliminar.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }


        #endregion

        #region Formato y utilidades (tu código original)

        private void CalcularTotal()
        {
            string precio = FormatoMilesDecimal(txtPrecioCompraProducto.Text);
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


        private void FormatearColumnasDGV()
        {
            // Precio Producto (columna 3)
            dgvProducto.Columns[3].DefaultCellStyle.Format = "N2";

            // Cantidad Producto (columna 5)
            dgvProducto.Columns[5].DefaultCellStyle.Format = "N0";

            // Precio Compra (columna 7)
            dgvProducto.Columns[7].DefaultCellStyle.Format = "N2";

            // Precio Venta (columna 8)
            dgvProducto.Columns[8].DefaultCellStyle.Format = "N2";

           
        }

        private decimal ConvertirDecimal(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return 0;

            // 1) Eliminar miles (.)
            texto = texto.Replace(".", "");

            // 2) Reemplazar coma por punto
            texto = texto.Replace(",", ".");

            // 3) Intentar parsear con cultura invariante
            if (decimal.TryParse(texto, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal d))
                return d;

            // Si falla, retornar 0 (o podrías lanzar excepción)
            return 0;
        }






        private string FormatoMilesDecimal(string texto)
        {
            // limpiar primero
            texto = texto.Replace(".", "").Replace(",", ".");

            if (!decimal.TryParse(texto, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal valor))
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

        private void txtPrecioCompraProducto_Leave(object sender, EventArgs e)
        {
            txtPrecioCompraProducto.Text = FormatoMilesDecimal(txtPrecioCompraProducto.Text);
        }

        private void txtPrecioVentaProducto_Leave(object sender, EventArgs e)
        {
            txtPrecioVentaProducto.Text = FormatoMilesDecimal(txtPrecioVentaProducto.Text);
        }

        private void txtPrecioCompraProducto_TextChanged(object sender, EventArgs e) => CalcularTotal();
        private void txtPrecioVentaProducto_TextChanged(object sender, EventArgs e) => CalcularTotal();

        private void txtCantidadProducto_TextChanged(object sender, EventArgs e)
        {
            if (!txtCantidadProducto.Focused) return;
            int pos = txtCantidadProducto.SelectionStart;
            txtCantidadProducto.Text = FormatoMilesEntero(txtCantidadProducto.Text);
            txtCantidadProducto.SelectionStart = Math.Min(pos + 1, txtCantidadProducto.Text.Length);
            CalcularTotal();
        }

        private void SoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == (char)Keys.Back) return;
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
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
        private void txtPrecioCompraProducto_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimal_KeyPress(sender, e);
        private void txtPrecioVentaProducto_KeyPress(object sender, KeyPressEventArgs e) => SoloDecimal_KeyPress(sender, e);

        #endregion





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


        private void BtnModificarProducto_Click(object sender, EventArgs e)
        {
            bool validar = ValidacionCamposProducto();
            int nResultado = -1;
            if (validar == true)
            {
                TxtBox_a_ObjProducto();
                nResultado = objNegProducto.abmProducto("Modificar", objEntProducto);

                // Modificar compra asociada
                objEntCompra.IdProveedor = Convert.ToInt32(cmbDistribuidorProducto.SelectedValue);
                objEntCompra.IdMetodoDePago = Convert.ToInt32(cmbMetodoPago.SelectedValue);
                objEntCompra.FechaCompraProductos = dtFechaCompraProducto.Value;

                objNegCompra.ModificarCompra(objEntCompra);

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

        private void btnAgregarMetodoDePago_Click(object sender, EventArgs e)
        {
            Form form3 = new FormRegistroMetodoDePago();
            form3.Show();
        }
    }

}
