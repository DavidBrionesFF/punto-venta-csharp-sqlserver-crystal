using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class ProductoRepositorio : DAOImpl<Producto>
    {
        private static ProductoRepositorio instance = new ProductoRepositorio();
        private ProductoRepositorio()
        {

        }

        internal static ProductoRepositorio Instance
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

        public bool delete(Producto model)
        {
            var query = "delete from Producto where id_producto="+model.Id_producto;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public Producto find(int id)
        {
            Producto producto = new Producto();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("select * from Producto where id_producto="+id);

            while (reader.Read())
            {
                producto.Id_producto = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Precio_compra = reader.GetDecimal(2);
                producto.Precio_venta = reader.GetDecimal(3);
                producto.Codigo = reader.GetString(4);
                producto.Minimo = reader.GetInt32(5);
                producto.Maximo = reader.GetInt32(6);
                producto.Tipo = reader.GetString(7);
            }
            reader.Close();
            return producto;
        }

        public List<Producto> findAll()
        {
            List<Producto> productos = new List<Producto>();

            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("select * from Producto");

            while (reader.Read())
            {
                Producto producto = new Producto();
                producto.Id_producto = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Precio_compra = reader.GetDecimal(2);
                producto.Precio_venta = reader.GetDecimal(3);
                producto.Codigo = reader.GetString(4);
                producto.Minimo = reader.GetInt32(5);
                producto.Maximo = reader.GetInt32(6);
                producto.Tipo = reader.GetString(7);
                productos.Add(producto);
            }
            reader.Close();
            return productos;
        }

        public List<String> findTipo()
        {
            var query = "select tipo from producto group by tipo";
            List<String> tipos = new List<string>();

            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                tipos.Add(reader.GetString(0));
            }
            reader.Close();
            return tipos;
        }

        public bool save(List<Producto> models)
        {
            throw new NotImplementedException();
        }

        public bool save(Producto model)
        {
            String query = "insert into Producto (nombre,precio_compra,precio_venta,codigo,minimo,maximo,tipo) values "
                +" ('"+model.Nombre+"','"+model.Precio_compra+"','"+model.Precio_venta+"','"+model.Codigo+"','"+model.Minimo+"','"+model.Maximo+"','"+model.Tipo+"')";

            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(Producto model)
        {
            String query = "update Producto set nombre='"+model.Nombre+"',precio_compra='"+model.Precio_compra+"',precio_venta='"+model.Precio_venta+"',codigo='"+model.Codigo+"',minimo='"+model.Minimo+"',maximo='"+model.Maximo+"',tipo='"+model.Tipo+"' where id_producto="+model.Id_producto;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
