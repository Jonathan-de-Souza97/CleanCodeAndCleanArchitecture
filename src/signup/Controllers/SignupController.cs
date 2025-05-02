using Microsoft.AspNetCore.Mvc;
using signup.Application.DTOS;
using signup.Application.Interfaces;

namespace signup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignupController : ControllerBase
    {
        
        private readonly ISignup _signup;
        private readonly IGetUsers _getUsers;

        public SignupController(ISignup signup, IGetUsers getUsers)
        {
            _signup = signup;
            _getUsers = getUsers;
        }

        [HttpPost("/v1/Signup")]
        [Produces("application/json")]
        public async Task<IActionResult> Signup(InputSignup input)
        {
            var response = await _signup.Execute(input);

            if (!response.Sucess)
                return StatusCode(422, response);

            return StatusCode(200, response);
        }

        [HttpPost("/v1/Accounts")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAccounts()
        {
            var response = await _getUsers.Execute();

            if (!response.Sucess)
                return StatusCode(422, response);

            return StatusCode(200, response);
        }
    }
}
