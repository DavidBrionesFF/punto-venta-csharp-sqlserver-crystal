using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class Compra
    {
        public Compra()
        {

        }

        private int id_compra;
        private int numero;
        private int proveedor;
        private int usuario;
        private DateTime fecha_compra;
        private double total;
        private double isv;
        private double subtotal;
        private double descuento;

        public int Id_compra
        {
            get
            {
                return id_compra;
            }

            set
            {
                id_compra = value;
            }
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public int Proveedor
        {
            get
            {
                return proveedor;
            }

            set
            {
                proveedor = value;
            }
        }

        public int Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }

        public DateTime Fecha_compra
        {
            get
            {
                return fecha_compra;
            }

            set
            {
                fecha_compra = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public double Isv
        {
            get
            {
                return isv;
            }

            set
            {
                isv = value;
            }
        }

        public double Subtotal
        {
            get
            {
                return subtotal;
            }

            set
            {
                subtotal = value;
            }
        }

        public double Descuento
        {
            get
            {
                return descuento;
            }

            set
            {
                descuento = value;
            }
        }
    }
}
