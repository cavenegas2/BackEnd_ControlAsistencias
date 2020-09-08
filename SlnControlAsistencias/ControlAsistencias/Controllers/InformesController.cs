using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUAsistencia;
using BEUAsistencia.Transaction;

namespace ControlAsistencias.Controllers
{
    public class InformesController : Controller
    {

        // GET: Informes
        public ActionResult Index()
        {
            return View(InformeBLL.List());
        }

        // GET: Informes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = InformeBLL.Get(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            return View(informe);
        }

        // GET: Informes/Create
        public ActionResult Create()
        {
            ViewBag.id_asis = new SelectList(AsistenciaBLL.List(), "id_asis", "id_asis");
            ViewBag.id_emp = new SelectList(EmpleadoBLL.List(), "id_emp", "nombre_completo");
            return View();
        }

        // POST: Informes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pago_empleado,id_asis,id_emp,dias_trabajo")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                InformeBLL.Create(informe);
                return RedirectToAction("Index");
            }

            ViewBag.id_asis = new SelectList(AsistenciaBLL.List(), "id_asis", "id_asis", informe.id_asis);
            ViewBag.id_emp = new SelectList(EmpleadoBLL.List(), "id_emp", "nombre_completo", informe.id_emp);
            return View(informe);
        }

        // GET: Informes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = InformeBLL.Get(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_asis = new SelectList(AsistenciaBLL.List(), "id_asis", "id_asis", informe.id_asis);
            ViewBag.id_emp = new SelectList(EmpleadoBLL.List(), "id_emp", "nombre_completo", informe.id_emp);
            return View(informe);
        }

        // POST: Informes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pago_empleado,id_asis,id_emp,dias_trabajo")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                InformeBLL.Update(informe);
                return RedirectToAction("Index");
            }
            ViewBag.id_asis = new SelectList(AsistenciaBLL.List(), "id_asis", "id_asis", informe.id_asis);
            ViewBag.id_emp = new SelectList(EmpleadoBLL.List(), "id_emp", "nombre_completo", informe.id_emp);
            return View(informe);
        }

        // GET: Informes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = InformeBLL.Get(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            return View(informe);
        }

        // POST: Informes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InformeBLL.List();
            return RedirectToAction("Index");
        }

    }
}
