using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class CreditoCliente
    {
        public CreditoCliente()
        {

        }

        private int id_credito_cliente;
        private int factura;
        private bool pagado;

        public int Id_credito_cliente
        {
            get
            {
                return id_credito_cliente;
            }

            set
            {
                id_credito_cliente = value;
            }
        }

        public int Factura
        {
            get
            {
                return factura;
            }

            set
            {
                factura = value;
            }
        }

        public bool Pagado
        {
            get
            {
                return pagado;
            }

            set
            {
                pagado = value;
            }
        }
    }
}
