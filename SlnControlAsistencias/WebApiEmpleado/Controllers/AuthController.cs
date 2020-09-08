using BEUAsistencia;
using BEUAsistencia.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiEmpleado.Models;

namespace WebApiEmpleado.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(Usuario usuario)
        {
            if (usuario == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            usuario = UsuarioBLL.Validate(usuario);
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
