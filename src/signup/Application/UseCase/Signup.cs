using signup.Application.DTOS;
using signup.Application.Interfaces;
using signup.Application.Responses;
using signup.Domain.Validate.AccountValidation;

namespace signup.Application.UseCase
{
    public class Signup : ISignup
    {
        public Signup()
        {

        }

        public async Task<Response<AccountDTO>> Execute(InputSignup input)
        {
            var nameIsValid = ValidateName.Execute(input.Name);
            if (!nameIsValid) return Response<AccountDTO>.Error("Name invalid");

            var emailIsValid = ValidateEmail.Execute(input.Email);
            if (!emailIsValid) return Response<AccountDTO>.Error("Email invalid");

            var documentInvalid = ValidateCPF.Execute(input.Document);
            if (!documentInvalid) return Response<AccountDTO>.Error("CPF invalid");

            var passwordIsValid = ValidatePassword.Execute(input.Password);
            if (!passwordIsValid) return Response<AccountDTO>.Error("Password invalid");

            var account = input.ToEntity();

            var dto = new AccountDTO
            {
                name = account.name,
                email = account.email,
                document = account.document
            };
            return Response<AccountDTO>.Success(dto);
        }
    }
}
