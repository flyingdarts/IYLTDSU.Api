using IYLTDSU.Backend.LambdaApi.Models.Games.X01;
using IYLTDSU.Business.Games.X01.Create;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace IYLTDSU.Backend.LambdaApi.Controllers;

[Route("[controller]")]
public class X01Controller : BaseController
{
    [HttpPost("x01")]
    [OpenApiOperation("CreateX01Game", "Create an X01 game", "Creates a game with players")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateX01GameResponseDto))]
    public async Task<IActionResult> Post([FromBody] CreateX01GameRequestDto request, CancellationToken cancellationToken)
    {
        var createX01Command = Mapper.Map<CreateX01GameCommand>(request);
        var createX01Response = await Mediator.Send(createX01Command, cancellationToken);
        return StatusCode(201, Mapper.Map<CreateX01GameResponseDto>(createX01Response));
    }
}
