using System.Text.RegularExpressions;

namespace signup.Domain.Validate.AccountValidation
{
    public static class ValidatePassword
    {
        public static bool Execute(string password)
        {
            if (password.Length < 8) 
                return false;

            if (!Regex.IsMatch(password, @"\d+")) 
                return false;

            if (!Regex.IsMatch(password, @"[a-z]+")) 
                return false;

            return Regex.IsMatch(password, @"[A-Z]+");
        }
    }
}
