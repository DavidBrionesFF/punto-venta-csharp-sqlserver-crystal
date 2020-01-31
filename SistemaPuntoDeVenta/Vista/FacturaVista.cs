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
    public partial class FacturaVista : Form
    {
        public FacturaVista()
        {
            InitializeComponent();
        }

        public void refrescar()
        {
            comboCliente.Items.Clear();
            comboProducto.Items.Clear();
            comboNumeroFactura.Items.Clear();

            foreach(Venta venta in VentaRepositorio.Instance.findAll())
            {
                comboNumeroFactura.Items.Add(venta.Numero);
            }

            foreach(Cliente cliente in ClienteRepositorio.Instance.findAll())
            {
                comboCliente.Items.Add(cliente.Id_cliente);
            }

            foreach(Producto producto in ProductoRepositorio.Instance.findAll())
            {
                comboProducto.Items.Add(producto.Id_producto);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                new ClienteVista().ShowDialog();

                Cliente cliente = SeleccionEntreVentanas.Instance.Cliente;

                txtCliente.Text = cliente.Nombre + " " + cliente.Apellido;
                comboCliente.Text = cliente.Id_cliente+"";


            }catch(Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new ProductoVista().ShowDialog();
                Producto producto = SeleccionEntreVentanas.Instance.Producto;
                txtProducto.Text = producto.Nombre;
                comboProducto.Text = producto.Id_producto + "";

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ClienteRepositorio.Instance.find(int.Parse(comboCliente.Text));
                txtCliente.Text = cliente.Nombre + " " + cliente.Apellido;
                
            }catch(Exception ex)
            {

            }
        }

        private void FacturaVista_Load(object sender, EventArgs e)
        {
            refrescar();
        }

        private void comboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Producto producto = ProductoRepositorio.Instance.find(int.Parse(comboProducto.Text));
                txtProducto.Text = producto.Nombre;
            }
            catch (Exception ex)
            {

            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int entrada = InventarioRepositorio.Instance.findExistenciaByProducto(int.Parse(comboProducto.Text));
                int salida = DescripcionVentaRepositorio.Instance.vendido(int.Parse(comboProducto.Text));
                int existencia = entrada - salida;

                if (existencia >= int.Parse(txtCantidad.Text))
                {
                    Producto producto = ProductoRepositorio.Instance.find(int.Parse(comboProducto.Text));

                    int cantidad = int.Parse(txtCantidad.Text);
                    decimal total = cantidad * producto.Precio_venta;

                    dataDescripcion.Rows.Add(producto.Id_producto, producto.Nombre, cantidad, producto.Precio_venta, total);

                }
                else
                {
                    MessageBox.Show(this, "Lo siento, solo se encuentra "+existencia+" de "+txtProducto.Text, "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sumar();
        }

        public void sumar()
        {
            double subtotal = 0;

            for(int i = 0; i<dataDescripcion.Rows.Count; i++)
            {
                subtotal = subtotal + Convert.ToDouble(dataDescripcion.Rows[i].Cells[4].Value);
            }

            double descuento = 0;

            try
            {
                descuento = double.Parse(
                        (txtDescuento.Text=="") ? "0" : txtDescuento.Text
                    );
            }
            catch
            {
                MessageBox.Show("Revise que el descuento sea numerico");
            }

            double total = 0;
            double isv = subtotal * 0.15;
            total = subtotal + isv - descuento;

            txtTotal.Text = total + "";
            txtIsv.Text = isv+ "";
            txtSubtotal.Text = subtotal + "";
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            sumar();
        }

        private void borrarLinea(object sender, EventArgs e)
        {
            sumar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataDescripcion.SelectedRows.Count; i++)
            {
                dataDescripcion.Rows.Remove(dataDescripcion.SelectedRows[i]);
            }
            sumar();
        }

        private List<DescripcionVenta> descripciones()
        {
            List<DescripcionVenta> ventas = new List<DescripcionVenta>();
            for (int i = 0; i < dataDescripcion.Rows.Count; i++)
            {
                DescripcionVenta venta = new DescripcionVenta();

                venta.Producto = Convert.ToInt32(dataDescripcion.Rows[i].Cells[0].Value);
                venta.Cantidad = Convert.ToInt32(dataDescripcion.Rows[i].Cells[2].Value);
                venta.Precio = Convert.ToDecimal(dataDescripcion.Rows[i].Cells[3].Value);
                venta.Venta = VentaRepositorio.Instance.findByCodigo(Convert.ToInt32(comboNumeroFactura.Text));
                ventas.Add(venta);
            }
            return ventas;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboCliente.Text != "" && comboNumeroFactura.Text!="")
            {
                try
                {
                    int cliente = int.Parse(comboCliente.Text);
                    int numero = int.Parse(comboNumeroFactura.Text);
                    int usuario = 1;

                    decimal subtotal = 0;
                    
                    for (int i = 0; i < dataDescripcion.Rows.Count; i++)
                    {
                        subtotal = subtotal + Convert.ToDecimal(dataDescripcion.Rows[i].Cells[4].Value);
                    }

                    decimal descuento = 0;

                    try
                    {
                        descuento = decimal.Parse(
                                (txtDescuento.Text == "") ? "0" : txtDescuento.Text
                            );
                    }
                    catch
                    {
                        MessageBox.Show("Revise que el descuento sea numerico");
                    }

                    decimal total = 0;
                    decimal isv = subtotal * (decimal)0.15;
                    total = subtotal + isv - descuento;

                    Venta venta = new Venta();

                    venta.Cliente = cliente;
                    venta.Usuario = usuario;
                    venta.Numero = numero;
                    venta.Subtotal = subtotal;
                    venta.Total = total;
                    venta.Descuento = descuento;
                    venta.Isv = isv;

                    try
                    {
                        VentaRepositorio.Instance.save(venta);
                        DescripcionVentaRepositorio.Instance.save(descripciones());

                        try
                        {
                            new SistemaPuntoDeVenta.Reporte.FacturaImprimir(int.Parse(comboNumeroFactura.Text)).ShowDialog();
                        }catch(Exception ex)
                        {

                        }
                    }catch(Exception ex)
                    {
                        
                    }

                }
                catch(Exception ex)
                {
                    
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new SistemaPuntoDeVenta.Reporte.FacturaImprimir(int.Parse(comboNumeroFactura.Text)).ShowDialog();
        }
    }
}
