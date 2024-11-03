using Microsoft.AspNetCore.Mvc.Testing;

namespace DRR.IntegrationTests
{
    public class AdminBaseTestClass : BaseTestClass
    {
        private const string Name = "Authentication";
        private const string Value = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiZDM4MGQxZjAtMjZhZi00MmE1LThlNzMtMTkwYzIwNTc4ZDlkIiwibmJmIjoxNjYyNzk1MDg2LCJleHAiOjE2NjI4ODE0ODYsImlhdCI6MTY2Mjc5NTA4Nn0.Px9RtmoPoktRnLEyNQtI8nUHY4gDlHXqt5dRW7dxZg8";


        public AdminBaseTestClass(WebApplicationFactory<Startup> factory) : base(factory)
        {
            _httpClient.DefaultRequestHeaders.Add(Name, Value);
        }
    }
}
