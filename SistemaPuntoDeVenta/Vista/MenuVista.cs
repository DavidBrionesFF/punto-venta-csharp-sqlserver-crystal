using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaPuntoDeVenta.Vista
{
    public partial class MenuVista : Form
    {
        public MenuVista()
        {
            InitializeComponent();
        }

        private void MenuVista_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new InventarioVista().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ProductoVista().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ClienteVista().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FacturaVista().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new ProveedoresVista().ShowDialog();
        }
    }
}
