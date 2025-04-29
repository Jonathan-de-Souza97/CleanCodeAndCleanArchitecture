using signup.Domain.Validate.AccountValidation;

namespace signup.Domain.Entity
{
    public class Account
    {
        public Guid accountId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public string password { get; set; }


        public Account(string name, string email, string document, string password)
        {
            accountId = Guid.NewGuid();
            this.name = name;
            this.email = email;
            this.document = document;
            this.password = password;
        }
    }
}
