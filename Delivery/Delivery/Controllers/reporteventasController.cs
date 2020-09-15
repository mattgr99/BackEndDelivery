
using capaModelos.Modelos;
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
    [AllowAnonymous]
    //CORS
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class reporteventasController : ApiController
    {
        public IHttpActionResult Get()
        {

            try
            {
                using (DeliveryEntidades1 db = new DeliveryEntidades1())
                {
                    try
                    {
                        //List<rptCantidadProductos11_Result> todos = ReporteBLL.listProductos();
                        return Content(HttpStatusCode.OK, ReporteBLL.listProductos());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar reporte de productos " + ex.Message);
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
                throw ex;
            }
        } 
        
        public IHttpActionResult Get(Boolean activo)
        {

            try
            {
                using (DeliveryEntidades1 db = new DeliveryEntidades1())
                {
                    try
                    {
                        //List<rptCantidadProductos11_Result> todos = ReporteBLL.listProductos();
                        return Content(HttpStatusCode.OK, ReporteBLL.listMontoAgrupado());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar reporte de monto agrupado " + ex.Message);
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
                throw ex;
            }
        }
        public IHttpActionResult Get(DateTime fecha_inicial, DateTime fecha_final)
        {

            try
            {
                using (DeliveryEntidades1 db = new DeliveryEntidades1())
                {
                    try
                    {
                        //List<rptCantidadProductos11_Result> todos = ReporteBLL.listProductos();
                        return Content(HttpStatusCode.OK, ReporteBLL.listVentasCategoriasxMes(fecha_inicial, fecha_final));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al enviar reporte de Ventas por mes " + ex.Message);
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                return NotFound();
                throw ex;
            }
        }
    }
}
