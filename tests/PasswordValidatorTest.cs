using signup.Domain.Validate.AccountValidation;

namespace tests
{
    [Trait("Category", "Password")]
    public class PasswordValidatorTest
    {
        [Theory(DisplayName = "DeveValidarSenhaValida")]
        [InlineData("Jonathan@123")]
        [InlineData("@Outlook75")]
        [InlineData("Jonathan123@")]
        public void DeveValidarSenhaValida(string password)
        {
            //act
            var isValid = ValidatePassword.Execute(password);

            //assert
            Assert.True(isValid);
        }

        [Theory(DisplayName = "NaoDeveValidarSenhaInvalida")]
        [InlineData("jonathan")]
        [InlineData("@Jonathan")]
        [InlineData("123Jonathan")]
        [InlineData("@123JONATHAN")]
        [InlineData("12345678")]
        [InlineData("Jo123@")]
        [InlineData(null)]
        public void NaoDeveValidarSenhaInvalida(string password)
        {
            //act
            var isValid = ValidatePassword.Execute(password);

            //assert
            Assert.False(isValid);
        }

    }
}
