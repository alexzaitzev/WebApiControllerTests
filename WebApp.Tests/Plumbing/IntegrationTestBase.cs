using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace WebApp.Tests.Plumbing
{
    internal class IntegrationTestBase
    {
        protected TestServer Server { get; private set; }

        [OneTimeSetUp]
        public void BindServices()
        {
            this.Server = TestServer.Create<TestStartup>();
        }

        [OneTimeTearDown]
        public void DisposeServer()
        {
            this.Server.Dispose();
        }
    }
}
