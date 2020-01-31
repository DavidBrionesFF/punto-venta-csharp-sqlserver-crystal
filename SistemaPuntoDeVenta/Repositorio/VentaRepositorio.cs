using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SistemaPuntoDeVenta.Repositorio
{
    class VentaRepositorio : DAOImpl<Venta>
    {
        private static VentaRepositorio instance = new VentaRepositorio();

        private VentaRepositorio()
        {

        }

        internal static VentaRepositorio Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public bool delete(Venta model)
        {
            String query = "delete from factura where id_factura=" + model.Id_venta;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public int findByCodigo(int codigo)
        {
            int numero = 0;
            string query = "select id_factura from factura where numero=" + codigo;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                numero = reader.GetInt32(0);

            }
            reader.Close();
            return numero;
        }

        public Venta find(int id)
        {
            Venta venta = new Venta();
            string query = "select * from factura where id_usuario=" + id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                venta.Id_venta = reader.GetInt16(0);
                venta.Numero = reader.GetInt16(1);
                venta.Cliente = reader.GetInt16(2);
                venta.Usuario = reader.GetInt16(3);
                venta.Fecha_venta = reader.GetDateTime(4);
                venta.Total = reader.GetDecimal(5);
                venta.Subtotal = reader.GetDecimal(6);
                venta.Isv = reader.GetDecimal(7);
                venta.Descuento = reader.GetDecimal(8);

            }
            reader.Close();
            return venta;
        }

        public List<Venta> findAll()
        {
            List<Venta> ventas = new List<Venta>();
            string query = "select * from factura";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                Venta venta = new Venta();
                venta.Id_venta = reader.GetInt16(0);
                venta.Numero = reader.GetInt16(1);
                venta.Cliente = reader.GetInt16(2);
                venta.Usuario = reader.GetInt16(3);
                venta.Fecha_venta = reader.GetDateTime(4);
                venta.Total = reader.GetDecimal(5);
                venta.Subtotal = reader.GetDecimal(6);
                venta.Isv = reader.GetDecimal(7);
                venta.Descuento = reader.GetDecimal(8);
                ventas.Add(venta);
            }
            reader.Close();
            return ventas;
        }

        public bool save(List<Venta> models)
        {
            throw new NotImplementedException();
        }

        public bool save(Venta model)
        {
            String query = "insert into factura (numero,cliente,usuario,fecha_facturacion,total,subtotal,isv,descuento) ";
            query = query + " values ('"+model.Numero+"','"+model.Cliente+"',"+model.Usuario+",sysdatetime(),'"+model.Total.ToString().Replace(",", ".") + "','"+model.Subtotal.ToString().Replace(",",".") + "','"+model.Isv.ToString().Replace(",", ".") + "','"+model.Descuento.ToString().Replace(",", ".")  + "')";
            MessageBox.Show(query);
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(Venta model)
        {
            String query = "update factura set numero="+model.Numero+", cliente="+model.Cliente+", usuario="+model.Usuario+", fecha_facturacion='"+model.Fecha_venta.ToString("dd-MM-yy")+"', total='"+model.Total+"', subtotal='"+model.Subtotal+"', isv='"+model.Isv+"', descuento='"+model.Descuento+"' where id_factura="+model.Id_venta;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
