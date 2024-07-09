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
    public class MedidaController : Controller
    {
        // GET: Medida
        public JsonResult Obtener()
        {
            List<Medida> lista = CD_Medida.Instancia.ObtenerMedida();
            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);
        }

    }
}