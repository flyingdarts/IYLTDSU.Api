using IYLTDSU.Api.Models.Games.X01;
using IYLTDSU.Api.Requests.X01.Game;
using IYLTDSU.Api.Requests.X01.GameDart;
using IYLTDSU.Business.X01.GameDarts;
using IYLTDSU.Business.X01.Games.Create;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace IYLTDSU.Api.Controllers;

[Route("games/x01")]
public class X01GamesController : BaseController
{

    [HttpPost]
    [OpenApiOperation("CreateX01Game", "Create an X01 game", "Creates a game with players")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateX01GameResponse))]
    public async Task<IActionResult> Post([FromBody] CreateX01GameRequest request, CancellationToken cancellationToken)
    {
        var createX01Command = Mapper.Map<CreateX01GameCommand>(request);
        var createX01Response = await Mediator.Send(createX01Command, cancellationToken);
        return StatusCode(201, Mapper.Map<CreateX01GameResponse>(createX01Response));
    }

    [HttpPost("{gameId:long}/players/{playerId:guid}/darts")]
    [OpenApiOperation("CreateX01GameDart", "Create an X01 game dart", "Takes the input off a player  ")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateX01GameDartResponse))]
    public async Task<IActionResult> Post([FromRoute] long gameId, [FromRoute] Guid playerId, [FromBody] CreateX01GameDartRequest request, CancellationToken cancellationToken)
    {
        request.GameId = gameId; request.PlayerId = playerId;
        var createX01GameDartCommand = Mapper.Map<CreateX01GameDartCommand>(request);
        var createX01GameDartDetail = await Mediator.Send(createX01GameDartCommand, cancellationToken);
        return StatusCode(201, Mapper.Map<CreateX01GameDartResponse>(createX01GameDartDetail));
    }
}