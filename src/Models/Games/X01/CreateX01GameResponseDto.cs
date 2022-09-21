namespace IYLTDSU.Backend.LambdaApi.Models.Games.X01;

public class CreateX01GameResponseDto
{
    public long GameId { get; set; }
    public List<GamePlayerDto> Players { get; set; }
    public GameStatusEnumDto GameStatus { get; set; }
}
