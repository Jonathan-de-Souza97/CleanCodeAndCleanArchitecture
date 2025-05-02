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

        [Fact(DisplayName = "Deve criar uma conta")]
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

            //act assert
            var signup = await _httpClient.PostAsync("/v1/Signup", content);
            signup.StatusCode.Equals(200);

            var outputSignup = await signup.Content.ReadAsStringAsync();

            using (var jsonDoc = JsonDocument.Parse(outputSignup))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var message = root.GetProperty("message");
                var name = data.GetProperty("name").GetString();
                var email = data.GetProperty("email").GetString();
                var document = data.GetProperty("document").GetString();


                Assert.Equal("Done", message.ToString());
                Assert.Equal(name, inputSignup.Name);
                Assert.Equal(email, inputSignup.Email);
                Assert.Equal(document, inputSignup.Document);
            }
        }

        [Fact(DisplayName = "Não deve criar account, nome inválido")]
        private async void NãoDeveCriarUmaContaNomeInvalido()
        {
            //arrange
            var inputSignup = new InputSignup
            {
                Name = "John",
                Email = "john.doe@gmail.com",
                Document = "97456321558",
                Password = "asdQWE123@"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(inputSignup),
                Encoding.UTF8,
                "application/json"
            );

            //act assert
            var signup = await _httpClient.PostAsync("/v1/Signup", content);
            signup.StatusCode.Equals(422);

            var outputSignup = await signup.Content.ReadAsStringAsync();

            using (var jsonDoc = JsonDocument.Parse(outputSignup))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var message = root.GetProperty("message");

                Assert.Equal("Name invalid", message.ToString());
            }
        }

        [Fact(DisplayName = "Não deve criar account, email inválido")]
        private async void NãoDeveCriarUmaContaEmailInvalido()
        {
            //arrange
            var inputSignup = new InputSignup
            {
                Name = "John Doe",
                Email = "john.doe.com",
                Document = "97456321558",
                Password = "asdQWE123@"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(inputSignup),
                Encoding.UTF8,
                "application/json"
            );

            //act assert
            var signup = await _httpClient.PostAsync("/v1/Signup", content);
            signup.StatusCode.Equals(422);

            var outputSignup = await signup.Content.ReadAsStringAsync();

            using (var jsonDoc = JsonDocument.Parse(outputSignup))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var message = root.GetProperty("message");

                Assert.Equal("Email invalid", message.ToString());
            }
        }

        [Fact(DisplayName = "Não deve criar account, documento inválido")]
        private async void NãoDeveCriarUmaContaDocumentoInvalido()
        {
            //arrange
            var inputSignup = new InputSignup
            {
                Name = "John Doe",
                Email = "john.doe@gmail.com",
                Document = "97456321559",
                Password = "asdQWE123@"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(inputSignup),
                Encoding.UTF8,
                "application/json"
            );

            //act assert
            var signup = await _httpClient.PostAsync("/v1/Signup", content);
            signup.StatusCode.Equals(422);

            var outputSignup = await signup.Content.ReadAsStringAsync();

            using (var jsonDoc = JsonDocument.Parse(outputSignup))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var message = root.GetProperty("message");

                Assert.Equal("Document invalid", message.ToString());
            }
        }

        [Fact(DisplayName = "Não deve criar account, senha inválida")]
        private async void NãoDeveCriarUmaContaSenhaInvalida()
        {
            //arrange
            var inputSignup = new InputSignup
            {
                Name = "John Doe",
                Email = "john.doe@gmail.com",
                Document = "97456321558",
                Password = "asdQWE123"
            };

            var content = new StringContent(
                JsonSerializer.Serialize(inputSignup),
                Encoding.UTF8,
                "application/json"
            );

            //act assert
            var signup = await _httpClient.PostAsync("/v1/Signup", content);
            signup.StatusCode.Equals(422);

            var outputSignup = await signup.Content.ReadAsStringAsync();

            using (var jsonDoc = JsonDocument.Parse(outputSignup))
            {
                var root = jsonDoc.RootElement;
                var data = root.GetProperty("data");
                var message = root.GetProperty("message");

                Assert.Equal("Password invalid", message.ToString());
            }
        }
    }
}
