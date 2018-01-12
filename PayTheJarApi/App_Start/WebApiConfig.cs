using System.Web.Http;
#if DEBUG
using System.Web.Http.Cors;
#endif

namespace PayTheJarApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
#if DEBUG
            var cors = new EnableCorsAttribute("http://localhost:8100", "*", "*");
            config.EnableCors(cors);
#endif

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
