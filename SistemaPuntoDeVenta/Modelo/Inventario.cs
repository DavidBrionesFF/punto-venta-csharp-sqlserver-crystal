using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class Inventario
    {
        public Inventario()
        {

        }

        private int id_inventario;
        private int producto;
        private int cantidad;
        private int almacen;
        private String tipo;
        private DateTime fecha_inventario;

        public int Id_inventario
        {
            get
            {
                return id_inventario;
            }

            set
            {
                id_inventario = value;
            }
        }

        public int Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public int Almacen
        {
            get
            {
                return almacen;
            }

            set
            {
                almacen = value;
            }
        }

        public string Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public DateTime Fecha_inventario
        {
            get
            {
                return fecha_inventario;
            }

            set
            {
                fecha_inventario = value;
            }
        }
    }
}
