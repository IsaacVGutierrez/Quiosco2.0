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
    public partial class FormPagarDeudor : Form
    {
        private decimal deudaMaximaReal;

        public decimal MontoIngresado { get; private set; }

        public FormPagarDeudor(string nombre, decimal deuda)
        {
            InitializeComponent();

            deudaMaximaReal = deuda;
            labelInfo.Text = $"Confirmar que {nombre} realizará un pago ?\nDeuda actual: ${deuda:0.00}";

            txtMonto.Text = "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string texto = txtMonto.Text.Replace(".", ","); // <-- aceptar punto como decimal

            if (!decimal.TryParse(texto, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que 0.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (monto > deudaMaximaReal)
            {
                MessageBox.Show($"El monto no puede ser mayor a la deuda actual (${deudaMaximaReal}).",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MontoIngresado = monto;
            DialogResult = DialogResult.OK;
            Close();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, coma, punto y backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' &&
                e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }

}
