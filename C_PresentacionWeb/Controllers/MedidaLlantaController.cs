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
    public class MedidaLlantaController : Controller
    {
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<MedidaLlanta> lista = CD_MedidaLlanta.Instancia.ObtenerMedidaLlanta();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(MedidaLlanta objeto)
        {
            bool respuesta = false;

            if (objeto.IdMedidaLlanta == 0)
            {

                respuesta = CD_MedidaLlanta.Instancia.RegistrarMedidaLlanta(objeto);
            }
            else
            {
                respuesta = CD_MedidaLlanta.Instancia.ModificarMedidaLlanta(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_MedidaLlanta.Instancia.EliminarMedidaLlanta(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}