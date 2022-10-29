namespace IYLTDSU.Api.Requests.X01.Game;

public record CreateX01GameRequest(
    int PlayerCount,
    int Sets,
    int Leg,
    bool DoubleIn,
    bool DoubleOut,
    int StartingScore,
    List<Guid> PlayerIds
)
{
    internal long GameId { get; set; }
}