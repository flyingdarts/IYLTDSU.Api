namespace IYLTDSU.Api.Requests.X01.GameDart;
public record CreateX01GameDartRequest(List<int> Scores)
{
    public long GameId { get; set; }
    public Guid PlayerId { get; set; }
};
