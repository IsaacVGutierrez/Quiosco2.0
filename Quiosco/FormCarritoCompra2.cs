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
    public partial class FormCarritoCompra2 : Form
    {
        private List<CarritoItem> carrito;
        private int idCliente;
        private int idMetodoPago;
        private decimal subtotal;

        private VentaNegocio objNegVenta = new VentaNegocio();
        private DetalleVentaNegocio objNegDetalle = new DetalleVentaNegocio();
        private ProductoNegocio objNegProducto = new ProductoNegocio();

        public FormCarritoCompra2(List<CarritoItem> carritoItems, int clienteId, int metodoPagoId, decimal subtotalLocal)
        {
            InitializeComponent();
            carrito = carritoItems ?? new List<CarritoItem>();
            idCliente = clienteId;
            idMetodoPago = metodoPagoId;
            subtotal = subtotalLocal;

            // CargarResumen();
        }

        /*  private void CargarResumen()
          {
              dgvResumen.AutoGenerateColumns = false;
              dgvResumen.Columns.Clear();

              dgvResumen.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreProducto", HeaderText = "Producto", DataPropertyName = "NombreProducto" });
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
          } */

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // Validaciones finales: stock disponible (vuelvo a comprobar por si algo cambió)
            foreach (var item in carrito)
            {
                var prod = objNegProducto.ObtenerProducto().Find(p => p.IdProducto == item.IdProducto);
                if (prod == null)
                {
                    MessageBox.Show($"Producto {item.NombreProducto} no encontrado. La venta no puede continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }
                if (prod.CantidadProducto < item.Cantidad)
                {
                    MessageBox.Show($"Stock insuficiente para {item.NombreProducto}. Disponible: {prod.CantidadProducto}.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;
                    return;
                }
            }

            try
            {
                // 1) Crear entidad Venta
                Quiosco.Entidades.Venta v = new Quiosco.Entidades.Venta
                {
                    SubtotalVenta = subtotal,
                    FechaVenta = DateTime.Now,
                    IdMetodoDePagoVenta = idMetodoPago,
                    IdCliente = idCliente,
                    SaldoVenta = 0 // ajustar según tu lógica
                };

                int idVentaCreada = objNegVenta.abmVenta("Alta", v);
                if (idVentaCreada <= 0)
                    throw new Exception("No se pudo crear el registro de Venta.");

                // 2) Insertar cada detalle y descontar stock
                foreach (var item in carrito)
                {
                    Quiosco.Entidades.DetalleVenta det = new Quiosco.Entidades.DetalleVenta
                    {
                        IdVenta = idVentaCreada,
                        IdProducto = item.IdProducto,
                        CantidadProducto = item.Cantidad
                    };

                    int r = objNegDetalle.abmDetalleVenta("Alta", det);
                    if (r <= 0)
                        throw new Exception($"No se pudo insertar detalle para {item.NombreProducto}.");

                    // Reducir stock
                    objNegProducto.ReducirStock(item.IdProducto, item.Cantidad);
                }

                // Todo OK
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



        private void FormCarritoCompra2_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

