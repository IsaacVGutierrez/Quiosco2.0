using Quiosco.Entidades;
using Quiosco.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Quiosco.BD;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System.Drawing;

namespace Quiosco
{
    public partial class FormInicio : Form
    {


        public FormInicio()
        {
            InitializeComponent();



            dgvDeudor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDeudor.ColumnCount = 4;
            dgvDeudor.Columns[0].HeaderText = "Codigo Cliente";
            dgvDeudor.Columns[1].HeaderText = "Nombre Cliente";
            dgvDeudor.Columns[2].HeaderText = "Telefono Cliente";
            dgvDeudor.Columns[3].HeaderText = "Adeuda Cliente";



            // Carga inicial
            LlenarDGVDeudor();
            CargarValoresPieChartDesdeBD();
            MostrarPieSkiaEnPictureBox();
            CargarDetalleVenta();

            lblSaludo.Text = "¡ Bienvenido " + Sesion.UsuarioActual.NombreUsuario + " !";






        }



        private int hoveredSegment = -1;
        private readonly string[] labels = { "Ventas", "Compras", "Ganancias" };
        private readonly double[] values = { 15000, 5000, 8000 };

        private readonly SKColor[] colors = new SKColor[]
        {
         SKColors.DeepSkyBlue,
         SKColors.LimeGreen,
          SKColors.OrangeRed
          };



        private PieChart pieChart1;
        private float rotacion = 0f;
        private Label tooltipLabel;
        private readonly Color tooltipBaseColor = Color.FromArgb(30, 30, 30);



        public Cliente objEntDeudor = new Cliente();

        public ClienteNegocio objNegDeudor = new ClienteNegocio();

        public Usuario objEntUsuario = new Usuario();
        public UsuarioNegocio objNegUsuario = new UsuarioNegocio();



        // Método para crear SKBitmap con fondo transparente
        // --- Variables para animación ---
        private float animProgress = 1f;
        private readonly float animSpeed = 0.15f;
        System.Windows.Forms.Timer animTimer;


        private Bitmap CreatePieBitmapSkia(int width, int height)
        {
            double total = valuesDynamic.Sum();
            if (total == 0) total = 1; // evitar división por cero

            // Crear animación suave
            if (animTimer == null)
            {
                animTimer = new System.Windows.Forms.Timer();
                animTimer.Interval = 16;  // 60 FPS
                animTimer.Tick += (s, e) =>
                {
                    animProgress += animSpeed;
                    if (animProgress > 1f) animProgress = 1f;

                    if (rotacion < 360f)
                    {
                        rotacion += 15f;
                        if (rotacion >= 360f)
                        {
                            rotacion = 360f;
                            animTimer.Stop();
                        }
                    }

                    RedibujarGrafico();
                };

                animProgress = 0f;
                animTimer.Start();
            }

            var info = new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Premul);
            using (var surface = SKSurface.Create(info))
            {
                var canvas = surface.Canvas;
                canvas.Clear(SKColors.Transparent);

                float cx = width / 2f;
                float cy = height / 2f;
                float radius = Math.Min(width, height) * 0.45f * animProgress;
                float profundidad = radius * 0.2f;

                // Sombra 3D
                var sombra3D = new SKPaint
                {
                    Shader = SKShader.CreateLinearGradient(
                        new SKPoint(cx, cy - radius),
                        new SKPoint(cx, cy + radius + profundidad),
                        new SKColor[] { new SKColor(0, 0, 0, 100), new SKColor(0, 0, 0, 20) },
                        null,
                        SKShaderTileMode.Clamp),
                    IsAntialias = true
                };
                canvas.DrawOval(new SKRect(cx - radius, cy - radius + profundidad, cx + radius, cy + radius + profundidad), sombra3D);

                canvas.Save();
                canvas.Translate(cx, cy);
                canvas.RotateDegrees(rotacion);
                canvas.Translate(-cx, -cy);

                var segmentPaint = new SKPaint { IsAntialias = true };
                var glassBorder = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 5,
                    Shader = SKShader.CreateLinearGradient(
                        new SKPoint(cx - radius, cy - radius),
                        new SKPoint(cx + radius, cy + radius),
                        new[] { SKColors.White, new SKColor(255, 255, 255, 40), SKColors.White },
                        null,
                        SKShaderTileMode.Clamp),
                    IsAntialias = true
                };

                float startAngle = -90f;

