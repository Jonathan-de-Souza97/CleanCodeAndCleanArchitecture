using System.Text.RegularExpressions;

namespace signup.Domain.Validate.AccountValidation
{
    public static class ValidateName
    {

        public static bool Execute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return Regex.IsMatch(name, @"[a-zA-Z] [a-zA-Z]+");                
        }
    }
}
