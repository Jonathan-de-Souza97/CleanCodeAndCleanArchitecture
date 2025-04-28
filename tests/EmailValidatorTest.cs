using signup.Domain.Validate.AccountValidation;

namespace tests
{
    [Trait("Category", "Email")]
    public class EmailValidatorTest
    {
        
        [Theory(DisplayName = "DeveValidarEmailValido")]
        [InlineData("Jonathan@gmail.com")]
        [InlineData("Jonathan@outlook.com")]
        [InlineData("Jonathan@casasbahia.com.br")]
        public void DeveValidarEmailValido(string email)
        {
            //act
            var isValid = ValidateEmail.Execute(email);

            //assert
            Assert.True(isValid);
        }

        [Theory(DisplayName = "NaoDeveValidarEmailInvalido")]
        [InlineData("Jonathan.com.br")]
        [InlineData("@Jonathan.com")]
        [InlineData("@Jonathan")]
        [InlineData(null)]
        public void NaoDeveValidarEmailInvalido(string email)
        {
            //act
            var isValid = ValidateEmail.Execute(email);

            //assert
            Assert.False(isValid);
        }
    }
}