                for (int i = 0; i < valuesDynamic.Length; i++)
                {
                    float sweep = (float)(valuesDynamic[i] / total * 360.0);
                    float midAngle = startAngle + sweep / 2f;

                    float explode = (i == hoveredSegment) ? 25f : 0f;
                    double rad = Math.PI * midAngle / 180.0;
                    float offX = explode * (float)Math.Cos(rad);
                    float offY = explode * (float)Math.Sin(rad);

                    // Gradiente segmento
                    segmentPaint.Shader = SKShader.CreateRadialGradient(
                        new SKPoint(cx + offX, cy + offY),
                        radius,
                        new[]
                        {
                    colors[i].WithAlpha(255),
                    colors[i].WithAlpha(180),
                    colors[i].WithAlpha(120)
                        },
                        null,
                        SKShaderTileMode.Clamp
                    );

                    using (var path = new SKPath())
                    {
                        path.MoveTo(cx + offX, cy + offY);
                        path.ArcTo(new SKRect(cx - radius + offX, cy - radius + offY, cx + radius + offX, cy + radius + offY),
                                   startAngle, sweep, false);
                        path.Close();

                        canvas.DrawPath(path, segmentPaint);
                        canvas.DrawPath(path, glassBorder);
                    }

                    // Etiquetas dinámicas para evitar superposición
                    float labelRadius = radius * 0.6f + (radius * 0.4f * (float)(valuesDynamic[i] / total));
                    float lx = cx + labelRadius * (float)Math.Cos(rad);
                    float ly = cy + labelRadius * (float)Math.Sin(rad);

                    using var labelPaint = new SKPaint
                    {
                        Color = SKColors.White,
                        TextSize = radius * 0.1f + (radius * 0.05f * (float)(valuesDynamic[i] / total)), // tamaño dinámico según valor
                        IsAntialias = true,
                        TextAlign = SKTextAlign.Center
                    };

                    canvas.DrawText(labels[i], lx, ly, labelPaint);

                    startAngle += sweep;
                }

                canvas.Restore();

