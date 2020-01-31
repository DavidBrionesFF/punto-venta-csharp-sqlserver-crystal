using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class Venta
    {
        public Venta()
        {

        }

        private int id_venta;
        private int numero;
        private int cliente;
        private int usuario;
        private DateTime fecha_venta;
        private decimal total;
        private decimal isv;
        private decimal subtotal;
        private decimal descuento;

        public int Id_venta
        {
            get
            {
                return id_venta;
            }

            set
            {
                id_venta = value;
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

        public int Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
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
        

        public DateTime Fecha_venta
        {
            get
            {
                return fecha_venta;
            }

            set
            {
                fecha_venta = value;
            }
        }

        public decimal Total
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

        public decimal Isv
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

        public decimal Subtotal
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

        public decimal Descuento
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
