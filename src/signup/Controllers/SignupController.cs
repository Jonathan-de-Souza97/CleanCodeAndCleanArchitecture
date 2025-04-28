using Microsoft.AspNetCore.Mvc;
using signup.Application.DTOS;
using signup.Application.Interfaces;

namespace signup.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignupController : ControllerBase
    {
        
        private readonly ISignup _useCase;

        public SignupController(ISignup useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("/v1/Signup")]
        [Produces("application/json")]
        public async Task<IActionResult> Signup(InputSignup input)
        {
            var response = await _useCase.Execute(input);

            if (!response.Sucess)
                return UnprocessableEntity(response);

            return Ok(response);
        }
    }
}
