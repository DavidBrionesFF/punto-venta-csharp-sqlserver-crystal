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
using SistemaPuntoDeVenta;

namespace SistemaPuntoDeVenta.Vista
{
    public partial class ProductoVista : Form
    {

        private List<Producto> productos = new List<Producto>();
        public ProductoVista()
        {
            InitializeComponent();
        }

        private void onRefrescar()
        {
            productos = ProductoRepositorio.Instance.findAll();
            dataProducto.Rows.Clear();
            comboIdProducto.Items.Clear();
            dataExistencia.Rows.Clear();

            foreach (Producto p in productos)
            {
                comboIdProducto.Items.Add(p.Id_producto);
                dataProducto.Rows.Add(p.Id_producto, p.Nombre, p.Codigo, p.Precio_compra, p.Precio_venta, p.Minimo, p.Maximo, p.Tipo);
            }

            foreach (Inventario inventario in InventarioRepositorio.Instance.findExistencia())
            {
                Producto p = ProductoRepositorio.Instance.find(inventario.Producto);
                int descripcion = DescripcionVentaRepositorio.Instance.vendido(p.Id_producto);
                int total = inventario.Cantidad - descripcion;
                dataExistencia.Rows.Add(inventario.Producto, p.Codigo, p.Nombre, p.Precio_compra, p.Precio_venta,
                                        p.Minimo, p.Maximo, p.Tipo, total);
            }
        }

        private void ProductoVista_Load(object sender, EventArgs e)
        {
            onRefrescar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto();

                p.Nombre = txtNombre.Text;
                p.Maximo = int.Parse(txtMaximo.Text);
                p.Minimo = int.Parse(txtMinimo.Text);
                p.Precio_compra = decimal.Parse(txtCompra.Text);
                p.Precio_venta = decimal.Parse(txtVenta.Text);
                p.Tipo = txtTipo.Text;
                p.Codigo = txtCodigo.Text;

                ProductoRepositorio.Instance.save(p);

                MessageBox.Show(this, "Producto agregado", "Excelente");
                onRefrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto();

                p.Id_producto = int.Parse(comboIdProducto.Text);
                p.Nombre = txtNombre.Text;
                p.Maximo = int.Parse(txtMaximo.Text);
                p.Minimo = int.Parse(txtMinimo.Text);
                p.Precio_compra = decimal.Parse(txtCompra.Text);
                p.Precio_venta = decimal.Parse(txtVenta.Text);
                p.Tipo = txtTipo.Text;
                p.Codigo = txtCodigo.Text;

                ProductoRepositorio.Instance.update(p);

                MessageBox.Show(this, "Producto actualzado", "Excelente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                onRefrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboIdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Producto producto = ProductoRepositorio.Instance.find(int.Parse(comboIdProducto.Text));

                txtNombre.Text = producto.Nombre;
                txtCodigo.Text = producto.Codigo;
                txtCompra.Text = producto.Precio_compra+"";
                txtVenta.Text = producto.Precio_venta + "";
                txtMaximo.Text = producto.Maximo + "";
                txtMinimo.Text = producto.Minimo + "";
                txtTipo.Text = producto.Tipo;

                SeleccionEntreVentanas.Instance.Producto = producto;
            }catch( Exception ex)
            {
                
            }
        }

        private void dataProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "¿Desea eliminar el producto?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question)+""=="Yes") 
            {
                try
                {
                    Producto p = new Producto();
                    p.Id_producto = int.Parse(comboIdProducto.Text);
                    ProductoRepositorio.Instance.delete(p);
                    MessageBox.Show(this, "Eliminado correctamente!!", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }catch(Exception ex)
                {
                    MessageBox.Show(this, ex.Message,"Lo siento hubo un error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ProductoImprimir().Show();
        }
    }
}
