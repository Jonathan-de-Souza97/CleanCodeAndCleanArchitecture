using System.Text.RegularExpressions;

namespace signup.Domain.Validate.AccountValidation
{
    public static class ValidateEmail
    {
        public static bool Execute(string email)
        {
            return Regex.IsMatch(email, @"^(.+)\@(.+)$");
        }
    }
}
