using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelos.Transaccions
{
    public class ReporteBLL
    {
        public static List<rptCantidadProductos11_Result> listProductos()
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.rptCantidadProductos11().ToList();
        }
        public static List<rptMontoAgrupadoxCliente_Result> listMontoAgrupado()
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.rptMontoAgrupadoxCliente().ToList();
        }
        public static List<rptVentasCategoriaxMes_Result> listVentasCategoriasxMes(
            DateTime fecha_inicial, DateTime fecha_final)
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.rptVentasCategoriaxMes(fecha_inicial,fecha_final).ToList();
        }
    }
}
