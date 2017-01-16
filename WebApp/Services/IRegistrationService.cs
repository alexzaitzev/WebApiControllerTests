using WebApp.Models;

namespace WebApp.Services
{
    public interface IRegistrationService
    {
        bool Register(RegistrationModel model);
    }
}
