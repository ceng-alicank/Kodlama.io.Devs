using Application.Features.Users.AddGithubAdress;
using Application.Features.Users.Create;
using Application.Features.Users.DeleteGithubAdress;
using Application.Features.Users.Login;
using Application.Features.Users.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserCommandRequest request)
        {
            var result  = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("GithubAdress")]
        public async Task<IActionResult> AddGithubAdress(AddGithubAdressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("GithubAdress")]
        public async Task<IActionResult> UpdateGithubAdress(UpdateGithubAdressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("GithubAdress")]
        public async Task<IActionResult> GithubAdress( DeleteGithubAdressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
