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
        private int idMetodoPago;
        private decimal subtotal;

        private VentaNegocio objNegVenta = new VentaNegocio();
        private DetalleVentaNegocio objNegDetalle = new DetalleVentaNegocio();
        private ProductoNegocio objNegProducto = new ProductoNegocio();

        public FormCarritoCompra1(List<CarritoItem> carritoItems, int clienteId, int metodoPagoId, decimal subtotalLocal)
        {
            InitializeComponent();

            carrito = carritoItems ?? new List<CarritoItem>();
            idCliente = clienteId;
            idMetodoPago = metodoPagoId;
            subtotal = subtotalLocal;
        }

        private void FormCarritoCompra1_Load(object sender, EventArgs e)
        {
            CargarResumen();
        }

        private void CargarResumen()
        {
            dgvResumen.AutoGenerateColumns = false;
            dgvResumen.Columns.Clear();

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "NombreProducto", HeaderText = "Producto", DataPropertyName = "NombreProducto" });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PrecioUnitario", HeaderText = "Precio Unit.", DataPropertyName = "PrecioUnitario" });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Cantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad" });

            dgvResumen.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Subtotal", HeaderText = "Subtotal", DataPropertyName = "Subtotal" });

            dgvResumen.DataSource = carrito.Select(c => new
            {
                c.NombreProducto,
                PrecioUnitario = c.PrecioUnitario.ToString("#,##0.00"),
                c.Cantidad,
                Subtotal = c.Subtotal.ToString("#,##0.00")
            }).ToList();

            lblTotal.Text = subtotal.ToString("#,##0.00");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // VALIDACIÓN FINAL: STOCK
            foreach (var item in carrito)
            {
                var prod = objNegProducto.ObtenerProducto().Find(p => p.IdProducto == item.IdProducto);
                if (prod == null)
                {
                    MessageBox.Show($"Producto {item.NombreProducto} no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (prod.CantidadProducto < item.Cantidad)
                {
                    MessageBox.Show(
                        $"Stock insuficiente para {item.NombreProducto}. Disponible: {prod.CantidadProducto}",
                        "Stock insuficiente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            try
            {
                // 1️⃣ Crear VENTA
                Venta v = new Venta
                {
                    SubtotalVenta = subtotal,
                    FechaVenta = DateTime.Now,
                    IdMetodoDePagoVenta = idMetodoPago,
                    IdCliente = idCliente,
                    SaldoVenta = 0
                };

                int idVentaCreada = objNegVenta.abmVenta("Alta", v);
                if (idVentaCreada <= 0)
                    throw new Exception("No se pudo crear la venta.");

                // 2️⃣ Insertar DETALLES y descontar stock
                foreach (var item in carrito)
                {
                    DetalleVenta det = new DetalleVenta
                    {
                        IdVenta = idVentaCreada,
                        IdProducto = item.IdProducto,
                        CantidadProducto = item.Cantidad
                    };

                    int r = objNegDetalle.abmDetalleVenta("Alta", det);
                    if (r <= 0)
                        throw new Exception($"No se pudo insertar detalle para {item.NombreProducto}.");

                    objNegProducto.ReducirStock(item.IdProducto, item.Cantidad);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }



    }
}

