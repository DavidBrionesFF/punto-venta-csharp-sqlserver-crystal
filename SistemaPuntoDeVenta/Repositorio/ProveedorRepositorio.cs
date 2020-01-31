using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class ProveedorRepositorio : DAOImpl<Proveedor>
    {
        private static ProveedorRepositorio instance = new ProveedorRepositorio();
        
        private ProveedorRepositorio() { }

        internal static ProveedorRepositorio Instance
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

        public bool delete(Proveedor model)
        {
            var query = "delete from Proveedor where id_proveedor=" + model.Id_proveedor;
            return Conexion.getInstance().ejecutarQuery(query); 
        }

        public Proveedor find(int id)
        {
            Proveedor proveedor = new Proveedor();
            var query = "select * from Proveedor where id_proveedor ="+id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                proveedor.Id_proveedor = reader.GetInt16(0);
                proveedor.Nombre = reader.GetString(1);
                proveedor.Telefono = reader.GetString(2);
                proveedor.Rtn = reader.GetString(3);
                proveedor.Direccion = reader.GetString(4);
                proveedor.Tipo_empresa = reader.GetString(5);
            }
            reader.Close();
            return proveedor;
        }

        public List<Proveedor> findAll()
        {
            List<Proveedor> proveedores = new List<Proveedor>();
            var query = "select * from Proveedor";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                Proveedor proveedor = new Proveedor();
                proveedor.Id_proveedor = reader.GetInt16(0);
                proveedor.Nombre = reader.GetString(1);
                proveedor.Telefono = reader.GetString(2);
                proveedor.Rtn = reader.GetString(3);
                proveedor.Direccion = reader.GetString(4);
                proveedor.Tipo_empresa = reader.GetString(5);

                proveedores.Add(proveedor);
            }
            reader.Close();
            return proveedores;
        }

        public bool save(List<Proveedor> models)
        {
            throw new NotImplementedException();
        }

        public bool save(Proveedor model)
        {
            var query = "insert into Proveedor (nombre,telefono,rtn,direccion,tipo_empresa) values ";
            query = query + " ('"+model.Nombre+"','"+model.Telefono+"','"+model.Rtn+"','"+model.Direccion+"','"+model.Tipo_empresa+"')";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(Proveedor model)
        {
            var query = "update Proveedor set nombre='"+model.Nombre+"',telefono='"+model.Telefono+"',rtn='"+model.Rtn+"',direccion='"+model.Direccion+"',tipo_empresa='"+model.Tipo_empresa+"' where id_proveedor="+model.Id_proveedor;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
