using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class DescripcionCompra
    {
        public DescripcionCompra()
        {

        }

        private int id_descripcion_compra;
        private int producto;
        private int cantidad;
        private int compra;
        private double precio;

        public int Id_descripcion_compra
        {
            get
            {
                return id_descripcion_compra;
            }

            set
            {
                id_descripcion_compra = value;
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

        public int Compra
        {
            get
            {
                return compra;
            }

            set
            {
                compra = value;
            }
        }

        public double Precio
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
