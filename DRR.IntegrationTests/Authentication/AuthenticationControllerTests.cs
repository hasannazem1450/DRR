using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace DRR.IntegrationTests.Authentication
{
    public class AuthenticationControllerTests : BaseTestClass
    {
        public AuthenticationControllerTests(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_Not_ReturnOk_Sign_Out()
        {
            var response = await _httpClient.GetAsync("/api/v1.0/Authentication/sign-out");
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        [Fact]
        public async Task Should_ReturnOk_Sign_In()
        {
            var content = new SignInCommand()
            {
                IsPersistent = true,
                Password = "amir1345",
                UserName = "0024838772"
            };

            var response = await _httpClient.PutAsync("/api/v1.0/Authentication/sign-in", SignInCommandJsonContent(content));
            response.EnsureSuccessStatusCode();
        }

        [Theory]

        #region Data
        [InlineData("fortest", "a", "912")]
        [InlineData("fortest", "a", "9")]
        [InlineData("fortest", "a", "test")]
        [InlineData("fortest", "a", "تست")]
        [InlineData("fortest", "a", "09128136797")]
        [InlineData("fortest", "a", "")]
        [InlineData("fortest", "1", "912")]
        [InlineData("fortest", "1", "9")]
        [InlineData("fortest", "1", "test")]
        [InlineData("fortest", "1", "تست")]
        [InlineData("fortest", "1", "09128136797")]
        [InlineData("fortest", "1", "")]
        [InlineData("fortest", "123456", "912")]
        [InlineData("fortest", "123456", "9")]
        [InlineData("fortest", "123456", "test")]
        [InlineData("fortest", "123456", "تست")]
        [InlineData("fortest", "123456", "09128136797")]
        [InlineData("fortest", "123456", "")]
        [InlineData("fortest", "ا", "912")]
        [InlineData("fortest", "ا", "9")]
        [InlineData("fortest", "ا", "test")]
        [InlineData("fortest", "ا", "تست")]
        [InlineData("fortest", "ا", "09128136797")]
        [InlineData("fortest", "ا", "")]
        [InlineData("fortest", "", "912")]
        [InlineData("fortest", "", "9")]
        [InlineData("fortest", "", "test")]
        [InlineData("fortest", "", "تست")]
        [InlineData("fortest", "", "09128136797")]
        [InlineData("fortest", "", "")]
        [InlineData("تست", "a", "912")]
        [InlineData("تست", "a", "9")]
        [InlineData("تست", "a", "test")]
        [InlineData("تست", "a", "تست")]
        [InlineData("تست", "a", "09128136797")]
        [InlineData("تست", "a", "")]
        [InlineData("تست", "1", "912")]
        [InlineData("تست", "1", "9")]
        [InlineData("تست", "1", "test")]
        [InlineData("تست", "1", "تست")]
        [InlineData("تست", "1", "09128136797")]
        [InlineData("تست", "1", "")]
        [InlineData("تست", "123456", "912")]
        [InlineData("تست", "123456", "9")]
        [InlineData("تست", "123456", "test")]
        [InlineData("تست", "123456", "تست")]
        [InlineData("تست", "123456", "09128136797")]
        [InlineData("تست", "123456", "")]
        [InlineData("تست", "ا", "912")]
        [InlineData("تست", "ا", "9")]
        [InlineData("تست", "ا", "test")]
        [InlineData("تست", "ا", "تست")]
        [InlineData("تست", "ا", "09128136797")]
        [InlineData("تست", "ا", "")]
        [InlineData("تست", "", "912")]
        [InlineData("تست", "", "9")]
        [InlineData("تست", "", "test")]
        [InlineData("تست", "", "تست")]
        [InlineData("تست", "", "09128136797")]
        [InlineData("تست", "", "")]
        [InlineData("123", "a", "912")]
        [InlineData("123", "a", "9")]
        [InlineData("123", "a", "test")]
        [InlineData("123", "a", "تست")]
        [InlineData("123", "a", "09128136797")]
        [InlineData("123", "a", "")]
        [InlineData("123", "1", "912")]
        [InlineData("123", "1", "9")]
        [InlineData("123", "1", "test")]
        [InlineData("123", "1", "تست")]
        [InlineData("123", "1", "09128136797")]
        [InlineData("123", "1", "")]
        [InlineData("123", "123456", "912")]
        [InlineData("123", "123456", "9")]
        [InlineData("123", "123456", "test")]
        [InlineData("123", "123456", "تست")]
        [InlineData("123", "123456", "09128136797")]
        [InlineData("123", "123456", "")]
        [InlineData("123", "ا", "912")]
        [InlineData("123", "ا", "9")]
        [InlineData("123", "ا", "test")]
        [InlineData("123", "ا", "تست")]
        [InlineData("123", "ا", "09128136797")]
        [InlineData("123", "ا", "")]
        [InlineData("123", "", "912")]
        [InlineData("123", "", "9")]
        [InlineData("123", "", "test")]
        [InlineData("123", "", "تست")]
        [InlineData("123", "", "09128136797")]
        [InlineData("123", "", "")]
        [InlineData("1234567890", "a", "912")]
        [InlineData("1234567890", "a", "9")]
        [InlineData("1234567890", "a", "test")]
        [InlineData("1234567890", "a", "تست")]
        [InlineData("1234567890", "a", "09128136797")]
        [InlineData("1234567890", "a", "")]
        [InlineData("1234567890", "1", "912")]
        [InlineData("1234567890", "1", "9")]
        [InlineData("1234567890", "1", "test")]
        [InlineData("1234567890", "1", "تست")]
        [InlineData("1234567890", "1", "09128136797")]
        [InlineData("1234567890", "1", "")]
        [InlineData("1234567890", "123456", "912")]
        [InlineData("1234567890", "123456", "9")]
        [InlineData("1234567890", "123456", "test")]
        [InlineData("1234567890", "123456", "تست")]
        [InlineData("1234567890", "123456", "09128136797")]
        [InlineData("1234567890", "123456", "")]
        [InlineData("1234567890", "ا", "912")]
        [InlineData("1234567890", "ا", "9")]
        [InlineData("1234567890", "ا", "test")]
        [InlineData("1234567890", "ا", "تست")]
        [InlineData("1234567890", "ا", "09128136797")]
        [InlineData("1234567890", "ا", "")]
        [InlineData("1234567890", "", "912")]
        [InlineData("1234567890", "", "9")]
        [InlineData("1234567890", "", "test")]
        [InlineData("1234567890", "", "تست")]
        [InlineData("1234567890", "", "09128136797")]
        [InlineData("1234567890", "", "")]
        [InlineData("0024838772", "a", "912")]
        [InlineData("0024838772", "a", "9")]
        [InlineData("0024838772", "a", "test")]
        [InlineData("0024838772", "a", "تست")]
        [InlineData("0024838772", "a", "09128136797")]
        [InlineData("0024838772", "a", "")]
        [InlineData("0024838772", "1", "912")]
        [InlineData("0024838772", "1", "9")]
        [InlineData("0024838772", "1", "test")]
        [InlineData("0024838772", "1", "تست")]
        [InlineData("0024838772", "1", "09128136797")]
        [InlineData("0024838772", "1", "")]
        [InlineData("0024838772", "123456", "912")]
        [InlineData("0024838772", "123456", "9")]
        [InlineData("0024838772", "123456", "test")]
        [InlineData("0024838772", "123456", "تست")]
        [InlineData("0024838772", "123456", "09128136797")]
        [InlineData("0024838772", "123456", "")]
        [InlineData("0024838772", "ا", "912")]
        [InlineData("0024838772", "ا", "9")]
        [InlineData("0024838772", "ا", "test")]
        [InlineData("0024838772", "ا", "تست")]
        [InlineData("0024838772", "ا", "09128136797")]
        [InlineData("0024838772", "ا", "")]
        [InlineData("0024838772", "", "912")]
        [InlineData("0024838772", "", "9")]
        [InlineData("0024838772", "", "test")]
        [InlineData("0024838772", "", "تست")]
        [InlineData("0024838772", "", "09128136797")]
        [InlineData("0024838772", "", "")]
        [InlineData("", "a", "912")]
        [InlineData("", "a", "9")]
        [InlineData("", "a", "test")]
        [InlineData("", "a", "تست")]
        [InlineData("", "a", "09128136797")]
        [InlineData("", "a", "")]
        [InlineData("", "1", "912")]
        [InlineData("", "1", "9")]
        [InlineData("", "1", "test")]
        [InlineData("", "1", "تست")]
        [InlineData("", "1", "09128136797")]
        [InlineData("", "1", "")]
        [InlineData("", "123456", "912")]
        [InlineData("", "123456", "9")]
        [InlineData("", "123456", "test")]
        [InlineData("", "123456", "تست")]
        [InlineData("", "123456", "09128136797")]
        [InlineData("", "123456", "")]
        [InlineData("", "ا", "912")]
        [InlineData("", "ا", "9")]
        [InlineData("", "ا", "test")]
        [InlineData("", "ا", "تست")]
        [InlineData("", "ا", "09128136797")]
        [InlineData("", "ا", "")]
        [InlineData("", "", "912")]
        [InlineData("", "", "9")]
        [InlineData("", "", "test")]
        [InlineData("", "", "تست")]
        [InlineData("", "", "09128136797")]
        [InlineData("", "", "")]
        #endregion
        public async Task Should_Not_ReturnOk_Sign_Up(string userName, string password, string phoneNumber, string fullname = "")
        {
            var content = new SignUpCommand(userName, "amir1345", phoneNumber, fullname);

            var response = await _httpClient.PostAsync("/api/v1.0/Authentication/sign-up", SignUpCommandJsonContent(content));

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        [Theory]

        #region Data
        [InlineData("fortest", "a")]
        [InlineData("fortest", "1")]
        [InlineData("fortest", "123456")]
        [InlineData("fortest", "ا")]
        [InlineData("fortest", "")]
        [InlineData("تست", "a")]
        [InlineData("تست", "1")]
        [InlineData("تست", "123456")]
        [InlineData("تست", "ا")]
        [InlineData("تست", "")]
        [InlineData("123", "a")]
        [InlineData("123", "1")]
        [InlineData("123", "123456")]
        [InlineData("123", "ا")]
        [InlineData("123", "")]
        [InlineData("1234567890", "a")]
        [InlineData("1234567890", "1")]
        [InlineData("1234567890", "123456")]
        [InlineData("1234567890", "ا")]
        [InlineData("1234567890", "")]
        [InlineData("0024838772", "a")]
        [InlineData("0024838772", "1")]
        [InlineData("0024838772", "123456")]
        [InlineData("0024838772", "ا")]
        [InlineData("0024838772", "")]
        [InlineData("", "a")]
        [InlineData("", "1")]
        [InlineData("", "123456")]
        [InlineData("", "ا")]
        [InlineData("", "")]
        #endregion
        public async Task Should_Not_ReturnOk_Sign_In(string userName, string password)
        {
            var content = new SignInCommand()
            {
                IsPersistent = true,
                Password = password,
                UserName = userName,
            };

            var response = await _httpClient.PutAsync("/api/v1.0/Authentication/sign-in", SignInCommandJsonContent(content));

            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

        private static JsonContent SignInCommandJsonContent(SignInCommand command)
        {
            return JsonContent.Create(command);
        }

        private static JsonContent SignUpCommandJsonContent(SignUpCommand command)
        {
            return JsonContent.Create(command);
        }
    }
}
