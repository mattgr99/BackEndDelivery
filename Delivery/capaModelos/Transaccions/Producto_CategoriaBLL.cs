
using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUDelivery.Transactions
{
    public class Producto_CategoriaBLL
    {
        public static List<PRODUCTO_CATEGORIA> List()
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.PRODUCTO_CATEGORIA.ToList();
        }
    }
}
