using Microsoft.AspNetCore.Mvc.Testing;
using signup.Application.DTOS;
using System.Text;
using System.Text.Json;

namespace tests
{
    [Trait("Category", "Signup")]
    public class SignupTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public SignupTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        private async void DeveCriarUmaConta()
        {
            //arrange
            var inputSignup = new InputSignup { 
                Name = "John Doe", 
                Email = "john.doe@gmail.com", 
                Document = "97456321558", 
                Password = "asdQWE123@" };
            
            var content = new StringContent(
                JsonSerializer.Serialize(inputSignup),
                Encoding.UTF8,
                "application/json"
            );

            //act assert one
            var signup = await _httpClient.PostAsync("/v1/Signup", content);
            signup.StatusCode.Equals(200);

            //act assert two

            var account = await _httpClient.GetAsync("/v1/Accounts");

        }
    }
}
