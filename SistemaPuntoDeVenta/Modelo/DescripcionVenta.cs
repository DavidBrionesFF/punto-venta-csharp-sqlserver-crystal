using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class DescripcionVenta
    {
        public DescripcionVenta()
        {

        }

        private int id_descripcion_venta;
        private int producto;
        private int cantidad;
        private int venta;
        private decimal precio;

        public int Id_descripcion_venta
        {
            get
            {
                return id_descripcion_venta;
            }

            set
            {
                id_descripcion_venta = value;
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

        public int Venta
        {
            get
            {
                return venta;
            }

            set
            {
                venta = value;
            }
        }

        public decimal Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }
    }
}
