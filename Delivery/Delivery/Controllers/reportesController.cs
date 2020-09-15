using BEUDelivery.Transactions;
using capaModelos.Transaccions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Delivery.Controllers
{
    //CORS
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class reportesController : ApiController
    {
        public IHttpActionResult Get(int? id)
        {
            try
            {
                return Ok(DetFacturaBLL.Ventas(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IHttpActionResult Get(int? id, string fecha)
        {
            try
            {
                return Ok(DetFacturaBLL.Ventas(id, fecha));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
