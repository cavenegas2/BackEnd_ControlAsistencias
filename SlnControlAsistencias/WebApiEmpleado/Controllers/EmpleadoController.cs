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
    public class EmpleadoController : ApiController
    {
        public IHttpActionResult Post(Empleado empleado)
        {
            try
            {
                EmpleadoBLL.Create(empleado);
                return Content(HttpStatusCode.Created,"Empleado creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [ResponseType(typeof(Empleado))]
        public IHttpActionResult Get()
        {
            try {
                List<Empleado> todos = EmpleadoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex) {
                return Content(HttpStatusCode.BadRequest, ex);
            }
            
        }

        public IHttpActionResult Put(Empleado empleado)
        {
            try
            {
                 EmpleadoBLL.Update(empleado);
                return Content(HttpStatusCode.OK, "Empleado actualizado correctamente");

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
                Empleado result = EmpleadoBLL.Get(id);
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

        [ResponseType(typeof(Empleado))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                EmpleadoBLL.Delete(id);
                return Ok("Empleado eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest,ex);
            }
        }
    }
}