using signup.Domain.Validate;

namespace tests
{
    [Trait("Category", "CPF")]
    public class ValidateCPFTest
    {
        [Fact(DisplayName = "DeveValidarCPFValido1")]
        public void DeveValidarCPFValido1()
        {
            //Arrange
            const string cpf = "97456321558";

            //Act
            var act = new ValidateCPF(cpf);
            bool isValid = act.Validate();

            //Assert
            Assert.True(isValid);
        }

        [Fact(DisplayName = "DeveValidarCPFValido2")]
        public void DeveValidarCPFValido2()
        {
            //Arrange
            const string cpf = "71428793860";

            //Act
            var act = new ValidateCPF(cpf);
            bool isValid = act.Validate();

            //Assert
            Assert.True(isValid);
        }

        [Fact(DisplayName = "DeveValidarCPFValido3")]
        public void DeveValidarCPFValido3()
        {
            //Arrange
            const string cpf = "87748248800";

            //Act
            var act = new ValidateCPF(cpf);
            bool isValid = act.Validate();

            //Assert
            Assert.True(isValid);
        }

        [Fact(DisplayName = "NaoDeveValidarCPF1")]
        public void NaoDeveValidarCPF1()
        {
            // Arrange and Act
            var act = new ValidateCPF(null);
            bool isValid = act.Validate();

            //Assert
            Assert.False(isValid);
        }

        [Fact(DisplayName = "NaoDeveValidarCPF2")]
        public void NaoDeveValidarCPF2()
        {
            //Arrange
            const string cpf = "123";

            //Act
            var act = new ValidateCPF(cpf);
            bool isValid = act.Validate();

            //Assert
            Assert.False(isValid);
        }

        [Fact(DisplayName = "NaoDeveValidarCPF3")]
        public void NaoDeveValidarCPF3()
        {
            //Arrange
            const string cpf = "11111111111";

            //Act
            var act = new ValidateCPF(cpf);
            bool isValid = act.Validate();

            //Assert
            Assert.False(isValid);
        }
    }
}
