using System.Web;
using System.Web.Mvc;
using C_PresentacionWeb.Filters;

namespace C_PresentacionWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new C_PresentacionWeb.Filters.VerificarSesion());
        }
    }
}
