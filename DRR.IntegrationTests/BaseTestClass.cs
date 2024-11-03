using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DRR.IntegrationTests
{
    public class BaseTestClass : IClassFixture<WebApplicationFactory<Startup>>
    {

        protected readonly HttpClient _httpClient;

        public BaseTestClass(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }
    }
}
