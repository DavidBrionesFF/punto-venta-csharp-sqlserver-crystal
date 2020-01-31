using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPuntoDeVenta.Modelo
{
    class Producto
    {
        private int id_producto;
        private String nombre;
        private decimal precio_compra;
        private decimal precio_venta;
        private int minimo;
        private int maximo;
        private String codigo;
        private String tipo;

        public int Id_producto
        {
            get
            {
                return id_producto;
            }

            set
            {
                id_producto = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
        
        public int Minimo
        {
            get
            {
                return minimo;
            }

            set
            {
                minimo = value;
            }
        }

        public int Maximo
        {
            get
            {
                return maximo;
            }

            set
            {
                maximo = value;
            }
        }

        public string Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
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

        public decimal Precio_compra
        {
            get
            {
                return precio_compra;
            }

            set
            {
                precio_compra = value;
            }
        }

        public decimal Precio_venta
        {
            get
            {
                return precio_venta;
            }

            set
            {
                precio_venta = value;
            }
        }
    }
}
