using signup.Domain.Validate;
using signup.Domain.Validate.AccountValidation;

namespace tests
{
    [Trait("Category", "CPF")]
    public class CPFValidatorTest
    {
        [Theory(DisplayName = "DeveValidarCPFValido")]
        [InlineData("97456321558")]
        [InlineData("71428793860")]
        [InlineData("87748248800")]
        [InlineData("877.482.488-00")]
        [InlineData("877.482.48800")]
        [InlineData("877.48248800")]
        public void DeveValidarCPFValido(string cpf)
        {
            //Act
            bool isValid = ValidateCPF.Execute(cpf);

            //Assert
            Assert.True(isValid);
        }


        [Theory(DisplayName = "NaoDeveValidarCPFInvalido")]
        [InlineData(null)]
        [InlineData("111")]
        [InlineData("11111111111")]
        [InlineData("abc")]
        public void NaoDeveValidarCPFInvalido(string cpf)
        {
            //act
            bool isValid = ValidateCPF.Execute(cpf);

            //Assert
            Assert.False(isValid);
        }
    }
}
