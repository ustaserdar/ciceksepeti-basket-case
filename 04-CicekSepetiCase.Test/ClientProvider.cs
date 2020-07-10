using CicekSepetiCase.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;

namespace CicekSepetiCase.Test
{
    public class ClientProvider : IDisposable
    {
        private readonly TestServer TestServer;
        public HttpClient HttpClient { get; set; }

        public ClientProvider()
        {
            var baseDirectory = Directory.GetCurrentDirectory();
            var configDirectory = Path.Combine(baseDirectory, "appsettings.Development.json");

            TestServer = new TestServer(new WebHostBuilder().ConfigureAppConfiguration((appContext, configuration) =>
            {
                configuration.AddJsonFile(configDirectory);
            }).UseStartup<Startup>());

            HttpClient = TestServer.CreateClient();
        }

        public void Dispose()
        {
            TestServer?.Dispose();
            HttpClient?.Dispose();
        }
    }
}
