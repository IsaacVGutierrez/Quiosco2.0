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
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
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

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void VENTA_Click(object sender, EventArgs e)
        {

        }
    }
}
