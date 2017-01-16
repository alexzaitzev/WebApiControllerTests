using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class UserController : ApiController
    {
        private readonly IRegistrationService registrationService;

        public UserController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        public HttpResponseMessage Post(RegistrationModel model)
        {
            bool success = this.registrationService.Register(model);

            return new HttpResponseMessage(success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError);
        }
    }

}
