using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPuntoDeVenta.Modelo;
using System.Data.SqlClient;

namespace SistemaPuntoDeVenta.Repositorio
{
    class PagoCreditorVentaRepositorio : DAOImpl<PagoCreditoVenta>
    {
        public bool delete(PagoCreditoVenta model)
        {
            var query = "delete from pago_credito_compra where id_pago="+model.Pago_credito_venta;
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public PagoCreditoVenta find(int id)
        {
            PagoCreditoVenta pago = new PagoCreditoVenta();
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("SELECT * FROM pago_credito_cliente where id_pago="+id);
            while (reader.Read())
            {
                pago.Pago_credito_venta = reader.GetInt16(0);
                pago.Monto = reader.GetDecimal(1);
                pago.Recargo = reader.GetDecimal(2);
                pago.Fecha_pago = reader.GetDateTime(3);
                pago.Credito = reader.GetInt16(4);
            }
            reader.Close();
            return pago;
        }

        public List<PagoCreditoVenta> findAll()
        {
            List<PagoCreditoVenta> pagos = new List<PagoCreditoVenta>();
            
            SqlDataReader reader = Conexion.getInstance().ejecutarQueryLeer("SELECT * FROM pago_credito_cliente");
            while (reader.Read())
            {
                PagoCreditoVenta pago = new PagoCreditoVenta();
                pago.Pago_credito_venta = reader.GetInt16(0);
                pago.Monto = reader.GetDecimal(1);
                pago.Recargo = reader.GetDecimal(2);
                pago.Fecha_pago = reader.GetDateTime(3);
                pago.Credito = reader.GetInt16(4);
                pagos.Add(pago);
            }
            reader.Close();
            return pagos;
        }

        public bool update(PagoCreditoVenta model)
        {
            var query = "update pago_credito_cliente set monto='"+model.Monto+"',recargo='"+model.Recargo+"',credito="+model.Credito+")";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool save(PagoCreditoVenta model)
        {
            var query = "insert into pago_credito_cliente (monto,recargo,fecha_pago,credito) values('" + model.Monto + "','" + model.Recargo + "',sysdatetime()," + model.Credito + ")";
            return Conexion.getInstance().ejecutarQuery(query);
        }

        public bool save(List<PagoCreditoVenta> models)
        {
            throw new NotImplementedException();
        }
    }
}
