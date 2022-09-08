using Application.Features.Technologies.Create;
using Application.Features.Technologies.Delete;
using Application.Features.Technologies.GetList;
using Application.Features.Technologies.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyContoller : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnologyContoller(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("GetList")]
        public async Task<IActionResult> CreateTechnology(GetListTechnologyQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTechnology(CreateTechnologyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);  
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTechnology(UpdateTechnologyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTechnology(DeleteTechnologyCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
