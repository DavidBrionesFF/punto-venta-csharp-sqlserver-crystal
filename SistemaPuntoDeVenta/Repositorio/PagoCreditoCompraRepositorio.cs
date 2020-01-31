using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class PagoCreditoCompraRepositorio : DAOImpl<PagoCreditoCompra>
    {
        public bool delete(PagoCreditoCompra model)
        {
            var query = "delete from pago_credito_compra where id_pago="+model.Pago_credito_compra;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public PagoCreditoCompra find(int id)
        {
            var query = "select * from pago_credito_compra where id_pago="+id;
            PagoCreditoCompra pago = new PagoCreditoCompra();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer(query);

            while (reader.Read())
            {
                pago.Pago_credito_compra = reader.GetInt16(0);
                pago.Monto = reader.GetDouble(1);
                pago.Recargo = reader.GetDouble(2);
                pago.Fecha_pago = reader.GetDateTime(3);
                pago.Credito = reader.GetInt16(4);
            }
            reader.Close();
            return pago;
        }

        public List<PagoCreditoCompra> findAll()
        {
            List<PagoCreditoCompra> pagos = new List<PagoCreditoCompra>();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("SELECT * FROM pago_credito_compra");

            while (reader.Read())
            {
                PagoCreditoCompra pago = new PagoCreditoCompra();
                pago.Pago_credito_compra = reader.GetInt16(0);
                pago.Monto = reader.GetDouble(1);
                pago.Recargo = reader.GetDouble(2);
                pago.Fecha_pago = reader.GetDateTime(3);
                pago.Credito = reader.GetInt16(4);
                pagos.Add(pago);
            }
            reader.Close();
            return pagos;
        }

        public bool save(List<PagoCreditoCompra> models)
        {
            throw new NotImplementedException();
        }

        public bool save(PagoCreditoCompra model)
        {
            var query = "insert into pago_credito_compra (monto,recargo,fecha_pago,credito) values('" + model.Monto + "','" + model.Recargo + "',sysdatetime()," + model.Credito + ")";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool update(PagoCreditoCompra model)
        {
            var query = "update pago_credito_compra set monto='" + model.Monto + "',recargo='" + model.Recargo + "',credito=" + model.Credito + ")";
            return Conexion.getInstance().ejecutarQuery(query);
        }
    }
}
