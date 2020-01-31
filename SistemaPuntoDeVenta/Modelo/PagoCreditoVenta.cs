using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class PagoCreditoVenta
    {
        public PagoCreditoVenta()
        {

        }

        private int pago_credito_venta;
        private decimal monto;
        private decimal recargo;
        private DateTime fecha_pago;
        private int credito;
        
        
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
        
        public int Pago_credito_venta
        {
            get
            {
                return pago_credito_venta;
            }

            set
            {
                pago_credito_venta = value;
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

        public decimal Monto
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

        public decimal Recargo
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
    }
}
