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
    public class MarcaLlantaController : Controller
    {
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<MarcaLlanta> lista = CD_MarcaLlanta.Instancia.ObtenerMarcaLlanta();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(MarcaLlanta objeto)
        {
            bool respuesta = false;

            if (objeto.IdMarcaLlanta == 0)
            {

                respuesta = CD_MarcaLlanta.Instancia.RegistrarMarcaLlanta(objeto);
            }
            else
            {
                respuesta = CD_MarcaLlanta.Instancia.ModificarMarcaLlanta(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_MarcaLlanta.Instancia.EliminarMarcaLlanta(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}