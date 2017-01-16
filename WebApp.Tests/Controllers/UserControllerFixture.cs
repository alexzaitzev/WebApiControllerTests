using Moq;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Services;
using WebApp.Tests.Plumbing;

namespace WebApp.Tests.Controllers
{
    [TestFixture]
    internal class UserControllerFixture : IntegrationTestBase
    {
        [Test]
        public async Task TestRequestWasMappedCorrectlyAndUserRegistered()
        {
            // Arrange
            using (var client = new HttpClient(this.Server.Handler))
            {
                var body = new StringContent(@"{""login"":""Alex"", ""password"": ""password""}", Encoding.UTF8, "application/json");

                // Act
                var response = await client.PostAsync("http://api.webapp.com/users/", body);

                // Assert
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Test]
        public void TestUserCanBeRegistered()
        {
            // Arrange
            var registrationService = new Mock<IRegistrationService>();
            registrationService
                .Setup(x => x.Register(It.IsAny<RegistrationModel>()))
                .Returns(true);

            var userController = new UserController(registrationService.Object);

            // Act
            var response = userController.Post(new RegistrationModel { Login = "Alex", Password = "password" });

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
