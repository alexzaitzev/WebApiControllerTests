using Microsoft.Practices.Unity;
using Owin;
using System.Web.Http;
using WebApp.Services;

namespace WebApp.Tests.Plumbing
{
    public class TestStartup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute("users", "users", new { controller = "User" });

            var container = new UnityContainer();
            container.RegisterType<IRegistrationService, RegistrationService>();
            config.DependencyResolver = new UnityResolver(container);

            builder.UseWebApi(config);
        }
    }
}
