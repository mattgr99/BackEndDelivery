
using capaModelos.Modelos;
using BEUDelivery.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using capaModelos.Transaccions;
using System.Web.Http.Description;

namespace BackProyectoDelivery.Controllers
{
    //CORS
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    //[Authorize(Roles = "administrador")]
    public class productoController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                List<PRODUCTO> todos = ProductosBLL.List();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return NotFound();
                throw ex;
            }
        }



        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ProductosBLL.Get(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        
        public IHttpActionResult Post(PRODUCTO p)
        {
            try
            {
                ProductosBLL.Create(p);
                return Content(HttpStatusCode.Created, "Message: \n\trealizado correctamente!" + "\nstatus: \n\t 200");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Solicitud no procesada, Agregado con éxito");
            }
        }


        public IHttpActionResult Delete(int id)
        {
            try
            {
                ProductosBLL.Delete(id);
                return Content(HttpStatusCode.OK, "Borrado con éxito");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, "Solicitud no procesada , No se pudo eliminar");
            }
        }



        public IHttpActionResult Put(PRODUCTO producto)
        {
            if (ProductosBLL.Update(producto))
            {
                return Content(HttpStatusCode.OK, "Producto actualizado");
            }
            return Content(HttpStatusCode.InternalServerError, "Error interno del servidor");
        }
    }
}
