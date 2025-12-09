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


            LlenarDGVDeudor();






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


        public Cliente objEntDeudor = new Cliente();

        public ClienteNegocio objNegDeudor = new ClienteNegocio();



        // Método para crear SKBitmap con fondo transparente
        // --- Variables para animación ---
        private float animProgress = 1f;
        private readonly float animSpeed = 0.15f;
        System.Windows.Forms.Timer animTimer;


        // Método mejorado
        private Bitmap CreatePieBitmapSkia(int width, int height)
        {
            double total = values.Sum();

            // Crear animación suave
            if (animTimer == null)
            {
                animTimer = new System.Windows.Forms.Timer();
                animTimer.Interval = 16;  // 60 FPS
                animTimer.Tick += (s, e) =>
                {
                    // Animación de entrada
                    animProgress += animSpeed;
                    if (animProgress > 1f) animProgress = 1f;

                    // Rotación SOLO de inicio hasta dar 1 vuelta
                    if (rotacion < 360f)
                    {
                        rotacion += 15f;      // velocidad rápida
                        if (rotacion >= 360f)
                        {
                            rotacion = 360f;
                            animTimer.Stop(); // ⛔ se detiene la rotación y el timer
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

                float radius = Math.Min(width, height) * 0.33f * animProgress;

                // ===============================
                // ⭐ EFECTO 3D — PROFUNDIDAD
                // ===============================
                float profundidad = radius * 0.22f;

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


                // ===============================
                // ⭐ SEGMENTOS PIE
                // ===============================
                var segmentPaint = new SKPaint { IsAntialias = true };

                // 🎨 Borde estilo “GLASS”
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

                for (int i = 0; i < values.Length; i++)
                {
                    float sweep = (float)(values[i] / total * 360.0);
                    float midAngle = startAngle + sweep / 2f;

                    // EXPLODE
                    float explode = (i == hoveredSegment) ? 25f : 0f;

                    double rad = Math.PI * midAngle / 180.0;
                    float offX = explode * (float)Math.Cos(rad);
                    float offY = explode * (float)Math.Sin(rad);

                    // ⭐ Gradiente en el segmento
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
                        path.ArcTo(
                            new SKRect((cx - radius) + offX, (cy - radius) + offY,
                                       (cx + radius) + offX, (cy + radius) + offY),
                            startAngle, sweep, false);
                        path.Close();

                        canvas.DrawPath(path, segmentPaint);
                        canvas.DrawPath(path, glassBorder);
                    }

                    // ===============================
                    // ⭐ ETIQUETAS ALREDEDOR DEL GRÁFICO
                    // ===============================
                    // float labelRadius = radius * 1.25f;   // queda afuera del segmento
                    float labelRadius = radius * 0.60f; // queda dentro del segmento

                    float lx = cx + labelRadius * (float)Math.Cos(rad);
                    float ly = cy + labelRadius * (float)Math.Sin(rad);


                    using var labelPaint = new SKPaint
                    {
                        Color = SKColors.White,
                        TextSize = radius * 0.12f,
                        IsAntialias = true,
                        TextAlign = SKTextAlign.Center
                    };

                    canvas.DrawText(labels[i], lx, ly, labelPaint);


                    startAngle += sweep;
                }

                // ===============================
                // ⭐ TEXTO DE HOVER — ETIQUETA EXTERNA
                // ===============================
                if (hoveredSegment != -1)
                {
                    float hoverMidAngle = 0f;
                    float angleAccum = -90f;

                    // Calculamos el ángulo exacto del segmento seleccionado
                    for (int i = 0; i < values.Length; i++)
                    {
                        float sweep = (float)(values[i] / total * 360.0);

                        if (i == hoveredSegment)
                        {
                            hoverMidAngle = angleAccum + sweep / 2f;
                            break;
                        }

                        angleAccum += sweep;
                    }

                    double radHover = Math.PI * hoverMidAngle / 180.0;

                    // Radio más grande para salir bien afuera
                    float hoverLabelRadius = radius * 1.55f;

                    float hx = cx + hoverLabelRadius * (float)Math.Cos(radHover);
                    float hy = cy + hoverLabelRadius * (float)Math.Sin(radHover);

                    using var hoverPaint = new SKPaint
                    {
                        Color = SKColors.Yellow,
                        TextSize = radius * 0.18f,
                        IsAntialias = true,
                        TextAlign = SKTextAlign.Center,
                        StrokeWidth = 3
                    };

                    // Texto grande afuera: etiqueta + valor
                    canvas.DrawText($"{labels[hoveredSegment]}  $ {values[hoveredSegment]:N0}", hx, hy, hoverPaint);
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




        // Uso desde el Form: asignar al PictureBox
        private void MostrarPieSkiaEnPictureBox()
        {
            Bitmap bmp = CreatePieBitmapSkia(400, 300);

            // Crear PictureBox si no existe
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


        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            double total = values.Sum();

            float cx = pictureBox1.Width / 2f;
            float cy = pictureBox1.Height / 2f;
            float radius = Math.Min(pictureBox1.Width, pictureBox1.Height) * 0.33f;

            float dx = e.X - cx;
            float dy = e.Y - cy;
            float dist = (float)Math.Sqrt(dx * dx + dy * dy);

            if (dist > radius + 25)
            {
                // fuera del gráfico
                if (hoveredSegment != -1)
                {
                    hoveredSegment = -1;
                    RedibujarGrafico();
                }
                pictureBox1.Cursor = Cursors.Default;


                return;
            }

            float angle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
            angle = (angle < -90) ? angle + 360 : angle;
            angle += 90;

            float start = 0;
            for (int i = 0; i < values.Length; i++)
            {
                float sweep = (float)(values[i] / total * 360.0);

                if (angle >= start && angle < start + sweep)
                {
                    if (hoveredSegment != i)
                    {
                        hoveredSegment = i;
                        RedibujarGrafico();
                    }
                    pictureBox1.Cursor = Cursors.Hand;
                    return;
                }

                start += sweep;
            }
        }


        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            hoveredSegment = -1;
            RedibujarGrafico();
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
            MostrarPieSkiaEnPictureBox();
            RedibujarGrafico();

            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseLeave += PictureBox1_MouseLeave;

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
