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
    public class MarcaProdController : Controller
    {
        public ActionResult Crear()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            List<MarcaProd> lista = CD_MarcaProd.Instancia.ObtenerMarcaProd();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Guardar(MarcaProd objeto)
        {
            bool respuesta = false;

            if (objeto.IdMarcaProd == 0)
            {

                respuesta = CD_MarcaProd.Instancia.RegistrarMarcaProd(objeto);
            }
            else
            {
                respuesta = CD_MarcaProd.Instancia.ModificarMarcaProd(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_MarcaProd.Instancia.EliminarMarcaProd(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}