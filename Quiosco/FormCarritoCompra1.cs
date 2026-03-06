using Quiosco.Entidades;
using Quiosco.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormCarritoCompra1 : Form
    {
        private List<CarritoItem> carrito;
        private int idCliente;
        private decimal subtotal;

        private VentaNegocio objNegVenta = new VentaNegocio();
        private DetalleVentaNegocio objNegDetalle = new DetalleVentaNegocio();
        private ProductoNegocio objNegProducto = new ProductoNegocio();
        private MetodoDePagoNegocio objNegMetodoPago = new MetodoDePagoNegocio();
        private VentaMetodoPagoNegocio objNegVentaMetodoPago = new VentaMetodoPagoNegocio();

        private List<VentaMetodoPagoItem> pagos = new List<VentaMetodoPagoItem>();

        public FormCarritoCompra1(List<CarritoItem> carritoItems, int clienteId, decimal subtotalLocal)
        {
            InitializeComponent();

            carrito = carritoItems ?? new List<CarritoItem>();
            idCliente = clienteId;
            subtotal = subtotalLocal;
        }

        private void FormCarritoCompra1_Load(object sender, EventArgs e)
        {
            CargarResumen();
            CargarComboMetodosPago();
            ActualizarTotales();

            dgvPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarResumen()
        {
            dgvResumen.AutoGenerateColumns = false;
            dgvResumen.Columns.Clear();

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn { Name = "Producto", HeaderText = "Producto", DataPropertyName = "NombreProducto" });
            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "Precio Unit.", DataPropertyName = "PrecioUnitario" });
            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad" });
            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", DataPropertyName = "Subtotal" });

            dgvResumen.DataSource = carrito.Select(c => new
            {
                c.NombreProducto,
                PrecioUnitario = c.PrecioUnitario.ToString("#,##0.00"),
                c.Cantidad,
                Subtotal = c.Subtotal.ToString("#,##0.00")
            }).ToList();

            lblTotal.Text = subtotal.ToString("#,##0.00");
        }

        private void CargarComboMetodosPago()
        {
            cmbMedioPago.DataSource = objNegMetodoPago.ObtenerMetodoDePago();
            cmbMedioPago.DisplayMember = "NombreMetodoDePago";
            cmbMedioPago.ValueMember = "IdMetodoDePago";
            cmbMedioPago.SelectedIndex = -1;
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            if (cmbMedioPago.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un método de pago.");
                return;
            }

            // Cambiamos el parseo para que acepte decimales correctamente
            if (!decimal.TryParse(txtMontoPago.Text.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            int idMetodo = Convert.ToInt32(cmbMedioPago.SelectedValue);

            var existente = pagos.Find(p => p.IdMetodoDePago == idMetodo);
            if (existente != null)
                existente.Monto += monto;
            else
                pagos.Add(new VentaMetodoPagoItem { IdMetodoDePago = idMetodo, Monto = monto });

            txtMontoPago.Text = "";
            ActualizarGrillaPagos();
            ActualizarTotales();
        }

        private void ActualizarGrillaPagos()
        {
            dgvPagos.DataSource = null;
            dgvPagos.DataSource = pagos.Select(p => new
            {
                IdMetodo = p.IdMetodoDePago, // Sigue estando aquí para que el código no falle
                Metodo = objNegMetodoPago.ObtenerMetodoDePago().Find(m => m.IdMetodoDePago == p.IdMetodoDePago)?.NombreMetodoDePago,
                Monto = p.Monto.ToString("#,##0.00")
            }).ToList();

            // Verificamos que existan columnas y ocultamos la del ID (que es la 0)
            if (dgvPagos.Columns.Count > 0)
            {
                dgvPagos.Columns["IdMetodo"].Visible = false;

                // Opcional: Mejorar los encabezados de las columnas visibles
                dgvPagos.Columns["Metodo"].HeaderText = "Medio de Pago";
                dgvPagos.Columns["Monto"].HeaderText = "Monto Cargado";
            }
        }

        private decimal TotalPagado() => pagos.Sum(p => p.Monto);
        private decimal Deuda() => subtotal - TotalPagado();

        private void ActualizarTotales()
        {
            lblTotalPagado.Text = TotalPagado().ToString("#,##0.00");
            decimal deudaActual = Deuda();

            // Si la deuda es negativa, mostramos el valor para que el usuario vea cuánto sobra
            lblDeuda.Text = deudaActual.ToString("#,##0.00");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // 1. Validar montos
            decimal diferencia = subtotal - TotalPagado();
            if (Math.Abs(diferencia) > 0.01m) // Usamos un margen pequeño por decimales
            {
                string msj = diferencia > 0 ? $"Faltan: ${diferencia:N2}" : $"{diferencia:N2}";
                MessageBox.Show(msj, "Validación de Pago");
                return;
            }

            try
            {
                // 2. Crear objeto Venta
                // Crear objeto VENTA

                Venta v = new Venta
                {
                    SubtotalVenta = subtotal,
                    FechaVenta = DateTime.Now,
                    IdCliente = idCliente,
                    SaldoVenta = 0, // Como validamos diferencia == 0, el saldo es 0
                                    // Tomamos el primer método de la lista de pagos para cumplir con el NOT NULL de la DB
                    IdMetodoDePagoVenta = pagos.Count > 0 ? pagos[0].IdMetodoDePago : 1
                };

                // 3. Grabar Venta y obtener ID
                // IMPORTANTE: Tu Negocio/Datos debe retornar el ID generado
                int idVentaCreada = objNegVenta.abmVenta("Alta", v);

                if (idVentaCreada <= 0)
                {
                    MessageBox.Show("La base de datos no devolvió un ID de venta válido. Revise el procedimiento almacenado.", "Error de BD");
                    return;
                }

                // 4. Grabar Detalles
                foreach (var item in carrito)
                {
                    objNegDetalle.abmDetalleVenta("Alta", new DetalleVenta
                    {
                        IdVenta = idVentaCreada,
                        IdProducto = item.IdProducto,
                        CantidadProducto = item.Cantidad
                    });

                    // 5. Descontar Stock
                    objNegProducto.ReducirStock(item.IdProducto, item.Cantidad);
                }

                // 6. Grabar Pagos
                foreach (var pago in pagos)
                {
                    objNegVentaMetodoPago.AgregarPago(new VentaMetodoPago
                    {
                        IdVenta = idVentaCreada,
                        IdMetodoDePago = pago.IdMetodoDePago,
                        Monto = pago.Monto
                    });
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Este mensaje te dirá la verdad de por qué falla
                MessageBox.Show("ERROR DETALLADO: " + ex.Message + "\n\n" + ex.StackTrace, "Falla al grabar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnQuitarPago_Click(object sender, EventArgs e)
        {
            if (dgvPagos.CurrentRow == null) return;

            // Obtenemos el ID del pago de la lista anónima de la grilla
            var filaElegida = dgvPagos.CurrentRow.DataBoundItem;
            // Usamos reflexión simple para sacar el ID sin importar la columna
            int idMetodo = (int)filaElegida.GetType().GetProperty("IdMetodo").GetValue(filaElegida, null);

            var pago = pagos.Find(p => p.IdMetodoDePago == idMetodo);
            if (pago != null) pagos.Remove(pago);

            ActualizarGrillaPagos();
            ActualizarTotales();
        }

        private void dgvPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class VentaMetodoPagoItem
    {
        public int IdMetodoDePago { get; set; }
        public decimal Monto { get; set; }
    }
}
