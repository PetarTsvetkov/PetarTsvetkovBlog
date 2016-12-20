using System.Web;
using System.Web.Mvc;

namespace Petar_Tsvetkov_Blog
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
