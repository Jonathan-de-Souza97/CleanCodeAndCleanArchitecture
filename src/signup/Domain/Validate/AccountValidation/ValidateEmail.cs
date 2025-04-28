using System.Text.RegularExpressions;

namespace signup.Domain.Validate.AccountValidation
{
    public static class ValidateEmail
    {
        public static bool Execute(string email)
        {
            if(string.IsNullOrWhiteSpace(email)) return false;

            return Regex.IsMatch(email, @"^(.+)\@(.+)$");
        }
    }
}
