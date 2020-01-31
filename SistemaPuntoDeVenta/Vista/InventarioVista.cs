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

namespace SistemaPuntoDeVenta.Vista
{
    public partial class InventarioVista : Form
    {
        List<Inventario> inventarios = new List<Inventario>();
        public InventarioVista()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new ProductoVista().ShowDialog();
                Producto producto = SeleccionEntreVentanas.Instance.Producto;
                txtTipo.Text = producto.Tipo;
                txtNombre.Text = producto.Nombre;
                comboProducto.Text = producto.Id_producto + "";

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario inventario = new Inventario();

                inventario.Cantidad = int.Parse(txtCantidad.Text);
                inventario.Producto = int.Parse(comboProducto.Text);
                inventario.Tipo = txtTipo.Text;

                InventarioRepositorio.Instance.save(inventario);
                MessageBox.Show(this, "Agragado al inventario", txtNombre.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                refrescar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lo siento pero no se pudo registrar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Producto producto = ProductoRepositorio.Instance.find(int.Parse(comboProducto.Text));
                txtTipo.Text = producto.Tipo;
                txtNombre.Text = producto.Nombre;
                comboProducto.Text = producto.Id_producto + "";

            }catch{

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Inventario inventario = new Inventario();

                inventario.Id_inventario = int.Parse(comboNumero.Text);
                inventario.Cantidad = int.Parse(txtCantidad.Text);
                inventario.Producto = int.Parse(comboProducto.Text);
                inventario.Tipo = txtTipo.Text;

                InventarioRepositorio.Instance.save(inventario);
                MessageBox.Show(this, "Inventario actualizado!!", txtNombre.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lo siento pero no se pudo registrar producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InventarioVista_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        public void refrescar()
        {
            inventarios = InventarioRepositorio.Instance.findAll();

            dataInventario.Rows.Clear();
            comboNumero.Items.Clear();
            comboProducto.Items.Clear();
            comboTipos.Items.Clear();
            dataExistencia.Rows.Clear();

            foreach(String data in ProductoRepositorio.Instance.findTipo())
            {
                comboTipos.Items.Add(data);
            }

            foreach (Producto p in ProductoRepositorio.Instance.findAll())
            {
                comboProducto.Items.Add(p.Id_producto);
            }

            foreach (Inventario inventario in inventarios)
            {
                comboNumero.Items.Add(inventario.Id_inventario);
                dataInventario.Rows.Add(inventario.Id_inventario, inventario.Producto,
                    ProductoRepositorio.Instance.find(inventario.Producto).Nombre,
                    inventario.Cantidad, inventario.Cantidad, inventario.Fecha_inventario);
            }

            foreach(Inventario inventario in InventarioRepositorio.Instance.findExistencia())
            {
                Producto p = ProductoRepositorio.Instance.find(inventario.Producto);
                int descripcion = DescripcionVentaRepositorio.Instance.vendido(p.Id_producto);
                int total = inventario.Cantidad - descripcion;
                dataExistencia.Rows.Add(inventario.Producto, p.Codigo, p.Nombre, p.Precio_compra, p.Precio_venta,
                                        p.Minimo, p.Maximo, p.Tipo,total);
            }
        }
    }
}
