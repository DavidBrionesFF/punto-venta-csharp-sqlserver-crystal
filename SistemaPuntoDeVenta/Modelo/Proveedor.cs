using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class Proveedor
    {
        public Proveedor()
        {

        }

        private int id_proveedor;
        private String nombre;
        private String rtn;
        private String direccion;
        private String tipo_empresa;
        private String telefono;

        public int Id_proveedor
        {
            get
            {
                return id_proveedor;
            }

            set
            {
                id_proveedor = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Rtn
        {
            get
            {
                return rtn;
            }

            set
            {
                rtn = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Tipo_empresa
        {
            get
            {
                return tipo_empresa;
            }

            set
            {
                tipo_empresa = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }
    }
}
