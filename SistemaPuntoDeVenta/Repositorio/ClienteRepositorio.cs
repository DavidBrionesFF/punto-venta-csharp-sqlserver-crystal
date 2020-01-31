using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using SistemaPuntoDeVenta.Repositorio;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class ClienteRepositorio : DAOImpl<Cliente>
    {
        private static ClienteRepositorio instance = new ClienteRepositorio();
        public ClienteRepositorio()
        {

        }

        internal static ClienteRepositorio Instance
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

        public bool delete(Cliente model)
        {
            var query = "delete from cliente where id_cliente="+model.Id_cliente;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public Cliente find(int id)
        {
            var query = "select * from cliente where id_cliente="+id;
            Cliente cliente = new Cliente();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                cliente.Id_cliente = reader.GetInt32(0);
                cliente.Nombre = reader.GetString(1);
                cliente.Apellido = reader.GetString(2);
                cliente.Telefono = reader.GetString(3);
                cliente.Identidad = reader.GetString(4);
                cliente.Direccion = reader.GetString(5);
            }

            reader.Close();
            return cliente;
        }

        public List<Cliente> findAll()
        {
            List<Cliente> clientes = new List<Cliente>();
            var query = "select * from cliente";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id_cliente = reader.GetInt32(0);
                cliente.Nombre = reader.GetString(1);
                cliente.Apellido = reader.GetString(2);
                cliente.Telefono = reader.GetString(3);
                cliente.Identidad = reader.GetString(4);
                cliente.Direccion = reader.GetString(5);
                clientes.Add(cliente);
            }
            reader.Close();
            return clientes;
        }

        public bool save(List<Cliente> models)
        {
            throw new NotImplementedException();
        }

        public bool save(Cliente model)
        {
            var query = "insert into cliente (nombre,apellido,telefono,identidad,direccion) values ";
            query += "('"+model.Nombre+"', '"+model.Apellido+"','"+model.Telefono+"', '"+model.Identidad+"','"+model.Direccion+"')"; 
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(Cliente model)
        {
            var query = "update cliente set nombre='" + model.Nombre + "', apellido='" + model.Apellido + "',telefono='" + model.Telefono + "', identidad='" + model.Identidad + "',direccion='" + model.Direccion + "' where  id_cliente="+model.Id_cliente;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}