using Microsoft.Practices.Unity;
using System.Web.Http;
using WebApp.Services;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("users", "users", new { controller = "User" });

            var container = new UnityContainer();
            container.RegisterType<IRegistrationService, RegistrationService>();
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
