using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
    public class Estado_PagoBLL
    {
        public static List<ESTADO_PAGO> List()
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.ESTADO_PAGO.ToList();
        }
    }
}
