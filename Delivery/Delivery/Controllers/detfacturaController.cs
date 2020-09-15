
using BEUDelivery.Transactions;
using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackProyectoDelivery.Controllers
{
    //CORS
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class detfacturaController : ApiController
    {
        public IHttpActionResult Get(int? id)
        {
            try
            {
                return Ok(DetFacturaBLL.List(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }




        public IHttpActionResult Post(DETALLE_FACTURA d)
        {
            try
            {
                DetFacturaBLL.Create(d);
                return Content(HttpStatusCode.OK, "Message: \n\tCompra Exitosa" + "\nGracias por preferirnos");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Solicitud no procesada");
            }
        }
    }
}
