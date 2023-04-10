using Microsoft.AspNetCore.Mvc.Testing;

namespace Lesson36.WebApp.Tests
{
    public class IntegrationTests
    {
        [Fact]
        public async Task PersonsControllerTest()
        {
            var factory = new WebApplicationFactory<Program>();
            var client = factory.CreateClient();

            var login = Guid.NewGuid().ToString();
            var password = Guid.NewGuid().ToString();

            var registerResponse = await client.PostAsync($"/Account/Register", new FormUrlEncodedContent(
                new KeyValuePair<string, string>[] { new("UserName", login), new("Password", password) }));            

            var response = await client.GetAsync($"/Persons/Index");

            Assert.True(response.IsSuccessStatusCode);
            Assert.EndsWith("/Persons/Index",
                response.RequestMessage.RequestUri.OriginalString);
        }

    }
}
