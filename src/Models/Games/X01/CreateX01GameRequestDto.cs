namespace IYLTDSU.Api.Models.Games.X01;

public record CreateX01GameRequestDto(int PlayerCount,
    int Sets,
    int Leg,
    bool DoubleIn,
    bool DoubleOut,
    int StartingScore,
    List<Guid> PlayerIds)
{
    internal long GameId { get; set; }
}
