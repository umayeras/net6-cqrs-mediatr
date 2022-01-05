using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApp.Business.Commands;
using WebApp.Business.Queries;
using WebApp.Business.Responses;

namespace WebApp.Api.Controllers;

public class SamplesController : BaseController
{
    public SamplesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ServiceResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        return Ok(await Mediator.Send(new GetSamplesQuery()));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetSampleByIdQuery(id);
        var result = await Mediator.Send(query);

        if (result is ValidationErrorResponse)
        {
            return BadRequest(result);
        }

        if (result.Payload == null)
        {
            return NotFound();
        }

        return !result.Success
            ? Error(result)
            : Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ServiceResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post([FromBody] AddSampleCommand request)
    {
        var result = await Mediator.Send(request);
        return !result.Success
            ? Error(result)
            : Ok(result);
    }
}