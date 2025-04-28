using signup.Domain.Entity;

namespace signup.Application.DTOS
{
    public class InputSignup
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }

        public Account ToEntity()
        {
            return new Account(
                Name,
                Email,
                Document,
                Password
            );
        }
    }
}
