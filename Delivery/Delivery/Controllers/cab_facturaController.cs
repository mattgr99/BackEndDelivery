
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
    public class cab_facturaController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(CabFacturaBLL.GetLastItem());
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }




        public IHttpActionResult Post(CAB_FACTURA c)
        {
            c.fecha = DateTime.Now;
            try
            {
                CabFacturaBLL.Create(c);
                return Content(HttpStatusCode.OK, "Message: \n\trealizado correctamente!" + "\nstatus: \n\t 200");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Solicitud no procesada, Agregado con éxito");
            }
        }
    }
}
