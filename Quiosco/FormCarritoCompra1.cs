using Quiosco.Entidades;
using Quiosco.Negocio;
using System;
using System.Collections.Generic;
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

            if (!decimal.TryParse(txtMontoPago.Text.Replace(".", "").Replace(",", "."), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            int idMetodo = Convert.ToInt32(cmbMedioPago.SelectedValue);

            // Evitamos duplicados: sumamos si ya existe
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
                Metodo = objNegMetodoPago.ObtenerMetodoDePago().Find(m => m.IdMetodoDePago == p.IdMetodoDePago)?.NombreMetodoDePago,
                Monto = p.Monto.ToString("#,##0.00")
            }).ToList();
        }

        private decimal TotalPagado() => pagos.Sum(p => p.Monto);

        private decimal Deuda() => subtotal - TotalPagado();

        private void ActualizarTotales()
        {
            lblTotalPagado.Text = TotalPagado().ToString("#,##0.00");
            lblDeuda.Text = Deuda() > 0 ? Deuda().ToString("#,##0.00") : "0,00";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN FINAL: STOCK
            foreach (var item in carrito)
            {
                var prod = objNegProducto.ObtenerProducto().Find(p => p.IdProducto == item.IdProducto);
                if (prod == null)
                {
                    MessageBox.Show($"Producto {item.NombreProducto} no encontrado.", "Error");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (prod.CantidadProducto < item.Cantidad)
                {
                    MessageBox.Show($"Stock insuficiente para {item.NombreProducto}. Disponible: {prod.CantidadProducto}");
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            try
            {
                // Crear VENTA
                Venta v = new Venta
                {
                    SubtotalVenta = subtotal,
                    FechaVenta = DateTime.Now,
                    IdCliente = idCliente,
                    SaldoVenta = Deuda() > 0 ? Deuda() : 0
                };

                int idVentaCreada = objNegVenta.abmVenta("Alta", v);
                if (idVentaCreada <= 0)
                    throw new Exception("No se pudo crear la venta.");

                // Insertar DETALLES y descontar stock
                foreach (var item in carrito)
                {
                    objNegDetalle.abmDetalleVenta("Alta", new DetalleVenta
                    {
                        IdVenta = idVentaCreada,
                        IdProducto = item.IdProducto,
                        CantidadProducto = item.Cantidad
                    });
                    objNegProducto.ReducirStock(item.IdProducto, item.Cantidad);
                }

                // Guardar PAGOS
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
                MessageBox.Show("Error al confirmar la venta: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
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
            string metodo = dgvPagos.CurrentRow.Cells["Metodo"].Value.ToString();
            var pago = pagos.Find(p => objNegMetodoPago.ObtenerMetodoDePago().Find(m => m.IdMetodoDePago == p.IdMetodoDePago)?.NombreMetodoDePago == metodo);
            if (pago != null)
                pagos.Remove(pago);

            ActualizarGrillaPagos();
            ActualizarTotales();
        }
    }

    public class VentaMetodoPagoItem
    {
        public int IdMetodoDePago { get; set; }
        public decimal Monto { get; set; }
    }
}
