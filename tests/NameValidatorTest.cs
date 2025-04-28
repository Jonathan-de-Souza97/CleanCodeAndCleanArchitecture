using signup.Domain.Validate.AccountValidation;

namespace tests
{
    [Trait("Category", "Name")]
    public class NameValidatorTest
    {
        [Theory(DisplayName = "DeveValidarNomeValido")]
        [InlineData("Jonathan de Souza")]
        [InlineData("Jonathan Souza")]
        [InlineData("Josue Pereira Santos")]
        public void DeveValidarNomeValido(string name)
        {
            //act
            var isValid = ValidateName.Execute(name);

            //assert
            Assert.True(isValid);
        }

        [Theory(DisplayName = "NaoDeveValidarNomeInvalido")]
        [InlineData("Jonathan")]
        [InlineData("Jonathan123")]
        [InlineData(null)]
        public void NaoDeveValidarNomeInValido(string name)
        {
            //act
            var isValid = ValidateName.Execute(name);

            //assert
            Assert.False(isValid);
        }
    }
}
