using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Projeto.Tests
{
    public class AppContext
    {
        public HttpClient Client { get; set; }

        private TestServer testServer;

        public AppContext()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            testServer = new TestServer(new WebHostBuilder()
                         .UseConfiguration(configuration)
                         .UseStartup<Presentation.Startup>());

            Client = testServer.CreateClient();
        }
    }
}
