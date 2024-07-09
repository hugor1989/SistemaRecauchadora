using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using C_Entidades;
using C_AccesoSQL;
using C_PresentacionWeb.Utilidades;

namespace C_PresentacionWeb.Controllers
{
    public class DiseñoBandaController : Controller
    {
        // GET: DiseñoBanda
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<DiseñoBanda> lista = CD_DiseñoBanda.Instancia.ObtenerDiseñoBanda();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(DiseñoBanda objeto)
        {
            bool respuesta = false;

            if (objeto.IdDiseñoBanda == 0)
            {

                respuesta = CD_DiseñoBanda.Instancia.RegistrarDiseñoBanda(objeto);
            }
            else
            {
                respuesta = CD_DiseñoBanda.Instancia.ModificarDiseñoBanda(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_DiseñoBanda.Instancia.EliminarDiseñoBanda(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}