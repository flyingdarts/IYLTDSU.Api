using IYLTDSU.Api.Models.Game;

namespace IYLTDSU.Api.Requests.X01.Game;

public class CreateX01GameResponse
{
    public long GameId { get; set; }
    public List<GamePlayerResponseModelDto> Players { get; set; }
    public GameStatusEnumDto GameStatus { get; set; }
}
