using Microsoft.AspNetCore.Mvc.Testing;
using signup.Application.DTOS;
using System.Text;
using System.Text.Json;
using signup;
using signup.Application.Responses;

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

            //act
            var responseSignup = await _httpClient.PostAsync("/v1/Signup", content);
            var outputSignup = await responseSignup.Content.ReadAsStringAsync();


            //assert
            responseSignup.EnsureSuccessStatusCode();

            using (var jsonDoc = JsonDocument.Parse(outputSignup))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var name = data.GetProperty("name").GetString();
                var email = data.GetProperty("email").GetString();
                var document = data.GetProperty("document").GetString();

                // Assert
                Assert.Equal(name, inputSignup.Name);
                Assert.Equal(email, inputSignup.Email);
                Assert.Equal(document, inputSignup.Document);
            }

        }
    }
}
