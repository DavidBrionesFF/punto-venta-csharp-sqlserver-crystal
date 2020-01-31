using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;

namespace SistemaPuntoDeVenta
{
    class SeleccionEntreVentanas
    {
        private SeleccionEntreVentanas()
        {

        }

        private static SeleccionEntreVentanas instance = new SeleccionEntreVentanas();

        public static SeleccionEntreVentanas Instance
        {
            get
            {
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        private Cliente cliente;
        private Usuario usuario;
        private Almacen almacen;
        private Inventario inventario;
        private Compra compra;
        private Venta venta;
        private Producto producto;
        private Proveedor proveedor;
        private PagoCreditoVenta pago_credito_venta;
        private PagoCreditoCompra pago_credito_compra;
        private DescripcionCompra descripcion_compra;
        private DescripcionVenta descripcion_venta;
        private CreditoCliente credito_cliente;
        private CreditoProveedor credtio_proveedor;

        public Cliente Cliente
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

        public Usuario Usuario
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

        public Almacen Almacen
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

        public Inventario Inventario
        {
            get
            {
                return inventario;
            }

            set
            {
                inventario = value;
            }
        }

        public Compra Compra
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

        public Venta Venta
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

        public Producto Producto
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

        public Proveedor Proveedor
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

        public PagoCreditoVenta Pago_credito_venta
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

        public PagoCreditoCompra Pago_credito_compra
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

        public DescripcionCompra Descripcion_compra
        {
            get
            {
                return descripcion_compra;
            }

            set
            {
                descripcion_compra = value;
            }
        }

        public DescripcionVenta Descripcion_venta
        {
            get
            {
                return descripcion_venta;
            }

            set
            {
                descripcion_venta = value;
            }
        }

        public CreditoCliente Credito_cliente
        {
            get
            {
                return credito_cliente;
            }

            set
            {
                credito_cliente = value;
            }
        }

        public CreditoProveedor Credtio_proveedor
        {
            get
            {
                return credtio_proveedor;
            }

            set
            {
                credtio_proveedor = value;
            }
        }
    }
}
