using signup.Application.DTOS;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;

namespace tests
{
    [Trait("Category", "Signup")]
    public class SignupTest
    {
        private readonly HttpClient _httpClient;

        public SignupTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new System.Uri("http://localhost:3000");
        }

        [Fact]
        private async void DeveCriarUmaConta()
        {
            //arrange
            var inputSignup = new InputSignup { 
                Name = "John Doe", 
                Email = "john.doe@gmail.com", 
                Document = "97456321558", 
                Password = "asdQWE123" };
            
            var content = new StringContent(
                JsonSerializer.Serialize(inputSignup),
                Encoding.UTF8,
                "application/json"
            );

            //act
            var responseSignup = await _httpClient.PostAsync("/signup", content);
            var outputSignup = await responseSignup.Content.ReadAsStringAsync();

            //assert
            Assert.NotNull(outputSignup);

        }
    }
}
