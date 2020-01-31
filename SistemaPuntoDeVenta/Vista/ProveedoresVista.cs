using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SistemaPuntoDeVenta.Modelo;
using SistemaPuntoDeVenta.Repositorio;

namespace SistemaPuntoDeVenta.Vista
{
    public partial class ProveedoresVista : Form
    {
        public ProveedoresVista()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();

            proveedor.Direccion = txtDireccion.Text;
            proveedor.Nombre = txtNombre.Text;
            proveedor.Rtn = txtRTN.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Tipo_empresa = txtTipoEmpresa.Text;

            ProveedorRepositorio.Instance.save(proveedor);

            MessageBox.Show("Guardado correctamente!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = new Proveedor();

                proveedor.Id_proveedor = int.Parse(comboNumero.Text);
                proveedor.Direccion = txtDireccion.Text;
                proveedor.Nombre = txtNombre.Text;
                proveedor.Rtn = txtRTN.Text;
                proveedor.Telefono = txtTelefono.Text;
                proveedor.Tipo_empresa = txtTipoEmpresa.Text;

                ProveedorRepositorio.Instance.update(proveedor);

                MessageBox.Show("Guardado correctamente!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboNumero_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Proveedor proveedor = ProveedorRepositorio.Instance.find(int.Parse(comboNumero.Text));

                txtDireccion.Text = proveedor.Direccion;
                txtNombre.Text = proveedor.Nombre;
                txtRTN.Text = proveedor.Rtn;
                txtTelefono.Text = proveedor.Telefono;
                txtTipoEmpresa.Text = proveedor.Tipo_empresa;
            } catch(Exception ex)
            {

            }
        }
    }
}
