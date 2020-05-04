using System.Web;
using System.Web.Mvc;

namespace SAPD.Frontend.SOP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
