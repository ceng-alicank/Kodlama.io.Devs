using Application.Features.Users.AddGithubAddress;
using Application.Features.Users.Create;
using Application.Features.Users.CreateAccessTokenByRefreshToken;
using Application.Features.Users.DeleteGithubAddress;
using Application.Features.Users.Login;
using Application.Features.Users.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpPost("CreateAccessTokenByRefreshToken")]
        public async Task<IActionResult> CreateAccessTokenByRefreshToken(CreateAccessTokenByRefreshTokenRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("GithubAddress")]
        public async Task<IActionResult> AddGithubAdress(AddGithubAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("GithubAddress")]
        public async Task<IActionResult> UpdateGithubAdress(UpdateGithubAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("GithubAddress")]
        public async Task<IActionResult> GithubAdress( DeleteGithubAddressCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
