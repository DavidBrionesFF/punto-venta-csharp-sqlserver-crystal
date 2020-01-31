using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class InventarioRepositorio : DAOImpl<Inventario>
    {
        private static InventarioRepositorio instance = new InventarioRepositorio();
        private InventarioRepositorio()
        {

        }

        internal static InventarioRepositorio Instance
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

        public bool delete(Inventario model)
        {
            var query = "delete from inventario where id_inventario="+model.Id_inventario;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public Inventario find(int id)
        {
            Inventario inventario = new Inventario();
            var query = "select * from inventario where id_inventario="+id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                inventario.Id_inventario = reader.GetInt16(0);
                inventario.Producto = reader.GetInt16(1);
                inventario.Cantidad = reader.GetInt16(2);
                inventario.Fecha_inventario = reader.GetDateTime(3);
                inventario.Almacen = reader.GetInt16(4);
                inventario.Tipo = reader.GetString(5);
            }
            reader.Close();
            return inventario;
        }

        public List<Inventario> findAll()
        {
            List<Inventario> inventarios = new List<Inventario>();
            var query = "select * from inventario ORDER BY fecha_inventario desc";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                Inventario inventario = new Inventario();
                inventario.Id_inventario = reader.GetInt32(0);
                inventario.Producto = reader.GetInt32(1);
                inventario.Cantidad = reader.GetInt32(2);
                inventario.Fecha_inventario = reader.GetDateTime(3);
                inventario.Tipo = reader.GetString(4);
                inventarios.Add(inventario);
            }
            reader.Close();
            return inventarios;
        }

        public bool save(Inventario model)
        {
            var query = "insert into Inventario (producto,cantidad,fecha_inventario,tipo) values (" + model.Producto+","+model.Cantidad+",sysdatetime(),'"+model.Tipo+"')";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(Inventario model)
        {
            var query = "update Inventario set prodcuto=" + model.Producto + ",cantidad=" + model.Cantidad + ",almacen=" + model.Almacen + ",tipo='" + model.Tipo + "')";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public List<Inventario> findExistencia()
        {
            var query = "select p.id_producto, sum(i.cantidad) as Existencia from producto p inner join inventario i on p.id_producto = i.producto group by p.id_producto";
            List<Inventario> inventarios = new List<Inventario>();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                Inventario inventario = new Inventario();

                inventario.Producto = reader.GetInt32(0);
                inventario.Cantidad = reader.GetInt32(1);

                inventarios.Add(inventario);
            }

            reader.Close();
            return inventarios;
        }

        public int findExistenciaByProducto(int p)
        {
            var query = "select p.id_producto, sum(i.cantidad) as Existencia from producto p inner join inventario i on p.id_producto = i.producto group by p.id_producto having p.id_producto="+p;
            int inventarios = 0;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                inventarios = reader.GetInt32(1);
                
            }
            reader.Close();
            return inventarios;
        }

        public bool save(List<Inventario> models)
        {
            throw new NotImplementedException();
        }
    }
}
