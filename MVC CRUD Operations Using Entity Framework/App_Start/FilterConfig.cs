using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD_Operations_Using_Entity_Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
