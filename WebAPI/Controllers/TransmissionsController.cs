using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.CreateRange;
using Application.Features.Transmissions.Queries.GetList;
using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.CreateRange;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransmissionsController : BaseController
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CreateTransmissionsCommand createTransmissionsCommand)
    {
        var response = await Mediator.Send(createTransmissionsCommand);
        return Ok(response);
    }

    [HttpPost("addRange")]
    public async Task<IActionResult> AddRange([FromBody] CreateTransmissionRangeCommand createTransmissionRangeCommand)
    {
        var response = await Mediator.Send(createTransmissionRangeCommand);
        return Ok(response);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetTransmissions([FromQuery] PageRequest pageRequest)
    {
        GetListTransmissionQuery getListTransmissionQuery = new GetListTransmissionQuery()
        {
            PageRequest = pageRequest
        };
        var response = await Mediator.Send(getListTransmissionQuery);
        return Ok(response);
    }
}

