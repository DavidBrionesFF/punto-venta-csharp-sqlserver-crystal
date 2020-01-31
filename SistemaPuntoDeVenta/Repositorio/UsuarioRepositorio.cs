using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class UsuarioRepositorio : DAOImpl<Usuario>
    {
        private static UsuarioRepositorio instance = new UsuarioRepositorio();
        private UsuarioRepositorio()
        {

        }

        internal static UsuarioRepositorio Instance
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

        public bool delete(Usuario model)
        {
            string query = "delete from Usuario where id_usuario=" + model.Id_usuario;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public Usuario find(int id)
        {
            Usuario usuario = new Usuario();
            string query = "select * from usuario where id_usuario=" + id;
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                usuario.Id_usuario = reader.GetInt32(0);
                usuario.Nombre_usuario = reader.GetString(1);
                usuario.Contraseña = reader.GetString(2);
                usuario.Nombre = reader.GetString(3);
            }
            reader.Close();
            return usuario;
        }

        public List<Usuario> findAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            string query = "select * from usuario";
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);
            while (reader.Read())
            {
                Usuario usuario = new Usuario();
                usuario.Id_usuario = reader.GetInt32(0);
                usuario.Nombre_usuario = reader.GetString(1);
                usuario.Contraseña = reader.GetString(2);
                usuario.Nombre = reader.GetString(3);
                usuarios.Add(usuario);
            }
            reader.Close();
            return usuarios;
        }

        public bool save(List<Usuario> models)
        {
            throw new NotImplementedException();
        }

        public bool save(Usuario model)
        {
            string query = "insert into Usuario (nombre_usuario,nombre,contrasena) values('"+model.Nombre_usuario+"','"+model.Nombre+"','"+model.Contraseña+"')";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(Usuario model)
        {
            string query = "update Usuario set nombre_usuario='" + model.Nombre_usuario + "', nombre='" + model.Nombre + "',contrasena='" + model.Contraseña + "' where id_usuario="+model.Id_usuario;
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
