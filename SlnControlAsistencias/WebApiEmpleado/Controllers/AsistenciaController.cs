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
    public class AsistenciaController : ApiController
    {
        public IHttpActionResult Post(Asistencia asistencia)
        {
            try
            {
                AsistenciaBLL.Create(asistencia);
                return Content(HttpStatusCode.Created,"Asistencia creada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [ResponseType(typeof(Asistencia))]
        public IHttpActionResult Get()
        {
            try {
                List<Asistencia> todos = AsistenciaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex) {
                return Content(HttpStatusCode.BadRequest, ex);
            }
            
        }

        public IHttpActionResult Put(Asistencia asistencia)
        {
            try
            {
                AsistenciaBLL.Update(asistencia);
                return Content(HttpStatusCode.OK, "Asistencia actualizada correctamente");

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
                Asistencia result = AsistenciaBLL.Get(id);
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

        [ResponseType(typeof(Asistencia))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                AsistenciaBLL.Delete(id);
                return Ok("Asistencia eliminada correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest,ex);
            }
        }
    }
}