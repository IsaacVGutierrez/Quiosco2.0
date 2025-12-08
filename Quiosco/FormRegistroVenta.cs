using Quiosco.Entidades;
using Quiosco.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Quiosco
{
    public partial class FormRegistroVenta : Form
    {
        // Carrito local (temporal)
        private List<CarritoItem> carrito = new List<CarritoItem>();

        #region DeclaracionVariables


        public ProductoNegocio objNegProducto = new ProductoNegocio();
        public ClienteNegocio objNegCliente = new ClienteNegocio();
        public MetodoDePagoNegocio objNegMetodoDePago = new MetodoDePagoNegocio();


        #endregion
        public FormRegistroVenta()
        {
            InitializeComponent();

            // Config DGV carrito
            dgvVenta.AutoGenerateColumns = false;
            dgvVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVenta.Columns.Clear();

            // Columnas: IdProducto (oculto), Nombre, PrecioUnitario, Cantidad, Subtotal
            var cId = new DataGridViewTextBoxColumn { Name = "IdProducto", DataPropertyName = "IdProducto", Visible = false };
            var cNombre = new DataGridViewTextBoxColumn { Name = "NombreProducto", HeaderText = "Producto", DataPropertyName = "NombreProducto" };
            var cPrecio = new DataGridViewTextBoxColumn { Name = "PrecioUnitario", HeaderText = "Precio Unit.", DataPropertyName = "PrecioUnitario" };
            var cCantidad = new DataGridViewTextBoxColumn { Name = "Cantidad", HeaderText = "Cantidad", DataPropertyName = "Cantidad" };
            var cSubtotal = new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal", DataPropertyName = "Subtotal" };

            dgvVenta.Columns.AddRange(new DataGridViewColumn[] { cId, cNombre, cPrecio, cCantidad, cSubtotal });

            // Inicializar combos
            LlenarCombosVentaProducto();
            LlenarCombosVentaCliente();
            LlenarCombosVentaMetodoDePago();

            ActualizarGrillaCarrito();
            txtSubtotalVenta.Text = "0,00";
        }

        #region Llenar Combos
        private void LlenarCombosVentaProducto()
        {
            cmbProductoVenta.DataSource = objNegProducto.ObtenerProducto();
            cmbProductoVenta.DisplayMember = "NombreProducto";
            cmbProductoVenta.ValueMember = "IdProducto";
            cmbProductoVenta.SelectedIndex = -1;
        }

        private void LlenarCombosVentaCliente()
        {
            cmbClienteVenta.DataSource = objNegCliente.ObtenerCliente();
            cmbClienteVenta.DisplayMember = "NombreCliente";
            cmbClienteVenta.ValueMember = "IdCliente";
            cmbClienteVenta.SelectedIndex = -1;
        }

        private void LlenarCombosVentaMetodoDePago()
        {
            cmbMedioPagoVenta.DataSource = objNegMetodoDePago.ObtenerMetodoDePago();
            cmbMedioPagoVenta.DisplayMember = "NombreMetodoDePago";
            cmbMedioPagoVenta.ValueMember = "IdMetodoDePago"; // fijate que tu BD use exactamente este nombre
            cmbMedioPagoVenta.SelectedIndex = -1;
        }
        #endregion

        #region Carrito - Add / Remove / Clear / Update




        private void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            if (cmbProductoVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!int.TryParse(txtCantidadVenta.Text.Replace(".", ""), out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int idProducto = Convert.ToInt32(cmbProductoVenta.SelectedValue);

            // Obtener producto para precio y stock
            var producto = objNegProducto.ObtenerProducto().Find(p => p.IdProducto == idProducto);
            if (producto == null)
            {
                MessageBox.Show("Producto no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Comprobación de stock disponible (no descontamos aún, solo comprobamos)
            if (producto.CantidadProducto < cantidad)
            {
                MessageBox.Show($"Stock insuficiente. Disponible: {producto.CantidadProducto}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Si el producto ya está en el carrito, sumar cantidades
            var existente = carrito.Find(x => x.IdProducto == idProducto);
            if (existente != null)
            {
                // verificar que la suma no exceda stock
                if (producto.CantidadProducto < existente.Cantidad + cantidad)
                {
                    MessageBox.Show($"No se puede agregar. Stock insuficiente para la cantidad total ({existente.Cantidad + cantidad}).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                existente.Cantidad += cantidad;
            }
            else
            {
                carrito.Add(new CarritoItem
                {
                    IdProducto = producto.IdProducto,
                    NombreProducto = producto.NombreProducto,
                    PrecioUnitario = producto.PrecioVenta,
                    Cantidad = cantidad
                });
            }

            ActualizarGrillaCarrito();
            txtCantidadVenta.Text = "1";
        }

        private void btnQuitarDelCarrito_Click(object sender, EventArgs e)
        {
            if (dgvVenta.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvVenta.CurrentRow.Cells["IdProducto"].Value);
            var item = carrito.Find(x => x.IdProducto == id);
            if (item != null)
            {
                carrito.Remove(item);
                ActualizarGrillaCarrito();
            }
        }

        private void btnVaciarCarrito_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0) return;
            if (MessageBox.Show("¿Vaciar el carrito?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                carrito.Clear();
                ActualizarGrillaCarrito();
            }
        }

        private void ActualizarGrillaCarrito()
        {
            // Para refrescar DataSource, clonamos la lista
            dgvVenta.DataSource = null;
            dgvVenta.DataSource = carrito.Select(c => new
            {
                c.IdProducto,
                c.NombreProducto,
                PrecioUnitario = c.PrecioUnitario.ToString("#,##0.00"),
                c.Cantidad,
                Subtotal = c.Subtotal.ToString("#,##0.00")
            }).ToList();

            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in carrito) total += item.Subtotal;
            txtSubtotalVenta.Text = total.ToString("#,##0.00");
        }

        #endregion

        #region Abrir Confirmar Venta (envía carrito)

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbClienteVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbMedioPagoVenta.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un medio de pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Preparamos info a pasar
            int idCliente = Convert.ToInt32(cmbClienteVenta.SelectedValue);
            int idMetodoPago = Convert.ToInt32(cmbMedioPagoVenta.SelectedValue);
            decimal subtotal = decimal.Parse(txtSubtotalVenta.Text.Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);

            // Abrimos form confirmar y le pasamos el carrito (copia) y datos del cliente/metodo
            var carritoCopia = carrito.Select(c => new CarritoItem
            {
                IdProducto = c.IdProducto,
                NombreProducto = c.NombreProducto,
                PrecioUnitario = c.PrecioUnitario,
                Cantidad = c.Cantidad
            }).ToList();

            FormCarritoCompra1 frmConfirmar = new FormCarritoCompra1(carritoCopia, idCliente, idMetodoPago, subtotal);
            var res = frmConfirmar.ShowDialog();

            if (res == DialogResult.OK)
            {
                // Si la venta fue confirmada y guardada en la BD, vaciamos el carrito local
                carrito.Clear();
                ActualizarGrillaCarrito();
                MessageBox.Show("Venta confirmada y registrada correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // si el usuario canceló o falló, no tocamos el carrito
            }
        }

        #endregion





        private void dgvVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }






        #region Validaciones y utilitarios (tus validaciones adaptadas)



        private void txtCantidadVenta_TextChanged(object sender, EventArgs e)
        {
            // Si querés mantener formato, lo podés adaptar - por ahora dejamos tal cual entrada entera.
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


        #endregion


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
