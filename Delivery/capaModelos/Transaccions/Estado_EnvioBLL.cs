using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
    public class Estado_EnvioBLL
    {
        public static List<ESTADO_ENVIO> List()
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.ESTADO_ENVIO.ToList();
        }
    }
}
