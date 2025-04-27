using System.Text.RegularExpressions;

namespace signup.Domain.Validate.AccountValidation
{
    public static class ValidateCPF
    {
        private const int VALID_LENGTH = 11;

        public static bool Execute(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Clean(cpf);

            if (cpf.Length != VALID_LENGTH)
                return false;

            if (AllDigitsEqual(cpf))
                return false;

            int dg1 = CalculateDigit(cpf, 10);
            int dg2 = CalculateDigit(cpf, 11);

            return ExtractDigit(cpf) == string.Concat(dg1, dg2);
        }

        public static string Clean(string cpf)
        {
            return Regex.Replace(cpf ?? string.Empty, @"\D", "");
        }

        private static bool AllDigitsEqual(string cpf)
        {
            char firstDigit = cpf[0];
            return cpf.All(digit => digit == firstDigit);
        }

        private static int CalculateDigit(string cpf, int factor)
        {
            var total = 0;

            foreach (var digit in cpf)
            {
                if (factor > 1) total += int.Parse(digit.ToString()) * factor--;
            }

            int rest = total % 11;
            return rest < 2 ? 0 : 11 - rest;
        }

        private static string ExtractDigit(string cpf)
        {
            return cpf.Substring(cpf.Length - 2, 2);
        }
    }
}