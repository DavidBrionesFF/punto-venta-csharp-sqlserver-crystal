using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class CreditoProveedor
    {

        public CreditoProveedor()
        {

        }

        private int id_credito_proveedor;
        private int factura;
        private bool pagado;

        public int Id_credito_proveedor
        {
            get
            {
                return id_credito_proveedor;
            }

            set
            {
                id_credito_proveedor = value;
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
