using signup.Domain.Validate.AccountValidation;

namespace signup.Domain.Entity
{
    public class Account
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }


        public Account(string name, string email, string document, string password)
        {
            id = new Guid();
            Name = name;
            Email = email;
            Document = document;
            Password = password;
        }
    }
}
