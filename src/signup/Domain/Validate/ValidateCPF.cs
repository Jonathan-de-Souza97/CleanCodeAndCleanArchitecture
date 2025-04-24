

using System.Globalization;

namespace signup.Domain.Validate
{
    public class ValidateCPF
    {
        private string _cpf;
        const int VALID_LENGTH = 11;


        public ValidateCPF(string cpf)
        {
            _cpf = cpf;            
        }

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_cpf))
                return false;

            _cpf = Clean(_cpf);

            if(_cpf.Length != VALID_LENGTH)
                return false;

            if (AllDigitsEqual(_cpf))
                return false;

            int dg1 = CalculateDigit(_cpf, 10);
            int dg2 = CalculateDigit(_cpf, 11);

            return ExtractDigit(_cpf) == string.Concat(dg1, dg2);
        }

        public string Clean(string cpf) 
        {
            return _cpf.Replace(@"\D", "");
        }

        private bool AllDigitsEqual(string cpf)
        {
            char firstDigit = cpf[0];
            return cpf.All(digit => digit == firstDigit);
        }

        private int CalculateDigit(string cpf, int factor)
        {
            var total = 0;

            foreach (var digit in cpf)
            {
                if (factor > 1) total += int.Parse(digit.ToString()) * factor--;
            }

            int rest = total % 11;
            return (rest < 2 ) ? 0 : 11 - rest;
        }

        private string ExtractDigit(string cpf)
        {
            return cpf.Substring(cpf.Length - 2, cpf.Length);
        }
    }
}
