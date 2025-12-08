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
using System.Globalization;
using Quiosco.BD;
using System.Windows.Forms.DataVisualization.Charting;


namespace Quiosco
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();


            CargarGrafico();



            dgvDeudor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDeudor.ColumnCount = 4;
            dgvDeudor.Columns[0].HeaderText = "Codigo Cliente";
            dgvDeudor.Columns[1].HeaderText = "Nombre Cliente";
            dgvDeudor.Columns[2].HeaderText = "Telefono Cliente";
            dgvDeudor.Columns[3].HeaderText = "Adeuda Cliente";


            LlenarDGVDeudor();






        }




        public Cliente objEntDeudor = new Cliente();

        public ClienteNegocio objNegDeudor = new ClienteNegocio();


        private void CrearGrafico()
        {
            Chart chart = new Chart();
            chart.Parent = this; // Agregarlo al formulario
            chart.Dock = DockStyle.Fill; // Que ocupe todo el formulario

            // Crear el área del gráfico
            ChartArea area = new ChartArea("Area1");
            chart.ChartAreas.Add(area);

            // Crear la serie de datos
            Series serie = new Series("Serie1");
            serie.ChartType = SeriesChartType.Pie; // Gráfico de torta

            // EJEMPLO de datos
            serie.Points.AddXY("Ventas", 15000);
            serie.Points.AddXY("Compras", 5000);
            serie.Points.AddXY("Ganancias", 8000);

            chart.Series.Add(serie);

            // Estilo lindo
            serie["PieLabelStyle"] = "Outside";
            serie.BorderWidth = 2;
            serie.BorderColor = Color.White;
            chart.BackColor = Color.WhiteSmoke;

            this.Controls.Add(chart);
        }



        private void CargarGrafico()
        {
            chart1 = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();

            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);

            series1.ChartArea = "ChartArea1";
            series1.ChartType = SeriesChartType.Pie;
            series1.Name = "Series1";

            chart1.Series.Add(series1);

            chart1.Location = new Point(600, 150);
            chart1.Size = new Size(350, 300);
            chart1.BackColor = Color.WhiteSmoke;

            tabInicio.Controls.Add(chart1);
        }





        private void LlenarDGVDeudor()
        {
            dgvDeudor.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegDeudor.listadoCliente("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    decimal deuda = Convert.ToDecimal(dr["AdeudaCliente"]);

                    if (deuda > 0)   // 👈 solo agregar deudores reales
                    {
                        dgvDeudor.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2], deuda.ToString());
                    }
                }

            }
        }


        // HACE QUE AL BUSCAR SOLO MUESTRE LOS QUE TIENEN DEUDA MAYOR A 0 
        /*  
         private void LlenarDgDeudorBuscar()
{
    string cual = txtBuscarDeudor.Text;
    dgvDeudor.Rows.Clear();

    DataSet ds = objNegDeudor.listarClienteBuscar(cual);

    if (ds.Tables[0].Rows.Count > 0)
    {
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            decimal deuda = Convert.ToDecimal(dr["AdeudaCliente"]);

            if (deuda > 0)
            {
                dgvDeudor.Rows.Add(
                    dr["IdCliente"].ToString(),
                    dr["NombreCliente"].ToString(),
                    dr["TelefonoCliente"].ToString(),
                    deuda.ToString()
                );
            }
        }
    }
}           */


        private void LlenarDgDeudorBuscar()
        {
            string cual = txtBuscarDeudor.Text;
            dgvDeudor.Rows.Clear();
            DataSet ds = new DataSet();
            ds = objNegDeudor.listarClienteBuscar(cual);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvDeudor.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2], dr[3]);
                }
            }
        }

        /* private void TxtBox_a_ObjDeudor()
        {
            objEntDeudor.NombreCliente = txtNombreDeudor.Text;
            objEntDeudor.TelefonoCliente = txtTelefonoDeudor.Text;
            objEntDeudor.AdeudaCliente = int.Parse(txtAdeudaDeudor.Text);


        }

        private void Ds_a_TxtBoxDeudor(DataSet ds)
        {
            txtNombreDeudor.Text = ds.Tables[0].Rows[0]["NombreCliente"].ToString();
            txtTelefonoDeudor.Text = ds.Tables[0].Rows[0]["TelefonoCliente"].ToString();
            txtAdeudaDeudor.Text = ds.Tables[0].Rows[0]["AdeudaCliente"].ToString();

        }
        */

        /*
        public bool ValidacionCamposDeudor()
        {

            //Nombre
            if (txtNombreDeudor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Nombre de Deudor ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtNombreDeudor.Text.Length > 90 || txtNombreDeudor.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombre de 90 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Telefono
            if (txtTelefonoDeudor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un Telefono de Deudor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtTelefonoDeudor.Text.Length > 50 || txtTelefonoDeudor.Text.Length < 2)
            {
                MessageBox.Show("Solo se permiten nombres entre 2 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            //Adeuda
            if (txtAdeudaDeudor.Text == string.Empty)
            {
                MessageBox.Show("Ingrese si Adeuda un monto el Deudor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (txtAdeudaDeudor.Text.Length > 50 || txtAdeudaDeudor.Text.Length < 0)
            {
                MessageBox.Show("Solo se permiten precio entre 0 y 50 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;


        } */


        /*  private void btnModificarDeudor_Click(object sender, EventArgs e)
          {
              //bool validar = ValidacionCamposDeudor();
              int nResultado = -1;
              // if (validar == true)
              {
                  TxtBox_a_ObjDeudor();
                  nResultado = objNegDeudor.abmCliente("Modificar", objEntDeudor);
                  if (nResultado != -1)
                  {
                      MessageBox.Show("El Deudor fue modificado con éxito");
                      LimpiarDeudor();
                      LlenarDGVDeudor();
                      btnModificarDeudor.Visible = false;
                      // btnCargarCliente.Visible = true;
                      btnCancelarDeudor.Visible = false;
                  }
                  else
                  {
                      MessageBox.Show("Se produjo un error al intentar modificar el Deudor");
                  }
              }
          }
        */

        /*  private void dgvDeudor_CellClick(object sender, DataGridViewCellEventArgs e)
          {

              DataSet ds = new DataSet();
              objEntDeudor.IdCliente = Convert.ToInt32(dgvDeudor.CurrentRow.Cells[0].Value);
              ds = objNegDeudor.listadoCliente(objEntDeudor.IdCliente.ToString());
              if (ds.Tables[0].Rows.Count > 0)
              {
                  Ds_a_TxtBoxDeudor(ds);
                  // btnCargarDeudor.Visible = false;
                  btnModificarDeudor.Visible = true;
                  btnCancelarDeudor.Visible = true;
              }
          }*/


        private int selectedIdCliente = 0;
        private string selectedNombre = "";
        private decimal selectedDeuda = 0;

        private void dgvDeudor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hace clic en el encabezado, salir
            if (e.RowIndex < 0) return;

            var row = dgvDeudor.Rows[e.RowIndex];

            // Si hace clic en la fila nueva vacía (la del '*'), limpiar selección
            if (row.IsNewRow)
            {
                selectedIdCliente = 0;
                selectedNombre = "";
                selectedDeuda = 0;
                return;
            }

            // Validar que ninguna celda sea null
            if (row.Cells[0].Value == null ||
                row.Cells[1].Value == null ||
                row.Cells[3].Value == null)
            {
                selectedIdCliente = 0;
                selectedNombre = "";
                selectedDeuda = 0;
                return;
            }

            // Si todo está OK, cargar datos
            selectedIdCliente = Convert.ToInt32(row.Cells[0].Value);
            selectedNombre = row.Cells[1].Value.ToString();
            selectedDeuda = Convert.ToDecimal(row.Cells[3].Value);
        }

        /*

        private void txtNombreDeudor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefonoDeudor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void txtAdeudaDeudor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permite numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        */

        private void btnEliminarDeudor_Click(object sender, EventArgs e)
        {
            if (true)
            {

                DgEliminarDeudorId();

                LlenarDGVDeudor();

                MessageBox.Show("Se elimino el Deudor");
            }
        }




        public void DgEliminarDeudorId()
        {
            string id = txtEliminarDeudor.Text;
            dgvDeudor.Rows.Clear();
            DataSet ds = new DataSet();

            try
            {
                ds = objNegDeudor.ListarClienteEliminar(id);

                if (ds.Tables.Count >= 0)
                {
                    try
                    {
                        foreach (DataRow dr in ds.Tables)
                        {
                            dgvDeudor.Rows.Add(dr[0].ToString(), dr[1], dr[2], dr[3]);
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


        private void btnCancelarDeudor_Click(object sender, EventArgs e)
        {
            LimpiarDeudor();
            // btnCargarDeudor.Visible = true;
            //btnModificarDeudor.Visible = true;
            btnCancelarDeudor.Visible = true;
            LlenarDGVDeudor();
        }



        private void btnBuscarDeudor_Click(object sender, EventArgs e)
        {
            {
                LlenarDgDeudorBuscar();
            }
        }

        private void LimpiarDeudor()
        {
            // txtNombreDeudor.Text = string.Empty;
            // txtTelefonoDeudor.Text = string.Empty;
            // txtAdeudaDeudor.Text = string.Empty;
            txtBuscarDeudor.Clear();
            txtEliminarDeudor.Clear();
        }


        private void btnPagarDeudor_Click(object sender, EventArgs e)
        {
            if (selectedIdCliente == 0)
            {
                MessageBox.Show("Seleccione un Deudor primero.");
                return;
            }

            // Abrimos el formulario de pago pasando nombre + deuda que tenemos en memoria
            using (FormPagarDeudor fp = new FormPagarDeudor(selectedNombre, selectedDeuda))
            {
                var dr = fp.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    decimal monto = fp.MontoIngresado;

                    // --- LECTURA DE LA DEUDA REAL EN BD (verificación final) ---
                    DataSet ds = objNegDeudor.listadoCliente(selectedIdCliente.ToString());
                    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No se pudo obtener la deuda actual desde la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    decimal deudaActualEnBD;
                    try
                    {
                        deudaActualEnBD = Convert.ToDecimal(ds.Tables[0].Rows[0]["AdeudaCliente"]);
                    }
                    catch
                    {
                        MessageBox.Show("Valor de deuda en base de datos no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Comparación definitiva
                    if (monto > deudaActualEnBD)
                    {
                        MessageBox.Show($"El monto ingresado ({monto:0.00}) supera la deuda actual en la base (${deudaActualEnBD:0.00}). Operación cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Calcular nueva deuda
                    decimal nuevaDeuda = deudaActualEnBD - monto;

                    // Actualizar la deuda en la BD (objEntDeudor espera AdeudaCliente)
                    objEntDeudor.IdCliente = selectedIdCliente;
                    // si tu campo en la entidad es decimal, mantené decimal; si es int, convertí con cuidado
                    objEntDeudor.AdeudaCliente = nuevaDeuda;

                    // Ejecutar la modificación (tu método construye SQL con el valor que le pases)
                    objNegDeudor.abmCliente("ModificarSoloDeuda", objEntDeudor);

                    // Actualizar lo que tenés en memoria
                    selectedDeuda = nuevaDeuda;

                    MessageBox.Show("Pago realizado", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // refrescar la grilla
                    LlenarDGVDeudor();
                }
            }
        }






        private DetalleVentaNegocio objNegDetalle = new DetalleVentaNegocio();

        private void FormInicio_Load(object sender, EventArgs e)
        {
            CargarDetalleVenta();
            CargarProductosEnStock();
            CrearGrafico();
        }

        private void CargarDetalleVenta()
        {
            try
            {
                dgvDetalleVenta.DataSource = objNegDetalle.Union().Tables[0];

                // Ocultar columnas que no querés mostrar
                dgvDetalleVenta.Columns["IdDetalleVenta"].Visible = false;
                dgvDetalleVenta.Columns["IdVenta"].Visible = false;
                dgvDetalleVenta.Columns["IdProducto"].Visible = false;


                // Renombrar headers
                dgvDetalleVenta.Columns["NombreCliente"].HeaderText = "Cliente";
                dgvDetalleVenta.Columns["NombreProducto"].HeaderText = "Producto";
                dgvDetalleVenta.Columns["CantidadProducto"].HeaderText = "Cantidad";
                dgvDetalleVenta.Columns["PrecioVenta"].HeaderText = "Precio Unit.";
                dgvDetalleVenta.Columns["SubtotalVenta"].HeaderText = "Subtotal";
                dgvDetalleVenta.Columns["FechaVenta"].HeaderText = "Fecha";
                dgvDetalleVenta.Columns["NombreMetodoDePago"].HeaderText = "Metodo De Pago";

                /* // Reordenar columnas → NombreCliente primero
                 dgvDetalleVenta.Columns["NombreCliente"].DisplayIndex = 0;
                 dgvDetalleVenta.Columns["NombreProducto"].DisplayIndex = 1;
                 dgvDetalleVenta.Columns["Cantidad"].DisplayIndex = 2;
                 dgvDetalleVenta.Columns["PrecioUnitario"].DisplayIndex = 3;
                 dgvDetalleVenta.Columns["Subtotal"].DisplayIndex = 4;
                 dgvDetalleVenta.Columns["FechaVenta"].DisplayIndex = 5;

                 // Ajustar tamaño automático
                 dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                */


                // -------------------------------
                // FORMATO ESPECIAL
                // -------------------------------

                // Cantidad: número entero
                dgvDetalleVenta.Columns["CantidadProducto"].DefaultCellStyle.Format = "N0";

                // Precio unitario con 2 decimales
                dgvDetalleVenta.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
                dgvDetalleVenta.Columns["PrecioVenta"].DefaultCellStyle.FormatProvider =
                    new CultureInfo("es-AR");

                // Subtotal con símbolo de moneda (configuración local)
                dgvDetalleVenta.Columns["SubtotalVenta"].DefaultCellStyle.Format = "C2";
                dgvDetalleVenta.Columns["SubtotalVenta"].DefaultCellStyle.FormatProvider =
                    new CultureInfo("es-AR");

                // Fecha formato argentino
                //dgvDetalleVenta.Columns["FechaVenta"].DefaultCellStyle.Format = "dd/MM/yyyy";

                // ORDENAR columnas manualmente
                dgvDetalleVenta.Columns["NombreCliente"].DisplayIndex = 2;
                dgvDetalleVenta.Columns["NombreProducto"].DisplayIndex = 3;
                dgvDetalleVenta.Columns["MarcaProducto"].DisplayIndex = 4;
                dgvDetalleVenta.Columns["NombreMetodoDePago"].DisplayIndex = 8;
                dgvDetalleVenta.Columns["PrecioVenta"].DisplayIndex = 6;
                dgvDetalleVenta.Columns["SubtotalVenta"].DisplayIndex = 7;
                dgvDetalleVenta.Columns["CantidadProducto"].DisplayIndex = 5;
                dgvDetalleVenta.Columns["FechaVenta"].DisplayIndex = 9;






                // Ajustar tamaño automático
                AjustarTamañoDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle de ventas: " + ex.Message);
            }
        }

        private void AjustarTamañoDGV()
        {
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDetalleVenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvDetalleVenta.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }





        private void btnBuscarDetalleVenta_Click(object sender, EventArgs e)
        {
            string buscar = txtBuscarDetalleVenta.Text.Trim();

            if (string.IsNullOrWhiteSpace(buscar))
            {
                CargarDetalleVenta();
                return;
            }

            try
            {
                dgvDetalleVenta.DataSource = objNegDetalle.listarDetalleVentaBuscar(buscar).Tables[0];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar detalle de venta: " + ex.Message);
            }
        }










        private void CargarProductosEnStock()
        {
            ListaProductos lp = new ListaProductos();
            dgvStockProductos.DataSource = lp.ObtenerProductosEnStock().Tables[0];

            // ocultar ID si querés
            dgvStockProductos.Columns["IdProducto"].Visible = false;

            // formatear precio
            dgvStockProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "#,##0.00";
            dgvStockProductos.Columns["PrecioVenta"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR");

            // auto size
            dgvStockProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }




        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            ListaProductos lp = new ListaProductos();

            if (txtBuscarStockProductos.Text.Trim() == "")
            {
                CargarProductosEnStock();
                return;
            }

            dgvStockProductos.DataSource = lp.BuscarProductosEnStock(txtBuscarStockProductos.Text).Tables[0];
        }






        private void btnRegistrarProducto_Click(object sender, EventArgs e)
        {
            Form form2 = new FormRegistrarProducto();
            form2.Show();
        }

        private void tabProveedor_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCaja_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            Form form3 = new FormRegistroVenta();
            form3.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void VENTA_Click(object sender, EventArgs e)
        {

        }


    }
}
