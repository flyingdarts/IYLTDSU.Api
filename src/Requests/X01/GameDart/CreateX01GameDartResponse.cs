using IYLTDSU.Api.Models.Game;

namespace IYLTDSU.Api.Requests.X01.GameDart;

public class CreateX01GameDartResponse
{
    public long GameId { get; set; }
    public bool RoundCompleted { get; set; }
    public GameStatusEnumDto GameStatus { get; set; }
}
