using BEUAsistencia;
using BEUAsistencia.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace WebApiEmpleado.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class InformeController : ApiController
    {
        public IHttpActionResult Post(Informe informe)
        {
            try
            {
                InformeBLL.Create(informe);
                return Content(HttpStatusCode.Created, "Informe creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [ResponseType(typeof(Informe))]
        public IHttpActionResult Get()
        {
            try {
                List<Informe> todos = InformeBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex) {
                return Content(HttpStatusCode.BadRequest, ex);
            }
            
        }

        public IHttpActionResult Put(Informe informe)
        {
            try
            {
                InformeBLL.Update(informe);
                return Content(HttpStatusCode.OK, "Informe actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        public IHttpActionResult Get(int id)
        {
            try
            {
                Informe result = InformeBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }

        }

        [ResponseType(typeof(Informe))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                InformeBLL.Delete(id);
                return Ok("Informe eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest,ex);
            }
        }
    }
}