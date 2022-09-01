using Application.Features.Commands.ProgrammingLanguages.Request;
using Application.Features.ProgrammingLanguages.Queries.Request;
using Application.Features.ProgrammingLanguages.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgrammingLanguageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> GetProgrammingLanguageList(GetProgrammingLanguageListQueryRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProgrammingLanguage(CreateProgrammingLanguageCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetProgrammingLanguageById(GetProgrammingLanguageByIdQueryRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProgrammingLanguage(DeleteProgrammingLanguageCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProgrammingLanguage(UpdateProgrammingLanguageCommandRequest command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