                using (var img = surface.Snapshot())
                using (var data = img.Encode(SKEncodedImageFormat.Png, 100))
                using (var ms = data.AsStream())
                {
                    return new Bitmap(ms);
                }
            }
        }






        internal class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);
        }

        private double[] valuesDynamic = new double[] { 0, 0, 0 };

        private void CargarValoresPieChartDesdeBD()
        {
            // Obtenemos las fechas de los controles
            DateTime inicio = dtpDesde.Value.Date; // .Date para que empiece a las 00:00:00
            DateTime fin = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1); // Hasta el final del día elegido

            try
            {
                // IMPORTANTE: Tus métodos de negocio deben aceptar estos parámetros DateTime
                double totalVentas = objNegDetalle.ObtenerTotalVentas(inicio, fin);
                double totalCompras = objNegDetalle.ObtenerTotalCompras(inicio, fin);

                double totalGanancias = totalVentas - totalCompras;

                // Actualizamos los valores que usa el gráfico
                valuesDynamic = new double[] { totalVentas, totalCompras, totalGanancias };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar valores filtrados: " + ex.Message);
            }
        }




        // Uso desde el Form: asignar al PictureBox
        private void MostrarPieSkiaEnPictureBox()
        {
            Bitmap bmp = CreatePieBitmapSkia(400, 300);


            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bmp;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }




        private void RedibujarGrafico()
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = CreatePieBitmapSkia(pictureBox1.Width, pictureBox1.Height);
        }


        private void FormInicio_Load(object sender, EventArgs e)
        {

            // Inicializar filtros: desde hace un mes hasta hoy
            dtpDesde.Value = DateTime.Now.AddMonths(-1);
            dtpHasta.Value = DateTime.Now;

            CargarDetalleVenta();
            CargarValoresPieChartDesdeBD();
            CargarProductosEnStock();
            MostrarPieSkiaEnPictureBox();
            RedibujarGrafico();

            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeudor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStockProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseLeave += PictureBox1_MouseLeave;

            // tooltipLabel (mejor inicializar aquí)
            tooltipLabel = new Label();
            tooltipLabel.AutoSize = true;
            tooltipLabel.Visible = false;
            tooltipLabel.Padding = new Padding(8);
            tooltipLabel.ForeColor = Color.White;
            tooltipLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            tooltipLabel.BorderStyle = BorderStyle.None;
            tooltipLabel.MaximumSize = new Size(240, 0);

            tooltipLabel.Region = System.Drawing.Region.FromHrgn(
                NativeMethods.CreateRoundRectRgn(0, 0, 300, 60, 12, 12)
            );

            // inicial BackColor totalmente transparente
            tooltipLabel.BackColor = Color.FromArgb(0, tooltipBaseColor.R, tooltipBaseColor.G, tooltipBaseColor.B);

            this.Controls.Add(tooltipLabel);
            tooltipLabel.BringToFront();

            if (Sesion.UsuarioActual == null)
            {
                MessageBox.Show("Error: no hay usuario logueado.");
                this.Close();
                return;
            }


            if (Sesion.UsuarioActual.Rol != "Admin")
            {
                btnGestionUsuarios.Visible = false;
            }

            if (Sesion.UsuarioActual.Rol != "Admin")
            {
                btnEliminarProductos.Visible = false;
            }


            if (Sesion.UsuarioActual.Rol != "Admin")
            {
                btnEliminarDeudor.Visible = false;
            }

        }


        private async void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double total = values.Sum();

            float cx = pictureBox1.Width / 2f;
            float cy = pictureBox1.Height / 2f;
            float radius = Math.Min(pictureBox1.Width, pictureBox1.Height) * 0.33f;

            float dx = e.X - cx;
            float dy = e.Y - cy;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            // Si está DENTRO del pie (dist <= radius + padding) -> detectar segmento y mostrar tooltip
            float padding = 25f; // margen para explode/hover
            if (dist <= radius + padding)
            {
                // calcular ángulo y encontrar el segmento
                float angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
                angle = (angle < -90) ? angle + 360 : angle;
                angle += 90;

                float start = 0;
                int found = -1;
                for (int i = 0; i < values.Length; i++)
                {
                    float sweep = (float)(values[i] / total * 360.0);
                    if (angle >= start && angle < start + sweep)
                    {
                        found = i;
                        break;
                    }
                    start += sweep;
                }

                if (found != -1)
                {
                    // cambiar hoveredSegment si hace falta (para redraw)
                    if (hoveredSegment != found)
                    {
                        hoveredSegment = found;
                        RedibujarGrafico(); // hará crecer el segmento (explode)
                    }

                    // preparar texto y color del tooltip según segmento
                    string text = $"{labels[found]}  $ {valuesDynamic[found]:N0}";

                    tooltipLabel.Text = text;

                    // convertir SKColor -> System.Drawing.Color
                    SKColor sk = colors[found];
                    Color segColor = Color.FromArgb(220, sk.Red, sk.Green, sk.Blue);

                    // posición: convertir coordenada del mouse en pictureBox a coordenada del form
                    Point screenPt = pictureBox1.PointToScreen(new Point(e.X + 12, e.Y + 12));
                    Point clientPt = this.PointToClient(screenPt);

                    tooltipLabel.Location = clientPt;

                    // si ya visible y mismo color, solo mover
                    if (tooltipLabel.Visible)
                    {
                        tooltipLabel.BackColor = Color.FromArgb(220, segColor.R, segColor.G, segColor.B);
                    }
                    else
                    {
                        // fijar color con alpha 0 y animar a alpha 220
                        tooltipLabel.BackColor = Color.FromArgb(0, segColor.R, segColor.G, segColor.B);
                        // arrancar fade (no bloquear el hilo UI)
                        _ = tooltipLabel.FadeBackgroundAsync(Color.FromArgb(220, segColor.R, segColor.G, segColor.B), 180);
                    }

                    tooltipLabel.Visible = true;
                    pictureBox1.Cursor = Cursors.Hand;
                    return;
                }
            }

            // si llegamos acá: fuera del pie o sin segmento detectado
            if (hoveredSegment != -1)
            {
                hoveredSegment = -1;
                RedibujarGrafico();
            }

            if (tooltipLabel.Visible)
            {
                // fade out y ocultar (async)
                _ = tooltipLabel.FadeOutBackgroundAsync(120);
            }

            pictureBox1.Cursor = Cursors.Default;
        }


        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            hoveredSegment = -1;
            RedibujarGrafico();

            if (tooltipLabel.Visible)
            {
                _ = tooltipLabel.FadeOutBackgroundAsync(120);
            }

            pictureBox1.Cursor = Cursors.Default;
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



        private void btnEliminarDeudor_Click(object sender, EventArgs e)
        {
            if (selectedIdCliente == 0)
            {
                MessageBox.Show("Seleccione un deudor para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"¿Está seguro de eliminar al deudor {selectedNombre}?",
                                          "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                objNegDeudor.ListarClienteEliminar(selectedIdCliente.ToString());
                MessageBox.Show("Deudor eliminado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar selección y refrescar grilla
                selectedIdCliente = 0;
                selectedNombre = "";
                selectedDeuda = 0;
                LlenarDGVDeudor();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el deudor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void btnCancelarDeudor_Click(object sender, EventArgs e)
        {
            LimpiarDeudor();
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
            txtBuscarDeudor.Clear();

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



        private void CargarDetalleVenta()
        {
    
            try
            {
                DataTable dt = objNegDetalle.Union().Tables[0];
                dgvDetalleVenta.DataSource = dt;

                // Ocultar IDs
                if (dgvDetalleVenta.Columns.Contains("IdDetalleVenta")) dgvDetalleVenta.Columns["IdDetalleVenta"].Visible = false;
                if (dgvDetalleVenta.Columns.Contains("IdVenta")) dgvDetalleVenta.Columns["IdVenta"].Visible = false;
                if (dgvDetalleVenta.Columns.Contains("IdProducto")) dgvDetalleVenta.Columns["IdProducto"].Visible = false;


                CultureInfo culturaAR = new CultureInfo("es-AR");
                // Formato de Moneda
                var estiloDinero = new DataGridViewCellStyle
                {
                    Format = "C2",
                    FormatProvider = culturaAR,
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    ForeColor = Color.DarkGreen,
                    Font = new Font(dgvDetalleVenta.Font, FontStyle.Bold)
                };

                dgvDetalleVenta.Columns["PrecioVenta"].DefaultCellStyle = estiloDinero;
                dgvDetalleVenta.Columns["SubtotalVenta"].DefaultCellStyle = estiloDinero;

                // --- AJUSTE PARA MÚLTIPLES PAGOS ---
                if (dgvDetalleVenta.Columns.Contains("NombreMetodoDePago"))
                {
                    dgvDetalleVenta.Columns["NombreMetodoDePago"].HeaderText = "Detalle de Pago";
                    dgvDetalleVenta.Columns["NombreMetodoDePago"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvDetalleVenta.Columns["NombreMetodoDePago"].DefaultCellStyle.ForeColor = Color.Blue;
                    dgvDetalleVenta.Columns["NombreMetodoDePago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dgvDetalleVenta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Para que la fila crezca si hay muchos pagos
                                                                                      
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
            dgvStockProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvStockProductos.Columns["PrecioVenta"].DefaultCellStyle.FormatProvider = new CultureInfo("es-AR");

            // auto size
            dgvStockProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvStockProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvStockProductos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

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

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual.Rol != "Admin")
            {
                MessageBox.Show("No tiene permisos para acceder a esta sección.");
                return;
            }

            new FormAdminUsuarios().ShowDialog();
        }


        private void ActualizarDatos()
        {
            // Esto refresca todos los DataGridView que dependen de la BD
            LlenarDGVDeudor();
            CargarDetalleVenta();
            CargarProductosEnStock();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            CargarDetalleVenta();
            CargarValoresPieChartDesdeBD();
            CargarProductosEnStock();
            MostrarPieSkiaEnPictureBox();
            RedibujarGrafico();
        }

        private void FormInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cierra toda la aplicación de manera limpia
            Application.Exit();
        }


        private void btnEliminarProductos_Click(object sender, EventArgs e)
        {
            if (dgvStockProductos.CurrentRow == null || dgvStockProductos.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProducto;
            try
            {
                idProducto = Convert.ToInt32(dgvStockProductos.CurrentRow.Cells["IdProducto"].Value);
            }
            catch
            {
                MessageBox.Show("El Id del producto seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nombreProducto = dgvStockProductos.CurrentRow.Cells["NombreProducto"].Value.ToString();

            var confirm = MessageBox.Show($"¿Está seguro de eliminar el producto {nombreProducto}?",
                                          "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                ListaProductos lp = new ListaProductos();
                lp.ListarProductoEliminar(idProducto);  // <-- aquí llamás al método de negocio para eliminar

                MessageBox.Show("Producto eliminado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar grilla
                // Refrescar grilla
                CargarProductosEnStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            // 1. Capturar las fechas de los controles
            DateTime fechaInicio = dtpDesde.Value.Date;
            // Para la fecha de fin, sumamos un día y restamos un segundo para incluir todo el día elegido
            DateTime fechaFin = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1);

            // 2. Llamar a la lógica de negocio con los parámetros
            double ventas = objNegDetalle.ObtenerTotalVentas(fechaInicio, fechaFin);
            double compras = objNegDetalle.ObtenerTotalCompras(fechaInicio, fechaFin);
            double ganancias = ventas - compras;

            // 3. Actualizar los datos del gráfico (Suponiendo que usas valuesDynamic)
            valuesDynamic = new double[] { ventas, compras, ganancias };

            // 4. Refrescar la animación y el dibujo
            animProgress = 0f;
            if (animTimer != null) animTimer.Start();

            pictureBox1.Invalidate();
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            // El selector "Hasta" no permitirá elegir una fecha menor a la de "Desde"
            dtpHasta.MinDate = dtpDesde.Value;
        }
    }
}
