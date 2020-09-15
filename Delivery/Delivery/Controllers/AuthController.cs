using capaModelos.Modelos;
using capaModelos.Transaccions;
using Delivery.Models;
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
    [RoutePrefix("api/login")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LOG_IN usuario)
        {
            if (usuario == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            usuario = LogInBLL.Validate(usuario);
            if (usuario != null)
            {
                return Ok(new
                {
                    user = usuario,
                    token = TokenGenerator.GenerateTokenJwt(usuario)
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
