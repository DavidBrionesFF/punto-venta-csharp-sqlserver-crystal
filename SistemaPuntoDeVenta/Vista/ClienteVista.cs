using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaPuntoDeVenta.Modelo;
using SistemaPuntoDeVenta.Repositorio;
using SistemaPuntoDeVenta.Reporte;

namespace SistemaPuntoDeVenta.Vista
{
    public partial class ClienteVista : Form
    {
        private List<Cliente> clientes = new List<Cliente>();
        public ClienteVista()
        {
            InitializeComponent();
        }

        private void ClienteVista_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        public void refrescar()
        {
            clientes = ClienteRepositorio.Instance.findAll();
            comboIdCliente.Items.Clear();
            dataCliente.Rows.Clear();
            foreach(Cliente cl in clientes)
            {
                comboIdCliente.Items.Add(cl.Id_cliente);
                dataCliente.Rows.Add(cl.Id_cliente, cl.Nombre, cl.Apellido, cl.Telefono, cl.Identidad,cl.Direccion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.Apellido = txtApellido.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Identidad = txtIdentidad.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Telefono = txtTelefono.Text;

                ClienteRepositorio.Instance.save(cliente);
                refrescar();
                MessageBox.Show(this, "Cliente agregado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(this,ex.Message, "Error al insertar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();

                cliente.Apellido = txtApellido.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Identidad = txtIdentidad.Text;
                cliente.Id_cliente = int.Parse(comboIdCliente.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Telefono = txtTelefono.Text;

                ClienteRepositorio.Instance.update(cliente);
                refrescar();
                MessageBox.Show(this, "Cliente actualzado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error al actualizar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboIdCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ClienteRepositorio.Instance.find(int.Parse(comboIdCliente.Text));

                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDireccion.Text = cliente.Direccion;
                txtIdentidad.Text = cliente.Identidad;
                txtTelefono.Text = cliente.Telefono;
                SeleccionEntreVentanas.Instance.Cliente = cliente;
            }catch(Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente.Id_cliente = int.Parse(comboIdCliente.Text);
                ClienteRepositorio.Instance.delete(cliente);
                refrescar();
                MessageBox.Show(this, "Cliente eliminado","Excelente",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch(Exception ex)
            {
                MessageBox.Show(this, "Error al eliminar cliente","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                new ClienteImprimir().Show();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new UsuarioVista().ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
