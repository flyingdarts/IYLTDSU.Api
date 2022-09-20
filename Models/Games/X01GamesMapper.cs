using AutoMapper;
using IYLTDSU.Backend.LambdaApi.Models.Games.X01;
using IYLTDSU.Business.Games.X01.Create;

namespace IYLTDSU.Api.Models.Games;

public class X01GamesMapper : Profile
{
    public X01GamesMapper()
    {
        CreateMap<CreateX01GameRequestDto, CreateX01GameCommand>();
        CreateMap<CreateX01GameCommandResponse, CreateX01GameResponseDto>()
            .ForMember(x => x.GameStatus, opt => opt.MapFrom(src => src.Game.Status))
            .ForMember(x => x.Players, opt => opt.MapFrom(src => src.GamePlayers
                .Select(x => new GamePlayerDto() { PlayerId = x.PlayerId })))
            .ForMember(x => x.GameId, opt => opt.MapFrom(src => src.Game.GameId));

        //CreateMap<CreateX01GameDartRequest, CreateX01GameDartCommand>();
        //CreateMap<CreateX01GameDartDetail, CreateX01GameDartResponse>();
    }
}
