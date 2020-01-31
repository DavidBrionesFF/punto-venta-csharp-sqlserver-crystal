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
    class DescripcionVentaRepositorio : DAOImpl<DescripcionVenta>
    {
        private static DescripcionVentaRepositorio instance = new DescripcionVentaRepositorio();

        private DescripcionVentaRepositorio()
        {

        }

        internal static DescripcionVentaRepositorio Instance
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

        public bool delete(DescripcionVenta model)
        {
            throw new NotImplementedException();
        }

        public DescripcionVenta find(int id)
        {
            throw new NotImplementedException();
        }

        public List<DescripcionVenta> findAll()
        {
            throw new NotImplementedException();
        }

        public bool save(List<DescripcionVenta> models)
        {
            foreach(DescripcionVenta venta in models)
            {
                save(venta);
            }

            return true;
        }

        public bool save(DescripcionVenta model)
        {
            var query = "insert into descripcion_factura (producto,cantidad,factura,precio) values ";
            query += " (" + model.Producto + ", " + model.Cantidad + ", " + model.Venta + ", " + model.Precio.ToString().Replace(",",".") + ")";
            
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(DescripcionVenta model)
        {
            throw new NotImplementedException();
        }

        public int vendido(int producto)
        {
            int vendido = 0;
            var query = "select p.id_producto, sum(d.cantidad) as Existencia from producto p inner join descripcion_factura d on p.id_producto = d.producto group by p.id_producto having p.id_producto ="+producto;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                vendido = reader.GetInt32(1);
            }

            reader.Close();
            return vendido;
        }
    }
}
