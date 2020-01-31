using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class PagoCreditoCompra
    {
        public PagoCreditoCompra()
        {

        }

        private int pago_credito_compra;
        private double monto;
        private double recargo;
        private DateTime fecha_pago;
        private int credito;

        public int Pago_credito_compra
        {
            get
            {
                return pago_credito_compra;
            }

            set
            {
                pago_credito_compra = value;
            }
        }

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public double Recargo
        {
            get
            {
                return recargo;
            }

            set
            {
                recargo = value;
            }
        }

        public DateTime Fecha_pago
        {
            get
            {
                return fecha_pago;
            }

            set
            {
                fecha_pago = value;
            }
        }

        public int Credito
        {
            get
            {
                return credito;
            }

            set
            {
                credito = value;
            }
        }
    }
}
