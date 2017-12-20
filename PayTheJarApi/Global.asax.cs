using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace PayTheJarApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the dependency injector container
            var container = IocContainer.Instance;

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            // Used by simple injector to create instances of Web API objects
            GlobalConfiguration.Configuration.DependencyResolver =
                        new SimpleInjectorWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
