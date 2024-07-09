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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            List<Cliente> oListaCliente = CD_Cliente.Instancia.ObtenerClientes();
            return Json(new { data = oListaCliente }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Guardar(Cliente objeto)
        {
            bool respuesta = false;

            if (objeto.IdCliente == 0)
            {
                respuesta = CD_Cliente.Instancia.RegistrarCliente(objeto);
            }
            else
            {
                respuesta = CD_Cliente.Instancia.ModificarCliente(objeto);
            }


            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            bool respuesta = CD_Cliente.Instancia.EliminarCliente(id);

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}